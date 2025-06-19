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
    public partial class Form1 : Form
    {
        DataBase db = new DataBase();

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = textBox1.Text;
            string password = textBox2.Text;

            SqlDataAdapter adapter = new SqlDataAdapter();
            DataTable tableUsers = new DataTable();

            // Проверяем, админ ли это
            string queryStr = $"SELECT id, username, password FROM Emplo WHERE username = @login AND password = @password AND root = 1;";
            SqlCommand command = new SqlCommand(queryStr, db.getConnection());
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);
            adapter.SelectCommand = command;
            adapter.Fill(tableUsers);

            if (tableUsers.Rows.Count == 1)
            {
                MessageBox.Show("Вход успешен", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                AdminPanel AP = new AdminPanel(this, login);
                AP.Show();
                Hide();
                return;  // Прерываем выполнение, чтобы не проверять обычного пользователя
            }

            // Проверяем, обычный ли это пользователь
            adapter = new SqlDataAdapter();
            tableUsers = new DataTable();
            queryStr = $"SELECT root, username, password FROM Emplo WHERE username = @login AND password = @password AND root = 0;";
            command = new SqlCommand(queryStr, db.getConnection());
            command.Parameters.AddWithValue("@login", login);
            command.Parameters.AddWithValue("@password", password);
            adapter.SelectCommand = command;
            adapter.Fill(tableUsers);

            if (tableUsers.Rows.Count == 1)
            {
                MessageBox.Show("Вход успешен", "Выполнено", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Emplo EP = new Emplo(this, login);
                EP.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Аккаунта не существует", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
