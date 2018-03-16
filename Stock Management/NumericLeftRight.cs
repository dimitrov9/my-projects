using System;
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
    public partial class NumericLeftRight : UserControl
    {
        public NumericUpDown NumericUpDown
        {
            get
            {
                return numValue;
            }
        }

        public NumericLeftRight()
        {
            InitializeComponent();
        }

        private void btnDecrement_Click(object sender, EventArgs e)
        {
            numValue.DownButton();
        }

        private void btnIncrement_Click(object sender, EventArgs e)
        {
            numValue.UpButton();
        }
    }
}
