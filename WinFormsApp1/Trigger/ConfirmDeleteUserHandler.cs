using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.Repository;

namespace WinFormsApp1.Trigger
{
    internal class ConfirmDeleteUserHandler : Itrigger
    {

        UserRepository repo;

        long userId;

        manageUser prev;

        String content;
        String title;

        public ConfirmDeleteUserHandler(UserRepository repo, long userId)
        {
            this.repo = repo;
            this.userId = userId;
        }

        public ConfirmDeleteUserHandler WithContent(String content)
        {
            this.content = content;
            return this;
        }

        public ConfirmDeleteUserHandler WithTitle(String title)
        {
            this.title = title;
            return this;
        }


        public ConfirmDeleteUserHandler AddForm(manageUser prev)
        {
            this.prev= prev;
            return this;
        }

        public String Content()
        {
            return this.content;
        }

        public void PerformNo()
        {
            throw new NotImplementedException();
        }

        public void PerFormYes()
        {
            this.repo.RemoveUserByid(this.userId);
            this.prev.RefreshData();
        }

        public String Title()
        {
            return this.title;
        }
    }
}
