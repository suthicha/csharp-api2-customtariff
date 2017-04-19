using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTariff.Models
{
    public class ProductModel
    {
        public int id { get; set; }
        public string companyCode { get; set; }
        public string divisionCode { get; set; }
        public string section { get; set; }
        public string formality { get; set; }
        public string typeofProduct { get; set; }
        public string partname { get; set; }
        public string spec { get; set; }
        public string fullPartname { get; set; }
        public string madeby { get; set; }
        public string unit { get; set; }
        public string pdtDescriptionTH { get; set; }
        public string tariffCode { get; set; }
        public string tariffSeq { get; set; }
        public string tariffUnit { get; set; }
        public Double dutyRate { get; set; }
        public Boolean needLicense { get; set; }
        public string ministry { get; set; }
        public string pdtClass { get; set; }
        public string customsFunc { get; set; }
        public string usedForMachine { get; set; }
        public string cropPlanningRemark { get; set; }
        public string filter1 { get; set; }
        public string filter2 { get; set; }
        public string filter3 { get; set; }
        public string filter4 { get; set; }
        public string filter5 { get; set; }
        public string filter6 { get; set; }
        public string remark1 { get; set; }
        public string remark2 { get; set; }
        public string operationCode { get; set; }
        public string programCode { get; set; }
        public string createBy { get; set; }
        public DateTime createDate { get; set; }
        public string updateBy { get; set; }
        public DateTime updateDate { get; set; }
    }
}