using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using GospDiplom.DAL.Entities;
using GospDiplom.DAL.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;
using System.Data.OleDb;
using System.Data.SqlClient;

namespace GospDiplom.DAL.EF
{
   public class DbInitialazer : DropCreateDatabaseIfModelChanges/*DropCreateDatabaseAlways*/<GospContext>
    {
        private readonly SqlConnection strConnection;



        protected override void Seed(GospContext db)
        {

         






            // base.Seed(db);
            var userManager = new ApplicationUserManager(new UserStore<ApplicationUser>(db));

            var roleManager = new ApplicationRoleManager(new RoleStore<ApplicationRole>(db));
            // создаем  роли  lkz 
            var role1 = new ApplicationRole { Name = "admin" };
            var role2 = new ApplicationRole { Name = "moderator" };
            var role3 = new ApplicationRole { Name = "user" };
            var role4 = new ApplicationRole { Name = "kiosk" };
            // добавляем роли в бд
            roleManager.Create(role1);
            roleManager.Create(role2);
            roleManager.Create(role3);
            roleManager.Create(role4);
            // создаем администратора
            var admin = new ApplicationUser
            {
                Email = "admin@mail.ru",
                UserName = "Boss"
            };
            string password = "123456";
            var result = userManager.Create(admin, password);
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(admin.Id, role1.Name);
                userManager.AddToRole(admin.Id, role2.Name);
                userManager.AddToRole(admin.Id, role3.Name);
            }
            // создаем модератора
            var moderator = new ApplicationUser
            {
                Email = "mmm@mail.ru",
                UserName = "Moderator"
            };
            password = "654321";
            result = userManager.Create(moderator, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(moderator.Id, role2.Name);
                userManager.AddToRole(moderator.Id, role3.Name);
            }
            //создаем простого пользователя васю
            var user = new ApplicationUser
            {
                Email = "vvv@mail.ru",
                UserName = "Vasja"
            };
            password = "111111";
            result = userManager.Create(user, password);

            // если создание пользователя прошло успешно
            if (result.Succeeded)
            {
                // добавляем для пользователя роль
                userManager.AddToRole(user.Id, role3.Name);

            }

            db.SaveChanges();

            //___________________________________________________________________________________________________________________________________
            db.Organizations.AddRange(new List<Organization>
            {
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 285, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 2851, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 2852, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 2853, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 281, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 125, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 72, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 3060, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 109, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 1030, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 469, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 755, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 794, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 2016, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 535231, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 535233, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 535234, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 535235, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 535236, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 535237, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Энергосбыт, Dogovor= 535238, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Дистанция_Жлобин, Dogovor= 5857, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.Дистанция_Гомель, Dogovor= 5857, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.БелГУТ, Dogovor= 5857, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName=OrgNames.КЖРЭУП, Dogovor= 5857, Telefon=0, Email= "energo-gomel@osp.by"}
            });

            db.SaveChanges();

            db.Kiosks.AddRange(new List<Kiosk>
            {
                new Kiosk
                {
                    Nomer="1", ModelKioska="Киоск", Arenda= new DateTime(2019, 9, 16), Town= Towns.Гомель, Adress="ул. Трудовая, д. 3", OrganizationId=1
                },
                new Kiosk
                {
                    Nomer="2", ModelKioska="Киоск",  Arenda= new DateTime(2019, 9, 16), Town= Towns.Ельск, Adress="пр. Ленина, р-н Ж/Д техникума", OrganizationId=23
                },
                new Kiosk
                {
                    Nomer="3", ModelKioska="Киоск", Arenda= new DateTime(2019, 9, 16), Town= Towns.Калинковичи, Adress="ул. Крестянская, р-н т.ц. Космос", OrganizationId=25
                },
                new Kiosk
                {
                    Nomer="4", ModelKioska="Киоск", Arenda= new DateTime(2019, 9, 16), Town=Towns.Жлобин, Adress="ул. Рогачевская д.2а", OrganizationId=22
                }
            });

            for (int i = 5; i < 210; i++)
            {
                db.Kiosks.Add(new Kiosk { Nomer = i.ToString(), Arenda = new DateTime(2019, 9, 16), ModelKioska = "Киоск", OrganizationId = 1, Town = Towns.Гомель });

            }

            db.SaveChanges();

            db.Schetchiks.AddRange(new List<Schetchik>
            {
                new Schetchik
                {
                     ModelSchetchika="Mirtek", NomerSchetchika="12345", TexUchet=false, TwoTarif=false, KioskId=1
                },
                 new Schetchik
                {
                     ModelSchetchika="Energomer", NomerSchetchika="23456", TexUchet=true, TwoTarif=true, KioskId=1
                },
                  new Schetchik
                {
                     ModelSchetchika="Mirtek", NomerSchetchika="34567", TexUchet=false, TwoTarif=true, KioskId=2
                },
                   new Schetchik
                {
                     ModelSchetchika="Energomer", NomerSchetchika="45678", TexUchet=true, TwoTarif=false, KioskId=2
                },
                    new Schetchik
                {
                     ModelSchetchika="Mirtek", NomerSchetchika="56789", TexUchet=false, TwoTarif=true, KioskId=3
                },
                     new Schetchik
                {
                     ModelSchetchika="Energomer", NomerSchetchika="67890", TexUchet=false, TwoTarif=false, KioskId=3
                },
                      new Schetchik
                {
                     ModelSchetchika="Mirtek", NomerSchetchika="78901", TexUchet=false, TwoTarif=true, KioskId=4
                }
            });

