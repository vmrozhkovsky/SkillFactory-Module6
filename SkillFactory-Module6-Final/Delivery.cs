using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory_Module6_Final
{
    //Класс доставки создан для демонстрации агрегации. 
    public class Delivery
    {
        public Delivery(string name, string address) { }
        
        private Courier<string> OrderCourier;
        public Delivery(Courier<string> courier)
        {
            this.OrderCourier = courier;
        }

    }
}
