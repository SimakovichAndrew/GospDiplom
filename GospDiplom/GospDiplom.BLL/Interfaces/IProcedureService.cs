using GospDiplom.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GospDiplom.BLL.Interfaces
{
    public interface IProcedureService:IDisposable
    {
        void MakeProcedure(KioskDTO orderDto);//какя-то функциональность
        KioskDTO GetKiosk(int? id); //Выбор киоска для работы с ним
        IEnumerable<KioskDTO> GetKiosks();//получение всех киосkов
        IndicationDTO GetIndication(int? id);
        IEnumerable<IndicationDTO> GetIndications();
        SchetchikDTO GetSchetchik(int? id); //Выбор счетчика для работы с ним
        IEnumerable<SchetchikDTO> GetCounters();//получение всех счетчиков
        //void Dispose();// ???
    }
}
