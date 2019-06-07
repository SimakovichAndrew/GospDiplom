using GospDiplom.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospDiplom.WEB.Models
{
    public class SchetchikViewModel
    {
        public int KioskId { get; set; }

        public int SchetchikId { get; set; }
        public int NomerSchetchika { get; set; }
        public string ModelSchetchika { get; set; }
        public bool TexUchet { get; set; }
        public bool TwoTarif { get; set; }
        public Nullable<DateTime> Poverka { get; set; }
        public int Poteri { get; set; }
    }
}