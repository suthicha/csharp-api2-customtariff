using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomTariff.Api2.DataAccess.Entities
{
    public class TariffClass : EntityBase
    {
        [Column(TypeName = "Varchar"), MaxLength(35)]
        public string OldTariffCode { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(35)]
        public string TariffCode { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(15)]
        public string RefType { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(512)]
        public string Remark1 { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(512)]
        public string Remark2 { get; set; }
    }
}