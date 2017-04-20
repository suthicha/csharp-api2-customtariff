﻿using CustomTariff.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace CustomTariff.WinAppTest
{
    public class TariffController
    {
        public void Executed(IEnumerable<ProductModel> products)
        {
            using (SqlConnection conn = new SqlConnection(@"data source=.\SQLExpress;uid=sa;password=cti2016;database=editariff"))
            {
                conn.Open();

                var cmd = conn.CreateCommand();
                var trans = conn.BeginTransaction();
                cmd.Transaction = trans;

                try
                {
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandTimeout = 0;

                    for (int i = 0; i < products.Count(); i++)
                    {
                        var obj = products.ElementAt(i);
                        cmd.CommandText = @"INSERT INTO Products SELECT
                        @companyCode, @divisionCode, @section, @formality, @typeofProduct, @partname,
                        @spec, @fullPartname, @madeby, @unit, @pdtDescriptionTH, @tariffCode, @tariffSeq, @tariffUnit,
                        @dutyRate, @needLicense, @ministry, @pdtClass, @customsFunc, @usedForMachine, @cropPlanningRemark,
                        @filter1, @filter2, @filter3, @filter4, @filter5, @filter6,
                        @remark1, @remark2, @operationCode, @programCode, @createBy, @createDate, @updateBy, @updateDate";

                        cmd.Parameters.AddWithValue("@companyCode", obj.companyCode);
                        cmd.Parameters.AddWithValue("@divisionCode", obj.divisionCode);
                        cmd.Parameters.AddWithValue("@section", obj.section);
                        cmd.Parameters.AddWithValue("@formality", obj.formality);
                        cmd.Parameters.AddWithValue("@typeofProduct", obj.typeofProduct);
                        cmd.Parameters.AddWithValue("@partname", obj.partname);
                        cmd.Parameters.AddWithValue("@spec", obj.spec);
                        cmd.Parameters.AddWithValue("@fullPartname", obj.fullPartname);
                        cmd.Parameters.AddWithValue("@madeby", obj.madeby);
                        cmd.Parameters.AddWithValue("@unit", obj.unit);
                        cmd.Parameters.AddWithValue("@pdtDescriptionTH", obj.pdtDescriptionTH);
                        cmd.Parameters.AddWithValue("@tariffCode", obj.tariffCode);
                        cmd.Parameters.AddWithValue("@tariffSeq", obj.tariffSeq);
                        cmd.Parameters.AddWithValue("@tariffUnit", obj.tariffUnit);
                        cmd.Parameters.AddWithValue("@dutyRate", obj.dutyRate);
                        cmd.Parameters.AddWithValue("@needLicense", obj.needLicense);
                        cmd.Parameters.AddWithValue("@ministry", obj.ministry);
                        cmd.Parameters.AddWithValue("@pdtClass", obj.pdtClass);
                        cmd.Parameters.AddWithValue("@customsFunc", obj.customsFunc);
                        cmd.Parameters.AddWithValue("@usedForMachine", obj.usedForMachine);
                        cmd.Parameters.AddWithValue("@cropPlanningRemark", obj.cropPlanningRemark);
                        cmd.Parameters.AddWithValue("@filter1", obj.filter1);
                        cmd.Parameters.AddWithValue("@filter2", obj.filter2);
                        cmd.Parameters.AddWithValue("@filter3", obj.filter3);
                        cmd.Parameters.AddWithValue("@filter4", obj.filter4);
                        cmd.Parameters.AddWithValue("@filter5", obj.filter5);
                        cmd.Parameters.AddWithValue("@filter6", obj.filter6);
                        cmd.Parameters.AddWithValue("@remark1", obj.remark1);
                        cmd.Parameters.AddWithValue("@remark2", obj.remark2);
                        cmd.Parameters.AddWithValue("@operationCode", obj.operationCode);
                        cmd.Parameters.AddWithValue("@programCode", obj.programCode);
                        cmd.Parameters.AddWithValue("@createBy", obj.createBy);
                        cmd.Parameters.AddWithValue("@createDate", obj.createDate);
                        cmd.Parameters.AddWithValue("@updateBy", obj.updateBy);
                        cmd.Parameters.AddWithValue("@updateDate", obj.updateDate);

                        cmd.ExecuteNonQuery();
                        cmd.Parameters.Clear();
                    }

                    trans.Commit();
                }
                catch (Exception ex)
                {
                    trans.Rollback();
                    throw new Exception(ex.Message);
                }
            }
        }
    }
}