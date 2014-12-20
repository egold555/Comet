﻿using System.Xml;

namespace VixenPlus {
    public interface ISeqIOHandler {

        string DialogFilterList();
        string FileExtension();
        int PreferredOrder();
        bool IsNativeToVixenPlus();
        bool CanSave();
        void Save(EventSequence eventSequence);
        bool CanOpen();
        void Open(XmlNode contextNode, EventSequence eventSequence);
    }
}