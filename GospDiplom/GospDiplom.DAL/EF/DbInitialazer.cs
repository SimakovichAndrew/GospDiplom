using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Entity;
using GospDiplom.DAL.Entities;


namespace GospDiplom.DAL.EF
{
    class DbInitialazer:DropCreateDatabaseIfModelChanges<GospContext>
    {
        protected override void Seed(GospContext db)
        {
           // base.Seed(db);

            db.Kiosks.AddRange(new List<Kiosk>
            {
                new Kiosk
                {
                    Nomer=1, ModelKioska="Павильон", IdOsn=1, IdTexUchet=2
                },
                new Kiosk
                {
                    Nomer=2, ModelKioska="Киоск", IdOsn=1, IdTexUchet=4
                },
                new Kiosk
                {
                    Nomer=3, ModelKioska="Киоск", IdOsn=5, IdTexUchet=6
                }
            });

            db.Schetchiks.AddRange(new List<Schetchik>
            {
                new Schetchik
                {
                    IdKiosk =1, ModelSchetchika="Mirtek", NomerSchetchika=12345, Tarif1=0, Tarif2=0, TarifSumm=0, TexUchet=false
                },
                 new Schetchik
                {
                    IdKiosk =1, ModelSchetchika="Energomer", NomerSchetchika=23456, Tarif1=0, Tarif2=0, TarifSumm=0, TexUchet=false
                },
                  new Schetchik
                {
                    IdKiosk =2, ModelSchetchika="Mirtek", NomerSchetchika=34567, Tarif1=0, Tarif2=0, TarifSumm=0, TexUchet=false
                },
                   new Schetchik
                {
                    IdKiosk =2, ModelSchetchika="Energomer", NomerSchetchika=45678, Tarif1=0, Tarif2=0, TarifSumm=0, TexUchet=false
                },
                    new Schetchik
                {
                    IdKiosk =3, ModelSchetchika="Mirtek", NomerSchetchika=56789, Tarif1=0, Tarif2=0, TarifSumm=0, TexUchet=false
                },
                     new Schetchik
                {
                    IdKiosk =3, ModelSchetchika="Energomer", NomerSchetchika=67890, Tarif1=0, Tarif2=0, TarifSumm=0, TexUchet=false
                },
                      new Schetchik
                {
                    IdKiosk =1, ModelSchetchika="Mirtek", NomerSchetchika=78901, Tarif1=0, Tarif2=0, TarifSumm=0, TexUchet=false
                }
            });

            db.Equipments.AddRange(new List<Equipment>
            {
                new Equipment{ModelEq="Диодная", TypeEq="лампа", PowerEq=8},
                 new Equipment{ModelEq="Люма", TypeEq="лампа", PowerEq=18},
                  new Equipment{ModelEq="Кас-1", TypeEq="Касса", PowerEq=10},
                   new Equipment{ModelEq="Маслянный", TypeEq="Обогреватель", PowerEq=1000}
            });

            db.KioskEqs.AddRange(new List<KioskEq>
            {
                new KioskEq{KioskId=1, EqId=1, Quantity=2},
                new KioskEq{KioskId=1, EqId=2, Quantity=3},
                new KioskEq{KioskId=1, EqId=3, Quantity=1},
                new KioskEq{KioskId=1, EqId=4, Quantity=1},
                new KioskEq{KioskId=2, EqId=1, Quantity=2},
                new KioskEq{KioskId=2, EqId=3, Quantity=1},
                new KioskEq{KioskId=3, EqId=3, Quantity=1},

            });

            db.SaveChanges();

        }

    }
}
