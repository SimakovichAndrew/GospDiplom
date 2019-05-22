using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospDiplom.WEB.Models
{
    public class KioskViewModel
    {
        public int KioskId { get; set; }
        public int Nomer { get; set; }
        public string ModelKioska { get; set; }
        public string Town { get; set; }
        public int TexUchetId { get; set; }
        public DateTime Arenda { get; set; }

       // public ICollection<EquipmentDTO> Equipments { get; set; }
        public ICollection<BLL.DTO.SchetchikDTO> Schetchiks { get; set; }
    }
}