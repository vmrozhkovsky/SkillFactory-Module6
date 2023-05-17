using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory_Module6_Final
{
    public class Order
    {
        public int id;
        Basket basket = new Basket();
    }
    public class Basket
    {
        static int ProductCount = 0;
        int[] ProductIdArray = new int[] { };
        public void NewProduct(int productId)
        {
            ProductCount++;
            ProductIdArray[ProductCount] = productId;
        }
    } 
}
