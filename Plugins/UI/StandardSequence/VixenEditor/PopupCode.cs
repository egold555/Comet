﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VixenEditor
{
    public partial class PopupCode : Form
    {
        public PopupCode(String code)
        {
            InitializeComponent();
            this.textBox1.Text = code;
        }
    }
}
