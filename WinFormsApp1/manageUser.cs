using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.BussinessObject;
using WinFormsApp1.partialForm;
using WinFormsApp1.Repository;

namespace WinFormsApp1
{
    public partial class manageUser : Form
    {

        UserRepository repo = new UserRepository();
        public manageUser()
        {
            InitializeComponent();
        }

        public void LoadUsers()
        {
            this.Visible = true;
            dataGridView1.DataSource = this.getuserData();
        }

        private DataTable getuserData()
        {
            DataTable table = new DataTable();

            table.Columns.Add("Id", typeof(long));
            table.Columns.Add("Email", typeof(String));
            table.Columns.Add("Name", typeof(String));
            table.Columns.Add("Country", typeof(String));
            table.Columns.Add("City", typeof(String));

            List<UserEntity> users = this.repo.FindAlExceptAdmin();
            Console.WriteLine(users.Count);
            Console.WriteLine(users.Count);

            foreach (UserEntity user in users)
            {
                richTextBox1.Text += user.UserName;
                table.Rows.Add(user.Id, user.UserName, user.Country, user.City, user.Email);
            }
            return table;
        }

        private void manageUser_Load(object sender, EventArgs e)
        {

        }

        public void RefreshData()
        {
            DataTable data = this.getuserData();
            dataGridView1.DataSource = data;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                userIDSelected.Text= Convert.ToString(dataGridView1.Rows[e.RowIndex].Cells[0].Value);
            }
        }

        private void createUserBtn_Click(object sender, EventArgs e)
        {

        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void createUserBtn_Enter(object sender, EventArgs e)
        {

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if(userIDSelected.Text!= null) {
                UserEntity userEntity = this.repo.findById(Convert.ToInt64(userIDSelected.Text));
                if (userEntity != null)
                {
                    PartialFormCreateUser formCreateUsr = new PartialFormCreateUser().addFormStack(this)
                         .InjectRepo(repo).LoadUserEntity(userEntity);
                    formCreateUsr.Visible= true;
                }
            }
        }
    }
}
