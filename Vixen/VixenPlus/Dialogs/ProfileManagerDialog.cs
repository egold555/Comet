using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.IO;
using System.Windows.Forms;

using CommonUtils;

namespace VixenPlus.Dialogs
{
    public partial class ProfileManagerDialog : Form
    {
        private readonly List<int> _channelOrderMapping;
        private readonly Color _pictureBoxHoverColor = Color.FromArgb(80, 80, 255);
        private readonly SolidBrush _pictureBrush = new SolidBrush(Color.Black);
        private readonly Color _pictureDisabledColor = Color.FromArgb(192, 192, 192);
        private readonly Color _pictureEnabledColor = Color.FromArgb(128, 128, 255);
        private readonly Font _pictureFont = new Font("Arial", 13f, FontStyle.Bold);
        private readonly Pen _picturePen = new Pen(Color.Black, 2f);
        private Profile _contextProfile;

        public ProfileManagerDialog(object objectInContext)
        {
            InitializeComponent();
            foreach (var str in Directory.GetFiles(Paths.ProfilePath, "*.pro"))
            {
                try
                {
                    listBoxProfiles.Items.Add(new Profile(str));
                }
                catch (Exception)
                {
                    // Empty catch since we don't want to bomb on attempting to add a profile.
                }
            }
            var bitmap = new Bitmap(pictureBoxReturnFromProfileEdit.Image);
            bitmap.MakeTransparent();
            pictureBoxReturnFromProfileEdit.Image = bitmap;
            _channelOrderMapping = new List<int>();
            var profile = objectInContext as Profile;
            if (profile != null) {
                var profileListed = false;
                foreach (var item in listBoxProfiles.Items) {
                    if (((Profile) item).Name != profile.Name) {
                        continue;
                    }
                    profileListed = true;
                    break;
                }
                if (!profileListed)
                {
                    listBoxProfiles.Items.Add(profile);
                }
                EditProfile(profile);
            }
            else
            {
                tabControl.SelectedTab = tabProfiles;
            }
        }

        private void AddProfileChannel() {
            int num = treeViewProfile.Nodes.Count + 1;
            var channelObject = new Channel("Channel " + num.ToString(CultureInfo.InvariantCulture), 0);
            _contextProfile.AddChannelObject(channelObject);
            treeViewProfile.Nodes.Add(channelObject.Name).Tag = channelObject;
            _channelOrderMapping.Add(_channelOrderMapping.Count);
        }

        private void buttonAddMultipleProfileChannels_Click(object sender, EventArgs e)
        {
            int num;
            try
            {
                num = Convert.ToInt32(textBoxProfileChannelCount.Text);
            }
            catch
            {
                MessageBox.Show("Need to have a valid number for the number of channels to add.", Vendor.ProductName,
                                MessageBoxButtons.OK, MessageBoxIcon.Hand);
                return;
            }
            treeViewProfile.BeginUpdate();
            while (num-- > 0)
            {
                AddProfileChannel();
            }
            treeViewProfile.EndUpdate();
        }

        private void buttonAddProfileChannel_Click(object sender, EventArgs e)
        {
            AddProfileChannel();
        }

        private void buttonChangeProfileName_Click(object sender, EventArgs e)
        {
            if (ChangeProfileName())
            {
                labelProfileName.Text = _contextProfile.Name;
            }
        }

        private void buttonDone_Click(object sender, EventArgs e)
        {
            foreach (Profile profile in listBoxProfiles.Items)
            {
                if (!(profile.FileName != string.Empty || ChangeProfileName()))
                {
                    DialogResult = DialogResult.None;
                    break;
                }
                profile.SaveToFile();
            }
        }

        private void buttonPlugins_Click(object sender, EventArgs e)
        {
            var dialog = new PluginListDialog(_contextProfile);
            dialog.ShowDialog();
            dialog.Dispose();
        }

        private void buttonRemoveProfileChannels_Click(object sender, EventArgs e)
        {
            RemoveSelectedProfileChannelObjects();
        }

