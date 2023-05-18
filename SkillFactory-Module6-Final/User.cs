using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SkillFactory_Module6_Final
{
    //Абстрактный класс User. Для демонстрации обобщения классов и методов предполагается, что из формы регистрации пользователя в качестве пароля может прийти string или int. 
    abstract class User<TPassword>
    {

        public virtual int UserAge
        {
            get
            {
                return UserAge;
            }
            set 
            {
                if (value > 18) UserAge = value;
                else Console.WriteLine("Вы не можете сделать покупку в нашем магазине, т.к. вам нет 18 лет.");
            }
        }

        protected TPassword UserPassword
        {
            get;
            private set;
        }

        public string UserLogin;
        public string UserName;
        public string UserAddress;
        public string this[string propname]
        {
            get
            {
                switch (propname)
                {
                    case "Login": return UserLogin;
                    case "Name": return UserName;
                    case "Address": return UserAddress;
                    default: throw new Exception("Не известное свойство пользователя");
                }
            }
            set
            {
                switch (propname)
                {
                    case "Login":
                        UserLogin = value;
                        break;
                    case "Name":
                        UserName = value;
                        break;
                    case "Address":
                        UserAddress = value;
                        break;
                }
            }
        }

        //Конструктор для создания полного профиля пользователя
        public User(string login, string name, TPassword password, int age, string address)
        {
            this.UserLogin = login;
            this.UserName = name;
            this.UserPassword = password;
            this.UserAge = age;
            this.UserAddress = address;
        }

        //Конструктор для создания быстрого профиля пользователя
        public User(string login, TPassword password)
        {
            this.UserPassword = password;
            this.UserLogin = login;
        }

        public virtual void ChangeUserPassword(TPassword newPassword)
        {
            this.UserPassword = newPassword;
        }
    }

    //Класс для создания объекта пользователя Admin, с проверкой сложности пароля
    class Admin<T> : User<T>
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

    //Класс для создания объекта пользователя покупатель
    class Bayer<T> : User<T>
    {
        Order UserOrder = null;
        private int OrderId = 1;
        public Bayer(string login, string name, T password, int age, string address) : base(login, name, password, age, address)
        {
            Console.WriteLine("Пользователь создан");
        }

        public Bayer(string login, T password) : base(login,  password)
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

    class Courier<T> : User<T>
    {
        public Courier(string login, string name, T password, int age, string address) : base(login, name, password, age, address)
        {
            Console.WriteLine("Пользователь создан");
        }

        public Courier(string login, T password) : base(login, password)
        {
            Console.WriteLine("Для покупателя не доступно создание простого пользователя. Заполните все поля.");
        }
    }

}
