using GospDiplom.DAL.Entities;
using GospDiplom.DAL.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.DAL.Interfaces
{ //Объект UnitOfWork будет содержать ссылки на менеджеры пользователей и ролей, а также на репозиторий пользователей.
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Kiosk> Kiosks { get; }
        IRepository<Schetchik> Schetchiks { get; }
        IRepository<Equipment> Equipments { get; }
        IRepository<Indication> Indications { get; }
        IRepository<Organization> Organizations { get; }

        ApplicationUserManager UserManager { get; }
        IClientManager ClientManager { get; }
        ApplicationRoleManager RoleManager { get; }


        Task SaveAsync();
        void Save();
    }
}
