using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory_Module6_Final
{
    //Класс для создания объекта пользователя Admin, с проверкой сложности пароля
    public class Admin<T> : User<T>
    {
        public static int AdminPasswordMinLength = 8;

        public Admin(string login, string name, T password, int age, string address) : base(login, name, password, age, address)
        {
            if (CheckPassword(password))
            {
                Console.WriteLine("Пользователь создан");
            }
        }

        public Admin(string login, T password) : base(login, password)
        {
            if (CheckPassword(password))
            {
                Console.WriteLine("Простой пользователь создан");
            }
        }

        public override int UserAge
        {
            get
            {
                return base.UserAge;
            }
            set
            {
                if (value > 21)
                {
                    base.UserAge = value;
                }
                else
                {
                    Console.WriteLine("Администратор должен быть старше 21 года.");
                }
            }
        }

        public override void ChangeUserPassword(T newPassword)
        {
            if (CheckPassword(newPassword))
            {
                base.ChangeUserPassword(newPassword);
                Console.WriteLine("Пароль администратора изменен.");
            }
        }

        private bool CheckPassword(T password)
        {
            if (password is string userPasswordString)
            {
                if (userPasswordString.Length < AdminPasswordMinLength)
                {
                    Console.WriteLine("Слишком короткий пароль администратора. Должен содержать более 8 символов.");
                    return false;
                }
            }
            else
            {
                Console.WriteLine("Для администратора нельзя использовать цифровой пароль");
                return false;
            }
            return true;
        }

    }
}
