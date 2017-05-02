using CustomTariff.Controllers;
using System;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;

namespace CustomTariff.WinApp
{
    public partial class downloadForm : Form
    {
        public string DestinationFileName { get; set; }
        public string DownloadType { get; set; }

        private int totalRecord = 0;
        private ExcellController _controller;
        private DIYBackgroundWorker _backgroundWorker;
        private BindingSource _bsSource;

        public downloadForm()
        {
            InitializeComponent();
            _backgroundWorker = new DIYBackgroundWorker();
            _backgroundWorker.DoWork += backgroundWorker1_DoWork;
            _backgroundWorker.ProgressChanged += backgroundWorker1_ProgressChanged;
            _backgroundWorker.RunWorkerCompleted += backgroundWorker1_RunWorkerCompleted;
            _backgroundWorker.WorkerReportsProgress = true;
        }

        private void downloadForm_Load(object sender, EventArgs e)
        {
            _bsSource = mainForm.CustomBindingSource;
            totalRecord = _bsSource.Count;
            label1.Text = DestinationFileName;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var cultureInfo = new System.Globalization.CultureInfo("en-US");
                _controller = new ExcellController();
                _controller.CreateWorkSheet("Sheet1");
                _controller.CreateHeader("COMPANY", "DIVISION", "SECTION", "FORMALITY",
                    "TYPE OF PRODUCT", "PART NAME", "SPEC", "FULL PART NAME",
                    "MADE BY", "UNIT", "TRANSLATION", "TARIFF NO.", "TARIFF CODE",
                    "UNIT2", "DUTY RATE", "NEED LICENSE", "MINISTRY", "CLASS",
                    "CUSTOMS FUNCTION", "USED FOR MACHINE", "CORP PLANNING REMARK",
                    "T1FIL1", "T1FIL2", "T1FIL3", "T1FIL4", "T1FIL5", "T1FIL6",
                    "T1RMK1", "T1RMK2", "MAINT.DATE", "OPERATOR", "PROGRAM");

                for (int i = 0; i < totalRecord; i++)
                {
                    var drv = (DataRowView)_bsSource[i];

                    _controller.AddRow(
                        drv["CompanyCode"],
                        drv["DivisionCode"],
                        drv["Section"],
                        drv["Formality"],
                        drv["TypeOfProduct"],
                        drv["PartName"],
                        drv["SPEC"],
                        drv["FullPartName"],
                        drv["MadeBy"],
                        drv["Unit"],
                        drv["PdtDescriptionTH"],
                        drv["NewTariffCode"],
                        drv["NewStatCode"],
                        drv["NewTariffUnit"],
                        drv["NewDutyRate"],
                        drv["NeedLicense"],
                        drv["Ministry"],
                        drv["PdtClass"],
                        drv["CustomsFunc"],
                        drv["UsedForMachine"],
                        drv["CropPlanningRemark"],
                        drv["Filter1"],
                        drv["Filter2"],
                        drv["Filter3"],
                        drv["Filter4"],
                        drv["Filter5"],
                        drv["Filter6"],
                        drv["Remark1"],
                        drv["Remark2"],
                        DateTime.Now.ToString("yyyyMMdd", cultureInfo),
                        drv["OPRCode"],
                        drv["PRGCode"]);

                    _backgroundWorker.ReportProgress(CalcProgress(i, totalRecord));

                    lblRecordText.Invoke(new Action(() => { lblRecordText.Text = i.ToString(); }));
                }

                btnDownload.Invoke(new Action(() =>
                {
                    btnDownload.Text = "Exporting...";
                }));
                _controller.Save(DestinationFileName);

                e.Result = 100;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int CalcProgress(int a, int b)
        {
            return Convert.ToInt32((a * 100) / b);
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = 0;
            btnDownload.Text = "Completed";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(DestinationFileName))
            {
                MessageBox.Show("Find not found output location.!!!");
                return;
            }

            _backgroundWorker.RunWorkerAsync();
            btnDownload.Text = "Download";
        }
    }
}