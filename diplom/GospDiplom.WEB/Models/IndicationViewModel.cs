using System;

namespace GospDiplom.WEB.Models
{
    public class IndicationViewModel
    {
        public int IndicationId { get; set; }
        public DateTime Month { get; set; }
        public double Tarif1 { get; set; }
        public double Tarif2 { get; set; }
        public double TarifSumm { get; set; }


        public int SchetchikId { get; set; }
    }
}