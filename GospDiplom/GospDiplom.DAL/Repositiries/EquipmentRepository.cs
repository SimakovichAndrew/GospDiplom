using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Linq;
using GospDiplom.DAL.Interfaces;
using GospDiplom.DAL.Entities;
using GospDiplom.DAL.EF;

namespace GospDiplom.DAL.Repositiries
{
    class EquipmentRepository : IRepository<Equipment>
    {
        private GospContext db;
        public EquipmentRepository(GospContext context)
        {
            db = context;
        }

        public void Create(Equipment item)
        {
            db.Equipments.Add(item);
        }

        public void Delete(int id)
        {
            Equipment equipment = db.Equipments.Find(id);
            if (equipment != null)
                db.Equipments.Remove(equipment);
        }

        public IEnumerable<Equipment> Find(Func<Equipment, bool> predicate)
        {
            return db.Equipments.Include(o => o.EqId).Where(predicate).ToList();
        }

        public Equipment Get(int id)
        {
            return db.Equipments.Find(id);
        }

        public IEnumerable<Equipment> GetAll()
        {
            return db.Equipments;
        }

        public Equipment GetString(string topicname)
        {
            return db.Equipments.Where(x => x.ModelEq == topicname).First();
        }

        public void Update(Equipment item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
