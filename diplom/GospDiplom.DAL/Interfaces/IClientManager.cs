using GospDiplom.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.DAL.Interfaces
{
    //Данный интерфейс содержит один метод для создания нового профиля пользователя.
    public interface IClientManager : IDisposable
    {
        void Create(ClientProfile item);
        ClientProfile Find(/*int? id*/string name);
        ClientProfile FindId(int? id);
    }
}
