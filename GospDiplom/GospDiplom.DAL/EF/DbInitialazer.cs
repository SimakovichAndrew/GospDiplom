using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using GospDiplom.DAL.Entities;


namespace GospDiplom.DAL.EF
{
   public class DbInitialazer:/* DropCreateDatabaseIfModelChanges*/DropCreateDatabaseAlways<GospContext>
    {
        protected override void Seed(GospContext db)
        {
           // base.Seed(db);

            db.Kiosks.AddRange(new List<Kiosk>
            {
                new Kiosk
                {
                    Nomer="1", ModelKioska="Павильон", Arenda=DateTime.Now, Town="Гомель"
                },
                new Kiosk
                {
                    Nomer="2", ModelKioska="Киоск",  Arenda=DateTime.Now, Town="Мозырь"
                },
                new Kiosk
                {
                    Nomer="3", ModelKioska="Киоск", Arenda=DateTime.Now, Town="Гомель"
                },
                new Kiosk
                {
                    Nomer="4", ModelKioska="Магазин", Arenda=DateTime.Now, Town="Речица"
                }
            });

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
                new Indication{Tarif1=0.5, Tarif2=2.5, Month=DateTime.Now, SchetchikId=1 },
                new Indication{Tarif1=0.5, Tarif2=2.5, Month=DateTime.Now, SchetchikId=2 },
                new Indication{Tarif1=0.5, Tarif2=2.5, Month=DateTime.Now, SchetchikId=3 },
                new Indication{Tarif1=0.5, Tarif2=2.5, Month=DateTime.Now, SchetchikId=4 },
                new Indication{Tarif1=0.5, Tarif2=2.5, Month=DateTime.Now, SchetchikId=5 },
                new Indication{Tarif1=0.5, Tarif2=2.5, Month=DateTime.Now, SchetchikId=6 },
                new Indication{Tarif1=0.5, Tarif2=2.5, Month=DateTime.Now, SchetchikId=7 }
            });

            //db.KioskEqs.AddRange(new List<KioskEq>
            //{
            //    new KioskEq{KioskEqId=1, EqId=1, Quantity=2},
            //    new KioskEq{KioskEqId=1, EqId=2, Quantity=3},
            //    new KioskEq{KioskEqId=1, EqId=3, Quantity=1},
            //    new KioskEq{KioskEqId=1, EqId=4, Quantity=1},
            //    new KioskEq{KioskEqId=2, EqId=1, Quantity=2},
            //    new KioskEq{KioskEqId=2, EqId=3, Quantity=1},
            //    new KioskEq{KioskEqId=3, EqId=3, Quantity=1},

            //});

            db.SaveChanges();

        }

    }
}
