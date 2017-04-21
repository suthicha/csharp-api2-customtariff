using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomTariff.Models
{
    public class TariffModel
    {
        public int Id { get; set; }

        public string TariffCode { get; set; }

        public string NewTariffCode { get; set; }

        public string Extension { get; set; }

        public string Remark { get; set; }

        public int Length { get; set; }
    }
}