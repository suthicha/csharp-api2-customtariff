using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomTariff.WinApp
{
    public partial class tariffForm : Form
    {
        public DataRowView ItemDataRow { get; set; }

        public tariffForm()
        {
            InitializeComponent();
            this.Load += TariffForm_Load;
        }

        private void TariffForm_Load(object sender, EventArgs e)
        {
            if (ItemDataRow == null) return;
            BoundItemBinding(ItemDataRow);
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
                txtNewTariffCode.SelectionStart = txtNewTariffCode.Text.Length;
            }
            catch { }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (txtNewTariffCode.Text != ItemDataRow["NewTariffCode"].ToString())
            {
                var dlg = MessageBox.Show("ดำเนินการแก้ไข TariffCode ใหม่?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (dlg == DialogResult.No)
                {
                    return;
                }
            }

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
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void chkUsedOldInformation_Click(object sender, EventArgs e)
        {
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