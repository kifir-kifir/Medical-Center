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
    public partial class FormAddDoctor : Form
    {
        Form_main mainForm;

        public FormAddDoctor(Form_main f)
        {
            InitializeComponent();
            this.CenterToScreen();
            mainForm = f;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string surname = maskedTextBox_Surname.Text;
            if (surname == "")
            {
                MessageBox.Show(this, "Не введена фамилия", "Ошибка");
                return;
            }

            string name = maskedTextBox_Name.Text;
            if (name == "")
            {
                MessageBox.Show(this, "Не введено имя", "Ошибка");
                return;
            }

            string patronomic = maskedTextBox_Patronomic.Text;
            if (patronomic == "")
            {
                MessageBox.Show(this, "Не введено отчество", "Ошибка");
                return;
            }

            DateTime data;
            bool chek = DateTime.TryParse(maskedTextBox_Data.Text, out data);
            string checkData = maskedTextBox_Data.Text.Replace(" ", "").Replace(".", "");
            if (checkData.Length < 8)
            {
                MessageBox.Show(this, "Не введена дата рождения", "Ошибка");
                return;
            }

            if (!chek)
            {
                MessageBox.Show(this, "Не верный формат даты", "Ошибка");
                return;
            }

            string sex_s = comboBox_Sex.Text;
            if (sex_s == "")
            {
                MessageBox.Show(this, "Не выбран пол", "Ошибка");
                return;
            }
            sex sex = (sex)Enum.Parse(typeof(sex), sex_s);

            string tel = maskedTextBox_Phone.Text;
            string checkTel = maskedTextBox_Phone.Text.Replace(" ", "").Replace("-", "").Replace(")", "").Replace("(", "").Replace("+", "");
            if (checkTel.Length < 11)
            {
                MessageBox.Show(this, "Не введен номер телефона", "Ошибка");
                return;
            }

            var searchTel = mainForm.GetDoctors().FirstOrDefault(n => n.Phone == tel);
            if(searchTel != null)
            {
                MessageBox.Show(this, "Данный врач уже добавлен", "Ошибка");
                return;
            }

            string pos = maskedTextBox_Position.Text;
            if (pos == "")
            {
                MessageBox.Show(this, "Не введена специанльность", "Ошибка");
                return;
            }

            // расписание
            StringBuilder workingDays = new StringBuilder("     ");
            var day1 = groupBox1.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (day1 != null)
            {
                if (day1.Name == "radioButton1")
                {
                    workingDays[0] = '0';
                }
                else
                {
                    workingDays[0] = '1';
                }
            }
            else
            {
                workingDays[0] = '0';
            }

            var day2 = groupBox2.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (day2 != null)
            {
                if (day2.Name == "radioButton3")
                {
                    workingDays[1] = '0';
                }
                else
                {
                    workingDays[1] = '1';
                }
            }
            else
            {
                workingDays[1] = '0';
            }

            var day3 = groupBox3.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (day3 != null)
            {
                if (day3.Name == "radioButton5")
                {
                    workingDays[2] = '0';
                }
                else
                {
                    workingDays[2] = '1';
                }
            }
            else
            {
                workingDays[2] = '0';
            }

            var day4 = groupBox4.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (day4 != null)
            {
                if (day4.Name == "radioButton7")
                {
                    workingDays[3] = '0';
                }
                else
                {
                    workingDays[3] = '1';
                }
            }
            else
            {
                workingDays[3] = '0';
            }

            var day5 = groupBox5.Controls.OfType<RadioButton>().FirstOrDefault(r => r.Checked);
            if (day5 != null)
            {
                if (day5.Name == "radioButton9")
                {
                    workingDays[4] = '0';
                }
                else
                {
                    workingDays[4] = '1';
                }
            }
            else
            {
                workingDays[4] = '0';
            }

            int office;
            int.TryParse(textBox_Office.Text, out office);
            string result;
            List<Doctor> searchDoctors = mainForm.GetDoctors().Where(n => n.Office == office).ToList();
            if(searchDoctors.Count == 2)
            {
                MessageBox.Show(this, $"К {office} кабинету больше нельзя никого прикрепить", "Ошибка");
                return;
            }

            if (searchDoctors != null)
            {
                result = ChecDays(office, workingDays.ToString(), searchDoctors[0]);

                if (result != "")
                {
                    MessageBox.Show(this, result, "Ошибка");
                    return;
                }
            }

            if (office == 0)
            {
                MessageBox.Show(this, "Не введен кабинет", "Ошибка");
                return;
            }

            mainForm.AddDoctor(surname, name, patronomic, data, sex, tel, pos, office, workingDays.ToString());

            Close();
        }

        private string ChecDays(int office, string workingDays, Doctor doctor)
        {
            string tempWorkingDays = doctor.WorkingDays;

            if (tempWorkingDays[0] == workingDays[0])
            {
                if (tempWorkingDays[0] == '0')
                {
                    return $"В понедельник утром в {office} кабинете работает {doctor.Surname} {doctor.Name}";
                }
                else
                {
                    return $"В понедельник вечером {office} кабинете работает {doctor.Surname} {doctor.Name}";
                }
            }

            if (tempWorkingDays[1] == workingDays[1])
            {
                if (tempWorkingDays[1] == '0')
                {
                    return $"Во вторник утром {office} кабинете работает {doctor.Surname} {doctor.Name}";
                }
                else
                {
                    return $"Во вторник вечером {office} кабинете работает {doctor.Surname} {doctor.Name}";
                }
            }

            if (tempWorkingDays[2] == workingDays[2])
            {
                if (tempWorkingDays[2] == '0')
                {
                    return $"В среду утром {office} кабинете работает {doctor.Surname} {doctor.Name}";
                }
                else
                {
                    return $"В среду вечером {office} кабинете работает {doctor.Surname} {doctor.Name}";
                }
            }

            if (tempWorkingDays[3] == workingDays[3])
            {
                if (tempWorkingDays[3] == '0')
                {
                    return $"В четверг утром {office} кабинете работает {doctor.Surname} {doctor.Name}";
                }
                else
                {
                    return $"В четверг вечером {office} кабинете работает {doctor.Surname} {doctor.Name}";
                }
            }

            if (tempWorkingDays[4] == workingDays[4])
            {
                if (tempWorkingDays[4] == '0')
                {
                    return $"В пятницу утром {office} кабинете работает {doctor.Surname} {doctor.Name}";
                }
                else
                {
                    return $"В пятницу вечером {office} кабинете работает {doctor.Surname} {doctor.Name}";
                }
            }

            return "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maskedTextBox_Surname.Text = "";
            maskedTextBox_Name.Text = "";
            maskedTextBox_Patronomic.Text = "";
            maskedTextBox_Data.Text = "";
            comboBox_Sex.Text = "";
            maskedTextBox_Phone.Text = "";
            maskedTextBox_Position.Text = "";
            textBox_Office.Text = "";

            foreach (GroupBox GB in Controls.OfType<GroupBox>())
            {
                foreach (Control control in GB.Controls)
                {
                    RadioButton tb = control as RadioButton;
                    if (tb != null)
                    {
                        tb.Checked = false;
                    }
                }
            } 
        }
    }
}
