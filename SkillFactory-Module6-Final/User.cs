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
    public abstract class User<TPassword>
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
}
