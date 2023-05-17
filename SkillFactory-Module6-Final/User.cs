using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillFactory_Module6_Final
{
    //Абстрактный класс User. Для демонстрации обобщения классов и методов предполагается, что из формы регистрации пользователя в качестве пароля может прийти string или int. 
    abstract class User<TPassword>
    {
        private int age;
        public virtual int UserAge
        {
            get
            {
                return age;
            }
            set 
            {
                if (value > 18) age = value;
                else Console.WriteLine("Вы не можете сделать покупку в нашем магазине, т.к. вам нет 18 лет.");
            }
        }
        protected TPassword UserPassword
        {
            get;
            private set;
        }
        public string UserName;
        public string UserLastName;
        public string UserEmail;
        public string UserPhone;
        public string UserAddress;

        public User(string name, string lastname, string email, string phone, TPassword password, int age)
        {
            this.UserName = name;
            this.UserLastName = lastname;
            this.UserEmail = email;
            this.UserPhone = phone;
            this.UserPassword = password;
            this.UserAge = age;
        }
        protected virtual void ChangeUserPassword(TPassword newPassword)
        {
            this.UserPassword = newPassword;
        }
    }

    class Admin<T> : User<T>
    {
        public static int AdminPasswordMinLength = 8;
        public Admin(string name, string lastname, string email, string phone, T password, int age) : base(name, lastname, email, phone, password, age)
        {
            if (CheckPassword(password))
            {
                Console.WriteLine("Пользователь создан");
            }
            //if (UserPassword is string userPasswordString)
            //{
            //    if (userPasswordString.Length < AdminPasswordMinLength)
            //    {
            //        Console.WriteLine("Слишком короткий пароль администратора. Должен содержать более 8 символов.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Для администратора нельзя использовать цифровой пароль");
            //}
        }

        public override int UserAge
        {
            get
            {
                return base.UserAge;
            }
            set 
            {
                if (value > 21) base.UserAge = value;
                else Console.WriteLine("Администратор должен быть старше 21 года.");
            }

        }

        protected override void ChangeUserPassword(T newPassword)
        {
            if (CheckPassword(newPassword))
            {
                base.ChangeUserPassword(newPassword);
                Console.WriteLine("Пароль администратора изменен.");
            }
            //if (newPassword is string userPasswordString)
            //{
            //    if (userPasswordString.Length < AdminPasswordMinLength)
            //    {
            //        Console.WriteLine("Слишком короткий пароль администратора. Должен содержать более 8 символов.");
            //    }
            //}
            //else
            //{
            //    Console.WriteLine("Для администратора нельзя использовать цифровой пароль");
            //}
        }
        private bool CheckPassword(T password)
        {
            if (password is string userPasswordString)
            {
                if (userPasswordString.Length < AdminPasswordMinLength)
                {
                    Console.WriteLine("Слишком короткий пароль администратора. Должен содержать более 8 символов.");
                }
            }
            else
            {
                Console.WriteLine("Для администратора нельзя использовать цифровой пароль");
            }
            return true;
        }

    }

    class Bayer<T> : User<T>
    {
        Order order = null;
        public Bayer(string name, string lastname, string email, string phone, T password, int age, int productcol) : base(name, lastname, email, phone, password, age)
        {

        }
        public void AddProduct(int productId)
        {
            if (order == null) 
            { 
                Order order = new Order();
            }
            else
            {

            }
        }

    }

}
