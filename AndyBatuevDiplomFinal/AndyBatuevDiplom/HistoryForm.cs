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
    public partial class HistoryForm : Form
    {

        private Zapis backForm;
        private string userLogin;
        public HistoryForm(Zapis backForm, string login)
        {
            InitializeComponent();
            userLogin = login;
            this.backForm = backForm;
        }

        private void HistoryForm_Load(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(@"Data Source=DESKTOP-Q8N94AP;Initial Catalog=BatuevDiplom;Integrated Security=True;TrustServerCertificate=True;Encrypt=False"))
            {
                conn.Open();

                string query = "SELECT dateZapis, doctorName, doctorSpec, treatment FROM archive_zapis WHERE login = @UserLogin";
                SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                adapter.SelectCommand.Parameters.AddWithValue("@UserLogin", userLogin);

                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            backForm.Show();
            Hide();
        }
    }
}
