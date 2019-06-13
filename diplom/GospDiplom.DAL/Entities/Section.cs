using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.DAL.Entities
{
   public class Section
    {
        [ForeignKey("Kiosk")]
        public int SectionId { get; set; }
        public string NomerKioska { get; set; }
        public string AdresSection { get; set; }
        public double AreaSection { get; set; }
        public string Kadastr { get; set; }
        public DateTime DataResh { get; set; }
        public string TypeArenda { get; set; }
        public string Certefikat { get; set; }
        public DateTime DateArenda { get; set; }

       
        //public int KioskId { get; set; }

        public virtual Kiosk Kiosk { get; set; }
    }
}
