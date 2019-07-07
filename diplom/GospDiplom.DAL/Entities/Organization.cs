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
        public OrgNames OrgName { get; set; }
        public int  Dogovor { get; set; }
        public int Telefon { get; set; }
        public string Email { get; set; }
        public int Limit { get; set; }

        public virtual ICollection<Kiosk> Kiosks { get; set; }
 
    }

    //public override string ToString()
    //{
    //    string orgName = 
    //    return OrgName;
    //}

    public enum OrgNames
    {
        Энергосбыт, БелГУТ, Дистанция_Гомель, Дистанция_Жлобин, КЖРЭУП, Больница, ГорЭлектроТранспорт 
    }
}
