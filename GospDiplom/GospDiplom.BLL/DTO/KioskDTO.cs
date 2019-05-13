using System;
using System.Collections.Generic;
using System.Text;

namespace GospDiplom.BLL.DTO
{ 
   public class KioskDTO
    {
        public int KioskId { get; set; }
        public int Nomer { get; set; }
        public string ModelKioska { get; set; }
        public int IdOsn { get; set; }
        public int IdTexUchet { get; set; }
        public DateTime Arenda { get; set; }

        public ICollection<EquipmentDTO> equipments { get; set; }
        public ICollection<SchetchikDTO> schetchiks { get; set; }

    }
}
