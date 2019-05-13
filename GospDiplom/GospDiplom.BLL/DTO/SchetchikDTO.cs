using System;
using System.Collections.Generic;
using System.Text;

namespace GospDiplom.BLL.DTO
{ 
   public class SchetchikDTO
    {
        public int SchetchikId { get; set; }
        public int NomerSchetchika { get; set; }
        public string ModelSchetchika { get; set; }
        public double Tarif1 { get; set; }
        public double Tarif2 { get; set; }
        public double TarifSumm { get; set; }
        public int IdKiosk { get; set; }
        public bool TexUchet { get; set; }

    }
}
