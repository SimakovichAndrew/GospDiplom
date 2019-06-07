using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GospDiplom.DAL.Entities
{
   public class Kiosk
    {
        public Kiosk()
        {
            this.Schetchiks = new HashSet<Schetchik>();
            Equipments = new HashSet<Equipment>();
        }

        [Required]
        public int KioskId { get; set; }

        [Required]
        public string Nomer { get; set; }
        public string ModelKioska { get; set; }
        public Nullable<DateTime> Arenda { get; set; }
        public string Town { get; set; }
        public string Adress { get; set; }
        public double Area { get; set; }



        public virtual ICollection<Equipment> Equipments { get; set; }
        public virtual ICollection<Schetchik> Schetchiks { get; set; }

        // Это свойство будет использоваться как внешний ключ
        [ForeignKey("Organization")]
        public Nullable<int> OrganizationId { get; set; }
        //ссылка на контрагента
        public virtual Kiosk Organization { get; set; }
        //// Это свойство будет использоваться как внешний ключ
        //[ForeignKey("Equipment")]
        //public Nullable<int> EquipmentId { get; set; }
        ////ссылка на оборудование
        //public virtual Equipment Equipment { get; set; }
    }
}
