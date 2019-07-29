using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Threading.Tasks;
using GospDiplom.DAL.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace GospDiplom.DAL.EF
{
    public class GospContext : /*DbContext, */IdentityDbContext<ApplicationUser>
    {
        //1-й способ создания строки подключения
       // string connectionString = @"Data Source=(localdb)\mssqllocaldb;Initial Catalog=GospDiplom;Integrated Security=true;";

        public GospContext(string connectionString) : base(connectionString) { }

        public DbSet<Kiosk> Kiosks { get; set; }
        public DbSet<Schetchik> Schetchiks { get; set; }
        public DbSet<Equipment> Equipments { get; set; }
        public DbSet<Indication> Indications { get; set; }
        public DbSet<Organization> Organizations { get; set; }
        public DbSet<Section> Sections { get; set; }

        public DbSet<ClientProfile> ClientProfiles { get; set; }

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

        // ____________upload____________xls________________________


        //private void SaveFileToDatabase(string filePath)
        //{
        //    //String strConnection = "Data Source=.\\SQLEXPRESS;AttachDbFilename='C:\\Users\\Hemant\\documents\\visual studio 2010\\Projects\\CRMdata\\CRMdata\\App_Data\\Database1.mdf';Integrated Security=True;User Instance=True";

        //    String excelConnString = String.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=\"Excel 12.0\"", filePath);
        //    //Create Connection to Excel work book 
        //    using (OleDbConnection excelConnection = new OleDbConnection(excelConnString))
        //    {
        //        //Create OleDbCommand to fetch data from Excel 
        //        using (OleDbCommand cmd = new OleDbCommand("Select [ID],[Name],[Designation] from [Sheet1$]", excelConnection))
        //        {
        //            excelConnection.Open();
        //            using (OleDbDataReader dReader = cmd.ExecuteReader())
        //            {
        //                using (SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection))
        //                {
        //                    //Give your Destination table name 
        //                    sqlBulk.DestinationTableName = "Excel_table";
        //                    sqlBulk.WriteToServer(dReader);
        //                }
        //            }
        //        }
        //    }
        //}


        //private string GetLocalFilePath(string saveDirectory, FileUpload fileUploadControl)
        //{


        //    string filePath = Path.Combine(saveDirectory, fileUploadControl.FileName);

        //    fileUploadControl.SaveAs(filePath);

        //    return filePath;

        //}
