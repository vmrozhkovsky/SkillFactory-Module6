using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory_Module6_Final
{
    public class Courier<T> : User<T>
    {
        public Courier(string login, string name, T password, int age, string address) : base(login, name, password, age, address)
        {
            Console.WriteLine("Пользователь создан");
        }

        public Courier(string login, T password) : base(login, password)
        {
            Console.WriteLine("Для курьера не доступно создание простого пользователя. Заполните все поля.");
        }
    }
}
