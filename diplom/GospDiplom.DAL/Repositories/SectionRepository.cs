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
    public class SectionRepository : IRepository<Section>
    {
        private GospContext db;

        public SectionRepository(GospContext gospContext)
        {
            db = gospContext;
        }


        public void Create(Section item)
        {
            db.Sections.Add(item);
            //throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Section section = db.Sections.Find(id);
            if(section != null)
            {
                db.Sections.Remove(section);
            }

            //throw new NotImplementedException();
        }

        public IEnumerable<Section> Find(Func<Section, bool> predicate)
        {
            return db.Sections.Where(predicate).ToList();
            //throw new NotImplementedException();
        }

        public Section Get(int id)
        {
          return   db.Sections.Find(id);
            //throw new NotImplementedException();
        }

        public IEnumerable<Section> GetAll()
        {
            return db.Sections;
            //throw new NotImplementedException();
        }

        public Section GetString(string nomer)
        {
            return db.Sections.Where(x => x.NomerKioska == nomer).FirstOrDefault();
            //throw new NotImplementedException();
        }

        public IQueryable<Section> GetTs(int i)
        {
            throw new NotImplementedException();
        }

        public void Update(Section item)
        {
            db.Entry(item).State = EntityState.Modified;
            //throw new NotImplementedException();
        }
    }
}
