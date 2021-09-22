using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика24_App
{
    public class Doctor : Person
    {
        public string Position { get; set; }
        public int Office { get; set; }
        public string WorkingDays { get; set; }
        public int ID { get; set; }
        static int count = 0;

        public Doctor() { }

        public Doctor(string surname, string name, string patronomic, DateTime dateTime, sex sex, string phone, string position, int office, string workingDays)
        :base(surname, name, patronomic, dateTime, sex, phone)
        {
            ID = ++count;
            Position = position;
            Office = office;
            WorkingDays = workingDays;
        }

        public override string GetInfo()
        {
            return $"Специальность: {Position}\n" + base.GetInfo() + $"Кабинет: {Office}";
        }

        // Показывает время работы врача
        public string GetWorkingDays()
        {
            StringBuilder temp = new StringBuilder(128);
            temp.Append(base.GetFullInfo() + $"Специальность: {Position}\nКабинет: {Office}\n\nПринимает:");

            temp.Append("\nПонедельник: ");
            if (WorkingDays[0] == '1') temp.Append("с 14.00 до 18.00");
            else temp.Append("с 8.00 до 13.00");

            temp.Append("\nВторник: ");
            if (WorkingDays[1] == '1') temp.Append("с 14.00 до 18.00");
            else temp.Append("с 8.00 до 13.00");

            temp.Append("\nСреда: ");
            if (WorkingDays[2] == '1') temp.Append("с 14.00 до 18.00");
            else temp.Append("с 8.00 до 13.00");

            temp.Append("\nЧетверг: ");
            if (WorkingDays[3] == '1') temp.Append("с 14.00 до 18.00");
            else temp.Append("с 8.00 до 13.00");

            temp.Append("\nПятница: ");
            if (WorkingDays[4] == '1') temp.Append("с 14.00 до 18.00");
            else temp.Append("с 8.00 до 13.00");

            return temp.ToString();
        }

        // принимает ли врач в данные часы
        public bool IsAppointment(DateTime date)
        {
            // не принимаем по выходным
            if ((int)date.DayOfWeek > 5)
            {
                return false;
            }

            if (WorkingDays[(int)date.DayOfWeek - 1] == '1') // 14-18
            {
                if (date.Hour >= 14 && date.Hour < 18)
                {
                    return true;
                }
            }
            else // 8-13
            {
                if (date.Hour >= 8 && date.Hour < 13)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
