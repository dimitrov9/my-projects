using Karavas_Stock_Management.KaravasStockManagementDataSetTableAdapters;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace Karavas_Stock_Management
{
    public partial class Form1 : Form
    {
        //public int momentStateID;

        private DataTable dtStatesForObject;
        private DataTable allStatesForObjects;

        private DataRow rowWareHouse;
        private int numChecked;
        private bool archived;
        public Form1(bool archived)
        {

            InitializeComponent();
            this.archived = archived;
            //DataTable data = SQLControl.GetData(SQLControl.objectsWithLastStateQuery(false));

            //dtStatesForObject = data.Select("ObjectId > 1").CopyToDataTable();
            //allStatesForObjects = dtStatesForObject;
            //numChecked = 0;
            //rowWareHouse = data.Select("ObjectId = 1")[0];
            //rowWareHouse = SQLControl.GetData(SQLControl.warehouseLastStateQuery).Rows[0];

            //momentStateID = Convert.ToInt32(rowWareHouse[6].ToString());

            UpdateStatesForObject(archived);

            

        }

        /// <summary>
        /// Returns true there are records
        /// </summary>
        /// <param name="archived"></param>
        /// <returns></returns>
        private bool UpdateStatesForObject(bool archived,string searchValue = "")
        {
            searchValue = searchValue.ToLower();
            DataTable data = SQLControl.GetData(SQLControl.objectsWithLastStateQuery(archived));


            //Exception ako nema records
            if (data.Rows.Count <=1 && archived)
            {
                MessageBox.Show("There are no records for the wanted category!");
                return false;
            }
            else
            {
                    rowWareHouse = data.Select("ObjectID = 1")[0];
                    lblState.Text = rowWareHouse[5].ToString();
                try
                {
                    // When searching and there are no record after LINQ exception is thrown 
                    dtStatesForObject = data.Select("ObjectId > 1").CopyToDataTable();
                }
                catch
                {
                    flowLayoutPanel1.Controls.Clear();
                    numChecked = 0;
                    return false;
                }

                EnumerableRowCollection<DataRow> searchRows = dtStatesForObject.AsEnumerable()
                .Where(r => r.Field<string>("NameObject").ToLower().Contains(searchValue) ||
                       r.Field<string>("NameContractor").ToLower().Contains(searchValue) ||
                       r.Field<string>("Adress").ToLower().Contains(searchValue));
                if(searchRows != null && searchRows.Count() > 0)
                {
                    dtStatesForObject = searchRows.CopyToDataTable();
                }
                else
                {
                    MessageBox.Show("There are no records with the given search criteria!");
                }
            }

            numChecked = 0;
            CheckNumberChecked();

            AutoCompleteStringCollection col = new AutoCompleteStringCollection();
            flowLayoutPanel1.Controls.Clear();
            for (int i = dtStatesForObject.Rows.Count -1; i >=0 ; i--)
            {
                AddPanel(dtStatesForObject.Rows[i]);
                for (int j = 1; j < 4; j++)
                {
                    col.Add(dtStatesForObject.Rows[i][j].ToString().Trim());
                }
            }

            tbSearch.AutoCompleteCustomSource = col;


            return true;

        }

        private void AddPanel(DataRow row)
        {
            ObjectLocation objLoc = new ObjectLocation(row,this);
            flowLayoutPanel1.Controls.Add(objLoc);
        }

        private void bntAddObject_Click(object sender, EventArgs e)
        {
            AddObject addObjectForm = new AddObject();
            DialogResult digRes = addObjectForm.ShowDialog();
            if (digRes == DialogResult.OK)
            {
                // Return rows affected 
                int nesto1 = objectTableAdapter1.Insert(addObjectForm.nameObject, addObjectForm.nameContractor, addObjectForm.adress,false);
                UpdateStatesForObject(archived);
            }
            addObjectForm.Close();
        }

        /// <summary>
        /// Inserts 2 new "States" rows for the Object changing and the WareHouse
        /// </summary>
        /// <param name="prevStates">The Last 2 States to be updated</param>
        /// <param name="valueMontage">The value of how much the states should change</param>
        /// <param name="ifMontage">Tells if the event is Montage(true) or Demontage(false)</param>
        public void AddStates(DataTable prevStates,int valueMontage,bool ifMontage)
        {
            // Initialize a new int matrix "states", put the values from the DataTable there
            int[][] states = new int[2][];
            for (int i = 0; i < states.Length; i++)
            {
                states[i] = new int[5];
                for (int j = 0; j < states[i].Length; j++)
                {
                    states[i][j] = Convert.ToInt32(prevStates.Rows[i][j].ToString());
                }
            }
            // Insert new states for the current object and the Warehouse

            if (ifMontage)
            {
                stateTableAdapter1.Insert(states[0][1] + valueMontage,states[0][2],states[0][3] + valueMontage,states[0][4],DateTime.Now);
                stateTableAdapter1.Insert(valueMontage, 0,states[1][3] - valueMontage,states[1][4],DateTime.Now);
            }
            else
            {
                stateTableAdapter1.Insert(states[0][1] ,states[0][2] + valueMontage,states[0][3] - valueMontage,states[0][4],DateTime.Now);
                stateTableAdapter1.Insert(0, valueMontage, states[1][3]+ valueMontage,states[1][4],DateTime.Now);
            }

            //momentStateID = Convert.ToInt32(rowWareHouse[6].ToString());
            //Refresh the Objects in the flowLayoutPanel
            UpdateStatesForObject(archived);
            // Update State label for the WareHouse
            lblState.Text = rowWareHouse[5].ToString();

        }

        #region Methods for the checked Objects
        public void IncreaseNumberChecked()
        {
            numChecked++;
            CheckNumberChecked();
        }

        private void CheckNumberChecked()
        {
            if (numChecked > 0)
            {
                this.gbManipulate.Visible = true;
            }
            else
            {
                this.gbManipulate.Visible = false;
            }
        }

        public void DecreaseNumberChecked()
        {
            numChecked--;
            CheckNumberChecked();
        }
        #endregion

        #region Hand Cursor over lblState for the Warehouse

        private void lblState_MouseHover(object sender, EventArgs e)
        {
            Cursor = Cursors.Hand;
        }

        private void lblState_MouseLeave(object sender, EventArgs e)
        {
            Cursor = Cursors.Arrow;
        }

        #endregion

        private void lblState_Click(object sender, EventArgs e)
        {
            AddState addStateForm = new AddState(true, false, "Warehouse", "Karavas", "Jurumleri ###", 1, (int)rowWareHouse[5]);

            try {
                addStateForm.Show();
                    }
            catch
            {
                MessageBox.Show("This Object doesn't have any elements in it!");
            }
            
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            GenerateReport reportForm = new GenerateReport();
            reportForm.Show();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Are you sure you want to delete the object/s?" + Environment.NewLine + "Please be carefull!! No going back!!","Approve Delete",MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string objects = GetSelectedString();

                SQLControl.ExecuteQuery(SQLControl.deleteObjectWithStates(objects));

                UpdateStatesForObject(archived);
                CheckNumberChecked();
            }

        }

        private string GetSelectedString()
        {
            string objects = string.Empty;

            foreach (ObjectLocation obj in flowLayoutPanel1.Controls)
            {
                if (obj.check)
                {
                    objects += "," + obj.ID.ToString();
                }
            }

            objects = objects.Substring(1);
            return objects;
        }

        private void btnArhiva_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to archive the object/s?" , "Approve Archive", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string objects = GetSelectedString();
                SQLControl.ExecuteQuery(SQLControl.SwitchedClosedOnObjects(!archived, objects));

                UpdateStatesForObject(archived);

            }

        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            if (UpdateStatesForObject(!archived))
            {
                if (archived)
                {
                    btnArchive.Text = "Archived";
                    lblShowing.Text = "Active";
                    btnArhiva.Text = "Archive";
                }
                else
                {
                    btnArchive.Text = "Active";
                    lblShowing.Text = "Archived";
                    btnArhiva.Text = "Activate";

                }
                archived = !archived;
            }


        }

        private void tbSearch_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {

                string searchValue = tbSearch.Text;

                UpdateStatesForObject(false, searchValue);
                //if (searchValue.Length == 0)
                //{
                //    dtStatesForObject = allStatesForObjects;
                //}
                //else
                //{
                //    dtStatesForObject = allStatesForObjects.AsEnumerable()
                //    .Where(r => r.Field<String>("NameObject").Contains(searchValue) ||
                //     r.Field<String>("NameContractor").Contains(searchValue) ||
                //     r.Field<String>("Adress").Contains(searchValue)).CopyToDataTable();
                //}
                //flowLayoutPanel1.Controls.Clear();
                //for (int i = dtStatesForObject.Rows.Count - 1; i >= 0; i--)
                //{
                //    AddPanel(dtStatesForObject.Rows[i]);
                //}

                //var filtered = dtStatesForObject.AsEnumerable()
                //    .Where(r => r.Field<String>("ObjectName").Contains(searchValue) ||
                //     r.Field<String>("NameContractor").Contains(searchValue) ||
                //     r.Field<String>("Adress").Contains(searchValue)).to;


            }
        }


    }
}
