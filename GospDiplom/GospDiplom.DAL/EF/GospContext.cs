using System.Collections.Generic;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Threading.Tasks;
using GospDiplom.DAL.Entities;

namespace GospDiplom.DAL.EF
{
    public class GospContext : DbContext
    {
        public GospContext(string connectionString) : base(connectionString) { }

        public DbSet<Kiosk> Kiosks { get; set; }
        public DbSet<Schetchik> Schetchiks { get; set; }
        public DbSet<KioskEq> KioskEqs { get; set; }
        public DbSet<Equipment> Equipments { get; set; }


        static GospContext()
        {
            Database.SetInitializer(new DbInitialazer() );
        }
        public static GospContext Create(string connectionString)
        {
            return new GospContext(connectionString);
        }

    }
}
