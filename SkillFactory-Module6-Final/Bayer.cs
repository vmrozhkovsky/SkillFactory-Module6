using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory_Module6_Final
{
    //Класс для создания объекта пользователя покупатель
    public class Bayer<T> : User<T>
    {
        Order UserOrder = null;
        private int OrderId = 1;
        public Bayer(string login, string name, T password, int age, string address) : base(login, name, password, age, address)
        {
            Console.WriteLine("Пользователь создан");
        }

        public Bayer(string login, T password) : base(login, password)
        {
            Console.WriteLine("Для покупателя не доступно создание простого пользователя. Заполните все поля.");
        }

        public void AddNewOrder(int orderId)
        {
            OrderId = orderId;
            if (UserOrder == null)
            {
                Order UserOrder = new Order(OrderId);
                this.OrderId++;
            }
            else
            {
                Console.WriteLine("Заказ уже существует.");
            }
        }

        public void AddNewOrder()
        {
            if (UserOrder == null)
            {
                Order UserOrder = new Order(OrderId);
                this.OrderId++;
            }
            else
            {
                Console.WriteLine("Заказ уже существует.");
            }
        }

        public override void ChangeUserPassword(T newPassword)
        {
            base.ChangeUserPassword(newPassword);
            Console.WriteLine("Пароль пользователя изменен.");
        }

    }
}
