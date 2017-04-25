using System;

namespace CustomTariff.Models
{
    public class ProductNModel
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
        public string pdtDescriptionAddOn { get; set; }
        public string tariffCode { get; set; }
        public string tariffSeq { get; set; }
        public string tariffUnit { get; set; }
        public Double dutyRate { get; set; }
        public string newTariffCode { get; set; }
        public string newTariffSeq { get; set; }
        public string newTariffUnit { get; set; }
        public Double newDutyRate { get; set; }
    }
}