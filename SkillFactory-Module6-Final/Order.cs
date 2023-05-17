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

    }
    public class Basket
    {
        public Basket(int productcol)
        {
            string[] ProductArray = new string[productcol];
        }
        public int ProductCol;
    } 
}
