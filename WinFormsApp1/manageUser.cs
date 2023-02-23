using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using WinFormsApp1.BussinessObject;
using WinFormsApp1.partialForm;
using WinFormsApp1.Repository;
using WinFormsApp1.Trigger;

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
            CreateUserForm createForm = new CreateUserForm().InjectForm(this).InjectRepo(repo);
            createForm.Visible= true;
        }

        private void contextMenuStrip2_Opening(object sender, CancelEventArgs e)
        {

        }

        private void createUserBtn_Enter(object sender, EventArgs e)
        {

        }

        private void updateBtn_Click(object sender, EventArgs e)
        {
            if(userIDSelected.Text!= null || userIDSelected.Text!="") {
                long idToFind = TryParseLongValue(userIDSelected.Text);
                if (idToFind == -1)
                {
                    ShowErrorMsgBox("You must to choose exactly one entity!");
                    return;
                }
                UserEntity userEntity = this.repo.findById(Convert.ToInt64(userIDSelected.Text));
                if (userEntity != null)
                {
                    PartialFormCreateUser formCreateUsr = new PartialFormCreateUser().addFormStack(this)
                         .InjectRepo(repo).LoadUserEntity(userEntity);
                    formCreateUsr.Visible= true;
                }
            }
        }

        public static void ShowErrorMsgBox(String msg)
        {
            string message = msg;
            string title = "error";
            MessageBox.Show(message, title);
        }


        private long TryParseLongValue(String someValue)
        {
            try
            {
                return Convert.ToInt64(userIDSelected.Text);
            }
            catch(FormatException ex)
            {
                return -1;
            }
        }

        public static void DialogOtion(Itrigger trigger)
        {
            DialogResult dialogResult = MessageBox.Show(trigger.Content(), trigger.Title(), MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                trigger.PerFormYes();
            }
            else if (dialogResult == DialogResult.No)
            {
                return;
            }
        }

        private void deleteBtn_Click(object sender, EventArgs e)
        {
            long idToFind = TryParseLongValue(userIDSelected.Text);
            if (idToFind == -1)
            {
                ShowErrorMsgBox("You must to choose exactly one entity!");
                return;
            }
            Itrigger deleteTrigger = new ConfirmDeleteUserHandler(this.repo,idToFind)
                .WithContent("Delte this user?")
                .WithTitle("delete")
                .AddForm(this);

            DialogOtion(deleteTrigger);
        }
    }
}
