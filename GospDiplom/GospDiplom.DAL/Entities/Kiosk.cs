using System;
using System.Collections.Generic;
using System.Text;

namespace GospDiplom.DAL.Entities
{
   public class Equipment
    {
        public int KioskId { get; set; }
        public int Nomer { get; set; }
        public string ModelKioska { get; set; }
        public int IdOsn { get; set; }
        public int IdTexUchet { get; set; }
        public DateTime Arenda { get; set; }

        public ICollection<Equipment> equipments { get; set; }
        public ICollection<Schetchik> schetchiks { get; set; }

    }
}
