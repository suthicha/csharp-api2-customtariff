﻿using CustomTariff.Models;
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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openFileDialog1.FileName = "";

            var dlg = openFileDialog1.ShowDialog();

            if (dlg == DialogResult.OK)
            {
                textBox1.Text = openFileDialog1.FileName;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            var paramObj = e.Argument as object[];

            try
            {
                var excelController = new ExcelController();

                if (Convert.ToInt32(paramObj[0]) == 0)
                {
                    var dt = excelController.ReadSheets(paramObj[1].ToString());
                    var tariffs = excelController.ConvertToObjTariff(dt);

                    e.Result = new object[] { 0, tariffs };
                }
                else
                {
                    var tariffController = new TariffController();
                    tariffController.ExecImportTariff((List<TariffModel>)paramObj[1]);
                    e.Result = new object[] { 1, true };
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            var resObj = e.Result as object[];
            if (Convert.ToInt32(resObj[0]) == 0)
            {
                dgv1.DataSource = resObj[1];
                MessageBox.Show("OK ==> " + dgv1.RowCount.ToString());
            }
            else
            {
                MessageBox.Show("Execute Successfully");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "") return;

            backgroundWorker1.RunWorkerAsync(new object[] { 0, textBox1.Text });
        }

        private void button3_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(new object[] { 1, (List<TariffModel>)dgv1.DataSource });
        }
    }
}