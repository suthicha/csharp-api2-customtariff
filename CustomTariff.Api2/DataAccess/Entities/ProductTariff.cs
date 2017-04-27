using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CustomTariff.Api2.DataAccess.Entities
{
    public class ProductTariff : EntityBase
    {
        public string CompanyCode { get; set; }
        public string DivisionCode { get; set; }
        public string Section { get; set; }
        public string Formality { get; set; }
        public string TypeOfProduct { get; set; }
        public string PartName { get; set; }
        public string SPEC { get; set; }
        public string FullPartName { get; set; }
        public string MadeBy { get; set; }
        public string Unit { get; set; }
        public string PdtDescriptionTH { get; set; }
        public string TariffCode { get; set; }
        public string StatCode { get; set; }
        public string TariffUnit { get; set; }
        public Double DutyRate { get; set; }
        public string PdtDescriptionAddon { get; set; }
        public string NewTariffCode { get; set; }
        public string NewStatCode { get; set; }
        public string NewTariffUnit { get; set; }
        public Double NewDutyRate { get; set; }
        public int GroupId { get; set; }
        public string StatusTariffCode { get; set; }
        public string StatusStatCode { get; set; }
        public string StatusTariffUnit { get; set; }
        public string StatusDutyRate { get; set; }
        public string Remark { get; set; }
    }
}