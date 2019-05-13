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
    class SchetchikRepository : IRepository<Schetchik>
    {
        GospContext db;

        public SchetchikRepository(GospContext context)
        {
            db = context;
        }

        public void Create(Schetchik item)
        {
            db.Schetchiks.Add(item);
        }

        public void Delete(int id)
        {
            Schetchik schetchik = db.Schetchiks.Find(id);
            if (schetchik != null)
            {
                db.Schetchiks.Remove(schetchik);
            }
        }

        public IEnumerable<Schetchik> Find(Func<Schetchik, bool> predicate)
        {
            return db.Schetchiks.Include(o => o.IdKiosk).Where(predicate).ToList();
        }

        public Schetchik Get(int id)
        {
            return db.Schetchiks.Find(id);
        }

        public IEnumerable<Schetchik> GetAll()
        {
            return db.Schetchiks;
        }

        public Schetchik GetString(string topicname)
        {
            return db.Schetchiks.Where(x => x.ModelSchetchika == topicname).First();
        }

        public void Update(Schetchik item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
