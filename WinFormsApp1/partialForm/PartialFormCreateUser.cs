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
using WinFormsApp1.Repository.interfaces;

namespace WinFormsApp1.partialForm
{
    public partial class PartialFormCreateUser : Form
    {
        UserEntity userEntity;
        IUserRepository userRepo;
        manageUser prev;
        public PartialFormCreateUser()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        public PartialFormCreateUser addFormStack(manageUser prevForm)
        {
            this.prev = prevForm;
            return this;
        }

        public PartialFormCreateUser InjectRepo(IUserRepository userRepo)
        {
            if (userRepo != null)
            {
                this.userRepo = userRepo;
            }
            return this;
        }


        public PartialFormCreateUser LoadUserEntity(UserEntity userEntity)
        {
            this.userEntity = userEntity;
            this.userName.Text = userEntity.UserName;
            emailTxt.Text = userEntity.Email;
            countryTxt.Text = userEntity.Country;
            cityTxt.Text = userEntity.City;
            userIdTxt.Text = Convert.ToString(userEntity.Id);
            return this;
        }

        private void saveChangeBtn_Click(object sender, EventArgs e)
        {
            long id = this.userRepo.getlatestId() + 1;
            IUserBuilder userBuilder = new UserBuilder();
            String cityChange = cityTxt.Text;
            var newUsrData = userBuilder
                .InCity(cityTxt.Text)
                .ofCountry(countryTxt.Text)
                .setEmail(emailTxt.Text)
                .setName(userName.Text).build();
            try
            {
                this.userRepo.UpdateUserById(newUsrData, this.userEntity.Id);
                this.prev.RefreshData();
                prev.Visible = true;
                this.Close();
            }
            catch (Exception ex)
            {
                ShowErrorMsgBox(ex.Message);
            }
        }

        public void ShowErrorMsgBox(String msg)
        {
            string message = msg;
            string title = "error";
            MessageBox.Show(message, title);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
