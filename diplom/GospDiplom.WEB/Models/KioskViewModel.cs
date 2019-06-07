using GospDiplom.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospDiplom.WEB.Models
{
    public class KioskViewModel
    {


        public int KioskId { get; set; }


        public string Nomer { get; set; }
        public string ModelKioska { get; set; }
        public Nullable<DateTime> Arenda { get; set; }
        public string Town { get; set; }
        public string Adress { get; set; }
        public double Area { get; set; }



        // public int TexUchetId { get; set; }
        // public Nullable<DateTime> Arenda { get; set; }
      //  public OrganizationViewModel Organization { get; set; }
        //public int OrganizationId { get; set; }
        //public KioskDTO Kiosk { get; set; }
       // public ICollection<EquipmentDTO> Equipments { get; set; }
        //public ICollection<BLL.DTO.SchetchikDTO> Schetchiks { get; set; }
    }
}