﻿using System.Windows.Forms;

namespace VixenPlus {
    internal interface IUIPlugIn : IVixenMDI, IPlugIn
    {
        string FileExtension { get; }
        string FileTypeDescription { get; }
        bool IsDirty { get; set; }
        Form MdiParent {set; }
        EventSequence New(); 
        EventSequence New(EventSequence seedSequence);
        EventSequence Open(string filePath);
        DialogResult RunWizard(ref EventSequence resultSequence);
        void SaveTo(string filePath);
        void Show();
    }
}