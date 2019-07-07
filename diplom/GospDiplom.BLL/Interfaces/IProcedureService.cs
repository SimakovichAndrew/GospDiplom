using GospDiplom.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace GospDiplom.BLL.Interfaces
{
    public interface IProcedureService:IDisposable
    {
        IEnumerable<SchetchikDTO> MakeProcedure(/*KioskDTO orderDto, SchetchikDTO counter, IndicationDTO value*/);//какя-то функциональность
        KioskDTO GetKiosk(int? id); //Выбор киоска для работы с ним
        KioskDTO GetKiosk(string nomer); //Выбор киоска для работы с ним
        IEnumerable<KioskDTO> GetKiosks();//получение всех киосkов
        IndicationDTO GetIndication(int? id);
        IEnumerable<IndicationDTO> GetIndications();
        SchetchikDTO GetSchetchik(int? id); //Выбор счетчика для работы с ним
        IEnumerable<SchetchikDTO> GetCounters();//получение всех счетчиков
        IEnumerable<OrganizationDTO> GetOrganizations();
        OrganizationDTO GetOrganization(int? id);
        IEnumerable<EquipmentDTO> GetEquipments();
        EquipmentDTO GetEquipment(int? id);
        IEnumerable<AllTable> GetAllKioski();
        KioskDTO GetInfokiosk(string nomer);
        IEnumerable<AllCounter> GetAllCounters();
        AllCounter GetInfoCounter(int? id);
        void CreateIndication(string nomer, double tarif1, double tarif2);
        //void Dispose();// ???
    }
}
