using System;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CustomTariff.WinApp
{
    public partial class mainForm : Form
    {
        private int intOriginalExStyle = -1;
        private bool bEnableAntiFlicker = true;
        private DataSet dsResult;
        private BindingSource bs;

        public mainForm()
        {
            ToggleAntiFlicker(false);
            InitializeComponent();

            Helper.DoubleBuffered(this.dataGridView1, true);
            this.ResizeBegin += Form1_ResizeBegin;
            this.ResizeEnd += Form1_ResizeEnd;
            this.toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
            bs = new BindingSource();
            bs.ListChanged += Bs_ListChanged;

            this.dataGridView1.SelectionChanged += DataGridView1_SelectionChanged;
            this.dataGridView1.CellMouseClick += DataGridView1_CellMouseClick;
            this.__initDataGridViewColumns(dataGridView1);
            lblStatus.Text = "Ready";
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (dataGridView1[e.ColumnIndex, e.RowIndex].GetContentBounds(e.RowIndex).Contains(e.Location))
                {
                }
            }
        }

        private void DataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.RowCount == 0) return;
            var drv = dataGridView1.CurrentRow.DataBoundItem;
            BoundItemBinding(drv);
        }

        private void BoundItemBinding(Object obj)
        {
            try
            {
                var drv = obj as DataRowView;
                lblCompanyCode.Text = drv["CompanyCode"].ToString();
                lblDivisionCode.Text = drv["DivisionCode"].ToString();
                lblFullPartName.Text = drv["FullPartName"].ToString();
                lblTariffCode.Text = drv["TariffCode"].ToString();
                lblStatCode.Text = drv["StatCode"].ToString();
                lblTariffUnit.Text = drv["TariffUnit"].ToString();
                lblDutyRate.Text = Convert.ToDecimal(drv["DutyRate"]).ToString("#,##0");
                txtNewTariffCode.Text = drv["NewTariffCode"].ToString();
                txtNewStatCode.Text = drv["NewStatCode"].ToString();
                txtNewTariffUnit.Text = drv["NewTariffUnit"].ToString();
                txtNewDutyRate.Text = Convert.ToDecimal(drv["NewDutyRate"]).ToString("#,##0");
            }
            catch { }
        }

        private void ResetBoundItem()
        {
            lblCompanyCode.Text = "";
            lblDivisionCode.Text = "";
            lblFullPartName.Text = "";
            lblTariffCode.Text = "";
            lblStatCode.Text = "";
            lblTariffUnit.Text = "";
            lblDutyRate.Text = "";
            txtNewTariffCode.Text = "";
            txtNewStatCode.Text = "";
            txtNewTariffUnit.Text = "";
            txtNewDutyRate.Text = "";
        }

        private void Bs_ListChanged(object sender, ListChangedEventArgs e)
        {
            lblStatus.Text = "Done";
            lblTotalRecords.Text = string.Format("{0} Rec.", Convert.ToDecimal(bs.Count).ToString("#,##0"));
        }

        protected override CreateParams CreateParams
        {
            get
            {
                if (intOriginalExStyle == -1)
                {
                    intOriginalExStyle = base.CreateParams.ExStyle;
                }
                CreateParams cp = base.CreateParams;

                if (bEnableAntiFlicker)
                {
                    cp.ExStyle |= 0x02000000; //WS_EX_COMPOSITED
                }
                else
                {
                    cp.ExStyle = intOriginalExStyle;
                }

                return cp;
            }
        }

        private void Form1_ResizeEnd(object sender, EventArgs e)
        {
            ToggleAntiFlicker(false);
        }

        private void Form1_ResizeBegin(object sender, EventArgs e)
        {
            ToggleAntiFlicker(true);
        }

        private void ToggleAntiFlicker(bool Enable)
        {
            bEnableAntiFlicker = Enable;
            //hacky, but works
            this.MaximizeBox = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // backgroundWorker1.RunWorkerAsync();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                using (SqlConnection conn = new SqlConnection(@"data source=.\SQLExpress;uid=sa;password=cti2016;database=EDITARIFF"))
                {
                    conn.Open();
                    var cmd = conn.CreateCommand();
                    cmd.CommandText = @"select * from ProductTariffs Order by TrxId asc";

                    var da = new SqlDataAdapter(cmd);
                    da.Fill(ds);
                }

                e.Result = ds;
            }
            catch { }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.toolStripProgressBar1.Style = ProgressBarStyle.Blocks;

            try
            {
                dsResult = (DataSet)e.Result;
                bs.DataSource = dsResult.Tables[0];
                dataGridView1.DataSource = bs;
                this.btnLoadCustomsTariff.Click += btnLoadCustomsTariff_Click;
                ResetBoundItem();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ConditionFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ConditionFilter(cboTariffStatus.Text,
                    txtCompanyCode.Text,
                    txtDivisionCode.Text,
                    txtTariffCode.Text,
                    txtDescription.Text);
            }
        }

        private void __initDataGridViewColumns(DataGridView dgv)
        {
            dgv.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
            dgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersHeight = 28;
            dgv.ColumnHeadersDefaultCellStyle.Font = new Font("Tahoma", 8.25f, FontStyle.Regular);
            dgv.AutoGenerateColumns = false;
            dgv.MultiSelect = false;
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgv.RowTemplate.Height = 24;
            dgv.RowTemplate.MinimumHeight = 22;
            dgv.RowHeadersVisible = false;
            dgv.AllowUserToResizeRows = false;

            DataGridViewCheckBoxColumn chkCol = new DataGridViewCheckBoxColumn();
            chkCol.Name = "X";
            chkCol.HeaderText = "";
            chkCol.Width = 50;
            chkCol.ReadOnly = false;
            chkCol.FillWeight = 10;
            chkCol.Resizable = DataGridViewTriState.False;

            CheckBox checkboxHeader = new CheckBox();
            checkboxHeader.Name = "checkboxHeader";
            checkboxHeader.Size = new Size(18, 18);
            checkboxHeader.Location = new Point(20, 5);
            checkboxHeader.BackColor = Color.Transparent;
            checkboxHeader.CheckedChanged += CheckboxHeader_CheckedChanged;
            dgv.Columns.Add(chkCol);
            dgv.Controls.Add(checkboxHeader);

            dgv.Columns.Add(__newDgvColumn("comcd", "CompanyCode", 60, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(__newDgvColumn("divcd", "DivisionCode", 60, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(__newDgvColumn("FullPartName", "FullPartName", 250));
            dgv.Columns.Add(__newDgvColumn("TariffCode(old)", "TariffCode", 100, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(__newDgvColumn("StatCode(old)", "StatCode", 90, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(__newDgvColumn("TariffUnit(old)", "TariffUnit", 100, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(__newDgvColumn("DutyRate(old)", "DutyRate", 90, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(__newDgvColumn("TariffCode(New)", "NewTariffCode", 105, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(__newDgvColumn("StatCode(new)", "NewStatCode", 95, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(__newDgvColumn("TariffUnit(new)", "NewTariffUnit", 105, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(__newDgvColumn("DutyRate(new)", "NewDutyRate", 90, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(__newDgvColumn("Description(TH)", "PdtDescriptionTH", 250));
            dgv.Columns.Add(__newDgvColumn("Description(AddOn)", "PdtDescriptionAddon", 250));

            dgv.Columns.Add(__newDgvColumn("TariffCode(status)", "StatusTariffCode", 120, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(__newDgvColumn("StatCode(status)", "StatusStatCode", 120, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(__newDgvColumn("TariffUnit(status)", "StatusTariffUnit", 120, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(__newDgvColumn("DutyRate(status)", "StatusDutyRate", 120, DataGridViewContentAlignment.MiddleCenter));

            dgv.Columns["__col__PdtDescriptionTH"].DefaultCellStyle.Font = new Font("Tahoma", 9.75f);
            dgv.Columns["__col__PdtDescriptionAddon"].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 240);
            dgv.Columns["__col__NewTariffCode"].DefaultCellStyle.BackColor = Color.FromArgb(255, 231, 231);
            dgv.Columns["__col__NewStatCode"].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 240);
            dgv.Columns["__col__NewTariffUnit"].DefaultCellStyle.BackColor = Color.FromArgb(255, 231, 231);
            dgv.Columns["__col__NewDutyRate"].DefaultCellStyle.BackColor = Color.FromArgb(255, 255, 240);

            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                dgv.Columns[i].HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
            }
        }

        private void CheckboxHeader_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var m = dataGridView1.Rows[i];
                m.Cells[0].Value = ((CheckBox)dataGridView1.Controls.Find("checkboxHeader", true)[0]).Checked;
                dataGridView1.CurrentCell = dataGridView1[1, 1];
            }

            if (dataGridView1.RowCount > 0)
                dataGridView1.CurrentCell = dataGridView1[1, 0];
        }

        private DataGridViewTextBoxColumn __newDgvColumn(string title, string propertyName, int width, DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleLeft)
        {
            var col = new DataGridViewTextBoxColumn
            {
                DataPropertyName = propertyName,
                HeaderText = title.ToUpper(),
                Name = "__col__" + propertyName,
                ReadOnly = true,
                Width = width
            };

            col.DefaultCellStyle.Alignment = alignment;
            return col;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ConditionFilter(cboTariffStatus.Text,
                    txtCompanyCode.Text,
                    txtDivisionCode.Text,
                    txtTariffCode.Text,
                    txtDescription.Text);
        }

        private void ConditionFilter(string tariffStatus, string companyCode, string divisionCode, string tariffCode, string description)
        {
            if (cboTariffStatus.Text == "")
            {
                MessageBox.Show("Please select status.!!!");
                return;
            }

            string commandFilter = string.Empty;
            string splitCmd = string.Empty;

            try
            {
                if (!tariffStatus.Contains("ALL"))
                    commandFilter = string.Format("StatusTariffCode = '{0}' AND ", tariffStatus);

                if (!string.IsNullOrEmpty(companyCode))
                    commandFilter += string.Format("CompanyCode = '{0}' AND ", RegText(companyCode));

                if (!string.IsNullOrEmpty(divisionCode))
                    commandFilter += string.Format("DivisionCode = '{0}' AND ", RegText(divisionCode));

                if (tariffCode != "")
                {
                    splitCmd = commandFilter.Substring(commandFilter.Length - 5, 4);
                    commandFilter += string.Format("{0}NewTariffCode LIKE '{1}%' AND ", splitCmd.Contains("AND") ? "" : "AND ", RegText(tariffCode));
                }

                if (description != "")
                {
                    // splitCmd = commandFilter.Substring(commandFilter.Length - 5, 4);
                    commandFilter += string.Format("FullPartName LIKE '%{0}%'", RegText(description));
                }

                if (commandFilter != "")
                {
                    splitCmd = commandFilter.Substring(commandFilter.Length - 5, 4);

                    if (splitCmd.Contains("AND"))
                        commandFilter = commandFilter.Substring(0, commandFilter.Length - splitCmd.Length);
                }

                lblCommandText.Text = commandFilter.ToUpper();
                bs.Filter = commandFilter;
                ResetBoundItem();

                if (bs.Count > 0)
                    dataGridView1.CurrentCell = dataGridView1[0, 1];
            }
            catch (Exception ex)
            {
                MessageBox.Show("Found Error : " + ex.Message);
            }
        }

        private string RegText(string content)
        {
            return content.Replace("'", "''");
        }

        private void btnLoadCustomsTariff_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;
            backgroundWorker1.RunWorkerAsync();
            this.bs.DataSource = null;
            this.toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            this.lblStatus.Text = "Loading...";
            this.btnLoadCustomsTariff.Click -= btnLoadCustomsTariff_Click;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
        }
    }
}