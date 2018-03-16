using Karavas_Stock_Management.Properties;
using Karavas_Stock_Management.KaravasStockManagementDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace Karavas_Stock_Management
{
    public class ObjectLocation : Panel
    {
        #region Row Attributes
        public int ID;
        public string nameObject;
        public string nameContractor;
        public string adress;
        public bool finished;
        public int momentState;
        //public int stateID; 
        #endregion

        public DataRow row;
        public bool check;

        private Form1 mainForm;
        Label lblState;

        /// <summary>
        /// <para>Public Constructor for ObjectLocation returns a child of Panel</para>
        /// </summary>
        /// <param name="rowObject">The Row for 'this' in 'Object' table</param>
        /// <param name="firstForm">The Main form where the active Objects are shown</param>
        public ObjectLocation(DataRow rowObject,Form1 firstForm)
        {
            mainForm = firstForm;

            row = rowObject;
            check = false;

            #region Declaration of Row Attributes
            ID = (int)rowObject[0];
            nameObject = rowObject[1].ToString();
            nameContractor = rowObject[2].ToString();
            adress = rowObject[3].ToString();
            finished = rowObject[4].Equals(true);
            momentState = rowObject.IsNull(5) ? 0 : (int)rowObject[5];
 
            //stateID = Convert.ToInt32(rowObject[6].ToString());
            #endregion

            #region Apply Panel Template + child Controls
            ModifyPanel();
            AddCheckBox();
            //AddColumnsLabels();
            AddNameObjectLabel(nameObject);
            AddNameContractorLabel(nameContractor);
            AddAdressLabel(adress);
            AddStateLabel(momentState);
            AddMontageButton();
            AddDemontageButton();

            //this.MouseEnter += panel4_MouseEnter;
            //this.MouseLeave += panel4_MouseExit;
            //Controls.Find("btnMontage", false)[0].Visible = false;
            //Controls.Find("btnDemontage", false)[0].Visible = false;
            //AddRemoveButton(); 
            #endregion

        }

        #region Panel Template + variable Controls + Buttons
                /// <summary>
        /// Design the panel to be shown in the flowLayoutPanel
        /// </summary>
        private void ModifyPanel()
        {
            Size = new Size(1115, 56);
            Anchor = AnchorStyles.Right & AnchorStyles.Left;
            Margin = new Padding(8, 6, 8, 6);
            BackColor = Color.Azure;
            BorderStyle = BorderStyle.FixedSingle;
            Click += Panel_Click;
        }
        private void AddCheckBox()
        {
            CheckBox cb = new CheckBox();
            cb.Location = new Point(20, 20);
            cb.Size = new Size(new Point(20, 20));
            cb.CheckedChanged += Cb_CheckedChanged;
            this.Controls.Add(cb);

        }
        private void AddColumnsLabels()
        {
            Label lbl = new Label();
            lbl.Location = new Point(51, 14);
            lbl.Font = new Font("Microsoft Sans Serif", 15);
            lbl.Text = "ОБЈЕКТ";
            lbl.Click += Panel_Click;
            this.Controls.Add(lbl);

            lbl = new Label();
            lbl.Location = new Point(201, 14);
            lbl.Font = new Font("Microsoft Sans Serif", 15);
            lbl.Text = "ИЗВЕДУВАЧ";
            lbl.Size = new Size(new Point(131, 25));
            lbl.Click += Panel_Click;
            this.Controls.Add(lbl);

            lbl = new Label();
            lbl.Location = new Point(387, 14);
            lbl.Font = new Font("Microsoft Sans Serif", 15);
            lbl.Text = "АДРЕСА";
            lbl.Click += Panel_Click;
            this.Controls.Add(lbl);

            lbl = new Label();
            lbl.Location = new Point(544, 14);
            lbl.Font = new Font("Microsoft Sans Serif", 15);
            lbl.Text = "СОСТОЈБА";
            lbl.Size = new Size(new Point(131, 25));
            lbl.Click += Panel_Click;
            this.Controls.Add(lbl);
        }
                /// <summary>
        /// Adds the label that displays the NameObject value in that row and design it in the Panel
        /// </summary>
        /// <param name="cellNameObject">The cell where NameObject is in this row</param>
        private void AddNameObjectLabel(string cellNameObject)
        {
            Label lbl = new Label();
            lbl.AutoSize = false;
            lbl.Size = new Size(new Point(144, 57));
            lbl.Location = new Point(51, 0);
            lbl.Font = new Font("Microsoft Sans Serif", 12);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Text = cellNameObject.Trim();
            lbl.Click += Panel_Click;
            this.Controls.Add(lbl);
        }
                /// <summary>
        /// <para>Adds the label that displays the NameContractor value in that row and design it in the Panel</para>
        /// </summary>
        /// <param name="cellNameContractor">The cell where NameContractor is in this row</param>   
        private void AddNameContractorLabel(string cellNameContractor)
        {
            Label lbl = new Label();
            lbl.AutoSize = false;
            lbl.Size = new Size(new Point(180, 57));
            lbl.Location = new Point(201, 0);
            lbl.Font = new Font("Microsoft Sans Serif", 12);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Text = cellNameContractor.Trim();
            lbl.Click += Panel_Click;
            this.Controls.Add(lbl);
        }
        private void AddAdressLabel(string cellAdress)
        {
            Label lbl = new Label();
            lbl.AutoSize = false;
            lbl.Size = new Size(new Point(151, 57));
            lbl.Location = new Point(387, 0);
            lbl.Font = new Font("Microsoft Sans Serif", 12);
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Text = cellAdress.Trim();
            lbl.Click += Panel_Click;
            this.Controls.Add(lbl);
        }
        private void AddStateLabel(int cellState)
        {
            lblState = new Label();
            
            lblState.MouseHover += Lbl_MouseHover;
            lblState.MouseLeave += Lbl_MouseLeave;
            lblState.AutoSize = false;
            lblState.Size = new Size(new Point(140, 57));
            lblState.Location = new Point(544, 0);
            lblState.Font = new Font("Microsoft Sans Serif", 12);
            lblState.TextAlign = ContentAlignment.MiddleCenter;
            lblState.Text = cellState.ToString().Trim();
            lblState.Click += Panel_Click;
            this.Controls.Add(lblState);
        }

        private void Lbl_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        private void Lbl_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void AddMontageButton()
        {
            ObjectDedicatedButton btnMontage = new ObjectDedicatedButton(Resources.Mount40,Resources.MountText);
            btnMontage.Click += BtnMontage_Click;
            //btnMontage.Name = "btnMontage";
            //btnMontage.BackgroundImage = Resources.sign_add;
            //btnMontage.BackgroundImageLayout = ImageLayout.Stretch;
            btnMontage.Location = new Point(750, 7);
            //btnMontage.Size = new Size(new Point(139, 40));
            //btnMontage.Text = string.Empty;
            //btnMontage.UseVisualStyleBackColor = true;
            this.Controls.Add(btnMontage);
        }
        private void AddDemontageButton()
        {
            ObjectDedicatedButton btnDemontage = new ObjectDedicatedButton(Resources.Dismount40,Resources.DismountText);
            btnDemontage.Click += BtnDemontage_Click;
            //btnDemontage.Name = "btnDemontage";
            //btnDemontage.BackgroundImage = Resources.minus;
            //btnDemontage.BackgroundImageLayout = ImageLayout.Stretch;
            btnDemontage.Location = new Point(930, 7);
            //btnDemontage.Size = new Size(new Point(139, 38));
            //btnDemontage.Text = string.Empty;
            //btnDemontage.UseVisualStyleBackColor = true;
            this.Controls.Add(btnDemontage);
        }
        //private void AddRemoveButton()
        //{
        //    ObjectDedicatedButton btnDelete = new ObjectDedicatedButton(Resources.Delete40,Resources.DeleteText);
        //    btnDelete.Click += BtnDelete_Click;
        //    //btnDelete.BackgroundImage = Resources.delete;
        //    //btnDelete.BackgroundImageLayout = ImageLayout.Stretch;
        //    btnDelete.Location = new Point(1220, 7);
        //    //btnDelete.Size = new Size(new Point(139, 38));
        //    //btnDelete.Text = string.Empty;
        //    //btnDelete.UseVisualStyleBackColor = true;
        //    this.Controls.Add(btnDelete);
        //}
        #endregion

        #region Buttons + other Controls - Event Methods
        private void Panel_Click(object sender, EventArgs e)
        {
            if (momentState > 0)
            {
                AddState addStateForm = new AddState(true, false, nameObject, nameContractor, adress, ID, momentState);
                DialogResult res = addStateForm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    // mainForm.AddStates(stateRows, addStateForm.value, false);
                }
                addStateForm.Close();
            }
            else
            {
                MessageBox.Show("Please montage first so we have something to show you!");
            }
        }
        private void BtnDemontage_Click(object sender, EventArgs e)
        {
            if (momentState > 0)
            {
                AddState addStateForm = new AddState(false, false, nameObject, nameContractor, adress, ID, momentState);
                DialogResult res = addStateForm.ShowDialog();
                if (res == DialogResult.OK)
                {
                    momentState = SQLControl.GetLastSumState(ID);
                    lblState.Text = momentState.ToString();
                }
                addStateForm.Close();
            }
            else
            {
                MessageBox.Show("You cannot demontage, because this object is empty!");
            }

        }
        private void BtnMontage_Click(object sender, EventArgs e)
        {
            AddState addStateForm = new AddState(false,true, nameObject,nameContractor,adress,this.ID, momentState);
            DialogResult res = addStateForm.ShowDialog();
            if (res == DialogResult.OK)
            {
                momentState = SQLControl.GetLastSumState(ID);
                lblState.Text = momentState.ToString();
            }
            addStateForm.Close();
        }
        private void Cb_CheckedChanged(object sender, EventArgs e)
        {
            check = !check;
            if (check)
            {
                mainForm.IncreaseNumberChecked();
            }
            else
            {
                mainForm.DecreaseNumberChecked();
            }
        }
        //public void BtnDelete_Click(object sender, EventArgs e)
        //{
        //    string query = String.Join(" ", new String[] { "DELETE FROM Object WHERE ObjectID ='", ID.ToString(), "'" });
        //    SQLControl.DeleteRows(query);
        //    this.Parent.Controls.Remove(this);
        //} 


        #endregion

        private void panel4_MouseEnter(object sender, EventArgs e)
        {
            Controls.Find("btnMontage",false)[0].Visible = true;
            Controls.Find("btnDemontage", false)[0].Visible = true;
        }
        private void panel4_MouseExit(object sender, EventArgs e)
        {
            Controls.Find("btnMontage", false)[0].Visible = false;
            Controls.Find("btnDemontage", false)[0].Visible = false;
        }

    }
}

