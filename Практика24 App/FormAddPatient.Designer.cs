
namespace Практика24_App
{
    partial class FormAddPatient
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Sex = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.maskedTextBox_Phone = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_Data = new System.Windows.Forms.MaskedTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.maskedTextBox_PolisNumber = new System.Windows.Forms.MaskedTextBox();
            this.textBox_Diagnosis = new System.Windows.Forms.TextBox();
            this.maskedTextBox_Patronomic = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_Name = new System.Windows.Forms.MaskedTextBox();
            this.maskedTextBox_Surname = new System.Windows.Forms.MaskedTextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(11, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Фамилия";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(287, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Имя";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(563, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Отчество";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(12, 79);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(141, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Дата рождения";
            // 
            // comboBox_Sex
            // 
            this.comboBox_Sex.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.comboBox_Sex.FormattingEnabled = true;
            this.comboBox_Sex.Items.AddRange(new object[] {
            "Мужской\t",
            "Женский"});
            this.comboBox_Sex.Location = new System.Drawing.Point(194, 101);
            this.comboBox_Sex.Name = "comboBox_Sex";
            this.comboBox_Sex.Size = new System.Drawing.Size(120, 28);
            this.comboBox_Sex.TabIndex = 7;
            this.comboBox_Sex.Text = "Мужской\t";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(190, 79);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "Пол";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(349, 79);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(85, 20);
            this.label6.TabIndex = 10;
            this.label6.Text = "Телефон";
            // 
            // maskedTextBox_Phone
            // 
            this.maskedTextBox_Phone.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox_Phone.Location = new System.Drawing.Point(353, 102);
            this.maskedTextBox_Phone.Mask = "+7 (999) 000-00-00";
            this.maskedTextBox_Phone.Name = "maskedTextBox_Phone";
            this.maskedTextBox_Phone.Size = new System.Drawing.Size(180, 27);
            this.maskedTextBox_Phone.TabIndex = 13;
            this.maskedTextBox_Phone.Text = "9283220509";
            // 
            // maskedTextBox_Data
            // 
            this.maskedTextBox_Data.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox_Data.Location = new System.Drawing.Point(16, 102);
            this.maskedTextBox_Data.Mask = "00/00/0000";
            this.maskedTextBox_Data.Name = "maskedTextBox_Data";
            this.maskedTextBox_Data.Size = new System.Drawing.Size(140, 27);
            this.maskedTextBox_Data.TabIndex = 14;
            this.maskedTextBox_Data.Text = "08082001";
            this.maskedTextBox_Data.ValidatingType = typeof(System.DateTime);
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(442, 365);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(200, 50);
            this.button1.TabIndex = 2;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button2.Location = new System.Drawing.Point(212, 365);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 50);
            this.button2.TabIndex = 19;
            this.button2.Text = "Очистить форму";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(563, 79);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 20);
            this.label7.TabIndex = 20;
            this.label7.Text = "Номер полиса";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(12, 149);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(391, 20);
            this.label8.TabIndex = 21;
            this.label8.Text = "Предварительный диагноз (не обязательно)";
            // 
            // maskedTextBox_PolisNumber
            // 
            this.maskedTextBox_PolisNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox_PolisNumber.Location = new System.Drawing.Point(567, 102);
            this.maskedTextBox_PolisNumber.Mask = "00 >LL 000000";
            this.maskedTextBox_PolisNumber.Name = "maskedTextBox_PolisNumber";
            this.maskedTextBox_PolisNumber.Size = new System.Drawing.Size(256, 27);
            this.maskedTextBox_PolisNumber.TabIndex = 22;
            this.maskedTextBox_PolisNumber.Text = "00NN123456";
            // 
            // textBox_Diagnosis
            // 
            this.textBox_Diagnosis.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_Diagnosis.Location = new System.Drawing.Point(16, 172);
            this.textBox_Diagnosis.Multiline = true;
            this.textBox_Diagnosis.Name = "textBox_Diagnosis";
            this.textBox_Diagnosis.Size = new System.Drawing.Size(807, 173);
            this.textBox_Diagnosis.TabIndex = 23;
            this.textBox_Diagnosis.Text = "Дурачок немножко";
            // 
            // maskedTextBox_Patronomic
            // 
            this.maskedTextBox_Patronomic.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox_Patronomic.Location = new System.Drawing.Point(567, 32);
            this.maskedTextBox_Patronomic.Mask = ">L<???????????????";
            this.maskedTextBox_Patronomic.Name = "maskedTextBox_Patronomic";
            this.maskedTextBox_Patronomic.PromptChar = ' ';
            this.maskedTextBox_Patronomic.Size = new System.Drawing.Size(256, 27);
            this.maskedTextBox_Patronomic.TabIndex = 21;
            this.maskedTextBox_Patronomic.Text = "Николаевич";
            // 
            // maskedTextBox_Name
            // 
            this.maskedTextBox_Name.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox_Name.Location = new System.Drawing.Point(291, 32);
            this.maskedTextBox_Name.Mask = ">L<???????????????";
            this.maskedTextBox_Name.Name = "maskedTextBox_Name";
            this.maskedTextBox_Name.PromptChar = ' ';
            this.maskedTextBox_Name.Size = new System.Drawing.Size(251, 27);
            this.maskedTextBox_Name.TabIndex = 22;
            this.maskedTextBox_Name.Text = "Ян";
            // 
            // maskedTextBox_Surname
            // 
            this.maskedTextBox_Surname.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.maskedTextBox_Surname.Location = new System.Drawing.Point(15, 32);
            this.maskedTextBox_Surname.Mask = ">L<???????????????";
            this.maskedTextBox_Surname.Name = "maskedTextBox_Surname";
            this.maskedTextBox_Surname.PromptChar = ' ';
            this.maskedTextBox_Surname.Size = new System.Drawing.Size(251, 27);
            this.maskedTextBox_Surname.TabIndex = 23;
            this.maskedTextBox_Surname.Text = "Никифоров";
            // 
            // FormAddPatient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Aqua;
            this.ClientSize = new System.Drawing.Size(836, 433);
            this.Controls.Add(this.maskedTextBox_Surname);
            this.Controls.Add(this.maskedTextBox_Name);
            this.Controls.Add(this.textBox_Diagnosis);
            this.Controls.Add(this.maskedTextBox_Patronomic);
            this.Controls.Add(this.maskedTextBox_PolisNumber);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_Sex);
            this.Controls.Add(this.maskedTextBox_Data);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.maskedTextBox_Phone);
            this.DoubleBuffered = true;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.Name = "FormAddPatient";
            this.Text = "Добавление пациента";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_Sex;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Phone;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Data;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_PolisNumber;
        private System.Windows.Forms.TextBox textBox_Diagnosis;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Patronomic;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Name;
        private System.Windows.Forms.MaskedTextBox maskedTextBox_Surname;
    }
}