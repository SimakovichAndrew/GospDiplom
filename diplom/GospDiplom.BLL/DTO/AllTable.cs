using GospDiplom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.BLL.DTO
{
    public class AllTable
    {
        public string Nomer { get; set; }
        public string ModelCounter { get; set; }
        public string Gorod { get; set; }
        public string Adress { get; set; }
        public string OrgName { get; set; }
        public int Dogovor { get; set; }
        public Nullable<DateTime> Arenda { get; set; }

        //public KioskDTO Kiosk { get; set; }
        //public string OrgName { get; set; }
        //public int Dogovor { get; set; }

        //public OrganizationDTO Organization { get; set; }
    }
}
