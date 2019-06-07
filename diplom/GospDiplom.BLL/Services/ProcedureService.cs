using GospDiplom.BLL.Interfaces;
using GospDiplom.DAL.Interfaces;
using GospDiplom.DAL.Entities;
using GospDiplom.BLL.Infrastructure;
using GospDiplom.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;

namespace GospDiplom.BLL.Services
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
                    //Tarif1 = indication.GetEnumerator().Current.Tarif1,
                    //Tarif2 = indication.GetEnumerator().Current.Tarif2,
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

            return new KioskDTO { ModelKioska = kiosk.ModelKioska, KioskId = kiosk.KioskId, Nomer = kiosk.Nomer, Adress=kiosk.Adress, Arenda=kiosk.Arenda, Town=kiosk.Town };
        }

        public IEnumerable<KioskDTO> GetKiosks()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Kiosk, KioskDTO>()).CreateMapper();
            var temp= mapper.Map<IEnumerable<Kiosk>, List<KioskDTO>>(Database.Kiosks.GetAll());
            int i = 0;
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

            return new SchetchikDTO { ModelSchetchika = counter.ModelSchetchika, /*Kiosk = counter.KioskEqId,*/ NomerSchetchika = counter.NomerSchetchika, TexUchet=counter.TexUchet };
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

            return new IndicationDTO {Tarif1 = value.Tarif1, Tarif2 = value.Tarif2, TarifSumm = value.TarifSumm, Month=value.Month };
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

            return new OrganizationDTO { OrgName=value.OrgName, Dogovor=value.Dogovor, Email=value.Email, Telefon=value.Telefon, /*Kiosks=value.Kiosks,*/ OrganizationId=value.OrganizationId };
           //throw new NotImplementedException();
        }
    }
}
