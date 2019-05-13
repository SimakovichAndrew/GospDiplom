﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using System.Linq;
using GospDiplom.DAL.Interfaces;
using GospDiplom.DAL.Entities;
using GospDiplom.DAL.EF;
namespace GospDiplom.DAL.Repositories
{
    class KioskRepository : IRepository<Kiosk>
    {
        private GospContext db;

        public KioskRepository(GospContext context)
        {
            db = context;
        }

        public void Create(Kiosk item)
        {
            db.Kiosks.Add(item);
        }

        public void Delete(int id)
        {
            Kiosk kiosk = db.Kiosks.Find(id);
            if (kiosk != null)
            {
                db.Kiosks.Remove(kiosk);
            }
        }

        public IEnumerable<Kiosk> Find(Func<Kiosk, bool> predicate)
        {
            return db.Kiosks.Include(o => o.KioskId).Where(predicate).ToList();
        }

        public Kiosk Get(int id)
        {
            return db.Kiosks.Find(id);
        }

        public IEnumerable<Kiosk> GetAll()
        {
            return db.Kiosks;
        }

        public Kiosk GetString(string topicname)
        {
            return db.Kiosks.Where(x => x.Nomer == Convert.ToInt16(topicname)).First();
        }

        public void Update(Kiosk item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
    }
}
