using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        private TariffController _controller;
        private List<int> _checkedItems;

        public mainForm()
        {
            ToggleAntiFlicker(false);
            InitializeComponent();

            _controller = new TariffController();
            _checkedItems = new List<int>();

            Helper.DoubleBuffered(this.dataGridView1, true);
            this.ResizeBegin += Form1_ResizeBegin;
            this.ResizeEnd += Form1_ResizeEnd;
            this.toolStripProgressBar1.Style = ProgressBarStyle.Blocks;
            bs = new BindingSource();
            bs.ListChanged += Bs_ListChanged;

            this.dataGridView1.CellMouseClick += DataGridView1_CellMouseClick;
            this.dataGridView1.CellDoubleClick += DataGridView1_CellDoubleClick;
            this.__initDataGridViewColumns(dataGridView1);
            lblStatus.Text = "Ready";
        }

        private void DataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex >= 0 && e.RowIndex >= 0)
            {
                if (!splitContainer1.Panel2Collapsed)
                    VisiblePanelDetail();

                var itemDataRow = (DataRowView)dataGridView1.CurrentRow.DataBoundItem;
                var itemForm = new tariffForm();
                itemForm.ItemDataRow = itemDataRow;

                if (itemForm.ShowDialog() == DialogResult.OK)
                {
                    var drv = itemForm.ItemDataRow;
                    var mm = bs[bs.Find("TrxId", drv["TrxId"])];
                    mm = drv;
                    bs.EndEdit();
                    _controller.UpdateField(drv);
                    BoundItemBinding(drv);
                }
                VisiblePanelDetail();
            }
        }

        private void DataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.ColumnIndex >= 4 && e.RowIndex >= 0)
            {
                var drv = dataGridView1.CurrentRow.DataBoundItem;
                BoundItemBinding(drv);
                panel1.Tag = drv;
            }
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
                txtDescriptionAddon.Text = drv["PdtDescriptionAddon"].ToString();
                txtRemark.Text = drv["Remark"].ToString();
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
            txtDescriptionAddon.Text = "";
            txtRemark.Text = "";
            panel1.Tag = null;
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
                e.Result = _controller.GetAll();
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

                ResetBoundItem();
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
                ConditionFilter(cboTariffStatus.Text,
                    txtCompanyCode.Text,
                    txtDivisionCode.Text,
                    txtTariffCode.Text,
                    txtDescription.Text);
                var chk = ((CheckBox)dataGridView1.Controls.Find("checkboxHeader", true)[0]);
                chk.Checked = false;
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
            chkCol.DataPropertyName = "CheckState";
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
            dgv.Columns.Add(__newDgvColumn("Description(TH)", "PdtDescriptionTH", 600));
            dgv.Columns.Add(__newDgvColumn("Description(AddOn)", "PdtDescriptionAddon", 250));
            dgv.Columns.Add(__newDgvColumn("Remark", "Remark", 250));
            dgv.Columns.Add(__newDgvColumn("TariffCode(status)", "StatusTariffCode", 120, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(__newDgvColumn("StatCode(status)", "StatusStatCode", 120, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(__newDgvColumn("TariffUnit(status)", "StatusTariffUnit", 120, DataGridViewContentAlignment.MiddleCenter));
            dgv.Columns.Add(__newDgvColumn("DutyRate(status)", "StatusDutyRate", 120, DataGridViewContentAlignment.MiddleCenter));

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
            var checkState = ((CheckBox)dataGridView1.Controls.Find("checkboxHeader", true)[0]).Checked;
            _checkedItems.Clear();

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var row = dataGridView1.Rows[i];
                row.Cells[0].Value = checkState;
                dataGridView1.CurrentCell = dataGridView1[1, 0];

                if (checkState)
                {
                    var id = Convert.ToInt32(((DataRowView)row.DataBoundItem)["TrxId"]);
                    _checkedItems.Add(Convert.ToInt32(id));
                }
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

            ResetBoundItem();

            var chk = ((CheckBox)dataGridView1.Controls.Find("checkboxHeader", true)[0]);
            chk.Checked = false;
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
                    if (commandFilter.Length > 0)
                    {
                        splitCmd = commandFilter.Substring(commandFilter.Length - 5, 4);
                        commandFilter += string.Format("{0}NewTariffCode LIKE '{1}%' AND ", splitCmd.Contains("AND") ? "" : "AND ", RegText(tariffCode));
                    }
                    else
                    {
                        commandFilter = string.Format("NewTariffCode LIKE '{0}%' AND ", tariffCode);
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
                bs.Filter = commandFilter;
                ResetBoundItem();

                if (bs.Count > 0)
                    dataGridView1.CurrentCell = dataGridView1[0, 0];
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
            if (panel1.Tag == null)
            {
                MessageBox.Show("Find not found data to update.!!!");
                return;
            }

            var drv = (DataRowView)FillDataBoundItem();
            var bsItem = bs[bs.Find("TrxId", drv["TrxId"])];
            bsItem = drv;
            bs.EndEdit();

            FindCheckRow();

            if (_checkedItems.Count > 0)
            {
                List<DataRowView> items = new List<DataRowView>();
                items.Add(drv);

                for (int i = 0; i < _checkedItems.Count; i++)
                {
                    var childDrv = (DataRowView)bs[bs.Find("TrxId", _checkedItems[i])];

                    if (drv["NewTariffCode"].ToString() == childDrv["NewTariffCode"].ToString())
                    {
                        childDrv["NewStatCode"] = drv["NewStatCode"];
                        childDrv["NewTariffUnit"] = drv["NewTariffUnit"];
                        childDrv["NewDutyRate"] = drv["NewDutyRate"];
                        childDrv["PdtDescriptionAddon"] = drv["PdtDescriptionAddon"];
                        childDrv["Remark"] = drv["Remark"];

                        if (drv["NewStatCode"].ToString() != childDrv["StatCode"].ToString())
                            childDrv["StatusStatCode"] = "CHANGE";
                        else
                            childDrv["StatusStatCode"] = "NOT CHANGE";

                        if (drv["NewTariffUnit"].ToString() != childDrv["TariffUnit"].ToString())
                            childDrv["StatusTariffUnit"] = "CHANGE";
                        else
                            childDrv["StatusTariffUnit"] = "NOT CHANGE";

                        if (Convert.ToInt32(drv["NewDutyRate"]) != Convert.ToInt32(drv["DutyRate"]))
                            childDrv["StatusDutyRate"] = "CHANGE";
                        else
                            childDrv["StatusDutyRate"] = "NOT CHANGE";

                        var vrBs = bs[bs.Find("TrxId", childDrv["TrxId"])];
                        vrBs = childDrv;
                        items.Add(childDrv);
                    }
                }

                try
                {
                    _controller.UpdateFields(items.ToArray());
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update Error : " + ex.Message);
                }
            }
            else
            {
                try
                {
                    _controller.UpdateField(drv);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update Error : " + ex.Message);
                }
            }

            ResetBoundItem();
        }

        private object FillDataBoundItem()
        {
            if (panel1.Tag == null) return null;

            var ItemDataRow = (DataRowView)panel1.Tag;

            try
            {
                ItemDataRow["NewTariffCode"] = txtNewTariffCode.Text;
                ItemDataRow["NewStatCode"] = txtNewStatCode.Text;
                ItemDataRow["NewTariffUnit"] = txtNewTariffUnit.Text;
                ItemDataRow["NewDutyRate"] = Convert.ToDecimal(txtNewDutyRate.Text);
                ItemDataRow["PdtDescriptionAddon"] = txtDescriptionAddon.Text;
                ItemDataRow["Remark"] = txtRemark.Text;

                if (txtNewTariffCode.Text != ItemDataRow["TariffCode"].ToString().TrimEnd())
                    ItemDataRow["StatusTariffCode"] = "CHANGE";
                else
                    ItemDataRow["StatusTariffCode"] = "NOT CHANGE";

                if (txtNewStatCode.Text != ItemDataRow["StatCode"].ToString().TrimEnd())
                    ItemDataRow["StatusStatCode"] = "CHANGE";
                else
                    ItemDataRow["StatusStatCode"] = "NOT CHANGE";

                if (txtNewTariffUnit.Text != ItemDataRow["TariffUnit"].ToString().TrimEnd())
                    ItemDataRow["StatusTariffUnit"] = "CHANGE";
                else
                    ItemDataRow["StatusTariffUnit"] = "NOT CHANGE";

                if (Convert.ToInt32(txtNewDutyRate.Text) != Convert.ToInt32(ItemDataRow["DutyRate"]))
                    ItemDataRow["StatusDutyRate"] = "CHANGE";
                else
                    ItemDataRow["StatusDutyRate"] = "NOT CHANGE";

                DialogResult = DialogResult.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return ItemDataRow;
        }

        private void FindCheckRow()
        {
            _checkedItems.Clear();

            var tableSrc = (DataTable)bs.DataSource;
            var tableClone = tableSrc.DefaultView.ToTable();
            var dv = tableClone.DefaultView;
            dv.RowFilter = "CheckState = true";

            for (int i = 0; i < dv.Count; i++)
            {
                var cellCheckState = (Boolean)dv[i]["CheckState"];
                var id = Convert.ToInt32(dv[i]["TrxId"]);

                if (cellCheckState)
                {
                    _checkedItems.Add(id);
                }
                else
                {
                    try
                    {
                        _checkedItems.RemoveAt(id);
                    }
                    catch { }
                }
            }
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
            ResetBoundItem();
        }
    }
}