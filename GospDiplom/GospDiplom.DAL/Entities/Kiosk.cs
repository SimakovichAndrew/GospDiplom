using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GospDiplom.DAL.Entities
{
   public class Kiosk
    {
        [Required]
        public int KioskId { get; set; }

        [Required]
        public string Nomer { get; set; }
        public string ModelKioska { get; set; }
        public DateTime Arenda { get; set; }
        public string Town { get; set; }
        public string Adress { get; set; }

       // public virtual ICollection<Equipment> Equipments { get; set; }
        public virtual ICollection<Schetchik> Schetchiks { get; set; }

    }
}
