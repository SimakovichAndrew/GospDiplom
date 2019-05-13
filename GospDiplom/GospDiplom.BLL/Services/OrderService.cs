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
    public class OrderService : IOrderService
    {
        IUnitOfWork Database { get; set; }

        public OrderService(IUnitOfWork uow)
        {
            Database = uow;
        }
        public void MakeOrder(KioskDTO orderDto)
        {
            Kiosk phone = Database.Kiosks.Get(orderDto.KioskId);

            // валидация
            if (phone == null)
                throw new ValidationException("Телефон не найден", "");
            // применяем скидку
            //decimal sum = new Discount(0.1m).GetDiscountedPrice(phone.Price);
           Kiosk order = new Kiosk
            {
                Arenda = DateTime.Now,
                ModelKioska = orderDto.ModelKioska,
                Nomer = phone.Nomer,
               IdOsn = orderDto.IdOsn
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
                throw new ValidationException("Не установлено id телефона", "");
            var phone = Database.Kiosks.Get(id.Value);
            if (phone == null)
                throw new ValidationException("Телефон не найден", "");

            return new KioskDTO { ModelKioska = phone.ModelKioska, KioskId = phone.KioskId, Nomer = phone.Nomer, IdOsn = phone.IdOsn };
        }

        public IEnumerable<KioskDTO> GetKiosks()
        {
            // применяем автомаппер для проекции одной коллекции на другую
            var mapper = new MapperConfiguration(cfg => cfg.CreateMap<Kiosk, KioskDTO>()).CreateMapper();
            return mapper.Map<IEnumerable<Kiosk>, List<KioskDTO>>(Database.Kiosks.GetAll());
        }
    }
}
