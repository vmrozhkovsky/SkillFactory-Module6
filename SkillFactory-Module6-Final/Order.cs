using System;
using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory_Module6_Final
{
    //Обобщающий класс Order. Создан для демонстрации композиции. Так при удалении текущего заказа пользователя, удаляются объекты корзина и доставка.
    public class Order
    {
        //private Bayer<string> bayer;
        private static int CourierNumber;
        private Basket basket;
        private Delivery delivery;
        public int OrderId;

        public Order(int orderId)
        {
            this.OrderId = orderId;
            Basket basket = new Basket();
        }

        public void AddNewProduct(int productId)
        {
            basket.NewProduct(productId);
        }

        public void DeleteProduct(int productId)
        {
            basket.DeleteProduct(productId);
        }
    }
}
