using System.Text.RegularExpressions;
using System.Security.Cryptography;
using System.Text;
using System.Data.SqlClient;


namespace LoginForm
{
    public partial class Form1 : Form
    {

        string connection = @"Data Source=DESKTOP-S3RQ5UI\SQLEXPRESS;Initial Catalog=MiniProject1;Integrated Security=True;Encrypt=False";
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void login_Click(object sender, EventArgs e)
        {
            string password = textBox2.Text;
            string repeatPass = textBox3.Text;

            if (password == repeatPass)
            {
                string salt = " ";
                salt = DateTime.Now.ToString();
                string hashedPassword2 = hashPassword($"{password}{salt}");
                //if (hashedPassword2 == )
                {

                }
            }
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
                UserProfiles UserProfiles = new UserProfiles();
                UserProfiles.ShowDialog();
                
                string salt = " ";
                salt = DateTime.Now.ToString();
                string hashedPassword = hashPassword($"{password}{salt}");
                string username = textBox1.Text;
                MessageBox.Show(hashPassword(password));

                string query = "INSERT INTO Users (Username, DateAndTime, Password) VALUES (@Username, @DateAndTime, @Password)";

                SqlConnection con = new SqlConnection(connection);

                using (SqlCommand command = new SqlCommand(query, con))
                {
                    con.Open();
                    // Add parameters to prevent SQL injection
                    command.Parameters.AddWithValue("@Username", username);
                    command.Parameters.AddWithValue("@DateAndTime", salt);
                    command.Parameters.AddWithValue("@Password", hashedPassword); // Store hashed password

                    // Execute the query
                    int rowsAffected = command.ExecuteNonQuery();
                    con.Close();
                }
            }
            }
        }
}