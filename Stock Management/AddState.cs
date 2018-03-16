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
    public partial class AddState : Form
    {
        public int value;
        public int momentState;
        //public int stateID;
        public int objectID;
        bool ifMontage;
        DataTable dtElementsObject;
        DataTable dtElementsWarehouse;
        //private int[][] ElementsObject;
        //private int[][] ElementsWareHouse;
        //private Form1 mainForm;

        public AddState(bool ifPreview,bool ifMontage,string nameObject,string nameContractor,string adress,int ObjectID,int value)
        {
            InitializeComponent();
            this.momentState = value;
            //stateID = stateId;
            objectID = ObjectID;
            this.ifMontage = ifMontage;
            btnAddElement.Visible = ifMontage;

            dtElementsWarehouse = SQLControl.GetData(SQLControl.LatestElementTypesFromObject(1));
            dtElementsObject = SQLControl.GetData(SQLControl.LatestElementTypesFromObject(objectID));

            if (ifPreview)
            {
                labelTitle.Text = "STATE PREVIEW";
                btnAddElement.Visible = false;
                btnOk.Visible = false;
                lblDate.Visible = false;
                dateTimePicker1.Visible = false;

                bool isEmpty = true;
                for (int i = 0; i < dtElementsObject.Rows.Count; i++)
                {
                    if ((int)dtElementsObject.Rows[i][1] > 0)
                    {
                        flowLayoutPanel1.Controls.Add(new Element(true, false, dtElementsObject.Rows[i],objectID));
                        if (isEmpty)
                        {
                            isEmpty = false;
                        }
                    }
                }
                if (isEmpty)
                {
                    this.Close();
                }
            }
            else
            {
                lblDate.Visible = true;
                dateTimePicker1.Visible = true;

                string montageString;
                if (ifMontage)
                {
                    montageString = "Mount";
                    labelTitle.ForeColor = Color.LawnGreen;
                }
                else
                {
                    montageString = "Dismount";
                    labelTitle.ForeColor = Color.OrangeRed;

                    for (int i = 0; i < dtElementsObject.Rows.Count; i++)
                    {
                        if ((int)dtElementsObject.Rows[i][1] > 0)
                        {
                            flowLayoutPanel1.Controls.Add(new Element(false, false, dtElementsObject.Rows[i],objectID));
                        }
                    }
                }
                labelTitle.Text = montageString.ToUpper();
                btnOk.Text = montageString;

                //query = String.Join(String.Empty, "SELECT  * FROM Elements WHERE StateID= ", mainForm.momentStateID.ToString());
                //DataTable dtElementsWareHouse = SQLControl.GetData(query);

                //ElementsWareHouse = new int[dtElementsWareHouse.Rows.Count][];
                //for (int i = 0; i < dtElementsWareHouse.Rows.Count; i++)
                //{
                //    ElementsWareHouse[i] = new int[dtElementsWareHouse.Columns.Count];
                //    for (int j = 0; j < dtElementsWareHouse.Columns.Count; j++)
                //    {
                //        ElementsWareHouse[i][j] = Convert.ToInt32(dtElementsWareHouse.Rows[i][j]);
                //    }
                //}

                //dtElementsObject.Dispose();
                //dtElementsWareHouse.Dispose();
            }

            lblNameObject.Text = nameObject;
            lblNameContractor.Text = nameContractor;
            lblAdress.Text = adress;
            lblMomentState.Text = momentState.ToString();
        }


        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btnAddElement_Click(object sender, EventArgs e)
        {
            AddElement addElement = new AddElement();
            DialogResult dlg = addElement.ShowDialog();
            if (dlg == DialogResult.OK)
            {
                bool check = false;
                for (int i = 0; i < dtElementsWarehouse.Rows.Count; i++)
                {
                    if(((int)dtElementsWarehouse.Rows[i][0] == addElement.elementTypeID)) {

                        string selectedElementsId = "";
                        
                        foreach (DataRow item in addElement.dtDimensions.Rows)
                        {
                            selectedElementsId += item[1].ToString().Trim() + ", ";
                        }
                        selectedElementsId = selectedElementsId.Substring(0, selectedElementsId.Length - 2);

                        Element ele = new Element(false, true, dtElementsWarehouse.Rows[i], objectID, selectedElementsId);
                        ele.ChangeOpened(selectedElementsId);
                        
                        flowLayoutPanel1.Controls.Add(ele);
                        check = true;
                        break;
                    }
                }
                if (!check)
                {
                    MessageBox.Show("We have an error in reading the element from the warehouse!");
                }

            }
        }

        private void AddState_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'karavasStockManagementDataSet.Elements' table. You can move, or remove it, as needed.
            this.elementsTableAdapter.Fill(this.karavasStockManagementDataSet.Elements);

        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            //string date = String.Format("{0:yyyy-MM-dd}", dateTimePicker1.Value);
            if (!checkBox1.Checked)
            {
                MessageBox.Show("Please check the Date Checked if the Date is correct or change to correct Date");
                return;
            }


            if (ifMontage)
            {
                foreach (Element item in flowLayoutPanel1.Controls)
                {
                    foreach (OneDimensionPanel dim in item.pnlDim.Dimensions.Controls)
                    {

                        int lastStateObject = SQLControl.GetLastState(dim.elementID, objectID);
                        int newStateObject = lastStateObject + (int)dim.numericUpDown1.Value;

                        int lastStateWarehouse = SQLControl.GetLastState(dim.elementID, 1);
                        int newStateWarehouse = lastStateWarehouse - (int)dim.numericUpDown1.Value;
                        KaravasStockManagementDataSetTableAdapters.StateTableAdapter stdAdapter = new KaravasStockManagementDataSetTableAdapters.StateTableAdapter();
                        stdAdapter.Insert(objectID, dim.elementID, (int)dim.numericUpDown1.Value, newStateObject, dateTimePicker1.Value);
                        stdAdapter.Insert(1, dim.elementID, -(int)dim.numericUpDown1.Value, newStateWarehouse, dateTimePicker1.Value);

                    }
                }
            }
            else
            {
                foreach (Element item in flowLayoutPanel1.Controls)
                {
                    if (item.opened)
                    {
                        foreach (OneDimensionPanel dim in item.pnlDim.Dimensions.Controls)
                        {

                            int lastStateObject = SQLControl.GetLastState(dim.elementID, objectID);
                            int newStateObject = lastStateObject - (int)dim.numericUpDown1.Value;

                            int lastStateWarehouse = SQLControl.GetLastState(dim.elementID, 1);
                            int newStateWarehouse = lastStateWarehouse + (int)dim.numericUpDown1.Value;
                            KaravasStockManagementDataSetTableAdapters.StateTableAdapter stdAdapter = new KaravasStockManagementDataSetTableAdapters.StateTableAdapter();
                            stdAdapter.Insert(objectID, dim.elementID, -(int)dim.numericUpDown1.Value, newStateObject, dateTimePicker1.Value);
                            stdAdapter.Insert(1, dim.elementID, (int)dim.numericUpDown1.Value, newStateWarehouse, dateTimePicker1.Value);

                        }
                    }

                }
            }
            this.DialogResult = DialogResult.OK;


        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            checkBox1.Checked = true;
        }
    }
}
