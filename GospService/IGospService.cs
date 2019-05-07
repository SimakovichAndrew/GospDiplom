using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GospService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени интерфейса "IGospService" в коде и файле конфигурации.
    [ServiceContract]
    public interface IGospService
    {
        [OperationContract]
        List<Kiosk> GetAllUser();
        [OperationContract]
        int AddUser(int? Nomer, string Model);
        [OperationContract]
        Kiosk GetAllUserById(int id);

        [OperationContract]
        int UpdateUser(int Id, int Nomer, string Model);

        [OperationContract]
        int DeleteUserById(int Id);
    }


    [DataContract]
    public class Kioski
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int Nomer { get; set; }
        [DataMember]
        public string Model { get; set; }


    }
}