        private bool ChangeProfileName()
        {
            var dialog = new TextQueryDialog("Profile Name", "Name for this profile", _contextProfile.Name);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _contextProfile.Name = dialog.Response;
                dialog.Dispose();
                return true;
            }
            dialog.Dispose();
            return false;
        }

        private void comboBoxChannelOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxChannelOrder.SelectedIndex != -1)
            {
                List<Channel> channels = _contextProfile.Channels;
                if (comboBoxChannelOrder.SelectedIndex == 0)
                {
                    if (channels.Count == 0)
                    {
                        MessageBox.Show("There are no channels to reorder.", Vendor.ProductName, MessageBoxButtons.OK, MessageBoxIcon.Hand);
                        return;
                    }
                    pictureBoxProfileDeleteChannelOrder.Enabled = false;
                    comboBoxChannelOrder.SelectedIndex = -1;
                    List<Channel> channelList = _contextProfile.Channels;
                    var dialog = new ChannelOrderDialog(channelList, _channelOrderMapping);
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        _channelOrderMapping.Clear();
                        foreach (Channel channel in dialog.ChannelMapping)
                        {
                            _channelOrderMapping.Add(channelList.IndexOf(channel));
                        }
                    }
                    dialog.Dispose();
                }
                else if (comboBoxChannelOrder.SelectedIndex == (comboBoxChannelOrder.Items.Count - 1))
                {
                    pictureBoxProfileDeleteChannelOrder.Enabled = false;
                    comboBoxChannelOrder.SelectedIndex = -1;
                    _channelOrderMapping.Clear();
                    for (int i = 0; i < channels.Count; i++)
                    {
                        _channelOrderMapping.Add(i);
                    }
                    _contextProfile.LastSort = -1;
                }
                else
                {
                    _channelOrderMapping.Clear();
                    _channelOrderMapping.AddRange(((SortOrder) comboBoxChannelOrder.SelectedItem).ChannelIndexes);
                    _contextProfile.LastSort = comboBoxChannelOrder.SelectedIndex;
                    pictureBoxProfileDeleteChannelOrder.Enabled = true;
                }
                ReloadProfileChannelObjects();
            }
        }


        private void EditProfile(Profile profile)
        {
            _contextProfile = profile;
            labelProfileName.Text = profile.Name;
            UpdateSortList();
            ReloadProfileChannelObjects();
            comboBoxChannelOrder.SelectedIndex = _contextProfile.LastSort;
            tabEditProfile.Tag = tabControl.SelectedTab;
            tabControl.SelectedTab = tabEditProfile;
        }

        //ComponentResourceManager manager = new ComponentResourceManager(typeof(ProfileManagerDialog));
        //this.pictureBoxProfileDeleteChannelOrder.Image = (Image)manager.GetObject("pictureBoxProfileDeleteChannelOrder.Image");
        //this.pictureBoxProfileSaveChannelOrder.Image = (Image)manager.GetObject("pictureBoxProfileSaveChannelOrder.Image");
        //this.pictureBoxProfileChannelColors.Image = (Image)manager.GetObject("pictureBoxProfileChannelColors.Image");
        //this.pictureBoxProfileChannelOutputMask.Image = (Image)manager.GetObject("pictureBoxProfileChannelOutputMask.Image");
        //this.pictureBoxProfileChannelOutputs.Image = (Image)manager.GetObject("pictureBoxProfileChannelOutputs.Image");
        //this.pictureBoxReturnFromProfileEdit.Image = (Image)manager.GetObject("pictureBoxReturnFromProfileEdit.Image");


        private void listBoxProfiles_DoubleClick(object sender, EventArgs e)
        {
            if (listBoxProfiles.SelectedIndex != -1)
            {
                EditProfile((Profile) listBoxProfiles.SelectedItem);
            }
        }

        private void listBoxProfiles_KeyDown(object sender, KeyEventArgs e)
        {
            if ((listBoxProfiles.SelectedIndex != -1) && (e.KeyCode == Keys.Delete))
            {
                RemoveProfile((Profile) listBoxProfiles.SelectedItem);
            }
        }

        private void listBoxProfiles_SelectedIndexChanged(object sender, EventArgs e)
        {
            pictureBoxEditProfile.Enabled = pictureBoxRemoveProfile.Enabled = listBoxProfiles.SelectedIndex != -1;
        }

        private void PictureBase(PictureBox pb, Graphics g)
        {
            Color color = (m_hoveredButton == pb)
                              ? _pictureBoxHoverColor
                              : (pb.Enabled ? _pictureEnabledColor : _pictureDisabledColor);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            Rectangle clientRectangle = pb.ClientRectangle;
            clientRectangle.Inflate(-2, -2);
            _picturePen.Color = color;
            _pictureBrush.Color = color;
            g.FillEllipse(Brushes.White, clientRectangle);
            g.DrawEllipse(_picturePen, clientRectangle);
        }

        private void pictureBoxAddProfile_Click(object sender, EventArgs e)
        {
            var dialog = new TextQueryDialog("New Profile", "Name for the new profile", string.Empty);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                var item = new Profile {Name = dialog.Response};
                listBoxProfiles.Items.Add(item);
                EditProfile(item);
            }
            dialog.Dispose();
        }

        private void pictureBoxAddProfile_MouseEnter(object sender, EventArgs e)
        {
            m_hoveredButton = (PictureBox) sender;
            ((PictureBox) sender).Refresh();
        }

        private void pictureBoxAddProfile_MouseLeave(object sender, EventArgs e)
        {
            m_hoveredButton = null;
            ((PictureBox) sender).Refresh();
        }

        private void pictureBoxAddProfile_Paint(object sender, PaintEventArgs e)
        {
            PictureBase((PictureBox) sender, e.Graphics);
            e.Graphics.DrawString("+", _pictureFont, _pictureBrush, 3f, 1f);
        }

        private void pictureBoxEditProfile_Click(object sender, EventArgs e)
        {
            EditProfile((Profile) listBoxProfiles.SelectedItem);
        }

        private void pictureBoxEditProfile_Paint(object sender, PaintEventArgs e)
        {
            PictureBase((PictureBox) sender, e.Graphics);
            e.Graphics.DrawLine(_picturePen, 6, 11, 11, 6);
            e.Graphics.DrawLine(_picturePen, 9, 14, 14, 9);
        }

        private void pictureBoxProfileChannelColors_Click(object sender, EventArgs e)
        {
            List<Channel> channels = _contextProfile.Channels;
            var dialog = new AllChannelsColorDialog(channels);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                List<Color> channelColors = dialog.ChannelColors;
                for (int i = 0; i < channels.Count; i++)
                {
                    channels[i].Color = channelColors[i];
                }
            }
            dialog.Dispose();
        }

        private void pictureBoxProfileChannelOutputMask_Click(object sender, EventArgs e)
        {
            List<Channel> channels = _contextProfile.Channels;
            var dialog = new ChannelOutputMaskDialog(channels);
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foreach (Channel channel in channels)
                {
                    channel.Enabled = true;
                }
                foreach (int num in dialog.DisabledChannels)
                {
                    channels[num].Enabled = false;
                }
            }
            dialog.Dispose();
        }

        private void pictureBoxProfileChannelOutputs_Click(object sender, EventArgs e)
        {
            var dialog = new ChannelOrderDialog(_contextProfile.OutputChannels, null, "Channel output mapping");
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                _contextProfile.OutputChannels = dialog.ChannelMapping;
            }
            dialog.Dispose();
        }

        private void pictureBoxProfileDeleteChannelOrder_Click(object sender, EventArgs e)
        {
            if (
                MessageBox.Show(string.Format("Delete channel order '{0}'?", comboBoxChannelOrder.Text), Vendor.ProductName,
                                MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _contextProfile.Sorts.Remove((SortOrder) comboBoxChannelOrder.SelectedItem);
                comboBoxChannelOrder.Items.RemoveAt(comboBoxChannelOrder.SelectedIndex);
                pictureBoxProfileDeleteChannelOrder.Enabled = false;
            }
        }

        private void pictureBoxProfileSaveChannelOrder_Click(object sender, EventArgs e)
        {
            SortOrder item = null;
            var dialog = new TextQueryDialog("New order", "What name would you like to give to this ordering of the channels?",
                                             string.Empty);
            var no = DialogResult.No;
            while (no == DialogResult.No)
            {
                if (dialog.ShowDialog() == DialogResult.Cancel)
                {
                    dialog.Dispose();
                    return;
                }
                no = DialogResult.Yes;
                foreach (SortOrder order2 in _contextProfile.Sorts)
                {
                    if (order2.Name == dialog.Response)
                    {
                        if (
                            (no =
                             MessageBox.Show("This name is already in use.\nDo you want to overwrite it?", Vendor.ProductName,
                                             MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question)) == DialogResult.Cancel)
                        {
                            dialog.Dispose();
                            return;
                        }
                        item = order2;
                        break;
                    }
                }
            }
            dialog.Dispose();
            if (item != null)
            {
                item.ChannelIndexes.Clear();
                item.ChannelIndexes.AddRange(_channelOrderMapping);
                comboBoxChannelOrder.SelectedItem = item;
            }
            else
            {
                _contextProfile.Sorts.Add(item = new SortOrder(dialog.Response, _channelOrderMapping));
                item.ChannelIndexes.Clear();
                item.ChannelIndexes.AddRange(_channelOrderMapping);
                comboBoxChannelOrder.Items.Insert(comboBoxChannelOrder.Items.Count - 1, item);
                comboBoxChannelOrder.SelectedIndex = comboBoxChannelOrder.Items.Count - 2;
            }
        }

        private void pictureBoxRemoveProfile_Click(object sender, EventArgs e)
        {
            RemoveProfile((Profile) listBoxProfiles.SelectedItem);
        }

        private void pictureBoxRemoveProfile_Paint(object sender, PaintEventArgs e)
        {
            PictureBase((PictureBox) sender, e.Graphics);
            e.Graphics.DrawString("-", _pictureFont, _pictureBrush, 4f, 0f);
        }

        private void pictureBoxReturnFromChannelGroupEdit_Click(object sender, EventArgs e)
        {
            if (tabControl.SelectedTab.Tag == tabProfiles)
            {
                UpdateProfiles();
            }
            else if (tabControl.SelectedTab.Tag == tabEditProfile)
            {
                ReloadProfileChannelObjects();
            }
            tabControl.SelectedTab = (TabPage) tabControl.SelectedTab.Tag;
        }

        private void ReloadProfileChannelObjects()
        {
            int index = -1;
            if (treeViewProfile.SelectedNode != null)
            {
                if (treeViewProfile.SelectedNode.Level == 0)
                {
                    if (treeViewProfile.SelectedNode.IsExpanded)
                    {
                        index = treeViewProfile.SelectedNode.Index;
                    }
                }
                else if ((treeViewProfile.SelectedNode.Level == 1) && treeViewProfile.SelectedNode.Parent.IsExpanded)
                {
                    index = treeViewProfile.SelectedNode.Parent.Index;
                }
            }
            buttonRemoveProfileChannels.Enabled = false;
            treeViewProfile.BeginUpdate();
            treeViewProfile.Nodes.Clear();
            List<Channel> channels = _contextProfile.Channels;
            foreach (int num2 in _channelOrderMapping)
            {
                Channel channel = channels[num2];
                treeViewProfile.Nodes.Add(channel.Name).Tag = channel;
            }
            if (index != -1)
            {
                treeViewProfile.Nodes[index].Expand();
            }
            treeViewProfile.EndUpdate();
        }

        private void RemoveProfile(Profile profile)
        {
            if (
                MessageBox.Show(
                    string.Format("Remove profile {0}?\n\nThis will affect any sequences that use this profile.", profile.Name),
                    Vendor.ProductName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                File.Delete(profile.FileName);
                listBoxProfiles.Items.Remove(profile);
            }
        }

        private void RemoveSelectedProfileChannelObjects()
        {
            if (treeViewProfile.SelectedNode.Level != 0)
            {
                buttonRemoveProfileChannels.Enabled = false;
            }
            else if (
                MessageBox.Show("Remove the selected item from this profile?", Vendor.ProductName, MessageBoxButtons.YesNo,
                                MessageBoxIcon.Question) == DialogResult.Yes)
            {
                _channelOrderMapping.RemoveAt(_contextProfile.Channels.IndexOf((Channel) treeViewProfile.SelectedNode.Tag));
                _contextProfile.RemoveChannel((Channel) treeViewProfile.SelectedNode.Tag);
                treeViewProfile.Nodes.Remove(treeViewProfile.SelectedNode);
                treeViewProfile.SelectedNode = null;
                treeViewProfile_AfterSelect(null, null);
            }
        }

        private void treeViewProfile_AfterSelect(object sender, TreeViewEventArgs e)
        {
            buttonRemoveProfileChannels.Enabled = (treeViewProfile.SelectedNode != null) && (e.Node.Level == 0);
        }

        private void treeViewProfile_DoubleClick(object sender, EventArgs e)
        {
            if (treeViewProfile.SelectedNode != null)
            {
                var tag = (Channel) treeViewProfile.SelectedNode.Tag;
                var channels = new List<Channel>();
                foreach (TreeNode node in treeViewProfile.Nodes)
                {
                    channels.Add((Channel) node.Tag);
                }
                var dialog = new ChannelPropertyDialog(channels, tag, false);
                dialog.ShowDialog();
                ReloadProfileChannelObjects();
                dialog.Dispose();
            }
        }

        private void treeViewProfile_KeyDown(object sender, KeyEventArgs e)
        {
            if ((treeViewProfile.SelectedNode != null) && (e.KeyCode == Keys.Delete))
            {
                RemoveSelectedProfileChannelObjects();
            }
        }

        private void UpdateProfiles()
        {
            var list = new List<Profile>();
            foreach (Profile profile in listBoxProfiles.Items)
            {
                list.Add(profile);
            }
            listBoxProfiles.SelectedIndex = -1;
            listBoxProfiles.BeginUpdate();
            listBoxProfiles.Items.Clear();
            foreach (Profile profile in list)
            {
                listBoxProfiles.Items.Add(profile);
            }
            listBoxProfiles.EndUpdate();
        }

        private void UpdateSortList()
        {
            comboBoxChannelOrder.BeginUpdate();
            var item = (string) comboBoxChannelOrder.Items[0];
            var str2 = (string) comboBoxChannelOrder.Items[comboBoxChannelOrder.Items.Count - 1];
            comboBoxChannelOrder.Items.Clear();
            comboBoxChannelOrder.Items.Add(item);
            foreach (SortOrder order in _contextProfile.Sorts)
            {
                comboBoxChannelOrder.Items.Add(order);
            }
            comboBoxChannelOrder.Items.Add(str2);
            comboBoxChannelOrder.EndUpdate();
            int count = _contextProfile.Channels.Count;
            _channelOrderMapping.Clear();
            for (int i = 0; i < count; i++)
            {
                _channelOrderMapping.Add(i);
            }
        }

        private void treeViewProfile_DrawNode(object sender, DrawTreeNodeEventArgs e) {
            if ((e.State & TreeNodeStates.Selected) != 0) {
                e.DrawDefault = true;
                return;
            }

            // Draw the background of the selected node. The NodeBounds 
            // method makes the highlight rectangle large enough to 
            // include the text of a node tag, if one is present.
            e.Graphics.FillRectangle(new SolidBrush(_contextProfile.Channels[e.Node.Index].Color), e.Node.Bounds);

            // Retrieve the node font. If the node font has not been set, 
            // use the TreeView font.
            var nodeFont = e.Node.NodeFont ?? ((TreeView)sender).Font;

            // Draw the node text.
            e.Graphics.DrawString(e.Node.Text, nodeFont, Utils.GetTextColor(_contextProfile.Channels[e.Node.Index].Color),
                                  Rectangle.Inflate(e.Bounds, 2,0));
        }
    }
}