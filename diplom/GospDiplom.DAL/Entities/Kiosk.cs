using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace GospDiplom.DAL.Entities
{
   public class Kiosk
    {
        public Kiosk()
        {
            this.Schetchiks = new HashSet<Schetchik>();
            Equipments = new HashSet<Equipment>();
        }

        [Required]
        public int KioskId { get; set; }

        [Required]
        public string Nomer { get; set; }
        public string ModelKioska { get; set; }
        public Nullable<DateTime> Arenda { get; set; }
        public Towns Town { get; set; }
        public string Adress { get; set; }
        public double Area { get; set; }


        // [ForeignKey("Section")]
       // public Nullable<int> SectionId { get; set; }
       // public virtual Section Section { get; set; }

        public virtual ICollection<Equipment> Equipments { get; set; }
        public virtual ICollection<Schetchik> Schetchiks { get; set; }

        // Это свойство будет использоваться как внешний ключ
        [ForeignKey("Organization")]
        public Nullable<int> OrganizationId { get; set; }
        //ссылка на контрагента
        public virtual Organization Organization { get; set; }

        //// Это свойство будет использоваться как внешний ключ
        //[ForeignKey("Equipment")]
        //public Nullable<int> EquipmentId { get; set; }
        //ссылка на оборудование
        public virtual ICollection<EquipmentKiosk> EquipmentKiosk { get; set; }

    public Towns kioskTown(string t)
    {
            //string town = null;
            foreach (Towns i in Enum.GetValues(typeof(Towns)))
            {
                if (t.Equals(i.ToString()))
                { return i ; }
            }
            return 0;
    }
    }

   public enum Towns
    {
        Гомель, Ветка, БудаКошелева, Добруш, Речица, Хойники, Жлобин, Рогачев, Корма, Брагин, Лоев, Чечерск, Светлогорск, Октябрьский, Мозырь, Калинковичи, Петриков, Житковичи, Туров, Наровля, Ельск, Лельчицы 
    }
}
