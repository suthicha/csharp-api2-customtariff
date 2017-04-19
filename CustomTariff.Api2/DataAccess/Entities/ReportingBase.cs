using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomTariff.Api2.DataAccess.Entities
{
    public class ReportingBase
    {
        [Column(TypeName = "Varchar"), MaxLength(35)]
        public string CreateBy { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime CreateDate { get; set; }

        [Column(TypeName = "Varchar"), MaxLength(35)]
        public string UpdateBy { get; set; }

        public DateTime UpdateDate { get; set; }
    }
}