using GospDiplom.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.DAL.Interfaces
{ //Объект UnitOfWork будет содержать ссылки на менеджеры пользователей и ролей, а также на репозиторий пользователей.
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Equipment> Kiosks { get; }
        IRepository<Schetchik> Schetchiks { get; }
        IRepository<Equipment> Equipments { get; }
        IRepository<KioskEq> KioskEquipments { get; }
        Task SaveAsync();
        void Save();
    }
}
