using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Практика24_App
{
    public partial class FormAppointment : Form
    {
        Form_main mainForm;
        int Id; // id пациента для которого проводится прием
        Patient currentPatient;
        Doctor currentDoctor;
        DateTime currentDate = DateTime.Now;

        public FormAppointment(Form_main f, int id)
        {
            InitializeComponent();
            this.CenterToScreen();
            mainForm = f;
            this.Id = id;
        }

        private void FormAppointment_Load(object sender, EventArgs e)
        {
            currentPatient = mainForm.GetPatients()
                .Where(n => n.ID == Id)
                .FirstOrDefault();

            Text = $"Запись на прием ({currentPatient.Surname} {currentPatient.Name})";

            if (currentPatient != null)
            {
                // формируем периоды
                DateTime startDateMain;
                DateTime currentDate = DateTime.Now;
                int currentDay = (int)currentDate.DayOfWeek;
                if (currentDay == 0) // перевод из американской системы
                {
                    currentDay = 7;
                }
                currentDay--;

                startDateMain = currentDate.AddDays(-currentDay); // получили начало текущей недели

                for (int i = 0; i < 4; i++) // запись на ближайшие 4 недели
                {
                    comboBox_period.Items.Add(startDateMain.ToString("d") + " - " + startDateMain.AddDays(6).ToString("d"));
                    startDateMain = startDateMain.AddDays(7);
                }
            }
            else
            {
                MessageBox.Show(this, $"Пациент {currentPatient.Surname} не найден", "Ошибка");
            }

            foreach (var doctor in mainForm.GetDoctors())
            {
                comboBox_Doctors.Items.Add($"{doctor.Surname} {doctor.Name} {doctor.Patronomic} ({doctor.Position}) Каб. {doctor.Office}");
            }
        }

        private void comboBox_period_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            string selected = (string)comboBox.SelectedItem;

            DateTime dateStart = DateTime.Parse(selected.Split(' ')[0]);
            currentDate = dateStart;

            // обновляем список доступных записей для текущей недели
            UpdateAll(dateStart);
        }

        private void comboBox_Doctors_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;


            string selectedDoctorStr = (string)comboBox.SelectedItem;
            // вычленяем из полученой строки кабинета (он идет последний)
            string[] dived = selectedDoctorStr.Split(' ');
            int searchOffice = int.Parse(dived[dived.Length - 1]);
            currentDoctor = mainForm.GetDoctors()
                .Where(n => n.Office == searchOffice)
                .FirstOrDefault();
            
            if (currentDoctor == null)
            {
                MessageBox.Show(this, $"Доктор с Фамилией: {dived[0]} не найден", "Ошибка");
                Close();
            }

            UpdateAll(currentDate);
        }

        void CreateButtons(int day, FlowLayoutPanel flp)
        {
            DateTime startDate;
            DateTime startDateMain;
            int currentDay = (int)currentDate.DayOfWeek;
            if (currentDay == 0) // перевод из американской системы
            {
                currentDay = 7;
            }
            currentDay--;

            startDateMain = currentDate.AddDays(-currentDay);
            
            if (currentDoctor.WorkingDays[day] == '0') // утро
            {
                startDate = new DateTime(startDateMain.Year, startDateMain.Month, startDateMain.Day, 8, 0, 0);
                startDate = startDate.AddDays(day);
            }
            else // вечер
            {
                startDate = new DateTime(startDateMain.Year, startDateMain.Month, startDateMain.Day, 14, 0, 0);
                startDate = startDate.AddDays(day);
            }

            for (int i = 1; i <= 10; i++)
            {
                Button b = new Button();
                b.Size = new Size(152, 90);
                
                if (startDate <= DateTime.Now || !currentDoctor.IsAppointment(startDate) || !Appointment.CheckDoctorAppointment(currentDoctor, startDate) || !Appointment.CheckPatientAppointment(currentPatient, startDate))
                {
                    b.Enabled = false;
                }
                else
                {
                    DateTime newDate = startDate;
                    b.Click += new System.EventHandler((sender2, e2) => AddAppointment_Handler(sender2, e2, newDate));
                }

                b.Text = $"{startDate.Hour:00}:{startDate.Minute:00}";
                startDate = startDate.AddMinutes(30);
                b.Text += $" - {startDate.Hour:00}:{startDate.Minute:00}";

                flp.Controls.Add(b);
            }
        }

        // обрабатывает событие записи на прием
        void AddAppointment_Handler(object sender, EventArgs e, DateTime dateMeet)
        {
            Button button = (Button)sender;

            string result = Appointment.AddAppointment(currentDoctor, currentPatient, dateMeet);
            MessageBox.Show(this, result, "Результат");

            button.Enabled = false;

            mainForm.UpdateAppointment();
        }

        // Обновляет список всей недели
        void UpdateAll(DateTime fromDate)
        {
            if (currentDoctor != null)
            {
                flowLayoutPanel1.Controls.Clear();
                flowLayoutPanel2.Controls.Clear();
                flowLayoutPanel3.Controls.Clear();
                flowLayoutPanel4.Controls.Clear();
                flowLayoutPanel5.Controls.Clear();

                CreateButtons(0, flowLayoutPanel1);
                CreateButtons(1, flowLayoutPanel2);
                CreateButtons(2, flowLayoutPanel3);
                CreateButtons(3, flowLayoutPanel4);
                CreateButtons(4, flowLayoutPanel5);
            }

        }
    }
}
