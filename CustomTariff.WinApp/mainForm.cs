using CustomTariff.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace CustomTariff.WinApp
{
    public partial class mainForm : Form
    {
        private int intOriginalExStyle = -1;
        private bool bEnableAntiFlicker = true;
        private DataSet _dsResult;
        private static BindingSource _bsCustom;
        private TariffController _controller;
        private List<Object> _checkedItems;

        internal static BindingSource CustomBindingSource
        {
            get
            {
                return _bsCustom;
            }
        }

        public mainForm()
        {
            ToggleAntiFlicker(false);
            InitializeComponent();

            btnLoadCustomsTariff.Cursor = Cursors.Hand;
            btnExportForCustomer.Cursor = Cursors.Hand;
            btnExportForSystem.Cursor = Cursors.Hand;
            btnCancel.Cursor = Cursors.Hand;
            btnUpdate.Cursor = Cursors.Hand;
            btnSearch.Cursor = Cursors.Hand;

            _controller = new TariffController(ConfigurationManager.AppSettings["DbConnection"]);
            _checkedItems = new List<Object>();

            Helper.DoubleBuffered(this.dataGridView1, true);
            this.ResizeBegin += Form1_ResizeBegin;
            this.ResizeEnd += Form1_ResizeEnd;
            this.toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
            _bsCustom = new BindingSource();
            _bsCustom.ListChanged += HandlerBindingSourceListChanged;

            this.dataGridView1.CellMouseClick += HandlerDataGridViewCellMouseClick;
            this.dataGridView1.CellDoubleClick += HandlerDataGridViewCellDoubleClick;
            this.dataGridView1.CellContentClick += HandlerDataGridViewCellContentClick;
            this.initDataGridViewColumns(dataGridView1);
            lblStatus.Text = "Ready";
        }

        private void HandlerDataGridViewCellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (panel1.Tag == null) return;

            if (e.ColumnIndex == 0 && e.RowIndex >= 0)
            {
                DataGridViewCheckBoxCell ch1 = new DataGridViewCheckBoxCell();
                ch1 = (DataGridViewCheckBoxCell)dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0];

                if (ch1.Value == null)
                    ch1.Value = false;
                switch (ch1.Value.ToString())
                {
                    case "True":
                        ch1.Value = false;
                        break;

                    case "False":
                        ch1.Value = true;
                        break;
                }

                if ((Boolean)ch1.Value == false)
                {
                    var drv = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                    var items = _checkedItems;

                    bool seekItem = false;

                    _checkedItems.ForEach(q =>
                    {
                        var obj = q as List<object>;
                        if (Convert.ToInt32(obj[20]) == Convert.ToInt32(drv["TrxId"]))
                        {
                            seekItem = true;
                        }
                    });

                    if (seekItem)
                    {
                        var seekRow = _checkedItems.Find(q => Convert.ToInt32(((List<Object>)q)[20]) == Convert.ToInt32(drv["TrxId"]));
                        _checkedItems.Remove(seekRow);
                    }
                }
                else
                {
                    var newRow = Helper.ConvertToDataGridViewCell(dataGridView1.CurrentRow);
                    _checkedItems.Add(newRow);
                }
            }
        }

        private void HandlerDataGridViewCellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 1 && e.ColumnIndex <= 8 && e.RowIndex >= 0)
            {
                if (!splitContainer1.Panel2Collapsed)
                    VisiblePanelDetail();

                var itemDataRow = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                var itemForm = new tariffForm();
                itemForm.ItemDataRow = itemDataRow;

                if (itemForm.ShowDialog() == DialogResult.OK)
                {
                    var drv = itemForm.ItemDataRow;

                    var cells = dataGridView1.CurrentRow.Cells;
                    cells["__col__NewTariffCode"].Value = drv["NewTariffCode"];
                    cells["__col__NewStatCode"].Value = drv["NewStatCode"];
                    cells["__col__NewTariffUnit"].Value = drv["NewTariffUnit"];
                    cells["__col__NewDutyRate"].Value = Convert.ToDecimal(drv["NewDutyRate"]);
                    cells["__col__PdtDescriptionAddon"].Value = drv["PdtDescriptionAddon"];
                    cells["__col__Remark"].Value = drv["Remark"];

                    cells["__col__StatusTariffCode"].Value =
                        drv["NewTariffCode"].ToString().Equals(cells["__col__TariffCode"].Value) ? "NOT CHANGE" : "CHANGE";

                    cells["__col__StatusStatCode"].Value =
                        drv["NewStatCode"].ToString().Equals(cells["__col__StatCode"].Value) ? "NOT CHANGE" : "CHANGE";

                    cells["__col__StatusTariffUnit"].Value =
                        drv["NewTariffUnit"].ToString().Equals(cells["__col__TariffUnit"].Value) ? "NOT CHANGE" : "CHANGE";

                    cells["__col__StatusDutyRate"].Value =
                        Convert.ToDouble(drv["NewDutyRate"]).Equals(Convert.ToDouble(cells["__col__DutyRate"].Value)) ?
                        "NOT CHANGE" : "CHANGE";

                    var obj = Helper.ConvertToDataGridViewCell(dataGridView1.CurrentRow);
                    _controller.UpdateFields(obj);

                    dataGridView1.CurrentCell = dataGridView1[0, e.RowIndex];
                }
                VisiblePanelDetail();
            }
        }

        private void HandlerDataGridViewCellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (panel1.Tag != null) return;

            if (e.ColumnIndex >= 9 && e.ColumnIndex <= 12 && e.RowIndex >= 0)
            {
                dataGridView1.Columns["__col__checkbox"].ReadOnly = false;
                var drv = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                var objCells = Helper.ConvertToDataGridViewCell(dataGridView1.CurrentRow);

                if (chkAutoFilterOnSelected.Checked)
                {
                    setBoundItemBinding(drv);
                    panel1.Tag = objCells;

                    var commandFilter = _bsCustom.Filter;
                    btnCancel.Tag = commandFilter;

                    if (string.IsNullOrEmpty(commandFilter))
                    {
                        commandFilter = string.Format("CompanyCode='{0}' AND DivisionCode='{1}' AND NewTariffCode = '{2}'",
                                          drv["CompanyCode"],
                                          drv["DivisionCode"],
                                          drv["NewTariffCode"]);
                    }
                    else
                        commandFilter += string.Format("AND NewTariffCode = '{0}'", drv["NewTariffCode"]);

                    _bsCustom.Filter = commandFilter;
                    lblCommandText.Text = commandFilter.ToUpper();
                }
            }
        }

        private void setBoundItemBinding(Object obj)
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
                txtDescriptionAddon.Text = drv["PdtDescriptionAddon"].ToString();
                txtRemark.Text = drv["Remark"].ToString();
            }
            catch { }
        }

        private void resetCommandFilter()
        {
            if (btnCancel.Tag != null)
            {
                _bsCustom.Filter = btnCancel.Tag.ToString();
                lblCommandText.Text = _bsCustom.Filter;
            }

            panel1.Tag = null;
        }

        private void resetBoundItems()
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
            txtDescriptionAddon.Text = "";
            txtRemark.Text = "";

            clearCheckBoxSelected();

            if (btnCancel.Tag == null) panel1.Tag = null;
        }

        private void clearCheckBoxSelected()
        {
            for (int i = 0; i < _checkedItems.Count; i++)
            {
                var items = _checkedItems[i] as List<object>;
                var row = findDataGridViewRow(Convert.ToInt32(items[20]));
                row.Cells[0].Value = false;
            }
            _checkedItems.Clear();
        }

        private void HandlerBindingSourceListChanged(object sender, ListChangedEventArgs e)
        {
            lblStatus.Text = "Done";
            lblTotalRecords.Text = string.Format("{0}", Convert.ToDecimal(_bsCustom.Count).ToString("#,##0"));

            if (panel1.Tag != null)
            {
                var obj = panel1.Tag as List<object>;
                var row = findDataGridViewRow(Convert.ToInt32(obj[20]));
                dataGridView1.CurrentCell = dataGridView1[0, row.Index];

                setSelectRowStyle(row.Index, true);
            }
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
            this.MaximizeBox = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // backgroundWorker1.RunWorkerAsync();
        }

        private void SumAcceptTotalView()
        {
            _bsCustom.EndEdit();
            var acceptTotal = _dsResult.Tables[0].Select("UpdateStatus='A'").Count();
            var remainTotal = _dsResult.Tables[0].Rows.Count - acceptTotal;
            lblAcceptOrder.Text = Convert.ToDecimal(acceptTotal).ToString("N0");
            lblRemainOrder.Text = Convert.ToDecimal(remainTotal).ToString("N0");
        }

        private async void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                e.Result = await _controller.GetAll();
            }
            catch { }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            this.toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
            _bsCustom.Filter = string.Empty;
            lblCommandText.Text = string.Empty;

            try
            {
                _dsResult = (DataSet)e.Result;
                _bsCustom.DataSource = _dsResult.Tables[0];
                dataGridView1.DataSource = _bsCustom;

                resetBoundItems();
                SumAcceptTotalView();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            this.btnLoadCustomsTariff.Click += btnLoadCustomsTariff_Click;
        }

        private void ConditionFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                resetBoundItems();
                resetCommandFilter();

                ConditionFilter(cboTariffStatus.Text,
                    txtCompanyCode.Text,
                    txtDivisionCode.Text,
                    txtTariffCodeOld.Text,
                    txtTariffCodeNew.Text,
                    txtDescription.Text);

                var chk = ((CheckBox)dataGridView1.Controls.Find("checkboxHeader", true)[0]);
                chk.Checked = false;
            }
        }

        private void initDataGridViewColumns(DataGridView dgv)
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
            chkCol.Name = "__col__checkbox";
            chkCol.HeaderText = "";
            chkCol.DataPropertyName = "CheckState";
            chkCol.Width = 50;
            chkCol.ReadOnly = true;
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

            dgv.Columns.Add(createDataGridViewTextBoxColumn("STA", "UpdateStatus", 40, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("comcd", "CompanyCode", 60, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("divcd", "DivisionCode", 60, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("FullPartName", "FullPartName", 250));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("TariffCode(old)", "TariffCode", 100, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("StatCode(old)", "StatCode", 90, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("TariffUnit(old)", "TariffUnit", 100, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("DutyRate(old)", "DutyRate", 90, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("TariffCode(New)", "NewTariffCode", 105, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("StatCode(new)", "NewStatCode", 95, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("TariffUnit(new)", "NewTariffUnit", 105, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("DutyRate(new)", "NewDutyRate", 90, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("Description(TH)", "PdtDescriptionTH", 600));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("Description(AddOn)", "PdtDescriptionAddon", 250));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("Remark", "Remark", 250));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("TariffCode(status)", "StatusTariffCode", 120, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("StatCode(status)", "StatusStatCode", 120, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("TariffUnit(status)", "StatusTariffUnit", 120, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(createDataGridViewTextBoxColumn("DutyRate(status)", "StatusDutyRate", 120, DataGridViewContentAlignment.MiddleCenter));

            dgv.Columns["__col__PdtDescriptionTH"].DefaultCellStyle.Font = new Font("Tahoma", 9.75f);
            dgv.Columns["__col__PdtDescriptionAddon"].DefaultCellStyle.Font = new Font("Tahoma", 9.75f);
            dgv.Columns["__col__Remark"].DefaultCellStyle.Font = new Font("Tahoma", 9.75f);

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
            handlerCheckStateChanged();
        }

        private void handlerCheckStateChanged()
        {
            if (panel1.Tag == null) return;

            if (dataGridView1.RowCount >= 5000)
            {
                var dlg = MessageBox.Show("Are you select more than 5,000 items?",
                    "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlg == DialogResult.No)
                {
                    return;
                }
            }

            var checkState = ((CheckBox)dataGridView1.Controls.Find("checkboxHeader", true)[0]).Checked;

            _checkedItems.Clear();
            setCheckBoxOnItemsBinding(checkState);
        }

        private void setCheckBoxOnItemsBinding(Boolean checkState)
        {
            var cells = panel1.Tag as List<Object>;
            var newTariffCode = cells.ElementAt(9).ToString();

            if (checkState)
            {
                var rowFilter = dataGridView1.Rows.OfType<DataGridViewRow>().Where(
                q => q.Cells["__col__NewTariffCode"].Value.ToString() == newTariffCode);

                if (rowFilter == null || rowFilter.Count() == 0)
                    return;

                for (int i = 0; i < rowFilter.Count(); i++)
                {
                    rowFilter.ElementAt(i).Cells[0].Value = checkState;

                    _checkedItems.Add(Helper.ConvertToDataGridViewCell(rowFilter.ElementAt(i)));
                }
            }
            else
            {
                for (int i = 0; i < dataGridView1.RowCount; i++)
                {
                    dataGridView1.Rows[i].Cells[0].Value = false;
                }
                _checkedItems.Clear();
            }

            if (dataGridView1.RowCount > 0)
                dataGridView1.CurrentCell = dataGridView1[1, 0];
        }

        private DataGridViewTextBoxColumn createDataGridViewTextBoxColumn(
            string title, string propertyName, int width,
            DataGridViewContentAlignment alignment = DataGridViewContentAlignment.MiddleLeft)
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
                    txtTariffCodeOld.Text,
                    txtTariffCodeNew.Text,
                    txtDescription.Text);

            resetBoundItems();
            panel1.Tag = null;
            setCheckBoxStatus(false);
        }

        private void setCheckBoxStatus(Boolean status)
        {
            var chk = ((CheckBox)dataGridView1.Controls.Find("checkboxHeader", true)[0]);
            chk.Checked = status;
        }

        private void ConditionFilter(string tariffStatus,
            string companyCode,
            string divisionCode,
            string oldTariffCode,
            string newTariffCode,
            string description)
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

                if (oldTariffCode != "")
                {
                    if (commandFilter.Length > 0)
                    {
                        splitCmd = commandFilter.Substring(commandFilter.Length - 5, 4);
                        commandFilter += string.Format("{0}TariffCode LIKE '{1}%' AND ", splitCmd.Contains("AND") ? "" : "AND ", RegText(oldTariffCode));
                    }
                    else
                    {
                        commandFilter = string.Format("TariffCode LIKE '{0}%' AND ", oldTariffCode);
                    }
                }

                if (newTariffCode != "")
                {
                    if (commandFilter.Length > 0)
                    {
                        splitCmd = commandFilter.Substring(commandFilter.Length - 5, 4);
                        commandFilter += string.Format("{0}NewTariffCode LIKE '{1}%' AND ", splitCmd.Contains("AND") ? "" : "AND ", RegText(newTariffCode));
                    }
                    else
                    {
                        commandFilter = string.Format("NewTariffCode LIKE '{0}%' AND ", newTariffCode);
                    }
                }

                if (description != "")
                {
                    if (description.Contains("*"))
                    {
                        description = description.Replace("*", "");
                        commandFilter += string.Format("FullPartName = '{0}'", RegText(description));
                    }
                    else
                        commandFilter += string.Format("FullPartName LIKE '%{0}%'", RegText(description));
                }

                if (commandFilter != "")
                {
                    splitCmd = commandFilter.Substring(commandFilter.Length - 5, 4);

                    if (splitCmd.Contains("AND"))
                        commandFilter = commandFilter.Substring(0, commandFilter.Length - splitCmd.Length);
                }

                lblCommandText.Text = commandFilter.ToUpper();

                _bsCustom.Filter = commandFilter;

                if (_bsCustom.Count > 0)
                    dataGridView1.CurrentCell = dataGridView1[0, 0];
            }
            catch
            {
            }
        }

        private string RegText(string content)
        {
            return content.Replace("'", "''");
        }

        private void btnLoadCustomsTariff_Click(object sender, EventArgs e)
        {
            if (backgroundWorker1.IsBusy) return;

            if (dataGridView1.RowCount > 0)
            {
                var dlg = MessageBox.Show("Do you want reload data?", "Warning",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlg == DialogResult.No) return;
            }

            backgroundWorker1.RunWorkerAsync();
            _bsCustom.DataSource = null;

            lblAcceptOrder.Text = "0";
            lblRemainOrder.Text = "0";

            this.lblStatus.Text = "Loading...";
            this.toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            this.btnLoadCustomsTariff.Click -= btnLoadCustomsTariff_Click;
        }

        private void UpdateDataSource(DataRowView obj)
        {
            DataTable table = (DataTable)_bsCustom.DataSource;

            var result = table.AsEnumerable().Where(q => q.Field<int>("TrxId") == (int)obj["TrxId"]);

            if (result == null || result.Count() == 0) return;
            var rows = result;

            if (rows.Count() > 0)
            {
                var dr = rows.ElementAt(0);
                dr.BeginEdit();
                dr["NewStatCode"] = obj["NewStatCode"];
                dr["NewTariffCode"] = obj["NewTariffCode"];
                dr["NewDutyRate"] = obj["NewDutyRate"];
                dr["PdtDescriptionAddon"] = obj["PdtDescriptionAddon"];
                dr["Remark"] = obj["Remark"];
                dr.EndEdit();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtNewTariffCode.Text) ||
                string.IsNullOrEmpty(txtNewStatCode.Text) ||
                string.IsNullOrEmpty(txtNewTariffUnit.Text))
            {
                MessageBox.Show("Please enter new tariff information.!!!");
                return;
            }

            if (btnUpdate.Text == "OK")
            {
                btnUpdate.Text = "Update";
                btnCancel.Visible = true;
                resetBoundItems();
                resetCommandFilter();
                return;
            }

            if (panel1.Tag == null)
            {
                MessageBox.Show("Find not found data to update.!!!");
                return;
            }

            var objRows = getRowsToUpdate();

            backgroundWorker2.RunWorkerAsync(objRows);
            toolStripProgressBar1.Style = ProgressBarStyle.Marquee;
            lblStatus.Text = "Updating..";
        }

        private DataGridViewRow findDataGridViewRow(int id)
        {
            DataGridViewRow row = null;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                var drv = (DataRowView)dataGridView1.Rows[i].DataBoundItem;

                if (Convert.ToInt32(drv["TrxId"]) == id)
                {
                    row = dataGridView1.Rows[i];
                    break;
                }
            }
            return row;
        }

        private List<object> readRowToObjects(List<object> objRow)
        {
            int rowIndex = -1;
            int trxid = Convert.ToInt32(objRow[20]);
            DataGridViewRow row = findDataGridViewRow(trxid);

            if (row != null)
            {
                rowIndex = row.Index;

                var cells = dataGridView1.Rows[rowIndex].Cells;
                cells["__col__UpdateStatus"].Value = "A";
                cells["__col__NewTariffCode"].Value = txtNewTariffCode.Text;
                cells["__col__NewStatCode"].Value = txtNewStatCode.Text;
                cells["__col__NewTariffUnit"].Value = txtNewTariffUnit.Text;
                cells["__col__NewDutyRate"].Value = Convert.ToDecimal(txtNewDutyRate.Text);
                cells["__col__PdtDescriptionAddon"].Value = txtDescriptionAddon.Text;
                cells["__col__Remark"].Value = txtRemark.Text;

                cells["__col__StatusTariffCode"].Value =
                    txtNewTariffCode.Text.Equals(cells["__col__TariffCode"].Value) ? "NOT CHANGE" : "CHANGE";

                cells["__col__StatusStatCode"].Value =
                    txtNewStatCode.Text.Equals(cells["__col__StatCode"].Value) ? "NOT CHANGE" : "CHANGE";

                cells["__col__StatusTariffUnit"].Value =
                    txtNewTariffUnit.Text.Equals(cells["__col__TariffUnit"].Value) ? "NOT CHANGE" : "CHANGE";

                cells["__col__StatusDutyRate"].Value =
                    Convert.ToDouble(txtNewDutyRate.Text).Equals(Convert.ToDouble(cells["__col__DutyRate"].Value)) ?
                    "NOT CHANGE" : "CHANGE";

                var rowCells = dataGridView1.Rows[rowIndex];
                return Helper.ConvertToDataGridViewCell(rowCells);
            }
            else return null;
        }

        private List<object> getRowsToUpdate()
        {
            if (panel1.Tag == null) return null;

            var objRow = panel1.Tag as List<object>;
            var objRowsForUpdate = new List<object>();

            try
            {
                objRowsForUpdate.Add(readRowToObjects(objRow));

                for (int i = 0; i < _checkedItems.Count; i++)
                {
                    objRowsForUpdate.Add(readRowToObjects((List<object>)_checkedItems[i]));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("getRowsToUpdate : " + ex.Message);
            }
            return objRowsForUpdate;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            VisiblePanelDetail();
        }

        private void VisiblePanelDetail()
        {
            splitContainer1.Panel2Collapsed = !splitContainer1.Panel2Collapsed;
            linkLabel1.Text = linkLabel1.Text.Contains("HIDE") ? "SHOW" : "HIDE";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (panel1.Tag == null) return;

            var obj = panel1.Tag as List<object>;
            setCheckBoxOnItemsBinding(false);
            setCheckBoxStatus(false);
            dataGridView1.Columns["__col__checkbox"].ReadOnly = true;
            resetBoundItems();
            resetCommandFilter();
            _checkedItems.Clear();
            chkUsedOldInformation.Checked = false;

            if (btnCancel.Tag != null)
            {
                _bsCustom.Filter = btnCancel.Tag.ToString();
                lblCommandText.Text = _bsCustom.Filter;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            saveFileDialog1.FileName = string.Empty;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                var frm = new downloadForm();
                frm.DestinationFileName = saveFileDialog1.FileName;
                frm.DownloadType = "Customer";
                frm.ShowDialog();
            }
        }

        private void setSelectRowStyle(int rowIndex, Boolean status)
        {
            if (status)
            {
                dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Purple;
            }
            else
            {
                dataGridView1.Rows[rowIndex].DefaultCellStyle.ForeColor = Color.Black;
            }
        }

        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                var objRows = e.Argument as List<object>;

                e.Result = _controller.UpdateFields(objRows.ToArray());
            }
            catch (Exception ex)
            {
                MessageBox.Show("Updated Error : " + ex.Message);
            }
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
            lblStatus.Text = "Done";
            chkUsedOldInformation.Checked = false;

            if (Convert.ToBoolean(e.Result))
            {
                setCheckBoxStatus(false);
                btnCancel.Visible = false;
                btnUpdate.Text = "OK";
                clearCheckBoxSelected();
                SumAcceptTotalView();
                MessageBox.Show("Update successfully.");
            }
        }

        private void chkUsedOldInformation_Click(object sender, EventArgs e)
        {
            if (panel1.Tag == null) return;
            if (chkUsedOldInformation.CheckState == CheckState.Checked)
            {
                txtNewStatCode.Text = lblStatCode.Text;
                txtNewTariffUnit.Text = lblTariffUnit.Text;
                txtNewDutyRate.Text = lblDutyRate.Text;
            }
            else
            {
                txtNewStatCode.Text = "";
                txtNewTariffUnit.Text = "";
                txtNewDutyRate.Text = "";
            }
        }
    }
}