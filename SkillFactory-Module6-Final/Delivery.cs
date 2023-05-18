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
        private Courier<string> OrderCourier;
        private string DeliveryName;
        private string DeliveryAddress;
        private string DeliveryDescription;
        public enum DeliveryType
        {
            HomeDelivery,
            PostDelivery,
            Pickup
        }

        public Delivery(string name, string address, DeliveryType deliverytype, Courier<string> courier)
        {
            this.OrderCourier = courier;
            this.DeliveryName = name;
            this.DeliveryAddress = address;
            if (!(deliverytype == DeliveryType.Pickup) ) 
            {
                Console.WriteLine("Тип доставки {0}, имя курьера - {1}", deliverytype, OrderCourier.UserName);
            }
            else
            {
                Console.WriteLine("Выбран самолвывоз.");
            }
        }
        
        public Delivery(string name, Courier<string> courier)
        {
            this.OrderCourier = courier;
            this.DeliveryName = name;
        }

    }
}
