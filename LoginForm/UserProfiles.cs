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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace LoginForm
{
    public partial class UserProfiles : Form
    {

        string connection = @"Data Source=DESKTOP-S3RQ5UI\SQLEXPRESS;Initial Catalog=MiniProject1;Integrated Security=True;Encrypt=False";

        public UserProfiles()
        {
            InitializeComponent();
        }

        private void UserProfiles_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string query = "INSERT INTO Users_Profile (FirstName, LastName, Country, Gender) VALUES (@FirstName, @LastName, @Country, @Gender)";

            SqlConnection con = new SqlConnection(connection);

            string firstName = textBox1.Text;
            string lastName = textBox2.Text;
            string country = textBox3.Text;
            string gender = string.Empty;
            if (radioButton1.Checked == true)
            {
                gender = radioButton1.Text;
            }
            if (radioButton2.Checked == true)
            {
                gender = radioButton2.Text;
            }

            using (SqlCommand command = new SqlCommand(query, con))
            {
                con.Open();
                command.Parameters.AddWithValue("@FirstName", firstName);
                command.Parameters.AddWithValue("@LastName", lastName);
                command.Parameters.AddWithValue("@Country", country);
                command.Parameters.AddWithValue("@Gender", gender);

                int rowsAffected = command.ExecuteNonQuery();
                con.Close();
                Application.Exit();
            }
        }
    }
}
