using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospDiplom.WEB.Models
{
    public class IndicationViewModel
    {
        public int IndicationId { get; set; }
            public int IndicationKioskId { get; set; }
            public int IndicationSchetchikId { get; set; }
            public DateTime Month { get; set; }
            public double Tarif1 { get; set; }
            public double Tarif2 { get; set; }
            public double TarifSumm { get; set; }
    }
}