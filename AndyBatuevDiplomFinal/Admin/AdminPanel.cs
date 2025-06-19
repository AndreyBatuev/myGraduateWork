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
    public partial class AdminPanel : Form
    {
        DataBase db = new DataBase();
        Form1 loginForm;

        public AdminPanel(Form1 loginForm, string login)
        {
            InitializeComponent();
            this.loginForm = loginForm;
        }
        private void AdminPanel_Load(object sender, EventArgs e)
        {
            updateTables();
        }
        private void updateTables()
        {
            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable table = new DataTable();
            string queryStr = $"SELECT * FROM Emplo;";
            SqlCommand command = new SqlCommand(queryStr, db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            adapter = new SqlDataAdapter();
            table = new DataTable();
            queryStr = $"SELECT * FROM users;";
            command = new SqlCommand(queryStr, db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView2.DataSource = table;
            
            adapter = new SqlDataAdapter();
            table = new DataTable();
            queryStr = $"SELECT * FROM zapis;";
            command = new SqlCommand(queryStr, db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView3.DataSource = table;

            adapter = new SqlDataAdapter();
            table = new DataTable();
            queryStr = $"SELECT * FROM archive_zapis;";
            command = new SqlCommand(queryStr, db.getConnection());
            adapter.SelectCommand = command;
            adapter.Fill(table);
            dataGridView4.DataSource = table;

        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            loginForm.Show();
            Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void SaveChanges()
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-Q8N94AP;Initial Catalog=BatuevDiplom;Integrated Security=True;TrustServerCertificate=True;Encrypt=False"))
            {
                conn.Open();

                // Обновляем emplo (DataGridView1)
                SqlDataAdapter adapter1 = new SqlDataAdapter("SELECT * FROM emplo", conn);
                SqlCommandBuilder builder1 = new SqlCommandBuilder(adapter1);
                DataTable table1 = (DataTable)dataGridView1.DataSource;
                adapter1.Update(table1);

                // Обновляем users (DataGridView2)
                SqlDataAdapter adapter2 = new SqlDataAdapter("SELECT * FROM users", conn);
                SqlCommandBuilder builder2 = new SqlCommandBuilder(adapter2);
                DataTable table2 = (DataTable)dataGridView2.DataSource;
                adapter2.Update(table2);

                // Обновляем zapis (DataGridView3)
                SqlDataAdapter adapter3 = new SqlDataAdapter("SELECT * FROM zapis", conn);
                SqlCommandBuilder builder3 = new SqlCommandBuilder(adapter3);
                DataTable table3 = (DataTable)dataGridView3.DataSource;
                adapter3.Update(table3);

                // Обновляем archive_zapis (DataGridView4)
                SqlDataAdapter adapter4 = new SqlDataAdapter("SELECT * FROM archive_zapis", conn);
                SqlCommandBuilder builder4 = new SqlCommandBuilder(adapter4);
                DataTable table4 = (DataTable)dataGridView4.DataSource;
                adapter4.Update(table4);

                MessageBox.Show("Изменения сохранены!", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

    }
}
