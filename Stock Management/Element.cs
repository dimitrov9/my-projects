using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karavas_Stock_Management
{
    public class Element : Panel
    {
        //public NumericLeftRight numLR;
        DataRow elementTypeRow;
        public bool opened = false;

        int objectID;
        PictureBox pBox;
        public ElementTypeLabel lblElementType;
        //NumericLeftRight numState;
        public Label lblState;
        public DimensionsPanel pnlDim;

        private bool ifPreview;
        public Element(bool ifPreview,bool ifMontage,DataRow elementTypeRow,int objectID,string selectedDimensions = "")
        {
            this.ifPreview = ifPreview;
            this.objectID = objectID;
            this.elementTypeRow = elementTypeRow;
            ModifyPanel();

            AddPictureBox((int)elementTypeRow[0] - 1);

            AddElementTypeLabel((int)elementTypeRow[0]);

            AddStateLabel(elementTypeRow[1].ToString());

            #region Old Code
            //if (ifPreview)
            //{

            //}
            //else
            //{
            //        numState = new NumericLeftRight();
            //        numState.Location = new Point(5, 201);
            //        //numState.Font = new Font("Microsoft Sans Serif", 20);
            //        numState.Size = new Size(155, 40);
            //        numState.NumericUpDown.Maximum = (int)elementTypeRow[1];
            //        numLR = numState;
            //        this.Controls.Add(numState);


            //        lblState = new Label();
            //        lblState.Location = new Point(5, 270);
            //        lblState.Size = new Size(155, 25);
            //        lblState.Font = new Font("Microsoft Sans Serif", 14);
            //        lblState.AutoSize = false;
            //        lblState.TextAlign = ContentAlignment.MiddleCenter;
            //        lblState.Text = "Avaliable: " + elementTypeRow[1].ToString();
            //        lblState.BorderStyle = BorderStyle.FixedSingle;
            //        this.Controls.Add(lblState);
            //} 
            #endregion

            if (selectedDimensions.Equals(""))
            {
                lblState.Click += Element_Click;
                this.Click += Element_Click;
                pBox.Click += Element_Click;
                lblElementType.Click += Element_Click;
            }

        }

        private void AddStateLabel(string stateValue)
        {
            lblState = new Label();
            lblState.Text = stateValue;
            lblState.Location = new Point(5, 201);
            lblState.AutoSize = false;
            lblState.Font = new Font("Microsoft Sans Serif", 20);
            lblState.Size = new Size(155, 40);
            lblState.TextAlign = ContentAlignment.MiddleCenter;

            //lblState.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(lblState);
        }

        private void ModifyPanel()
        {
            this.BackColor = Color.PapayaWhip;
            this.Size = new Size(160, 250);
            this.Margin = new Padding(8);

            //this.MouseLeave += Element_MouseLeave;
        }

        private void Element_Click(object sender, EventArgs e)
        {
            ChangeOpened();

        }

        public void ChangeOpened(string selectedDims = "")
        {
            if (opened)
            {
                this.Size = new Size(170, 250);
                lblElementType.Location = new Point(5, 161);
                lblElementType.Size = new Size(160, 35);
                if (lblState != null)
                {
                    lblState.Location = new Point(5, 201);
                    lblState.Size = new Size(155, 40);
                }
                Controls.Remove(pnlDim);
                opened = false;
            }
            else
            {
                this.Size = new Size(330, 450);
                lblElementType.Location = new Point(165, 10);
                lblElementType.Size = new Size(130, 40);

                if (lblState != null)
                {
                    lblState.Location = new Point(165, lblElementType.Location.Y + lblElementType.Size.Height + 10);
                    lblState.Size = new Size(135, 40);
                }
                if (selectedDims.Equals("")){
                    pnlDim = new DimensionsPanel((int)elementTypeRow[0], objectID, selectedDims, ifPreview);
                }
                else
                {
                    pnlDim = new DimensionsPanel((int)elementTypeRow[0], 1, selectedDims, ifPreview);
                }

                pnlDim.Location = new Point(0, 160);
                Controls.Add(pnlDim);
                Height = pnlDim.Height + 160;
                opened = true;
            }
        }

        private void AddPictureBox(int elementTypeID)
        {
            pBox = new PictureBox();
            pBox.BackgroundImage = SQLControl.ImagesOfElementTypes[elementTypeID] ;
            pBox.BackgroundImageLayout = ImageLayout.Stretch;
            pBox.Location = new Point(9, 3);
            pBox.Size = new Size(155, 155);

            //pBox.BorderStyle = BorderStyle.FixedSingle;
            this.Controls.Add(pBox);
        }

        private void AddElementTypeLabel(int elementTypeID)
        {
            lblElementType = new ElementTypeLabel(elementTypeID);
            lblElementType.Width = 155;
            this.Controls.Add(lblElementType);
        }

    }
}
