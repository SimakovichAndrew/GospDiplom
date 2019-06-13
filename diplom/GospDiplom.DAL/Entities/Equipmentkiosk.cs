using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.DAL.Entities
{
    public class EquipmentKiosk
    {
        //public EquipmentKiosk(Equipment equipment, int quant)
        //{
        //    Equipment = equipment;
        //    QuantityEK = quant;
        //}

        [System.ComponentModel.DataAnnotations.Required]
        
        public int EquipmentKioskId { get; set; }
        public int QuantityEK { get; set; }


        [ForeignKey("Kiosk")]
        public int KioskId { get; set; }
        public virtual Kiosk Kiosk { get; set; }

        //[ForeignKey("Equipment")]
        //public int EquipmentId { get; set; }

        // 
        public virtual Equipment Equipment { get; set; }

    }
}
