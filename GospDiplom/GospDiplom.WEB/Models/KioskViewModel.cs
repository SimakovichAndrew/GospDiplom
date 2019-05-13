using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospDiplom.WEB.Models
{
    public class KioskViewModel
    {
        public int KioskId { get; set; }
        public int Nomer { get; set; }
        public string ModelKioska { get; set; }
        public int IdOsn { get; set; }
        public int IdTexUchet { get; set; }
        public DateTime Arenda { get; set; }
    }
}