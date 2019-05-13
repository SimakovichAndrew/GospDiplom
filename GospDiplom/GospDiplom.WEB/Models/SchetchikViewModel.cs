using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospDiplom.WEB.Models
{
    public class SchetchikViewModel
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