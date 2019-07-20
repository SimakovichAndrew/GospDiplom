using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GospDiplom.DAL.Entities
{
   public class Schetchik
    {

        public Schetchik()
        {
            this.Indications = new HashSet<Indication>();
        }

        [Required]
        public int SchetchikId { get; set; }
        public string NomerSchetchika { get; set; }
        public string ModelSchetchika { get; set; }
        public bool TexUchet { get; set; }
        public bool TwoTarif { get; set; }
        public Nullable<DateTime> Poverka { get; set; }
        public int Poteri { get; set; }

        // Это свойство будет использоваться как внешний ключ
        [ForeignKey("Kiosk")]
        public Nullable<int> KioskId { get; set; }
        //ссылка на киоск
        public virtual Kiosk Kiosk { get; set; }


        public virtual ICollection<Indication> Indications { get; set; }
    }
}
