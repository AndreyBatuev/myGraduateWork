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
    public partial class Zapis : Form
    {
        int selectedHour = 10;
        int selectedMin = 0;
        DataBase db = new DataBase();
        
        private Form1 loginForm;
        string loginName;
        public Zapis(Form1 loginForm, string loginName)
        {
            InitializeComponent();
            this.loginForm = loginForm;
            this.loginName = loginName;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            loginForm.Show();
            Hide();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            
            string selectedSpec = comboBox1.SelectedItem?.ToString();
            string selectedDoctor = comboBox2.SelectedItem?.ToString();
            string loginUser = loginName; 

            if (string.IsNullOrEmpty(selectedSpec) || string.IsNullOrEmpty(selectedDoctor))
            {
                MessageBox.Show("Выберите врача и специализацию!");
                return;
            }

            DateTime selectedDate = monthCalendar1.SelectionStart.Date.AddHours(selectedHour).AddMinutes(selectedMin);

            // Проверка на прошедшую дату
            if (selectedDate < DateTime.Now)
            {
                MessageBox.Show("Ошибка: Нельзя записаться на прошедшую дату!");
                return;
            }

            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-Q8N94AP;Initial Catalog=BatuevDiplom;Integrated Security=True;TrustServerCertificate=True;Encrypt=False"))
            {
                sqlCon.Open();

                // Проверяем, есть ли уже запись у этого врача в это время
                string checkQuery = "SELECT COUNT(*) FROM zapis WHERE dateZapis = @DateZapis AND doctorName = @DoctorName";
                using (SqlCommand checkCmd = new SqlCommand(checkQuery, sqlCon))
                {
                    checkCmd.Parameters.Add("@DateZapis", SqlDbType.DateTime).Value = selectedDate;
                    checkCmd.Parameters.Add("@DoctorName", SqlDbType.NVarChar).Value = selectedDoctor;

                    int existingRecords = (int)checkCmd.ExecuteScalar();
                    if (existingRecords > 0)
                    {
                        MessageBox.Show("Ошибка: На это время врач уже записан к другому пациенту. Выберите другое время.");
                        return;
                    }
                }

                // Если проверка пройдена, выполняем запись
                string query = "INSERT INTO zapis (dateZapis, doctorName, doctorSpec, login) VALUES (@DateZapis, @DoctorName, @DoctorSpec, @Login)";

                using (SqlCommand command = new SqlCommand(query, sqlCon))
                {
                    command.Parameters.Add("@DateZapis", SqlDbType.DateTime).Value = selectedDate;
                    command.Parameters.Add("@DoctorName", SqlDbType.NVarChar).Value = selectedDoctor;
                    command.Parameters.Add("@DoctorSpec", SqlDbType.NVarChar).Value = selectedSpec;
                    command.Parameters.Add("@Login", SqlDbType.NVarChar).Value = loginUser;

                    command.ExecuteNonQuery();
                }
            }

            comboBox1.Text = null;
            comboBox2.Text = null;
            MessageBox.Show("Запись успешно создана!");
        }
    

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }





        private void LoadClientRecords()
        {
            string queryRecords = "SELECT TOP 3 dateZapis, doctorName, doctorSpec FROM zapis WHERE login = @login ORDER BY dateZapis DESC";

            db.openConnection();
            using (SqlCommand cmd = new SqlCommand(queryRecords, db.getConnection()))
            {
                cmd.Parameters.AddWithValue("@login", loginName);
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    richTextBox1.Clear();
                    while (reader.Read())
                    {
                        string date = reader["dateZapis"].ToString();
                        string doctorName = reader["doctorName"].ToString();
                        string doctorSpec = reader["doctorSpec"].ToString();

                        string record = $"Дата: {date}\nДоктор: {doctorName}\nСпециальность: {doctorSpec}\n\n";
                        richTextBox1.AppendText(record);
                    }
                }
            }
            db.closeConnection();
        }

        private void Zapis_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            // Строка подключения к базе данных
            string connectionString = @"Data Source=DESKTOP-Q8N94AP;Initial Catalog=BatuevDiplom;Integrated Security=True;TrustServerCertificate=True";

            // Запрос для получения уникальных специализаций
            string query = "SELECT DISTINCT specialization FROM emplo WHERE specialization IS NOT NULL";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command2 = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader2 = command2.ExecuteReader())
                        {
                            while (reader2.Read())
                            {
                                // Добавляем специализацию в comboBox1
                                comboBox1.Items.Add(reader2["specialization"].ToString());
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке специализаций: " + ex.Message);
                }
            }











            LoadClientRecords();

            string login = loginName;
            string firstName = "";
            string lastName = "";
            string middleName = "";

            string queryStr = $"SELECT firstName, surName, otchestvo FROM users WHERE NameLogin = '{login}'";

            db.getConnection().Open(); 

            SqlCommand command = new SqlCommand(queryStr, db.getConnection());
            SqlDataReader reader = command.ExecuteReader();

            if (reader.Read())
            {
                firstName = reader["firstName"].ToString();
                lastName = reader["surName"].ToString();
                middleName = reader["otchestvo"].ToString();
            }

            reader.Close();
            db.getConnection().Close(); 

            label3.Text = "Имя: " + firstName;
            label4.Text = "Фамилия: " + lastName;
            label5.Text = "Отчество: " + middleName;


        }
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Очищаем comboBox2 перед заполнением
            
            comboBox2.Items.Clear();

            // Проверяем, что в comboBox1 что-то выбрано
            if (comboBox1.SelectedItem == null) return;

            // Получаем выбранную специализацию
            string selectedSpecialization = comboBox1.SelectedItem.ToString();

            // Строка подключения к базе данных
            string connectionString = @"Data Source=DESKTOP-Q8N94AP;Initial Catalog=BatuevDiplom;Integrated Security=True;TrustServerCertificate=True";

            // Запрос для получения имен врачей по выбранной специализации
            string query = "SELECT first_name, last_name, middle_name FROM emplo WHERE specialization = @Specialization";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                try
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Передаем параметр в запрос
                        command.Parameters.AddWithValue("@Specialization", selectedSpecialization);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Формируем полное имя врача
                                string fullName = $"{reader["first_name"]} {reader["last_name"]} {reader["middle_name"]}";
                                // Добавляем имя в comboBox2
                                comboBox2.Items.Add(fullName);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при загрузке имен врачей: " + ex.Message);
                }
            }


        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (selectedHour > 10)
            {
                selectedHour--;
                label8.Text = Convert.ToString(selectedHour);
            }
            
        }

        private void button6_Click(object sender, EventArgs e)
        {
            if (selectedHour < 20)
            {
                selectedHour++;
                label8.Text = Convert.ToString(selectedHour);

            }
                
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (selectedMin > 0)
            {
                selectedMin -= 10;
                label9.Text = Convert.ToString(selectedMin);

            }
        }
        private void button5_Click(object sender, EventArgs e)
        {
            if (selectedMin < 50)
            {
                selectedMin += 10;
                label9.Text = Convert.ToString(selectedMin);
            }
                
        }

        private void button7_Click(object sender, EventArgs e)
        {
            HistoryForm historyForm = new HistoryForm(this, loginName);
            historyForm.ShowDialog();
        }
    }
}
