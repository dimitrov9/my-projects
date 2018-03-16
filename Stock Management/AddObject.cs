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
    public partial class AddObject : Form
    {
        public string nameObject { get; set; }
        public string nameContractor { get; set; }
        public string adress { get; set; }

        private bool validatedNameObject;
        private bool validatedNameContractor;
        private bool validatedAdress;


        public AddObject()
        {
            InitializeComponent();
            validatedNameObject = false;
            validatedNameContractor = false;
            validatedAdress = false;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            bool validated = validatedNameObject && validatedNameContractor && validatedAdress;
            if (validated)
            {
                nameObject = txtNameObject.Text;
                nameContractor = txtNameContractor.Text;
                adress = txtAdress.Text;
                this.DialogResult = DialogResult.OK;
            }
            else
            {
                MessageBox.Show("Имате грешка при внесување на податоците!");
            }

        }

        private void txtNameObject_Validating(object sender, CancelEventArgs e)
        {
            validatedNameObject = ValidateTextBoxes(txtNameObject, "Објектот");
        }

        private void txtNameContractor_Validating(object sender, CancelEventArgs e)
        {
            validatedNameContractor = ValidateTextBoxes(txtNameContractor,"Изведувачот");
        }

        private void txtAdress_Validating(object sender, CancelEventArgs e)
        {
            validatedAdress = ValidateTextBoxes(txtAdress, "Адресата");
        }

        /// <summary>
        /// Provides an error if the inputed text is not in (1,64) interval
        /// </summary>
        /// <param name="tb">The validating text box</param>
        /// <param name="str">The string reference in the error provider</param>
        private bool ValidateTextBoxes(TextBox tb,string str)
        {
            if (tb.Text.Trim().Length < 1)
            {
                errorProvider1.SetError(tb, String.Join(String.Empty, "Ве молиме внесете име на ", str,"!"));
                return false;
            }
            else if (tb.Text.Trim().Length > 63)
            { 
                errorProvider1.SetError(tb, String.Join(String.Empty, "Дозволени се 63 карактери за име на ", str, "!"));
                return false;
            }
            else
            {
                errorProvider1.SetError(tb, null);
                return true;
            }
        }

    }
}
