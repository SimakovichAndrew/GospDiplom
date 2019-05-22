using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.BLL.DTO
{
   public class IndicationDTO
    {
        public int IndicationId { get; set; }
        public DateTime Month { get; set; }
        public double Tarif1 { get; set; }
        public double Tarif2 { get; set; }
        public double TarifSumm { get; set; }
    }
}
