using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Windows.Forms;

using VixenPlusCommon;
using VixenPlusCommon.Properties;

namespace VixenPlus.Dialogs {
    internal partial class CurveLibraryDialog : Form {
        private readonly CurveLibrary _curveLibrary;
        private bool _isInternal;

        private const string ColorPrefix = "C";

        public CurveLibraryDialog() {
            InitializeComponent();
            Icon = Resources.VixenPlus;
            listViewRecords.Columns[0].Name = CurveLibrary.ManufacturerCol;
            listViewRecords.Columns[1].Name = CurveLibrary.LightCountCol;
            listViewRecords.Columns[2].Name = CurveLibrary.ColorCol;
            listViewRecords.Columns[3].Name = CurveLibrary.ControllerCol;
            _curveLibrary = new CurveLibrary();
            _isInternal = true;
            comboBoxManufacturer.SelectedIndex = 0;
            comboBoxCount.SelectedIndex = 0;
            comboBoxColor.SelectedIndex = 0;
            comboBoxController.SelectedIndex = 0;
            _isInternal = false;
            comboBoxSource.SelectedIndex = 0;
            listViewRecords.ListViewItemSorter = new ListViewItemSorter();
            ListViewSortIcons.SetSortIcon(listViewRecords, 0, SortOrder.Ascending);
        }


        public byte[] SelectedCurve { get; private set; }


        private void buttonOK_Click(object sender, EventArgs e) {
            if (listViewRecords.SelectedItems.Count > 0) {
                SetSelectedCurve((CurveLibraryRecord) listViewRecords.Items[listViewRecords.SelectedIndices[0]].Tag);
            }
        }


        private void comboBoxColor_DrawItem(object sender, DrawItemEventArgs e) {
            var box = (ComboBox) sender;
            if ((e.State & DrawItemState.Selected) != DrawItemState.None) {
                e.DrawBackground();
            }
            else {
                e.Graphics.FillRectangle(Brushes.White, e.Bounds);
            }
            if ((e.State & DrawItemState.Focus) != DrawItemState.None) {
                e.DrawFocusRectangle();
            }
            if (e.Index == 0) {
                e.Graphics.DrawString(box.Items[e.Index].ToString(), box.Font, Brushes.Black, e.Bounds);
            }
            else if ((e.Index >= 0) && (e.Index < box.Items.Count)) {
                var bounds = e.Bounds;
                bounds.Inflate(-16, -2);
                var boxItems = box.Items[e.Index] as string;
                if (boxItems == null) {
                    return;
                }
                using (var brush = new SolidBrush(Color.FromArgb(int.Parse(boxItems.Substring(1))))) {
                    e.Graphics.FillRectangle(brush, bounds);
                    e.Graphics.DrawRectangle(Pens.Black, bounds);
                }
            }
        }


        private void comboBoxFilter_SelectedIndexChanged(object sender, EventArgs e) {
            LoadRecords();
        }


        private void comboBoxSource_SelectedIndexChanged(object sender, EventArgs e) {
            LoadRecords();
        }


        private void CurveLibraryDialog_FormClosing(object sender, FormClosingEventArgs e) {
            _curveLibrary.Dispose();
        }


        private void listViewRecords_ColumnClick(object sender, ColumnClickEventArgs e) {
            if ((listViewRecords.Columns[e.Column].Tag == null) || (((SortOrder) listViewRecords.Columns[e.Column].Tag) == SortOrder.Descending)) {
                ListViewSortIcons.SetSortIcon(listViewRecords, e.Column, SortOrder.Ascending);
                listViewRecords.Columns[e.Column].Tag = SortOrder.Ascending;
                _curveLibrary.SortOrder = new CurveLibrary.Sort(listViewRecords.Columns[e.Column].Name, CurveLibrary.Sort.Direction.Asc);
                LoadRecords();
            }
            else {
                ListViewSortIcons.SetSortIcon(listViewRecords, e.Column, SortOrder.Descending);
                listViewRecords.Columns[e.Column].Tag = SortOrder.Descending;
                _curveLibrary.SortOrder = new CurveLibrary.Sort(listViewRecords.Columns[e.Column].Name, CurveLibrary.Sort.Direction.Desc);
                LoadRecords();
            }
        }


        private void listViewRecords_DrawColumnHeader(object sender, DrawListViewColumnHeaderEventArgs e) {
            e.DrawDefault = true;
        }


