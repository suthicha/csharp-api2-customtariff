using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CustomTariff.Api2.DataAccess.Entities
{
    public class EntityBase : ReportingBase
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Column(Order = 0)]
        public int TrxId { get; set; }
    }
}