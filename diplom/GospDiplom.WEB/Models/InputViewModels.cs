using GospDiplom.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospDiplom.WEB.Models
{
    public class InputViewModels
    {
        //public string OrgName { get; set; }
        //public int Dogovor { get; set; }
        public IEnumerable<AllTable> AllKioski { get; set; }
        public PagingInfo PagingInfoCom { get; set; }


        //public IEnumerable<KioskDTO> GetKiosks { get; set; }
        //public IEnumerable<SchetchikDTO> GetSchetchiks { get; set; }
        //public IEnumerable<OrganizationDTO> GetOrgans { get; set; }
        //public IEnumerable<IndicationDTO> GetIndications { get; set; }
        //public IEnumerable<EquipmentDTO> GetEquipments { get; set; }

        //public KioskDTO Kiosk { get; set; }
        //public SchetchikDTO Counetr { get; set; }
        //public IndicationDTO Indication { get; set; }
        //public OrganizationDTO GetOrg { get; set; }



        //public DateTime Month { get; set; }
        //public double Tarif1Start { get; set; }
        //public double Tarif1End { get; set; }
        //public string Kiosk { get; set; }
        //public int Counter { get; set; }

       // public string GetMonth(DateTime date) => date.ToString("MMM");
    }
}