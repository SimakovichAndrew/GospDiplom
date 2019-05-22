using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GospDiplom.DAL.Entities
{
   public class Schetchik
    {
        [Required]
        public int SchetchikId { get; set; }
        public int NomerSchetchika { get; set; }
        public string ModelSchetchika { get; set; }
        public bool TexUchet { get; set; }
        public bool TwoTarif { get; set; }

        // Это свойство будет использоваться как внешний ключ
        [ForeignKey("Kiosk")]
        public int KioskId { get; set; }
        //ссылка на киоск
        public Kiosk Kiosk { get; set; }

        public virtual ICollection<Indication> Indications { get; set; }
    }
}
