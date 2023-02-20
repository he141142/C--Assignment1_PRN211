using Microsoft.VisualBasic;
using Microsoft.VisualBasic.ApplicationServices;
using WinFormsApp1.BussinessObject;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        UserRepository userRepository = null;
        Form2 form2 = new Form2();
        public Form1()
        {
            InitializeComponent();
            userRepository = new UserRepository();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String user = textBox1.Text;
            String password = textBox2.Text;

            appendOutput(user);
            appendOutput(password);

            if (user == null || password == null || user == "" || password == "")
            {
                if (user == null || user == "")
                    userErr.Text = "email is mandatory";
                if (password == null || password == "")
                {
                    passwordErr.Text = "password is mandatory";
                }
            }

            UserEntity _user = this.userRepository.getByEmailAndPassword(user, password);

            if (_user == null)
            {
                appendOutput("email or password incorrect");
                return;
            }

            appendOutput(String.Format("email : {0}, password: {1}", user, password));

            this.LoginSuccess(_user);
        }


        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void LoginSuccess(UserEntity _user)
        {
            this.Visible = false;
            new Form2().LoadUserProfile(_user)
                .LoadData();
        }


        private void appendOutput(String msg)
        {
            debugConsole.AppendText(msg + "\n");
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
}