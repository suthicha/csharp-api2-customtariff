using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;

namespace CustomTariff.Controllers
{
    public static class Helper
    {
        public static void DoubleBuffered(this Control control, bool setting)
        {
            Type dgvType = control.GetType();
            PropertyInfo pi = dgvType.GetProperty("DoubleBuffered",
                  BindingFlags.Instance | BindingFlags.NonPublic);
            pi.SetValue(control, setting, null);
        }

        public static List<Object> ConvertToDataGridViewCell(DataGridViewRow currentRow)
        {
            List<Object> objs = new List<object>();
            for (int i = 0; i < currentRow.Cells.Count; i++)
            {
                objs.Add(currentRow.Cells[i].Value);
            }

            var drv = (DataRowView)currentRow.DataBoundItem;
            objs.Add(drv["TrxId"]);
            objs.Add(currentRow.Index);

            return objs;
        }
    }
}