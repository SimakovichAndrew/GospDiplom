using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GospDiplom.DAL.Entities
{
    public class Equipment
    {
        [Required]
        public int EquipmentId { get; set; }
        public string ModelEq { get; set; }
        public string TypeEq { get; set; }
        public int PowerEq { get; set; }
        public int Quantity { get; set; }

       // public virtual ICollection<Kiosk> Kiosk { get; set; }
    }
}
