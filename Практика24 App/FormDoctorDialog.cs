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
    public partial class FormDoctorDialog : Form
    {
        Form_main mainForm;
        int Id; // id врача
        Doctor currentDoctor;

        public FormDoctorDialog(Form_main f, int id)
        {
            InitializeComponent();
            this.CenterToScreen();
            mainForm = f;
            Id = id;
        }

        private void FormDoctorDialog_Load(object sender, EventArgs e)
        {
            currentDoctor = mainForm.GetDoctors()
                .Where(n => n.ID == Id)
                .FirstOrDefault();

            Text = $"Информация о враче ({currentDoctor.Surname} {currentDoctor.Name})";

            label1.Text = currentDoctor.GetWorkingDays();
            flowLayoutPanel_Doctor.Controls.Clear();

            using (UserContext db = new UserContext())
            {
                var appointments = db.Appointments.Where(n => n.Doctor_ID == Id).OrderBy(n => n.DateTime);

                foreach (Appointment appointment in appointments)
                {
                    Patient item1 = mainForm.GetPatients()
                        .Where(n => n.ID == appointment.Patient_ID)
                        .FirstOrDefault();

                    Label tmp = new Label();
                    tmp.AutoSize = false;
                    tmp.Padding = new Padding(0, 6, 0, 0);
                    tmp.Text += "Пациент: " + item1.Surname + " " + item1.Name + "\n";
                    tmp.Text += "Дата приема: " + appointment.DateTime.ToString();
                    tmp.Width = 195;
                    tmp.Height = 65;

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
                        FormDoctorDialog_Load(sender, e);
                    });

                    flow.Controls.Add(b, 1, 0);

                    flowLayoutPanel_Doctor.Controls.Add(flow);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            mainForm.Delete_Doctor(sender, e, Id);
            Close();
        }
    }
}
