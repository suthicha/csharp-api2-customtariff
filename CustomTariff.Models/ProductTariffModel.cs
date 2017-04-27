using System;

namespace CustomTariff.Models
{
    public class ProductTariffModel
    {
        public int id { get; set; }
        public string companyCode { get; set; }
        public string divisionCode { get; set; }
        public string section { get; set; }
        public string formality { get; set; }
        public string typeofProduct { get; set; }
        public string partName { get; set; }
        public string spec { get; set; }
        public string fullPartName { get; set; }
        public string madeBy { get; set; }
        public string unit { get; set; }
        public string pdtDescriptionTH { get; set; }
        public string tariffCode { get; set; }
        public string statCode { get; set; }
        public string tariffUnit { get; set; }
        public Double dutyRate { get; set; }
        public string pdtDescriptionAddon { get; set; }
        public string newTariffCode { get; set; }
        public string newStatCode { get; set; }
        public string newTariffUnit { get; set; }
        public Double newDutyRate { get; set; }
        public int groupId { get; set; }
        public string statusTariffCode { get; set; }
        public string statusStatCode { get; set; }
        public string statusTariffUnit { get; set; }
        public string statusDutyRate { get; set; }
        public string remark { get; set; }
        public string updateBy { get; set; }
        public DateTime updateDate { get; set; }
    }
}