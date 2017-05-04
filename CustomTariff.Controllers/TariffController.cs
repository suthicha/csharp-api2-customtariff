using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace CustomTariff.Controllers
{
    public class TariffController
    {
        private readonly string _connectionString;

        public TariffController(string connectionString)
        {
            _connectionString = connectionString;
        }

        public async Task<DataSet> GetAll()
        {
            DataSet ds = new DataSet();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                cmd.CommandText = @"select convert(bit,0) As CheckState,* from ProductTariffs where createdate <= '20161231' Order by TrxId asc";

                var da = new SqlDataAdapter(cmd);
                da.Fill(ds);
            }
            await Task.Delay(0);
            return ds;
        }

        public bool UpdateField(DataRowView obj)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                var trans = conn.BeginTransaction();
                cmd.Transaction = trans;

                try
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"Update ProductTariffs Set NewTariffCode=@NewTariffCode, NewStatCode=@NewStatCode,
                    NewTariffUnit=@NewTariffUnit, NewDutyRate=@NewDutyRate, PdtDescriptionAddon=@PdtDescriptionAddon,
                    StatusTariffCode=@StatusTariffCode, StatusStatCode=@StatusStatCode, StatusTariffUnit=@StatusTariffUnit,
                    StatusDutyRate=@StatusDutyRate, Remark=@Remark, UpdateDate=GETDATE() WHERE TrxId=@TrxId";

                    cmd.Parameters.AddWithValue("@TrxId", obj["TrxId"]);
                    cmd.Parameters.AddWithValue("@NewTariffCode", obj["NewTariffCode"]);
                    cmd.Parameters.AddWithValue("@NewStatCode", obj["NewStatCode"]);
                    cmd.Parameters.AddWithValue("@NewTariffUnit", obj["NewTariffUnit"]);
                    cmd.Parameters.AddWithValue("@NewDutyRate", obj["NewDutyRate"]);
                    cmd.Parameters.AddWithValue("@PdtDescriptionAddon", obj["PdtDescriptionAddon"]);
                    cmd.Parameters.AddWithValue("@Remark", obj["Remark"]);
                    cmd.Parameters.AddWithValue("@StatusTariffCode", obj["StatusTariffCode"]);
                    cmd.Parameters.AddWithValue("@StatusStatCode", obj["StatusStatCode"]);
                    cmd.Parameters.AddWithValue("@StatusTariffUnit", obj["StatusTariffUnit"]);
                    cmd.Parameters.AddWithValue("@StatusDutyRate", obj["StatusDutyRate"]);

                    cmd.ExecuteNonQuery();

                    trans.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Update Error : " + ex.Message);
                }
            }

            return result;
        }

        public bool UpdateFields(params object[] objs)
        {
            bool result = false;

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                conn.Open();
                var cmd = conn.CreateCommand();
                var trans = conn.BeginTransaction();
                cmd.Transaction = trans;

                try
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = @"Update ProductTariffs Set NewTariffCode=@NewTariffCode, NewStatCode=@NewStatCode,
                    NewTariffUnit=@NewTariffUnit, NewDutyRate=@NewDutyRate, PdtDescriptionAddon=@PdtDescriptionAddon,
                    StatusTariffCode=@StatusTariffCode, StatusStatCode=@StatusStatCode, StatusTariffUnit=@StatusTariffUnit,
                    StatusDutyRate=@StatusDutyRate, Remark=@Remark, UpdateDate=GETDATE() WHERE TrxId=@TrxId";

                    for (int i = 0; i < objs.Length; i++)
                    {
                        var obj = objs[i] as List<object>;
                        cmd.Parameters.AddWithValue("@TrxId", obj[19]);
                        cmd.Parameters.AddWithValue("@NewTariffCode", obj[8]);
                        cmd.Parameters.AddWithValue("@NewStatCode", obj[9]);
                        cmd.Parameters.AddWithValue("@NewTariffUnit", obj[10]);
                        cmd.Parameters.AddWithValue("@NewDutyRate", obj[11]);
                        cmd.Parameters.AddWithValue("@PdtDescriptionAddon", obj[13]);
                        cmd.Parameters.AddWithValue("@Remark", obj[14]);
                        cmd.Parameters.AddWithValue("@StatusTariffCode", obj[15]);
                        cmd.Parameters.AddWithValue("@StatusStatCode", obj[16]);
                        cmd.Parameters.AddWithValue("@StatusTariffUnit", obj[17]);
                        cmd.Parameters.AddWithValue("@StatusDutyRate", obj[18]);

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

                    trans.Commit();
                    result = true;
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception("Update Error : " + ex.Message);
                }
            }

            return result;
        }
    }
}