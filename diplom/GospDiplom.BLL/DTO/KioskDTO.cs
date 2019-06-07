using GospDiplom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace GospDiplom.BLL.DTO
{ 
   public class KioskDTO
    {
        //public KioskDTO()
        //{
        //    this.Schetchiks = new HashSet<Schetchik>();
        //    Equipments = new HashSet<Equipment>();
        //}


        public int KioskId { get; set; }


        public string Nomer { get; set; }
        public string ModelKioska { get; set; }
        public Nullable<DateTime> Arenda { get; set; }
        public string Town { get; set; }
        public string Adress { get; set; }
        public double Area { get; set; }


        //public virtual ICollection<Equipment> Equipments { get; set; }
        //public virtual ICollection<Schetchik> Schetchiks { get; set; }



        //public Nullable<int> OrganizationId { get; set; }

        //public virtual Kiosk Organizations { get; set; }
    }
}
