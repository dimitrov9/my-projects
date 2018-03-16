using Karavas_Stock_Management.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karavas_Stock_Management
{
    public partial class AddElement : Form
    {
        public int elementTypeID;
        public int dimensionID;

        DataTable elementTypes;
        public DataTable dtDimensions;
        public string selectedDimensions;

        public AddElement()
        {
            InitializeComponent();
            elementTypeID = -1;
            dimensionID = -1;

            string query = "Select ElementType From ElementTypes";
            elementTypes = SQLControl.GetData(query);

            for (int i = 0; i < elementTypes.Rows.Count; i++)
            {
                cboxElementType.Items.Add((string)elementTypes.Rows[i][0]);
            }

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            if(elementTypeID>=0 && clbDimensions.CheckedItems.Count>0 )
            {
                //elementID = SQLControl.GetElementID(cboxElementType.SelectedItem.ToString(), cboxDimensions.SelectedItem.ToString());
                elementTypeID = elementTypeID + 1;

                selectedDimensions = "'";
                foreach (var item in clbDimensions.CheckedItems)
                {
                    selectedDimensions += item.ToString().Trim() + "', '";
                }
                selectedDimensions = selectedDimensions.Substring(0, selectedDimensions.Length - 3);

                DataView dv = dtDimensions.DefaultView;
                dv.RowFilter = "Dimension IN (" + selectedDimensions + ")";
                dtDimensions = dv.ToTable();



                DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Имате невнесени полиња");
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void cboxElementType_SelectionChangeCommitted(object sender, EventArgs e)
        {
            elementTypeID = cboxElementType.SelectedIndex;

            dtDimensions= SQLControl.GetData(SQLControl.GetDimensions(cboxElementType.SelectedItem.ToString().Trim()));
            //dtDimensions.Select()

            dimensionID = -1;
            clbDimensions.Items.Clear();
            errorProvider1.Clear();
            pictureBox1.BackgroundImage = SQLControl.ImagesOfElementTypes[elementTypeID];

            for (int i = 0; i < dtDimensions.Rows.Count; i++)
            {
                clbDimensions.Items.Add((string)dtDimensions.Rows[i][0]);
            }

            clbDimensions.Height = clbDimensions.Items.Count * 28;

            this.Height = 412 + clbDimensions.Height;

        }

        private void cboxDimensions_Click(object sender, EventArgs e)
        {
            if (cboxElementType.SelectedIndex != -1)
            {
                errorProvider1.Clear();
            }
            else
            {
                errorProvider1.SetError(clbDimensions, "Оберете Тип на Елемент прво!");
            }

            dimensionID = clbDimensions.SelectedIndex;


        }

        private void cboxDimensions_SelectionChangeCommitted(object sender, EventArgs e)
        {
            dimensionID = clbDimensions.SelectedIndex;
        }
    }
}
