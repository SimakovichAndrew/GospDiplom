﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using GospDiplom.DAL.EF;
using GospDiplom.DAL.Entities;
using GospDiplom.DAL.Interfaces;

namespace GospDiplom.DAL.Repositories
{
    internal class OrganizationRepository : IRepository<Organization>
    {
        private GospContext db;

        public OrganizationRepository(GospContext db)
        {
            this.db = db;
        }

        public void Create(Organization item)
        {
            db.Organizations.Add(item);
            //throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            Organization organization = db.Organizations.Find(id);
            if (organization != null)
                db.Organizations.Remove(organization);
            //throw new NotImplementedException();
        }

        public IEnumerable<Organization> Find(Func<Organization, bool> predicate)
        {
            return db.Organizations.Where(predicate).ToList();
            //throw new NotImplementedException();
        }

        public Organization Get(int id)
        {
            return db.Organizations.Find(id);
            //throw new NotImplementedException();
        }

        public IEnumerable<Organization> GetAll()
        {
            return db.Organizations;
            //throw new NotImplementedException();
        }

        public Organization GetString(string nomer)
        {
            return db.Organizations.Where(x => x.OrgName == nomer).First();
            //throw new NotImplementedException();
        }

        public IQueryable<Organization> GetTs()
        {
            throw new NotImplementedException();
        }

        public void Update(Organization item)
        {
            db.Entry(item).State = EntityState.Modified;
            //throw new NotImplementedException();
        }
    }
}