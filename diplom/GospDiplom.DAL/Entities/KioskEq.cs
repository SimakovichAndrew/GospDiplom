using System;
using System.Collections.Generic;
using System.Text;

namespace GospDiplom.DAL.Entities
{
    public class KioskEq
    {
        public int KioskEqId { get; set;}
        public int Quantity { get; set; }

        public virtual IEnumerable<Equipment> Equipment { get; set; }
        public Kiosk Kiosk { get; set; }
    }
}
