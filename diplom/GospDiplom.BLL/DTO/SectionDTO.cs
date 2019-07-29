using GospDiplom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.BLL.DTO
{
    public class SectionDTO
    {
        public int SectionId { get; set; }

        public string NomerKioska { get; set; }
        public string AdresSection { get; set; }
        public double AreaSection { get; set; }
        public string Kadastr { get; set; }
        public DateTime DataResh { get; set; }
        public string TypeArenda { get; set; }
        public string Certefikat { get; set; }
        public DateTime DateArenda { get; set; }

        public Nullable<int> KioskId { get; set; }
      //  public virtual Kiosk Kiosk { get; set; }
    }
}
