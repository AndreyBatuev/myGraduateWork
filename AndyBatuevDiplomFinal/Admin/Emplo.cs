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

namespace Admin
{
    public partial class Emplo : Form
    {
        DataBase db = new DataBase();
        Form1 loginForm;
        private string login;

        public Emplo(Form1 loginForm, string login)
        {
            InitializeComponent();
            this.login = login;
            this.loginForm = loginForm;
        }
        private void Emplo_Load(object sender, EventArgs e)
        {

            string firstName = "", lastName = "", middleName = "";

                // Получаем ФИО врача
                string queryStr = "SELECT first_name, last_name, middle_name FROM emplo WHERE username = @login";
    
                db.openConnection();
                using (SqlCommand command = new SqlCommand(queryStr, db.getConnection()))
                {
                    command.Parameters.Add("@login", SqlDbType.NVarChar).Value = login;

                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            firstName = reader["first_name"].ToString().Trim();
                            lastName = reader["last_name"].ToString().Trim();
                            middleName = reader["middle_name"].ToString().Trim();
                        }
                    }
                }
                db.closeConnection();

                label2.Text = "Имя: " + firstName;
                label3.Text = "Фамилия: " + middleName;
                label4.Text = "Отчество: " + lastName;

                // ФИО врача должно совпадать с БД
                string fullName = $"{firstName} {lastName} {middleName}";
                
                // Загружаем записи к врачу
                DataTable table = new DataTable();
                queryStr = "SELECT * FROM zapis WHERE doctorName = @fullName";

                db.openConnection();
                using (SqlCommand command = new SqlCommand(queryStr, db.getConnection()))
                {
                    command.Parameters.Add("@fullName", SqlDbType.NVarChar).Value = fullName;

                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(table);
                }
                db.closeConnection();

                dataGridView1.DataSource = table;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int zapisId = Convert.ToInt32(textBox1.Text);
            string treatment = richTextBox1.Text;
            using (SqlConnection sqlCon = new SqlConnection(@"Data Source=DESKTOP-Q8N94AP;Initial Catalog=BatuevDiplom;Integrated Security=True;TrustServerCertificate=True;Encrypt=False"))
            {
                sqlCon.Open();

                string query = @"
            INSERT INTO archive_zapis (dateZapis, doctorName, doctorSpec, login, treatment)
            SELECT dateZapis, doctorName, doctorSpec, login, @Treatment
            FROM zapis
            WHERE id = @ZapisId;

            DELETE FROM zapis WHERE id = @ZapisId;";

                using (SqlCommand cmd = new SqlCommand(query, sqlCon))
                {
                    cmd.Parameters.AddWithValue("@ZapisId", zapisId);
                    cmd.Parameters.AddWithValue("@Treatment", treatment);

                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                        MessageBox.Show("Приём завершён. Лечение сохранено в архив.");
                    else
                        MessageBox.Show("Ошибка: запись не найдена.");
                }
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            Hide();
        }
    }
}
