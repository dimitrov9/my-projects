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
    public partial class GenerateReport : Form
    {
        public GenerateReport()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //using (KaravasStockManagementDataSet db = new KaravasStockManagementDataSet())
            //{
            //    GetReportBindingSource.DataSource = this.GetReportTableAdapter.GetData(dateFrom.Value, dateTo.Value);
            //    Microsoft.Reporting.WinForms.ReportParameter[] rParams = new Microsoft.Reporting.WinForms.ReportParameter[]
            //    {
            //        new Microsoft.Reporting.WinForms.ReportParameter("fromDate",String.Format("{0:yyyy-MM-dd}", dateFrom.Value)),
            //        new Microsoft.Reporting.WinForms.ReportParameter("toDate",String.Format("{0:yyyy-MM-dd}", dateTo.Value))
            //    };
            //    reportViewer1.LocalReport.SetParameters(rParams);
            //    reportViewer1.RefreshReport();
            //}
            this.GetReportTableAdapter.Fill(this.KaravasStockManagementDataSet.GetReport, dateFrom.Value, dateTo.Value);
            this.reportViewer1.RefreshReport();
            //string from = String.Format("{0:yyyy-MM-dd}", dateFrom.Value);
            //string to = String.Format("{0:yyyy-MM-dd}", dateTo.Value.AddDays(1));

            //SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            //saveFileDialog1.Filter = "csv files (*.csv)|*.csv|All files (*.*)|*.*";
            ////saveFileDialog1.FilterIndex = 2;
            //saveFileDialog1.RestoreDirectory = true;

            //if(saveFileDialog1.ShowDialog()== DialogResult.OK)
            //{
            //    SQLControl.GenerateReport(from, to, saveFileDialog1.FileName);
            //}

            //SQLControl.GenerateReport(from, to);
            // this.DialogResult = DialogResult.OK;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
        }

        private void btnLastMonth_Click(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            dateFrom.Value = now.AddMonths(-1);
            dateFrom.Value=dateFrom.Value.AddDays(-dateFrom.Value.Day);
            dateTo.Value = new DateTime(now.Year, now.Month, 1);
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            DateTime now = DateTime.Now;
            dateTo.Value = now;
            dateFrom.Value = now.AddDays((double)-numericUpDown1.Value);
        }

        private void GenerateReport_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'KaravasStockManagementDataSet.GetReport' table. You can move, or remove it, as needed.
            this.GetReportTableAdapter.Fill(this.KaravasStockManagementDataSet.GetReport, dateFrom.Value, dateTo.Value);

            this.reportViewer1.RefreshReport();
        }
    }
}
