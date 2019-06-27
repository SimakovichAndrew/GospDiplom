using GospDiplom.DAL.Entities;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
//using System.ComponentModel.DataAnnotations;
//using System.ComponentModel.DataAnnotations.Schema;

namespace GospDiplom.DAL.Entities
{
   public class ClientProfile
    {
        [Key]
        [ForeignKey("ApplicationUser")]
        public string Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        
        //Свойство навигации для внешнего ключа

     //public virtual ICollection<Kiosk> Kiosks { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}
//Класс пользователя и его профиля связаны отношением один-к-одному. Разделение данных о пользователя на два класса позволит независимо друг от друга рассматривать аутентификационные данные и вспомогательные данные, то есть профиль пользователя, которые не играют никакой роли при аутентификации.