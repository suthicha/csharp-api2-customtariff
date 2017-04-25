using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace CustomTariff.Api2.DataAccess.Entities
{
    public class ProductN : EntityBase
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

        [Column(TypeName = "Varchar"), MaxLength(512)]
        public string PdtDescriptionAddOn { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(35)]
        public string TariffCode { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(15)]
        public string TariffSeq { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(6)]
        public string TariffUnit { get; set; }

        public double DutyRate { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(35)]
        public string NewTariffCode { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(15)]
        public string NewTariffSeq { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(6)]
        public string NewTariffUnit { get; set; }

        public double NewDutyRate { get; set; }

        public int GroupId { get; set; }
    }
}