using GospDiplom.DAL.EF;
using GospDiplom.DAL.Entities;
using GospDiplom.DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.DAL.Repositories
{
   public class EFUnitOfWork : IUnitOfWork
    {
        GospContext db;


        private IRepository<Kiosk> KioskRepository;// => throw new NotImplementedException();

        private IRepository<Schetchik> SchetchikRepository;// => throw new NotImplementedException();

        private IRepository<Equipment> EquipmentRepository;// => throw new NotImplementedException();

        private IRepository<Indication> IndicationRepository;  // => throw new NotImplementedException();

        private IRepository<Organization> OrganizationRepository;



        public EFUnitOfWork(string connectionString)
        {
            db = new GospContext(connectionString);
        }


        public IRepository<Kiosk> Kiosks
        {
            get
            {
                if (KioskRepository == null)
                    KioskRepository = new KioskRepository(db);
                return KioskRepository;
            }
        }

        public IRepository<Schetchik> Schetchiks
        {
            get
            {
                if (SchetchikRepository == null)
                    SchetchikRepository = new SchetchikRepository(db);
                return SchetchikRepository;
            }
        }

        public IRepository<Equipment> Equipments
        {
            get
            {
                if (EquipmentRepository == null)
                    EquipmentRepository = new EquipmentRepository(db);
                return EquipmentRepository;
            }
        }

        public IRepository<Indication> Indications
        {
            get
            {
                if (IndicationRepository == null)
                    IndicationRepository = new IndicationRepository(db);
                return IndicationRepository;
            }
        }

        public IRepository<Organization> Organizations
        {
            get
            {
                if (OrganizationRepository == null)
                    OrganizationRepository = new OrganizationRepository(db);
                return OrganizationRepository;
            }
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                    //userManager.Dispose();
                    //roleManager.Dispose();
                    //clientManager.Dispose();
                }
                this.disposed = true;
            }
        }



        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public void Save()
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}
