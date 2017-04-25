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
    public partial class Form5 : Form
    {
        private ExcelController controller = new ExcelController();

        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var data = controller.Read(@"C:\Users\Administrator\Desktop\Tariff2017\TARIFF_NATTAKARN_UPDATE2.xlsx");

            dataGridView1.DataSource = data;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            var products = controller.ConvertToObjProductN2((DataTable)dataGridView1.DataSource);

            dataGridView1.DataSource = products;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            var tariffCtrl = new TariffController();
            tariffCtrl.ExecImportProductN((List<ProductNModel>)dataGridView1.DataSource);

            MessageBox.Show("OK");
        }
    }
}