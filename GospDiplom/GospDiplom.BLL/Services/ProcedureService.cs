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
        public void MakeProcedure(KioskDTO procedure)
        {
            Kiosk kiosk = Database.Kiosks.Get(procedure.KioskId);

            // валидация
            if (kiosk == null)
                throw new ValidationException("Киоск не найден", "");
            // применяем скидку
            //decimal sum = new Discount(0.1m).GetDiscountedPrice(counter.Price);
           Kiosk order = new Kiosk
            {
                Arenda = DateTime.Now,
                ModelKioska = procedure.ModelKioska,
                Nomer = kiosk.Nomer,
              // SchetchikId = procedure.OsnId
            };
            Database.Kiosks.Create(order);
            Database.Save();
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

            return new KioskDTO { ModelKioska = kiosk.ModelKioska, KioskId = kiosk.KioskId, Nomer = kiosk.Nomer };
        }

        public IEnumerable<KioskDTO> GetKiosks()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Kiosk, KioskDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Kiosk>, List<KioskDTO>>(Database.Kiosks.GetAll());
        }

        public SchetchikDTO GetSchetchik(int? id)
        {
            if (id == null)
                throw new ValidationException("Не установлено id счетчика", "");
            var counter = Database.Schetchiks.Get(id.Value);
            if (counter == null)
                throw new ValidationException("Счетчик  не найден", "");

            return new SchetchikDTO { ModelSchetchika = counter.ModelSchetchika, /*KioskId = counter.KioskEqId,*/ NomerSchetchika = counter.NomerSchetchika, TexUchet=counter.TexUchet };
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
    }
}