            db.SaveChanges();

            db.Equipments.AddRange(new List<Equipment>
            {
                new Equipment{ModelEq="Диодная", TypeEq="лампа", PowerEq=8, QuantityAll=3},
                 new Equipment{ModelEq="Люма", TypeEq="лампа", PowerEq=18, QuantityAll=5},
                  new Equipment{ModelEq="Кас-1", TypeEq="Касса", PowerEq=10, QuantityAll=1},
                   new Equipment{ModelEq="Маслянный", TypeEq="Обогреватель", PowerEq=1000, QuantityAll=1}
            });

            db.SaveChanges();

            db.Indications.AddRange(new List<Indication>
            {
                new Indication{Tarif1=10.0, Tarif2=2.5, Month=new DateTime(2019, 4, 16), SchetchikId=1 },
                new Indication{Tarif1=1.5, Tarif2=3.5, Month=new DateTime(2019, 3, 16), SchetchikId=2 },
                new Indication{Tarif1=4.5, Tarif2=5.5, Month=new DateTime(2019, 1, 16), SchetchikId=3 },
                new Indication{Tarif1=6.5, Tarif2=7.5, Month=new DateTime(2019, 2, 16), SchetchikId=4 },
                new Indication{Tarif1=8.5, Tarif2=9.5, Month=new DateTime(2019, 5, 16), SchetchikId=5 },
                new Indication{Tarif1=10.5, Tarif2=12.5, Month=new DateTime(2019, 9, 16), SchetchikId=6 },
                new Indication{Tarif1=14.5, Tarif2=15.5, Month=new DateTime(2019, 10, 16), SchetchikId=7 },
                new Indication{Tarif1=1.0, Tarif2=3.0, Month=new DateTime(2019, 1, 16), SchetchikId=1 },
                new Indication{Tarif1=4.0, Tarif2=5.0, Month=new DateTime(2019, 2, 16), SchetchikId=1 },
                new Indication{Tarif1=6.0, Tarif2=7.0, Month=new DateTime(2019, 3, 16), SchetchikId=1 },
            });

            db.SaveChanges();


            //--------------------------------------------------------------------------------------------
            // String excelConnString = String.Format("Provider=Microsoft.JET.OLEDB.4.0;Data Source={0};Extended Properties=\"Excel 8.0\"", @"D:\kioski.xls"/*filePath*/);
            String excelConnString = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source= D:\kioski.xlsx;Extended Properties='Excel 12.0 Xml;HDR=YES;'"/*filePath*/;

            //if (fileExtension == ".xls")
            //    conn.ConnectionString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 8.0;HDR=YES;'";
            //if (fileExtension == ".xlsx")
            //    conn.ConnectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + Import_FileName + ";" + "Extended Properties='Excel 12.0 Xml;HDR=YES;'";


            //Create Connection to Excel work book 
            //using (OleDbConnection excelConnection = new OleDbConnection(excelConnString))
            //{
            //    //Create OleDbCommand to fetch data from Excel 
            //    using (OleDbCommand cmd = new OleDbCommand("Select * from [adress$]", excelConnection))
            //    {
            //        excelConnection.Open();
            //        using (OleDbDataReader dReader = cmd.ExecuteReader())
            //        {
            //            //using (SqlBulkCopy sqlBulk = new SqlBulkCopy(strConnection))
            //            //{
            //            //    //Give your Destination table name 
            //            //    sqlBulk.DestinationTableName = "Excel_table";
            //            //    sqlBulk.WriteToServer(dReader);
            //            while (dReader.Read())
            //            {
            //                var row1Col0 = dReader[0];
            //                var row1Col1 = dReader[1];
            //               db.Kiosks.FirstOrDefaultAsync(x=>x.Nomer==dReader[1].ToString()).Result.Adress = dReader[2].ToString();
            //                var row1Col3 = dReader[3];

            //            }
            //            //}
            //        }
            //    }
            //}


            //db.SaveChanges();
            //--------------------------------------------------------------------------------------------



        }

    }
}
//string con =
//  @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=D:\temp\test.xls;" +
//  @"Extended Properties='Excel 8.0;HDR=Yes;'";    
//using(OleDbConnection connection = new OleDbConnection(con))
//{
//    connection.Open();
//    OleDbCommand command = new OleDbCommand("select * from [Sheet1$]", connection); 
//    using(OleDbDataReader dr = command.ExecuteReader())
//    {
//         while(dr.Read())
//         {
//             var row1Col0 = dr[0];
//Console.WriteLine(row1Col0);
//         }
//    }
//}