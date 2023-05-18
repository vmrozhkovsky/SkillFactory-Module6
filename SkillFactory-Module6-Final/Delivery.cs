using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory_Module6_Final
{
    //Класс доставки создан для демонстрации агрегации. Использует класс Courier. 
    public class Delivery
    {
        private string DeliveryName;
        private string DeliveryAddress;
        private Courier OrderCourier;
        public enum DeliveryType
        {
            HomeDelivery,
            PostDelivery,
            Pickup
        }

        public Delivery(string name, string address, DeliveryType deliverytype, Courier courier)
        {
            this.OrderCourier = courier;
            this.DeliveryName = name;
            this.DeliveryAddress = address;
            if (!(deliverytype == DeliveryType.Pickup) ) 
            {
                Console.WriteLine("Тип доставки {0}, имя курьера - {1}", deliverytype, OrderCourier.CourierName);
            }
            else
            {
                Console.WriteLine("Выбран самовывоз.");
            }
        }
    }
}
