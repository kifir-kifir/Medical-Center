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
    public partial class Form_main : Form
    {
        public Form_main()
        {
            InitializeComponent();
            CenterToScreen();
        }

        // Что-то вводят в поле поиска по фамилии доктора
        private void textBox_SearchDoc_TextChanged(object sender, EventArgs e)
        {
            //string currentText = textBox_SearchDoc.Text;
            StringBuilder temp = new StringBuilder(textBox_SearchDoc.Text);
            if(temp.Length != 0)
            {
                temp[0] = char.ToUpper(temp[0]);
            }

            UpdateDoctorsListPanel(temp.ToString());
        }

        // Обновляет список докторов
        void UpdateDoctorsListPanel(string search = "")
        {
            flowLayoutPanel_Doctors.Controls.Clear();

            // получение списка докторов из БД
            using (UserContext db = new UserContext())
            {
                var doctors = db.Doctors.OrderBy(n => n.Surname);

                foreach (Doctor doctor in doctors)
                {
                    // Если идет поиск, то отфильтровываем
                    if (search != "")
                    {
                        if (!doctor.Surname.StartsWith(search)) 
                        {
                            continue;
                        }
                    }

                    Button b = new Button();
                    b.Size = new Size(186, 90);
                    b.TextAlign = ContentAlignment.MiddleLeft;
                    b.Text = doctor.GetInfo();
                    b.Click += new EventHandler((sender2, e2) => this.ShowDoctorDialog(sender2, e2, doctor.ID));

                    flowLayoutPanel_Doctors.Controls.Add(b);
                }
            }
        }

        // Обрабатывает событие открытия откна для врача 
        void ShowDoctorDialog(object sender, EventArgs e, int id)
        {
            var newForm = new FormDoctorDialog(this, id);
            newForm.ShowDialog();
        }

        public List<Doctor> GetDoctors()
        {
            using (UserContext db = new UserContext())
            {
                List<Doctor> doctors = db.Doctors.OrderBy(n => n.Surname).ToList();
                return doctors;
            }  
        }

        // Обрабатывает событие удаления
        public void Delete_Doctor(object sender, EventArgs e, int id)
        {
            using (UserContext db = new UserContext())
            {
                var appointments = db.Appointments.Where(n => n.Doctor_ID == id);
                foreach (Appointment appointment in appointments)
                {
                    AppointmentDelete(appointment.ID);
                }
                UpdateAppointment();

                Doctor item = db.Doctors.SingleOrDefault(r => r.ID == id);
                db.Doctors.Remove(item);
                db.SaveChanges();
                UpdateDoctorsListPanel();
            }
        }

        private void textBox_SearchPatient_TextChanged(object sender, EventArgs e)
        {
            //string currentText = textBox_SearchPatient.Text;
            StringBuilder temp = new StringBuilder(textBox_SearchPatient.Text);
            if (temp.Length != 0)
            {
                temp[0] = char.ToUpper(temp[0]);
            }

            UpdatePatientsListPanel(temp.ToString());
        }

        // Обновляет список докторов
        void UpdatePatientsListPanel(string search = "")
        {
            flowLayoutPanel_Patients.Controls.Clear();

            // получение списка пациентов из БД
            using (UserContext db = new UserContext())
            {
                var patients = db.Patients.OrderBy(n => n.Surname);

                foreach (Patient patient in patients)
                {
                    // Если идет поиск, то отфильтровываем
                    if (search != "")
                    {
                        if (!patient.Surname.StartsWith(search))
                        {
                            continue;
                        }
                    }

                    Button b = new Button();
                    b.Size = new Size(186, 90);
                    b.TextAlign = ContentAlignment.MiddleLeft;
                    b.Text = patient.GetInfo();
                    b.Click += new EventHandler((sender2, e2) => this.ShowPatientDialog(sender2, e2, patient.ID));

                    flowLayoutPanel_Patients.Controls.Add(b);
                }
            }
        }

        // Обрабатывает событие открытия откна для пациета
        void ShowPatientDialog(object sender, EventArgs e, int id)
        {
            var newForm = new FormPatientDialog(this, id);
            newForm.ShowDialog();
        }

        public List<Patient> GetPatients()
        {
            using (UserContext db = new UserContext())
            {
                List<Patient> patients = db.Patients.OrderBy(n => n.Surname).ToList();
                return patients;
            }
        }

        // Обрабатывает событие удаления
        public void Delete_Patient(object sender, EventArgs e, int id)
        {
            using (UserContext db = new UserContext())
            {
                var appointments = db.Appointments.Where(n => n.Patient_ID == id);
                foreach (Appointment appointment in appointments)
                {
                    AppointmentDelete(appointment.ID);
                }
                UpdateAppointment();

                Patient item = db.Patients.SingleOrDefault(r => r.ID == id);
                db.Patients.Remove(item);
                db.SaveChanges();
                UpdatePatientsListPanel();
            }
        }

        private void textBox_SearchAppointment_TextChanged(object sender, EventArgs e)
        {
            //string currentText = textBox_SearchAppointment.Text;
            StringBuilder temp = new StringBuilder(textBox_SearchAppointment.Text);
            if (temp.Length != 0)
            {
                temp[0] = char.ToUpper(temp[0]);
            }


            UpdateAppointment(temp.ToString());
        }

        public void UpdateAppointment(string search = "")
        {
            flowLayoutPanel_Appointments.Controls.Clear();

            using (UserContext db = new UserContext())
            { 
                var appointments = db.Appointments.OrderBy(n => n.DateTime).ToList();

                foreach (Appointment appointment in appointments)
                {
                    Patient item1 = db.Patients
                   .Where(n => n.ID == appointment.Patient_ID)
                   .FirstOrDefault();

                    // Если идет поиск, то отфильтровываем
                    if (search != "")
                    {

                        if (!item1.Surname.StartsWith(search))
                        {
                            continue;
                        }
                    }

                    Doctor item2 = db.Doctors
                    .Where(n => n.ID == appointment.Doctor_ID)
                    .FirstOrDefault();

                    Label tmp = new Label();
                    tmp.AutoSize = false;
                    tmp.Padding = new Padding(0, 6, 0, 0);
                    tmp.Text = "Доктор: " + item2.Surname + " " + item2.Name + " - " + item2.Position + "\nКабинет: " + item2.Office + "\n";
                    tmp.Text += "Пациент: " + item1.Surname + " " + item1.Name + "\n";
                    tmp.Text += "Дата приема: " + appointment.DateTime.ToString();
                    tmp.Width = 500;
                    tmp.Height = 65;

                    var flow = new TableLayoutPanel();
                    flow.AutoSize = true;
                    flow.Controls.Add(tmp, 0, 0);

                    Button b = new Button();
                    b.Text = "Отменить запись";
                    b.AutoSize = true;
                    b.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);

                    b.Click += new System.EventHandler((sender, e) => this.AppointmentDelete(appointment.ID));
                    flow.Controls.Add(b, 1, 0);

                    flowLayoutPanel_Appointments.Controls.Add(flow);
                }
            }
        }

        public void AppointmentDelete(int id)
        {
            using (UserContext db = new UserContext())
            {
                var itemToRemove = db.Appointments.SingleOrDefault(n => n.ID == id);
                if (itemToRemove != null)
                {
                    db.Appointments.Remove(itemToRemove);
                    db.SaveChanges();
                }
            }
            UpdateAppointment();
        }

        // Открывает окно с вводом данных о враче
        private void button1_Click(object sender, EventArgs e)
        {
            var newForm = new FormAddDoctor(this);
            newForm.ShowDialog();
        }

        public void AddDoctor(string surname, string name, string patronomic, DateTime date, sex sex, string tel, string pos, int office, string workingDays)
        {
            using (UserContext db = new UserContext())
            {
                Doctor tmp = new Doctor(surname, name, patronomic, date, sex, tel, pos, office, workingDays);

                db.Doctors.Add(tmp);
                db.SaveChanges();
            }
            UpdateDoctorsListPanel();
        }

        // Открывает окно с вводом данных о новом пациенте
        private void button2_Click(object sender, EventArgs e)
        {
            var newForm = new FormAddPatient(this);
            newForm.ShowDialog();
        }

        public void AddPatient(string surname, string name, string patronomic, DateTime date, sex sex, string tel, string polisNum, string diagnosis)
        {
            using (UserContext db = new UserContext())
            {
                Patient tmp = new Patient(surname, name, patronomic, date, sex, tel, polisNum, diagnosis);
                db.Patients.Add(tmp);
                db.SaveChanges();
            }
            UpdatePatientsListPanel();
        }

        private void Form_main_Load(object sender, EventArgs e)
        {
            UpdateAppointment();
            UpdateDoctorsListPanel();
            UpdatePatientsListPanel();
        }
    }
}
