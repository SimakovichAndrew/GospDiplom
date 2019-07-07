﻿using GospDiplom.BLL.Interfaces;
using GospDiplom.DAL.Interfaces;
using GospDiplom.DAL.Entities;
using GospDiplom.BLL.Infrastructure;
using GospDiplom.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using System.Linq;

namespace GospDiplom.BLL.Service
{
    public class ProcedureService : IProcedureService
    {
        IUnitOfWork Database { get; set; }

        public ProcedureService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public IEnumerable<SchetchikDTO> MakeProcedure(/*KioskDTO procedure, SchetchikDTO counter, IndicationDTO value*/ )
        {
            IEnumerable<Kiosk> kiosk = Database.Kiosks.GetAll();
            // Indication tarif1 = Database.Indications.Get(3);

            //IEnumerable<Schetchik> schetchik = Database.Schetchiks.GetAll();
            IEnumerable<Indication> indication = Database.Indications.GetAll();

            // валидация
            if (kiosk == null)
                throw new ValidationException("Киоск не найден", "");
            // применяем скидку
            //decimal sum = new Discount(0.1m).GetDiscountedPrice(counter.Price);

            IEnumerable<SchetchikDTO> order = new List<SchetchikDTO>();
            for (int i = 0; i < 3; i++)
            {
                SchetchikDTO neworder = new SchetchikDTO
                {
                    //Nomer = kiosk.GetEnumerator().Current.Nomer.ToString(),
                    //Tarif1Start = indication.GetEnumerator().Current.Tarif1Start,
                    //Tarif1End = indication.GetEnumerator().Current.Tarif1End,
                    //Month = indication.GetEnumerator().Current.Month
                    // SchetchikId = procedure.OsnId
                };

            }




            //Database.Kiosks.Create(order);
            //Database.Save();
            return order;
        }

        public void Dispose()
        {
            Database.Dispose();
        }

        public KioskDTO GetKiosk(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id киоска", "");
            var kiosk = Database.Kiosks.Get(id.Value);
            if (kiosk == null)
                throw new ValidationException("Киоск не найден", "");

            return new KioskDTO { ModelKioska = kiosk.ModelKioska, KioskId = kiosk.KioskId, Nomer = kiosk.Nomer, Adress = kiosk.Adress, Arenda = kiosk.Arenda, Town = kiosk.Town.ToString() };
        }

