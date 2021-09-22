using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика24_App
{
    public enum sex { Мужской, Женский }

    public class Person
    {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronomic { get; set; }
        public sex Sex { get; set; } //0 - male, 1 - female
        public string Phone { get; set; }
        public DateTime DateTime { get; set; }

        public Person() { }

        public Person(string surname, string name, string patronomic, DateTime dateTime, sex sex, string phone)
        {
            Surname = surname;
            Name = name;
            Patronomic = patronomic;
            DateTime = dateTime;
            Sex = sex;
            Phone = phone;
        }

        public virtual string GetInfo()
        {
            return $"Фамилия: {Surname}\nИмя: {Name}\nОтчество: {Patronomic}\nТелефон: {Phone}\n";
        }

        public virtual string GetFullInfo()
        {
            return $"Фамилия: {Surname}\nИмя: {Name}\nОтчество: {Patronomic}\nПод: {Sex}\nДата рождения: {DateTime.ToString("d")}\nТелефон: {Phone}\n";
        }
    }
}
