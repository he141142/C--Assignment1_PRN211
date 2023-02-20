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
        Form prev;
        public PartialFormCreateUser()
        {
            InitializeComponent();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }


        public Form addFormStack(Form prevForm)
        {
            this.prev= prevForm;
            return this;
        }

        public PartialFormCreateUser InjectRepo(IUserRepository userRepo) {
            if (userRepo!=null) {
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
            return this;
        }

        private void saveChangeBtn_Click(object sender, EventArgs e)
        {
            long id = this.userRepo.getlatestId() + 1;
            IUserBuilder userBuilder = new UserBuilder();

        }
    }
}
