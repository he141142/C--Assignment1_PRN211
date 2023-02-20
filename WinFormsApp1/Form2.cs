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
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class Form2 : Form
    {

        UserEntity userEntity = null;
        public Form2()
        {
            InitializeComponent();

        }

        public void LoadData()
        {
            userLabel.Text = this.userEntity.UserName;
            emailLabel.Text = this.userEntity.Email;
            countryLabel.Text = this.userEntity.Country;
            cityLabel.Text = this.userEntity.City;
        }

        public Form2 LoadUserProfile(UserEntity userEntity)
        {
            this.userEntity = userEntity;
            this.Visible = true;
            if(userEntity.Role == constants.enums.Role.ADMIN)
            {
                this.button1.Visible = true;
            }

            return this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.HandleListUser();
        }

        private void HandleListUser()
        {
            this.Visible = false;
            manageUser manageUsr = new manageUser();
            manageUsr.LoadUsers();
        }
    }
}
