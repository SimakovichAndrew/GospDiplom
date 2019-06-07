using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using GospDiplom.DAL.Entities;


namespace GospDiplom.DAL.EF
{
   public class DbInitialazer : DropCreateDatabaseIfModelChanges/*DropCreateDatabaseAlways*/<GospContext>
    {
        protected override void Seed(GospContext db)
        {
            // base.Seed(db);

            db.Organizations.AddRange(new List<Organization>
            {
                new Organization{OrgName="Энергосбыт", Dogovor= 285, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 2851, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 2852, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 2853, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 281, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 125, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 72, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 3060, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 109, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 1030, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 469, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 755, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 794, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 2016, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 535231, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 535233, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 535234, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 535235, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 535236, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 535237, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Энергосбыт", Dogovor= 535238, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Дистанция Жлобин", Dogovor= 5857, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="Дистанция Гомель", Dogovor= 5857, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="БелГУТ", Dogovor= 5857, Telefon=0, Email= "energo-gomel@osp.by"},
                new Organization{OrgName="КЖРЭУП", Dogovor= 5857, Telefon=0, Email= "energo-gomel@osp.by"}
            });

            db.SaveChanges();

            db.Kiosks.AddRange(new List<Kiosk>
            {
                new Kiosk
                {
                    Nomer="1", ModelKioska="Киоск", Arenda= new DateTime(2019, 9, 16), Town="Гомель, р-н Центр", Adress="ул. Трудовая, д. 3", OrganizationId=1
                },
                new Kiosk
                {
                    Nomer="2", ModelKioska="Киоск",  Arenda= new DateTime(2019, 9, 16), Town="Гомель, р-н Центр", Adress="пр. Ленина, р-н Ж/Д техникума", OrganizationId=1
                },
                new Kiosk
                {
                    Nomer="3", ModelKioska="Киоск", Arenda= new DateTime(2019, 9, 16), Town="Гомель, р-н Центр", Adress="ул. Крестянская, р-н т.ц. Космос", OrganizationId=1
                },
                new Kiosk
                {
                    Nomer="4", ModelKioska="Киоск", Arenda= new DateTime(2019, 9, 16), Town="Гомель, р-н Центр", Adress="ул. Рогачевская д.2а", OrganizationId=1
                }
            });


            for (int i = 5; i < 210; i++)
            {
                db.Kiosks.Add(new Kiosk { Nomer = i.ToString(), Arenda = new DateTime(2019, 9, 16), ModelKioska = "Киоск", OrganizationId=1, Town="Гомель" });
           
            }


            db.SaveChanges();

            db.Schetchiks.AddRange(new List<Schetchik>
            {
                new Schetchik
                {
                     ModelSchetchika="Mirtek", NomerSchetchika=12345, TexUchet=false, TwoTarif=false, KioskId=1
                },
                 new Schetchik
                {
                     ModelSchetchika="Energomer", NomerSchetchika=23456, TexUchet=true, TwoTarif=true, KioskId=1
                },
                  new Schetchik
                {
                     ModelSchetchika="Mirtek", NomerSchetchika=34567, TexUchet=false, TwoTarif=true, KioskId=2
                },
                   new Schetchik
                {
                     ModelSchetchika="Energomer", NomerSchetchika=45678, TexUchet=true, TwoTarif=false, KioskId=2
                },
                    new Schetchik
                {
                     ModelSchetchika="Mirtek", NomerSchetchika=56789, TexUchet=false, TwoTarif=true, KioskId=3
                },
                     new Schetchik
                {
                     ModelSchetchika="Energomer", NomerSchetchika=67890, TexUchet=false, TwoTarif=false, KioskId=3
                },
                      new Schetchik
                {
                     ModelSchetchika="Mirtek", NomerSchetchika=78901, TexUchet=false, TwoTarif=true, KioskId=4
                }
            });

            db.SaveChanges();

            db.Equipments.AddRange(new List<Equipment>
            {
                new Equipment{ModelEq="Диодная", TypeEq="лампа", PowerEq=8, Quantity=3},
                 new Equipment{ModelEq="Люма", TypeEq="лампа", PowerEq=18, Quantity=5},
                  new Equipment{ModelEq="Кас-1", TypeEq="Касса", PowerEq=10, Quantity=1},
                   new Equipment{ModelEq="Маслянный", TypeEq="Обогреватель", PowerEq=1000, Quantity=1}
            });

            db.SaveChanges();

            db.Indications.AddRange(new List<Indication>
            {
                new Indication{Tarif1=0.5, Tarif2=2.5, Month=new DateTime(2019, 12, 16), SchetchikId=1 },
                new Indication{Tarif1=1.5, Tarif2=3.5, Month=new DateTime(2019, 3, 16), SchetchikId=2 },
                new Indication{Tarif1=4.5, Tarif2=5.5, Month=new DateTime(2019, 1, 16), SchetchikId=3 },
                new Indication{Tarif1=6.5, Tarif2=7.5, Month=new DateTime(2019, 2, 16), SchetchikId=4 },
                new Indication{Tarif1=8.5, Tarif2=9.5, Month=new DateTime(2019, 7, 16), SchetchikId=5 },
                new Indication{Tarif1=10.5, Tarif2=12.5, Month=new DateTime(2019, 9, 16), SchetchikId=6 },
                new Indication{Tarif1=14.5, Tarif2=15.5, Month=new DateTime(2019, 10, 16), SchetchikId=7 },
                new Indication{Tarif1=1.5, Tarif2=3.5, Month=new DateTime(2019, 1, 16), SchetchikId=1 },
                new Indication{Tarif1=4.5, Tarif2=5.5, Month=new DateTime(2019, 2, 16), SchetchikId=1 },
                new Indication{Tarif1=6.5, Tarif2=7.5, Month=new DateTime(2019, 3, 16), SchetchikId=1 },
            });

            db.SaveChanges();
        }

    }
}
