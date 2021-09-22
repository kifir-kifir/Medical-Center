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
    public partial class FormAddPatient : Form
    {
        Form_main mainForm;

        public FormAddPatient(Form_main f)
        {
            InitializeComponent();
            CenterToScreen();
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

            if(!chek)
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

            var searchTel = mainForm.GetPatients().FirstOrDefault(n => n.Phone == tel);
            if (searchTel != null)
            {
                MessageBox.Show(this, "Данный пациент уже добавлен", "Ошибка");
                return;
            }

            string polisNumber = maskedTextBox_PolisNumber.Text;
            if (polisNumber.Length < 12)
            {
                MessageBox.Show(this, "Не введен номер полиса", "Ошибка");
                return;
            }

            string diagnosis = textBox_Diagnosis.Text;

            mainForm.AddPatient(surname, name, patronomic, data, sex, tel, polisNumber, diagnosis);

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            maskedTextBox_Surname.Text = "";
            maskedTextBox_Name.Text = "";
            maskedTextBox_Patronomic.Text = "";
            maskedTextBox_Data.Text = "";
            comboBox_Sex.Text = "";
            maskedTextBox_Phone.Text = "";
            maskedTextBox_PolisNumber.Text = "";
            textBox_Diagnosis.Text = "";
        }
    }
}
