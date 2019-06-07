using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.DAL.Entities
{
   public class Organization
    {
        public Organization()
        {
            Kiosks = new HashSet<Kiosk>();
        }

        public int OrganizationId { get; set; }
        public string OrgName { get; set; }
        public int Dogovor { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }

        public virtual ICollection<Kiosk> Kiosks { get; set; }
 
    }
}
