using System;
using System.Collections.Generic;
using System.Text;

namespace GospDiplom.BLL.DTO
{ 
   public class SchetchikDTO
    {
       // public readonly KioskDTO Kiosk;
        public int KioskId { get; set; }

        public int SchetchikId { get; set; }
        public string NomerSchetchika { get; set; }
        public string ModelSchetchika { get; set; }
        public bool TexUchet { get; set; }
        public bool TwoTarif { get; set; }
        public Nullable<DateTime > Poverka { get; set; }
        public int Poteri { get; set; }
        public bool Archive { get; set; }
    }
}
