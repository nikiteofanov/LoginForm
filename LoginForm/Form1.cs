using System.Text.RegularExpressions;

namespace LoginForm
{
    public partial class Form1 : Form
    {
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
            }

        }
    }
}