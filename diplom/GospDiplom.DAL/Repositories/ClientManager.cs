using GospDiplom.DAL.Entities;
using GospDiplom.DAL.Interfaces;
using GospDiplom.DAL.EF;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.DAL.Repositories
{
    public class ClientManager : IClientManager
    {
        public GospContext Database { get; set; }
        public ClientManager(GospContext db)
        {
            Database = db;
        }

        public void Create(ClientProfile item)
        {
            Database.ClientProfiles.Add(item);
            Database.SaveChanges();
        }
        public ClientProfile Find(/*int? id*/string name)
        {
           return Database.ClientProfiles.Find(name);
            throw new NotImplementedException();
        }

        public ClientProfile FindId(int? id)
        {
           return Database.ClientProfiles.Find(id);
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            Database.Dispose();

        }

     
    }
}