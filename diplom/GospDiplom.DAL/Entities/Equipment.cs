using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GospDiplom.DAL.Entities
{
    public class Equipment
    {
        public Equipment()
        {
            
        }

        [Required]
      
        public int EquipmentId { get; set; }
        public string ModelEq { get; set; }
        public string TypeEq { get; set; }
        public int PowerEq { get; set; }
        public int QuantityAll { get; set; }

        //[ForeignKey("EquipmentKiosk")]
        //public int EquipmentKioskId { get; set; }
        //public virtual EquipmentKiosk Equipmentkiosk { get; set; }

        //// Это свойство будет использоваться как внешний ключ
        //[ForeignKey("Kiosk")]
        //public Nullable<int> KioskId { get; set; }
        ////ссылка на киоск
        //public virtual Kiosk Kiosks { get; set; }  }
    }
}