        private void listViewRecords_DrawSubItem(object sender, DrawListViewSubItemEventArgs e) {
            if (e.ColumnIndex == 2) {
                var bounds = e.Bounds;
                bounds.Inflate(-16, -2);
                var curveLibraryRecord = e.Item.Tag as CurveLibraryRecord;
                if (curveLibraryRecord == null) {
                    return;
                }
                using (var brush = new SolidBrush(Color.FromArgb(curveLibraryRecord.Color))) {
                    e.Graphics.FillRectangle(brush, bounds);
                    e.Graphics.DrawRectangle(Pens.Black, bounds);
                }
            }
            else {
                e.DrawDefault = true;
            }
        }


        private void listViewRecords_MouseDoubleClick(object sender, MouseEventArgs e) {
            if (listViewRecords.SelectedItems.Count > 0) {
                SetSelectedCurve((CurveLibraryRecord) listViewRecords.Items[listViewRecords.SelectedIndices[0]].Tag);
            }
            DialogResult = DialogResult.OK;
        }


        private void listViewRecords_SelectedIndexChanged(object sender, EventArgs e) {
            btnOkay.Enabled = listViewRecords.SelectedItems.Count > 0;
        }


        private void LoadRecords() {
            if (_isInternal) {
                return;
            }
            Cursor = Cursors.WaitCursor;
            try {
                SetFilters();
                listViewRecords.BeginUpdate();
                listViewRecords.Items.Clear();
                btnOkay.Enabled = false;
                try {
                    foreach (var record in _curveLibrary.Read()) {
                        listViewRecords.Items.Add(
                            new ListViewItem(new[]
                            {record.Manufacturer, record.LightCount, record.Color.ToString(CultureInfo.InvariantCulture), record.Controller})).Tag =
                            record;
                    }
                }
                catch (Exception exception) {
                    MessageBox.Show(exception.Message, Vendor.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                finally {
                    listViewRecords.EndUpdate();
                }
                if (_curveLibrary.IsFiltered) {
                    return;
                }
                PopulateFilter(comboBoxManufacturer, _curveLibrary.GetAllManufacturers());
                PopulateFilter(comboBoxCount, _curveLibrary.GetAllLightCounts());
                PopulateFilter(comboBoxColor, _curveLibrary.GetAllLightColors());
                PopulateFilter(comboBoxController, _curveLibrary.GetAllControllers());
            }
            finally {
                Cursor = Cursors.Default;
            }
        }


        private void SetFilters() {
            _curveLibrary.ManufacturerFilter = (comboBoxManufacturer.SelectedIndex == 0)
                ? null : new[] {new CurveLibrary.Filter(CurveLibrary.Filter.Operator.Equals, comboBoxManufacturer.SelectedItem.ToString())};
            _curveLibrary.LightCountFilter = (comboBoxCount.SelectedIndex == 0)
                ? null : new[] {new CurveLibrary.Filter(CurveLibrary.Filter.Operator.Equals, comboBoxCount.SelectedItem.ToString())};
            _curveLibrary.ColorFilter = (comboBoxColor.SelectedIndex == 0)
                ? null : new[] {new CurveLibrary.Filter(CurveLibrary.Filter.Operator.Equals, ColorFromString(comboBoxColor.SelectedItem.ToString()))};
            _curveLibrary.ControllerFilter = (comboBoxController.SelectedIndex == 0)
                ? null : new[] {new CurveLibrary.Filter(CurveLibrary.Filter.Operator.Equals, comboBoxController.SelectedItem.ToString())};
        }


        private void PopulateFilter(ComboBox affectedComboBox, IEnumerable<string> listItems) {
            var selectedIndex = affectedComboBox.SelectedIndex;
            affectedComboBox.Items.Clear();
            affectedComboBox.Items.Add("(All)");
            foreach (var listItem in listItems.Select(item => affectedComboBox != comboBoxColor ? item : StringFromColor(item)).Where(listItem => !affectedComboBox.Items.Contains(listItem))) {
                affectedComboBox.Items.Add(listItem);
            }
            _isInternal = true;
            affectedComboBox.SelectedIndex = selectedIndex;
            _isInternal = false;
        }


        private void SetSelectedCurve(CurveLibraryRecord clr) {
            if (comboBoxSource.SelectedIndex == 1) {
                _curveLibrary.Import(clr);
            }
            SelectedCurve = clr.CurveData;
        }


        private static string StringFromColor(string colorString) {
            return (ColorPrefix + colorString);
        }

        
        private static string ColorFromString(string mangledString) {
            return mangledString.Substring(ColorPrefix.Length);
        }
    }
}
