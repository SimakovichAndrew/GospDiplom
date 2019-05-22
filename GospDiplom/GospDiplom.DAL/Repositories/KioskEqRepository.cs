using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Linq;
using GospDiplom.DAL.Interfaces;
using GospDiplom.DAL.Entities;
using GospDiplom.DAL.EF;

namespace GospDiplom.DAL.Repositories
{
    public class KioskEqRepository : IRepository<KioskEq>
    {
        private GospContext db;

        public KioskEqRepository(GospContext context) { db = context; }

        public void Create(KioskEq item)
        {
            db.KioskEqs.Add(item);
        }

        public void Delete(int id)
        {
            KioskEq kioskEq = db.KioskEqs.Find(id);
            if (kioskEq != null)
            {
                db.KioskEqs.Remove(kioskEq);
            }
        }

        public IEnumerable<KioskEq> Find(Func<KioskEq, bool> predicate)
        {
            return db.KioskEqs.Where(predicate).ToList();
            //return db.KioskEqs.Include(o => o.EqId).Where(predicate).ToList();
            //throw new NotImplementedException();
        }

        public KioskEq Get(int id)
        {
            return db.KioskEqs.Find(id);
        }

        public IEnumerable<KioskEq> GetAll()
        {
            return db.KioskEqs;
        }

        public KioskEq GetString(string name)
        {
            throw new NotImplementedException();
            //return db.KioskEqs.Where(x => x.Quantity==name)
        }

        public void Update(KioskEq item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
