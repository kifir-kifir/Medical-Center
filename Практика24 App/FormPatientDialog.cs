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
    public partial class FormPatientDialog : Form
    {
        Form_main mainForm;
        int Id; // id пациента
        Patient currentPatient;

        public FormPatientDialog(Form_main f, int id)
        {
            InitializeComponent();
            this.CenterToScreen();
            mainForm = f;
            Id = id;
        }

        private void FormPatientDialog_Load(object sender, EventArgs e)
        {
            currentPatient = mainForm.GetPatients()
                .Where(n => n.ID == Id)
                .FirstOrDefault();

            Text = $"Информация о пациенте ({currentPatient.Surname} {currentPatient.Name})";

            label1.Text = currentPatient.GetFullInfo();
            flowLayoutPanel_Patient.Controls.Clear();

            using (UserContext db = new UserContext())
            {
                var appointments = db.Appointments.Where(n => n.Patient_ID == Id).OrderBy(n => n.DateTime);

                foreach (Appointment appointment in appointments)
                {
                    if (appointment.Patient_ID == Id)
                    {
                        Doctor item1 = mainForm.GetDoctors()
                        .Where(n => n.ID == appointment.Doctor_ID)
                        .FirstOrDefault();

                        Label tmp = new Label();
                        tmp.AutoSize = false;
                        tmp.Padding = new Padding(0, 6, 0, 0);
                        tmp.Text = "Доктор: " + item1.Surname + " " + item1.Name + " - " + item1.Position + ". Кабинет: " + item1.Office + "\n";
                        tmp.Text += "Дата приема: \n" + appointment.DateTime.ToString();
                        tmp.Width = 195;
                        tmp.Height = 85;

                        var flow = new TableLayoutPanel();
                        flow.AutoSize = true;
                        flow.Controls.Add(tmp, 0, 0);

                        Button b = new Button();
                        b.Text = "Отменить запись";
                        b.AutoSize = true;
                        b.BackColor = Color.Transparent;
                        b.Anchor = (AnchorStyles.Bottom | AnchorStyles.Left);

                        b.Click += new System.EventHandler((sender2, e2) =>
                        {
                            mainForm.AppointmentDelete(appointment.ID);
                            FormPatientDialog_Load(sender, e);
                        });

                        flow.Controls.Add(b, 1, 0);

                        flowLayoutPanel_Patient.Controls.Add(flow);
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var newForm = new FormAppointment(mainForm, Id);
            Close();
            newForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mainForm.Delete_Patient(sender, e, Id);
            Close();
        }
    }
}
