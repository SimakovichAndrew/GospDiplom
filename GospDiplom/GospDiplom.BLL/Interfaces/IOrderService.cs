using GospDiplom.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GospDiplom.BLL.Interfaces
{
    public interface IOrderService:IDisposable
    {
        void MakeOrder(KioskDTO orderDto);//какя-то функциональность
        KioskDTO GetKiosk(int? id); //Выбор киоска для работы с ним
        IEnumerable<KioskDTO> GetKiosks();//получение всех киосеов
       //void Dispose();// ???
    }
}
