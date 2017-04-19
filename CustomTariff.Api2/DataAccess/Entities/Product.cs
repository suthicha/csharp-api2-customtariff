using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomTariff.Api2.DataAccess.Entities
{
    public class Product : EntityBase
    {
        [Column(TypeName = "Varchar"), MaxLength(2)]
        public string CompanyCode { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(2)]
        public string DivisionCode { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(2)]
        public string Section { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(15)]
        public string Formality { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(15)]
        public string TypeOfProduct { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(255)]
        public string PartName { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(255)]
        public string SPEC { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(512)]
        public string FullPartName { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(15)]
        public string MadeBy { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(6)]
        public string Unit { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(512)]
        public string PdtDescriptionTH { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(35)]
        public string TariffCode { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(15)]
        public string TariffSeq { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(6)]
        public string TariffUnit { get; set; }

        public double DutyRate { get; set; }

        public Boolean NeedLicense { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(15)]
        public string Ministry { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(15)]
        public string PdtClass { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(512)]
        public string CustomsFunc { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(512)]
        public string UsedForMachine { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(512)]
        public string CropPlanningRemark { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(512)]
        public string Filter1 { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(512)]
        public string Filter2 { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(512)]
        public string Filter3 { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(512)]
        public string Filter4 { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(512)]
        public string Filter5 { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(512)]
        public string Filter6 { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(512)]
        public string Remark1 { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(512)]
        public string Remark2 { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(15)]
        public string OPRCode { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(15)]
        public string PRGCode { get; set; }
    }
}