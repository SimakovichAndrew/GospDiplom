using GospDiplom.DAL.EF;
using GospDiplom.DAL.Entities;
using GospDiplom.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace GospDiplom.DAL.Repositiries
{
    public class KioskEqRepository : IRepository<KioskEq>
    {
        private GospContext db;

        public KioskEqRepository()
        public void Create(KioskEq item)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KioskEq> Find(Func<KioskEq, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public KioskEq Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<KioskEq> GetAll()
        {
            throw new NotImplementedException();
        }

        public KioskEq GetString(string topicname)
        {
            throw new NotImplementedException();
        }

        public void Update(KioskEq item)
        {
            throw new NotImplementedException();
        }
    }
}
