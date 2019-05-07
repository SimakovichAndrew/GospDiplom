using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace GospService
{
    // ПРИМЕЧАНИЕ. Команду "Переименовать" в меню "Рефакторинг" можно использовать для одновременного изменения имени класса "GospService" в коде, SVC-файле и файле конфигурации.
    // ПРИМЕЧАНИЕ. Чтобы запустить клиент проверки WCF для тестирования службы, выберите элементы GospService.svc или GospService.svc.cs в обозревателе решений и начните отладку.
    public class GospService : IGospService
    {
        public void DoWork()
        {
        }
        public List<Kiosk> GetAllUser()
        {
            List<Kiosk> userlst = new List<Kiosk>();
            diplomEntities tstDb = new diplomEntities();
            var lstUsr = from k in tstDb.Kioski select k;
            foreach (var item in lstUsr)
            {
                Kiosk usr = new Kiosk();
                usr.IdKiosk = item.IdKiosk;
                usr.nomer = item.nomer;
                usr.model = item.model;
                userlst.Add(usr);

            }

            return userlst;
        }



        public Kiosk GetAllUserById(int id)
        {

            diplomEntities tstDb = new diplomEntities();
            var lstUsr = from k in tstDb.Kioski where k.IdKiosk == id select k;
            Kiosk usr = new Kiosk();
            foreach (var item in lstUsr)
            {

                usr.IdKiosk = item.IdKiosk;
                usr.nomer = item.nomer;
                usr.model = item.model;


            }

            return usr;
        }

        public int DeleteUserById(int Id)
        {

            diplomEntities tstDb = new diplomEntities();
            Kiosk usrdtl = new Kiosk();
            usrdtl.IdKiosk = Id;
            tstDb.Entry(usrdtl).State = EntityState.Deleted;
            int Retval = tstDb.SaveChanges();
            return Retval;
        }

        public int AddUser(int? Nomer, string Model)
        {
            diplomEntities tstDb = new diplomEntities();
            Kiosk usrdtl = new Kiosk();
            usrdtl.nomer = Nomer;
            usrdtl.model = Model;
            tstDb.Kioski.Add(usrdtl);
            int Retval = tstDb.SaveChanges();
            return Retval;
        }
        public int UpdateUser(int Id, int Nomer, string Model)
        {
            diplomEntities tstDb = new diplomEntities();
            Kiosk usrdtl = new Kiosk();
            usrdtl.IdKiosk = Id;
            usrdtl.nomer = Nomer;
            usrdtl.model = Model;
            tstDb.Entry(usrdtl).State = EntityState.Modified;

            int Retval = tstDb.SaveChanges();
            return Retval;
        }
    }
}
