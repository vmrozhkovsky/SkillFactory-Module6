using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory_Module6_Final
{
    //Класс для создания списка курьеров
    public class Courier
    {
        static List<string> Couriers;
        public string CourierName;

        static Courier()
        {
            List<string> Couriers = new List<string>() { "Courier1", "Courier2", "Courier3" };
        }

        public Courier(int courierNumber)
        {
            CourierName = Couriers[courierNumber];
            Couriers.Remove(CourierName);
        }
    }
}
