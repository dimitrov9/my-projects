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
    public partial class OneDimensionPanel : UserControl
    {
        public int elementID;

        public OneDimensionPanel(DataRow dimensionRow,bool ifPreview = false)
        {
            InitializeComponent();
            this.elementID = (int)dimensionRow[0];
            lblDimension.Text = (string)dimensionRow[1].ToString().Trim();
            lblAvaliable.Text = dimensionRow[2].ToString();

            if (ifPreview)
            {
                numericUpDown1.Visible = false;
            }
            else
            {
                numericUpDown1.Visible = true;
                numericUpDown1.Maximum = (int)dimensionRow[2];
            }


        }
    }
}
