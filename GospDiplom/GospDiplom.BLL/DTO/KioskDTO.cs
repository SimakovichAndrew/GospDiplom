using System;
using System.Collections.Generic;
using System.Text;

namespace GospDiplom.BLL.DTO
{ 
   public class KioskDTO
    {
        public int KioskId { get; set; }
        public string Nomer { get; set; }
        public string ModelKioska { get; set; }
        public DateTime Arenda { get; set; }
        public string Town { get; set; }
        public string Adress { get; set; }
    }
}
