using CustomTariff.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomTariff.WinAppTest
{
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                string dataPath = @"C:\Users\Administrator\Desktop\Tariff2017\TARIFF_NATTAKARN.xlsx";

                var controller = new ExcelController();
                e.Result = controller.Read(dataPath);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            dataGridView1.DataSource = e.Result;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var controller = new ExcelController();
            var m = controller.ConvertToObjProductN((DataTable)dataGridView1.DataSource);

            dataGridView1.DataSource = m;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var controller = new TariffController();
            var productNs = (List<ProductNModel>)dataGridView1.DataSource;
            controller.ExecImportProductN(productNs);

            MessageBox.Show("OK");
        }
    }
}