using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.BussinessObject;

namespace WinFormsApp1.Repository.interfaces
{
    public interface IUserRepository
    {
        public UserEntity getByEmailAndPassword(String email,String password);

        public List<UserEntity> FindAll();
        public List<UserEntity> FindAlExceptAdmin();

        public UserEntity findById(long id);

        public long getlatestId();

        public void addUser(List<UserEntity> entities);

        public UserEntity findByEmail(String email);

    }
}
