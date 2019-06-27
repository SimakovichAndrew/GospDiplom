using GospDiplom.DAL.EF;
using GospDiplom.DAL.Entities;
using GospDiplom.DAL.Identity;
using GospDiplom.DAL.Interfaces;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace GospDiplom.DAL.Repositories
{
    public class EFUnitOfWork : IUnitOfWork
    {
        private GospContext db;


        private IRepository<Kiosk> KioskRepository;// => throw new NotImplementedException();

        private IRepository<Schetchik> SchetchikRepository;// => throw new NotImplementedException();

        private IRepository<Equipment> EquipmentRepository;// => throw new NotImplementedException();

        private IRepository<Indication> IndicationRepository;  // => throw new NotImplementedException();

        private IRepository<Organization> OrganizationRepository;

        private ApplicationUserManager userManager;
        private ApplicationRoleManager roleManager;
       // private IClientManager clientManager;
        private ClientManager clientManager;


        public EFUnitOfWork(string connectionString)
        {
            db = new GospContext(connectionString);
            userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));
            roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            clientManager = new ClientManager(db);
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

        //private bool disposed = false;
        //public virtual void Dispose(bool disposing)
        //{
        //    if (!this.disposed)
        //    {
        //        if (disposing)
        //        {
        //            db.Dispose();
        //            //userManager.Dispose();
        //            //roleManager.Dispose();
        //            //clientManager.Dispose();
        //        }
        //        this.disposed = true;
        //    }
        //}
        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

        public void Save()
        {
            throw new NotImplementedException();
        }


//____________________________User__________________________________________
        public ApplicationUserManager UserManager
        {
            get { return userManager; }
        }

        public IClientManager ClientManager
        {
            get { return clientManager; }
        }

        public ApplicationRoleManager RoleManager
        {
            get { return roleManager; }
        }

        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    userManager.Dispose();
                    roleManager.Dispose();
                    clientManager.Dispose();
                }
                this.disposed = true;
            }
        }
    }
}
