using GospDiplom.DAL.EF;
using GospDiplom.DAL.Entities;
using GospDiplom.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.DAL.Repositories
{
  public  class IndicationRepository: IRepository<Indication>
    {
        private GospContext db;
        public IndicationRepository(GospContext context)
        {
            db = context;
        }

        public void Create(Indication item)
        {
            db.Indications.Add(item);
           // throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Indication indication = db.Indications.Find(id);
            if (indication != null)
                db.Indications.Remove(indication);

            //throw new NotImplementedException();
        }

        public IEnumerable<Indication> Find(Func<Indication, bool> predicate)
        {
            return db.Indications.Where(predicate).ToList();
           // throw new NotImplementedException();
        }

        public Indication Get(int id)
        {
            return db.Indications.Find(id);
            //throw new NotImplementedException();
        }

        public IEnumerable<Indication> GetAll()
        {
            return db.Indications;
            //throw new NotImplementedException();
        }

        public Indication GetString(string month)
        {
            return db.Indications.Where(x => x.Month.ToString()==month).First();
           // throw new NotImplementedException();
        }

        public IQueryable<Indication> GetTs()
        {
            throw new NotImplementedException();
        }

        public IQueryable<Indication> GetTs(int i)
        {
            throw new NotImplementedException();
        }

        public void Update(Indication item)
        {
            db.Entry(item).State = EntityState.Modified;
            // throw new NotImplementedException();
        }
    }
}
