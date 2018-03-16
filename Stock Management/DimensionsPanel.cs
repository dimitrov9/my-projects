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
    public partial class DimensionsPanel : UserControl
    {
        public DataTable dtDimensionStates;
        

        public DimensionsPanel(int elementType,int objectId,string selectedDimensions = "",bool ifPreview = false)
        {
            InitializeComponent();
            if (selectedDimensions.Equals(""))
            {
                dtDimensionStates = SQLControl.GetData(SQLControl.GetDimensionsStates(elementType, objectId));
            }
            else
            {
                dtDimensionStates = SQLControl.GetData(SQLControl.GetDimensionsStates(elementType, objectId,selectedDimensions));
            }


            //dtDimensionStates.Select()

            for (int i = 0; i < dtDimensionStates.Rows.Count; i++)
            {
                Dimensions.Controls.Add(new OneDimensionPanel(dtDimensionStates.Rows[i]));

            }
            Dimensions.Height = Dimensions.Controls.Count * 40 + 40;
            Height = Dimensions.Height;
            if (ifPreview)
            {
                Width -= 120;
                label2.Visible = false;
            }
        }

        //public DimensionsPanel(int elementType, int objectId,DataTable dtDimensions)
        //{
        //    InitializeComponent();
        //    dtDimensionStates = SQLControl.GetData(SQLControl.GetDimensionsStates(elementType, objectId));
        //}

        private void label1_Click(object sender, EventArgs e)
        {
            DataView dv = dtDimensionStates.DefaultView;
            if(dv.Sort.Equals("Dimension asc"))
            {
                dv.Sort = "Dimension desc";
            }
            else
            {
                dv.Sort = "Dimension asc";
            }

            dtDimensionStates = dv.ToTable();
            Dimensions.Controls.Clear();
            for (int i = 0; i < dtDimensionStates.Rows.Count; i++)
            {
                Dimensions.Controls.Add(new OneDimensionPanel(dtDimensionStates.Rows[i]));
            }
        }
    }
}
