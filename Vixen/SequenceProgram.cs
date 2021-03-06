﻿using System;
using System.Collections.Generic;
using System.IO;

namespace VixenPlus {
    public class SequenceProgram : ExecutableBase {
        private readonly ulong _key;
        private byte[][] _mask;
        private readonly Profile _profile;

        public SequenceProgram(EventSequence sequence) {
            _profile = null;
            UseSequencePluginData = false;
            TreatAsLocal = false;
            _key = Host.GetUniqueKey();
            _mask = null;
            FileName = sequence.FileName;
            ConstructUsing();
            SetupData = sequence.PlugInData;
            EventSequences.Add(new EventSequenceStub(sequence));
        }


        internal List<EventSequenceStub> EventSequences { get; private set; }

        public SetupData SetupData { get; private set; }

        public bool UseSequencePluginData { get; private set; }

        public override int AudioDeviceIndex {
            get { return -1; }
        }

        public override List<Channel> Channels {
            get {
                return _profile == null ? new List<Channel>() : _profile.Channels;
            }
        }

        public override List<Channel> FullChannels {
            get { return Channels; }
        }

        public override ulong Key {
            get { return _key; }
        }

        public override byte[][] Mask {
            get {
                if (_profile != null) {
                    return _profile.Mask;
                }
                if (_mask != null) {
                    return _mask;
                }
                _mask = new byte[EventSequences.Count][];
                for (var i = 0; i < EventSequences.Count; i++) {
                    _mask[i] = EventSequences[i].Mask[0];
                }
                return _mask;
            }
            set {
                if (_profile != null) {
                    return;
                }
                foreach (var t in EventSequences) {
                    t.Mask[0] = value[0];
                }
            }
        }

        public override string Name {
            get { return Path.GetFileNameWithoutExtension(FileName); }
        }

        public override SetupData PlugInData {
            get {
                return _profile == null ? SetupData : _profile.PlugInData;
            }
        }

        private void ConstructUsing() {
            EventSequences = new List<EventSequenceStub>();
        }

        public new void Dispose() {
            foreach (var stub in EventSequences) {
                stub.Dispose();
            }
            GC.SuppressFinalize(this);
        }

        ~SequenceProgram() {
            Dispose();
        }

        public override string ToString() {
            return Name;
        }
    }
}