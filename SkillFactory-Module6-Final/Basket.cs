using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory_Module6_Final
{
    public class Basket
    {
        static int ProductCount = 0;
        List<int> Products = new List<int>();

        public void NewProduct(int productId)
        {
            ProductCount++;
            Products.Add(productId);
            //foreach(var item in Products)
            //{
            //    Console.WriteLine(item);
            //}
        }
        public void DeleteProduct(int productId)
        {
            Products.Remove(productId);
            ProductCount--;
        }
    }
}
