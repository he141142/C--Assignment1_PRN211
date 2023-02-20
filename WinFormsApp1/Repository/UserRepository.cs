using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.BussinessObject;
using WinFormsApp1.DataAccess;
using WinFormsApp1.Repository.interfaces;

namespace WinFormsApp1.Repository
{
    public class UserRepository : IUserRepository
    {
        UserDAO userDAO;
        public UserRepository()
        {
            this.userDAO = UserDAO.Instance;
        }
        public UserEntity getByEmailAndPassword(string email, string password) => this.userDAO.findByEmailAndPassword(email, password);

        public List<UserEntity> FindAlExceptAdmin() => this.userDAO.findAllExceptAdmin();
        public List<UserEntity> FindAll()
        {
            throw new NotImplementedException();
        }

        public UserEntity findById(long id) => this.userDAO.findById(id);

        public long getlatestId() => this.userDAO.getMaxId();

        public void addUser(List<UserEntity> entities)
        {
            this.userDAO.addUser(entities);
        }


        public void InsertNew(UserEntity userEntity)
        {
            this.userDAO.InsertNew(userEntity);
        }

        public UserEntity findByEmail(String email) => this.userDAO.findByEmail(email);

        public void UpdateUserById(UserEntity userEntity, long id) => this.userDAO.UpdateUserById(userEntity, id);

    }
}
