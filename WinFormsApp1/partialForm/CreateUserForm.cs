using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinFormsApp1.BussinessObject;
using WinFormsApp1.BussinessObject.builder;
using WinFormsApp1.BussinessObject.IBuilder;
using WinFormsApp1.Repository;

namespace WinFormsApp1.partialForm
{
    public partial class CreateUserForm : Form
    {
        UserRepository repo;
        manageUser prev;
        public CreateUserForm()
        {
            InitializeComponent();
        }

        private void saveChangeBtn_Click(object sender, EventArgs e)
        {
            String _userName = userName.Text;
            String country = countryTxt.Text;
            String city = cityTxt.Text;
            String email = emailTxt.Text;
            String passWord = password.Text;
            String rePass = reEnterpassword.Text;
            IUserBuilder userBuild = new UserBuilder();
            UserEntity usr = userBuild
                .setName(_userName)
                .setPassword(passWord)
                .InCity(city)
                .ofCountry(country)
                .setEmail(email)
                .build();
            try
            {
                usr.SelfValidate();
                this.repo.InsertNew(usr);
                this.prev.RefreshData();
                this.Close();
                this.prev.Visible= true;
            }
            catch (Exception ex)
            {
                ShowErrorMsgBox(ex.Message);
                return;
            }

        }

        public CreateUserForm InjectForm(manageUser prev)
        {
            this.prev = prev;
            return this;
        }

        public CreateUserForm ỊnectRepo(UserRepository repo)
        {
            this.repo = repo;
            return this;
        }


        public void ShowErrorMsgBox(String msg)
        {
            string message = msg;
            string title = "error";
            MessageBox.Show(message, title);
        }

    }
}