        public IEnumerable<KioskDTO> GetKiosks()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Kiosk, KioskDTO>()).CreateMapper();
            var temp = mapper.Map<IEnumerable<Kiosk>, List<KioskDTO>>(Database.Kiosks.GetAll());
            //Mapper.Initialize(cfg => cfg.CreateMap<Kiosk, KioskDTO>());
            //var kioski = Mapper.Map<IEnumerable<Kiosk>, List<KioskDTO>>(Database.Kiosks.GetAll());
            //int i = 0;
            return temp;
        }

        public IEnumerable<KioskDTO> GetKiosksWithOrg()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            //var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Kiosk, KioskDTO>()).CreateMapper();
            return Mapper.Map<IEnumerable<Kiosk>, List<KioskDTO>>(Database.Kiosks.GetAll());
        }

        public SchetchikDTO GetSchetchik(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id счетчика", "");
            var counter = Database.Schetchiks.Get(id.Value);
            if (counter == null)
                throw new ValidationException("Счетчик  не найден", "");

            return new SchetchikDTO { ModelSchetchika = counter.ModelSchetchika, /*Kiosk = counter.KioskEqId,*/ NomerSchetchika = counter.NomerSchetchika, TexUchet = counter.TexUchet };
        }

        public IEnumerable<SchetchikDTO> GetCounters()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Schetchik, SchetchikDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Schetchik>, List<SchetchikDTO>>(Database.Schetchiks.GetAll());
        }

        public IndicationDTO GetIndication(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id Тарифа", "");
            var value = Database.Indications.Get(id.Value);
            if (value == null)
                throw new ValidationException("Показания не найдены", "");

            return new IndicationDTO { Tarif1 = value.Tarif1, Tarif2 = value.Tarif2, TarifSumm = value.TarifSumm, Month = value.Month };
            //throw new NotImplementedException();
        }

        public IEnumerable<IndicationDTO> GetIndications()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Indication, IndicationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Indication>, List<IndicationDTO>>(Database.Indications.GetAll());

            //throw new NotImplementedException();
        }

        public IEnumerable<OrganizationDTO> GetOrganizations()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Organization, OrganizationDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Organization>, List<OrganizationDTO>>(Database.Organizations.GetAll());
            //throw new NotImplementedException();
        }

        public OrganizationDTO GetOrganization(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id организации", "");
            var value = Database.Organizations.Get(id.Value);
            if (value == null)
                throw new ValidationException("Организация  не найдена", "");

            return new OrganizationDTO { OrgName = value.OrgName.ToString(), Dogovor = value.Dogovor, Email = value.Email, Telefon = value.Telefon, /*Kiosks=value.Kiosks,*/ OrganizationId = value.OrganizationId };
            //throw new NotImplementedException();
        }

        public IEnumerable<EquipmentDTO> GetEquipments()
        {
            throw new NotImplementedException();
        }

        public EquipmentDTO GetEquipment(int? id)
        {
            throw new NotImplementedException();
        }

        //public IEnumerable<AllTable> GetAllKioski()
        //{
        //    // применяем автомаппер для проекции одной коллекции на другую
        //    var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Kiosk, KioskDTO>()).CreateMapper();
        //    var kioski = mapper.Map<IEnumerable<Kiosk>, List<KioskDTO>>(Database.Kiosks.GetAll());

        //    var mapperOrg = new MapperConfiguration(cfg => cfg.CreateMap<Organization, OrganizationDTO>()).CreateMapper();
        //    var org =  mapperOrg.Map<IEnumerable<Organization>, List<OrganizationDTO>>(Database.Organizations.GetAll());

        //    List<AllTable> InfoKiosks = new List<AllTable>();

        //    foreach (var item in kioski )
        //    {
        //        InfoKiosks.Add(
        //            new AllTable {
        //            Kiosk = item,
        //            OrgName = org.Find(p=>p.OrganizationId==item.OrganizationId).OrgName,
        //            Dogovor = org.Find(p => p.OrganizationId == item.OrganizationId).Dogovor,

        //        });

        //    }


        //    return InfoKiosks;
        //    //throw new NotImplementedException();
        //}


        public IEnumerable<AllTable> GetAllKioski()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Kiosk, KioskDTO>()).CreateMapper();
            var temp = mapper.Map<IEnumerable<Kiosk>, List<KioskDTO>>(Database.Kiosks.GetAll());

            var mapperOrg = new MapperConfiguration(cfg => cfg.CreateMap<Organization, OrganizationDTO>()).CreateMapper();
            var org = mapperOrg.Map<IEnumerable<Organization>, List<OrganizationDTO>>(Database.Organizations.GetAll());

            // List<AllTable> InfoKiosks = new List<AllTable>();

            var InfoKiosks = temp
       .Join(
         org,          //  inner sequence
         e => e.OrganizationId,           //  outerKeySelector
         o => o.OrganizationId,           //  innerKeySelector
         (e, o) => new AllTable      //  resultSelector
         {
             Nomer = e.Nomer,
             ModelCounter = e.ModelKioska,
             Gorod = e.Town,
             Adress = e.Adress,
             OrgName = o.OrgName,
             Dogovor = o.Dogovor,
             Arenda = e.Arenda

         });

            return InfoKiosks;
        }

        public KioskDTO GetInfokiosk(string nomer)
        {
            if (nomer == null)
                throw new ValidationException("Не задан номер киоска", "");
            //var kiosk = Database.Kiosks.Get(id.Value);
            var kiosk = Database.Kiosks.GetString(nomer);
            var orgName = Database.Organizations.Get(3);
            if (kiosk == null)
                throw new ValidationException("Киоск не найден", "");
            return new KioskDTO { Adress = kiosk.Adress, Arenda = kiosk.Arenda, Area = kiosk.Area, ModelKioska = kiosk.ModelKioska, Town = kiosk.Town.ToString(), OrganizationId = kiosk.OrganizationId, Nomer = kiosk.Nomer };

            throw new NotImplementedException();
        }

        public IEnumerable<AllCounter> GetAllCounters()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Kiosk, KioskDTO>()).CreateMapper();
            var kioski = mapper.Map<IEnumerable<Kiosk>, List<KioskDTO>>(Database.Kiosks.GetAll());

            var mapperOrg = new MapperConfiguration(cfg => cfg.CreateMap<Organization, OrganizationDTO>()).CreateMapper();
            var org = mapperOrg.Map<IEnumerable<Organization>, List<OrganizationDTO>>(Database.Organizations.GetAll());

            var mapperCount = new MapperConfiguration(cfg => cfg.CreateMap<Schetchik, SchetchikDTO>()).CreateMapper();
            var count = mapperCount.Map<IEnumerable<Schetchik>, List<SchetchikDTO>>(Database.Schetchiks.GetAll());

            var mapperIndication = new MapperConfiguration(cfg => cfg.CreateMap<Indication, IndicationDTO>()).CreateMapper();
            var indicat = mapperIndication.Map<IEnumerable<Indication>, List<IndicationDTO>>(Database.Indications.GetAll());




            var GetInfoCounter = count
                .Join(
                kioski,
                cnt => cnt.KioskId,
                ksk => ksk.KioskId,
                (cnt, ksk) => new
                {
                    ksk.KioskId,
                    ksk.OrganizationId,
                    ksk.Nomer,
                    cnt.NomerSchetchika,
                    cnt.SchetchikId,
                    cnt.TexUchet,
                    cnt.TwoTarif,
                    cnt.ModelSchetchika,

                }).Join(org,
                    cntksk => cntksk.OrganizationId,
                    organ => organ.OrganizationId,
                    (cntksk, organ) => new
                    {
                        cntksk.SchetchikId,
                        cntksk.Nomer,
                        cntksk.NomerSchetchika,
                        cntksk.ModelSchetchika,
                        cntksk.TexUchet,
                        cntksk.TwoTarif,
                        organ.OrgName,
                        organ.Dogovor,
                    }).Join(indicat,
                    cntkskorg => cntkskorg.SchetchikId,
                    indication => indication.SchetchikId,
                    (cntkskorg, indication) => new
                    {
                        cntkskorg.Nomer,
                        cntkskorg.ModelSchetchika,
                        cntkskorg.NomerSchetchika,
                        cntkskorg.TexUchet,
                        cntkskorg.TwoTarif,
                        indication.Tarif1,
                        indication.Tarif2,
                        indication.Month,
                        cntkskorg.OrgName,
                        cntkskorg.Dogovor
                    }).ToList();

            List<AllCounter> GetCounter = new List<AllCounter>();

            double diff = 0;

            for (int i = 0; i < indicat.Count; i++)
            {
                if (String.IsNullOrEmpty((GetInfoCounter.Where(y => y.NomerSchetchika == GetInfoCounter.ElementAt(i).NomerSchetchika).First().Month.Month - 1).ToString()) || (GetInfoCounter.Where(y => y.NomerSchetchika == GetInfoCounter.ElementAt(i).NomerSchetchika).First().Month.Month - 1) == 0)
                    diff = 0;
                else 
                if (GetInfoCounter.Any(x => x.Month.Month == (GetInfoCounter.ElementAt(i).Month.Month - 1) && x.NomerSchetchika == GetInfoCounter.ElementAt(i).NomerSchetchika))
                    diff = GetInfoCounter.Where(x => x.Month.Month == (GetInfoCounter.ElementAt(i).Month.Month - 1) && x.NomerSchetchika == GetInfoCounter.ElementAt(i).NomerSchetchika).First().Tarif1;
                else
                    diff = 0;

              //  var elem = GetInfoCounter.First();
                //    foreach (var item in GetInfoCounter.Where(x=>x.Nomer==GetInfoCounter.ElementAt(i).Nomer))
                //{
                //   var elem = item;
              
                GetCounter.Add(
                new AllCounter{
                    NomerCounter =  GetInfoCounter/*.Where(x => x.Nomer == GetInfoCounter.ElementAt(i).Nomer).ElementAt(y)*/.ElementAt(i).NomerSchetchika,
                    NomerKioska = GetInfoCounter.ElementAt(i).Nomer,
                    ModelCounter = GetInfoCounter.ElementAt(i).ModelSchetchika,
                    Tarif1Start = diff/*GetInfoCounter.ElementAt(i).Tarif1*/,
                    Tarif1End = GetInfoCounter.ElementAt(i).Tarif1,
                    Month = GetInfoCounter.ElementAt(i).Month.ToString("MMMM"),
                    TechUchet = GetInfoCounter.ElementAt(i).TexUchet,
                    TwoTarif = GetInfoCounter.ElementAt(i).TwoTarif,
                    OrgName = GetInfoCounter.ElementAt(i).OrgName,
                    Dogovor = GetInfoCounter.ElementAt(i).Dogovor,
                    Date = GetInfoCounter.ElementAt(i).Month,
                    Span = GetInfoCounter.ElementAt(i).Tarif1 - diff
                }
                );
                //}
            }

            return GetCounter;
            //throw new NotImplementedException();
        }

        public AllCounter GetInfoCounter(int? id)
        {
            throw new NotImplementedException();
        }

        public KioskDTO GetKiosk(string nomer)
        {
            if (nomer == null)
                throw new ValidationException("Не установлен номер киоска", "");
            var kiosk = Database.Kiosks.GetString(nomer);
            if (kiosk == null)
                throw new ValidationException("Киоск не найден", "");

            return new KioskDTO { ModelKioska = kiosk.ModelKioska, KioskId = kiosk.KioskId, Nomer = kiosk.Nomer, Adress = kiosk.Adress, Arenda = kiosk.Arenda, Town = kiosk.Town.ToString() };

            throw new NotImplementedException();
        }

        public /*IndicationDTO*/void CreateIndication(string nomer, double tarif1, double tarif2)
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Kiosk, KioskDTO>()).CreateMapper();
            var kioski = mapper.Map<IEnumerable<Kiosk>, List<KioskDTO>>(Database.Kiosks.GetAll());

            var mapperOrg = new MapperConfiguration(cfg => cfg.CreateMap<Organization, OrganizationDTO>()).CreateMapper();
            var org = mapperOrg.Map<IEnumerable<Organization>, List<OrganizationDTO>>(Database.Organizations.GetAll());

            var mapperCount = new MapperConfiguration(cfg => cfg.CreateMap<Schetchik, SchetchikDTO>()).CreateMapper();
            var count = mapperCount.Map<IEnumerable<Schetchik>, List<SchetchikDTO>>(Database.Schetchiks.GetAll());

            var mapperIndication = new MapperConfiguration(cfg => cfg.CreateMap<Indication, IndicationDTO>()).CreateMapper();
            var indicat = mapperIndication.Map<IEnumerable<Indication>, List<IndicationDTO>>(Database.Indications.GetAll());

            int GetIndication= indicat
                .Where(x=>x.SchetchikId==count.Where(y=>y.KioskId==kioski.Where(k=>k.Nomer==nomer).First().KioskId).First().SchetchikId).First().IndicationId;
            //GetIndication.Tarif1 = tarif1;
            //GetIndication.Tarif2 = tarif2;
            Database.Indications.Get(GetIndication).Tarif1 = tarif1;
            Database.Indications.Get(GetIndication).Tarif2 = tarif2;
            Database.Save();

            //throw new NotImplementedException();
        }
    }
}