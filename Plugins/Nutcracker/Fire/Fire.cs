﻿using System.Windows.Forms;
using VixenPlus;

namespace Fire {
    public partial class Fire : UserControl, INutcrackerEffect {
        public Fire() {
            InitializeComponent();
        }


        public string EffectName {
            get { return "Fire"; }
        }

        public byte[] EffectData {
            get { throw new System.NotImplementedException(); }
        }

        public void Startup() {
            throw new System.NotImplementedException();
        }


        public void ShutDown() {
            throw new System.NotImplementedException();
        }
    }
}
