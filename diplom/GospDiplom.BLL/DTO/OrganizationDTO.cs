using GospDiplom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.BLL.DTO
{
    public class OrganizationDTO
    {
        //public OrganizationDTO()
        //{
        //    Kiosks = new HashSet<Kiosk>();
        //}

        public int OrganizationId { get; set; }
        public string OrgName { get; set; }
        public int Dogovor { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }

        //public virtual ICollection<Kiosk> Kiosks { get; set; }
    }
}
