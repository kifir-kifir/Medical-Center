using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Практика24_App
{
    public class Appointment 
    {
        public int ID { get; set; }
        static int count = 0;
        public int Doctor_ID { get; set; }
        public int Patient_ID { get; set; }
        public DateTime DateTime { get; set; }

        public Appointment() { }

        public Appointment(Doctor doctor, Patient patient, DateTime dateTime)
        {
            ID = ++count;
            Doctor_ID = doctor.ID;
            Patient_ID = patient.ID;
            DateTime = dateTime;
        }

        // Добавление новой записи.
        public static string AddAppointment(Doctor doctor, Patient patient, DateTime date)
        {
            // проверка 1: работает ли врач в эту смену?
            if (doctor.IsAppointment(date))
            {
                // Проверка 2: занят ли врач другим пациентом?
                if (CheckDoctorAppointment(doctor, date))
                {
                    // Проверка 3: свободен ли пациент в это время?
                    if (CheckPatientAppointment(patient, date))
                    {
                        using (UserContext db = new UserContext())
                        {
                            Appointment temp = new Appointment(doctor, patient, date);
                            db.Appointments.Add(temp);
                            db.SaveChanges();
                        }

                        return $"Успешно. {patient.Surname} записан на прием к {doctor.Surname} - {doctor.Position} на дату: {date}.";
                    }
                }
                else
                {
                    return "Ошибка: в данное время уже ведется приём другого пациента";
                }
            }
            else
            {
                return "Ошибка: врач не принимает в данные часы";
            }

            return "Ошибка: Невозможно провести запись";
        }

        // Проверяет, занят ли врач каким-либо пациентом в это время
        public static bool CheckDoctorAppointment(Doctor doctor, DateTime date)
        {
            using (UserContext db = new UserContext())
            {
                var appointments = db.Appointments.Where(n => n.Doctor_ID == doctor.ID);
                foreach (Appointment appointment in appointments)
                {
                    if (date < appointment.DateTime.AddMinutes(30) && date > appointment.DateTime.AddMinutes(-30))
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        // Проверяет, занят ли пациент в это время
        public static bool CheckPatientAppointment(Patient patient, DateTime date)
        {
            using (UserContext db = new UserContext())
            {
                var appointments = db.Appointments.Where(n => n.Patient_ID == patient.ID);
                foreach (Appointment appointment in appointments)
                {
                    if (date < appointment.DateTime.AddMinutes(30) && date > appointment.DateTime.AddMinutes(-30))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    } 
}
