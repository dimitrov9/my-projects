﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karavas_Stock_Management
{
    public partial class ObjectDedicatedButton : UserControl
    {
        public ObjectDedicatedButton(Image icon,Image text = null)
        {
            InitializeComponent();
            pictureBox1.BackgroundImage = icon;
            pictureBox2.BackgroundImage = text;
            WireAllControls(this);
        }

        private void WireAllControls(Control cont)
        {
            foreach (Control ctl in cont.Controls)
            {
                ctl.Click += ctl_Click;
                if (ctl.HasChildren)
                {
                    WireAllControls(ctl);
                }
            }
        }

        private void ctl_Click(object sender, EventArgs e)
        {
            this.InvokeOnClick(this, EventArgs.Empty);
        }

    }
}

