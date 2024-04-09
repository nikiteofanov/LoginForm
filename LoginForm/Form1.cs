using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;


namespace LoginForm
{
    public partial class Form1 : Form
    {

        string connection = @"Data Source=LAB108PC18\SQLEXPRESS;Initial Catalog=Miniproject;Integrated Security=True";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(connection);

            try
            {
                using (SqlCommand cmd = new SqlCommand("INSERT INTO "))
                {
                    con.Open();





                    con.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }

        }

        private void login_Click(object sender, EventArgs e)
        {
            

        }

        string hashPassword(string password)
        {
            SHA256 hashAlgorithm = SHA256.Create();
            var bytes = Encoding.Default.GetBytes(password);
            var hash = hashAlgorithm.ComputeHash(bytes);
            return Convert.ToBase64String(hash);
        }

        private void register_Click(object sender, EventArgs e)
        {
            string password = textBox2.Text;
            string repeatPass = textBox3.Text;
            string pattern = "^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$";
            if (Regex.IsMatch(password, pattern))
            {
                label6.Text = "";
            }
            else
            {
                label6.Text = "Invalid password!";
            }

            if (!(password == repeatPass))
            {
                label5.Text = "Passwords do not match! Try again!";
            }
            else
            {
                label5.Text = "";
            }

            if ((Regex.IsMatch(password, pattern)) && password == repeatPass)
            {
                MessageBox.Show("Successful Login!");
                string salt = " ";
                salt = DateTime.Now.ToString();
                textBox2.Text = salt;
                hashPassword($"{password}{salt}");
                MessageBox.Show(hashPassword(password));
            }
        }
    }
}