using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace AndyBatuevDiplom
{
    public partial class Form2 : Form
    {
        DataBase db = new DataBase();
        private Form1 loginForm;

        public Form2(Form1 loginForm)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

            loginForm.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nameLogin = textBox1.Text;
            string pass = textBox8.Text;
            string passConfirm = textBox10.Text; // Второй пароль для проверки
            string firstName = textBox9.Text;
            string surName = textBox2.Text;
            string otchestvo = textBox3.Text;
            string serPass = textBox4.Text;
            string numPass = textBox5.Text;
            string polisOMS = textBox6.Text;
            string snils = textBox7.Text;

            // Получаем дату рождения из MonthCalendar
            string birthDate = monthCalendar1.SelectionStart.ToString("yyyy-MM-dd");

            // Проверка: все ли поля заполнены?
            if (string.IsNullOrWhiteSpace(nameLogin) ||
                string.IsNullOrWhiteSpace(pass) ||
                string.IsNullOrWhiteSpace(passConfirm) ||
                string.IsNullOrWhiteSpace(firstName) ||
                string.IsNullOrWhiteSpace(surName) ||
                string.IsNullOrWhiteSpace(otchestvo) ||
                string.IsNullOrWhiteSpace(serPass) ||
                string.IsNullOrWhiteSpace(numPass) ||
                string.IsNullOrWhiteSpace(polisOMS) ||
                string.IsNullOrWhiteSpace(snils))
            {
                MessageBox.Show("Ошибка: Все поля должны быть заполнены!");
                return;
            }

            // Проверка: совпадают ли пароли?
            if (pass != passConfirm)
            {
                MessageBox.Show("Ошибка: пароли не совпадают!");
                return;
            }

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-Q8N94AP;Initial Catalog=BatuevDiplom;Integrated Security=True;TrustServerCertificate=True;Encrypt=False"))
            {
                sqlCon.Open();

                // Проверяем, существует ли уже пользователь с таким логином, паспортом, полисом или СНИЛС
                string checkQuery = "SELECT COUNT(*) FROM users WHERE NameLogin = @NameLogin OR (serPass = @SerPass AND numPass = @NumPass) OR PolisOMS = @PolisOMS OR Snils = @Snils";

                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlCon))
                {
                    checkCmd.Parameters.AddWithValue("@NameLogin", nameLogin);
                    checkCmd.Parameters.AddWithValue("@SerPass", serPass);
                    checkCmd.Parameters.AddWithValue("@NumPass", numPass);
                    checkCmd.Parameters.AddWithValue("@PolisOMS", polisOMS);
                    checkCmd.Parameters.AddWithValue("@Snils", snils);

                    int existingRecords = (int)checkCmd.ExecuteScalar();
                    if (existingRecords > 0)
                    {
                        MessageBox.Show("Ошибка: Пользователь с таким логином, паспортом, полисом ОМС или СНИЛС уже существует!");
                        return;
                    }
                }

                // Если проверки пройдены, добавляем нового пользователя
                string query = "INSERT INTO users (NameLogin, pass, firstName, surName, otchestvo, serPass, numPass, PolisOMS, Snils, birthDate) " +
                               "VALUES (@NameLogin, @Pass, @FirstName, @SurName, @Otchestvo, @SerPass, @NumPass, @PolisOMS, @Snils, @BirthDate)";

                using (SqlCommand command = new SqlCommand(query, sqlCon))
                {
                    command.Parameters.AddWithValue("@NameLogin", nameLogin);
                    command.Parameters.AddWithValue("@Pass", pass);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@SurName", surName);
                    command.Parameters.AddWithValue("@Otchestvo", otchestvo);
                    command.Parameters.AddWithValue("@SerPass", serPass);
                    command.Parameters.AddWithValue("@NumPass", numPass);
                    command.Parameters.AddWithValue("@PolisOMS", polisOMS);
                    command.Parameters.AddWithValue("@Snils", snils);
                    command.Parameters.AddWithValue("@BirthDate", birthDate); // Добавляем дату рождения

                    command.ExecuteNonQuery();
                }
            }

            MessageBox.Show("Пользователь добавлен!");


        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
