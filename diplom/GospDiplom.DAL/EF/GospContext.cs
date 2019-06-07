﻿using System.Collections.Generic;
using System.Data.Entity;
using System.Threading.Tasks;
using GospDiplom.DAL.Entities;

namespace GospDiplom.DAL.EF
{
    public class GospContext : DbContext
    {
        //1-й способ создания строки подключения
       // string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=GospDiplom;Integrated Security=true;";

        public GospContext(string connectionString) : base(connectionString) { }

        public DbSet<Kiosk> Kiosks { get; set; }
        public DbSet<Schetchik> Schetchiks { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Indication> Indications { get; set; }
        public DbSet<Organization> Organizations { get; set; }

        static GospContext()
        {
            Database.SetInitializer<GospContext>(new DbInitialazer() );
        }

        public static GospContext Create(string connectionString)
        {
            return new GospContext(connectionString);
        }

    }
}