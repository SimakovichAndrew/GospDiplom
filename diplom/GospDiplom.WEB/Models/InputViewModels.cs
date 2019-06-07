using GospDiplom.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace GospDiplom.WEB.Models
{
    public class InputViewModels
    {
        //public IEnumerable<KioskDTO> GetKiosks { get; set; }
        //public IEnumerable<SchetchikDTO>GetSchetchiks { get; set; }
        //public IEnumerable<IndicationDTO> GetIndications { get; set; }
        public KioskViewModel Kiosk { get; set; }
        //public SchetchikViewModel Counetr { get; set; }
        //public IndicationViewModel Indication { get; set; }
        public OrganizationViewModel GetOrg { get; set; }
        public string OrgName { get; set; }
        //public IEnumerable<OrganizationDTO> GetOrgans { get; set; } 
        //public DateTime Month { get; set; }
        //public double Tarif1 { get; set; }
        //public double Tarif2 { get; set; }
        //public string Kiosk { get; set; }
        //public int Counter { get; set; }

        public string GetMonth(DateTime date)
        {
            return date.ToString("MMM");
        }
    }
}