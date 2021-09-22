using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика24_App
{
    public class Patient : Person
    {
        public int ID { get; set; }
        static int count = 0;
        public string PolisNumber { get; set; }
        public string Diagnosis { get; set; }

        public Patient() { }

        public Patient(string surname, string name, string patronomic, DateTime dateTime, sex sex, string phone, string polisNumber, string diagnosis)
        : base(surname, name, patronomic, dateTime, sex, phone)
        {
            ID = ++count;
            PolisNumber = polisNumber;
            Diagnosis = diagnosis;
        }

        public override string GetInfo()
        {
            return base.GetInfo() + $"Номер полиса: {PolisNumber}";
        }

        public override string GetFullInfo()
        {
            if (Diagnosis == "")
            {
                Diagnosis = "отсутствует";
            }

            return base.GetFullInfo() + $"Номер полиса: {PolisNumber}\n{Diagnosis}";
        }
    }
}
