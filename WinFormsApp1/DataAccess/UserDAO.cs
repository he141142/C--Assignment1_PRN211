using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.BussinessObject;
using WinFormsApp1.BussinessObject.builder;
using WinFormsApp1.BussinessObject.IBuilder;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace WinFormsApp1.DataAccess
{
    internal class UserDAO
    {
        private static UserDAO instance = null;
        private static readonly object instanceLock = new object();

        private IEnumerable<UserEntity> userEntityList = null;

        public UserDAO()
        {
            IUserBuilder userBuilder = new UserBuilder();
            IEnumerable<UserEntity> userEntityList = new List<UserEntity> {
                new UserEntity
                {
                    Id=1,
                    City = "Ha Noi",
                    Country = "Viet Nam",
                    Email = "longnt1@vmodev.com",
                    UserName= "longnt1",
                    Password="123456",
                    Role= constants.enums.Role.USER
                },
                userBuilder
                .setName("jon35")
                .setPassword("123456")
                .ofCountry("VietNam")
                .InCity("Dong Nai")
                .WithId(3)
                .setEmail("jon35@gmail.com")
                .Role(constants.enums.Role.USER)
                .build(),
                userBuilder.newInstance()
                .setName("hoaprox")
                 .WithId(2)
                .setPassword("123456")
                .ofCountry("VietNam")
                .setEmail("hoaprox@gmail.com")
                .InCity("Hai Duong")
                .Role(constants.enums.Role.USER)
                .build()
               ,
                userBuilder.newInstance()
                .setName("admin")
                .setPassword("admin")
                .ofCountry("VietNam")
                .setEmail("admin")
                .WithId(0)
                .InCity("Hai Duong")
                .Role(constants.enums.Role.ADMIN)
                .build()
            };

            this.userEntityList = userEntityList;
        }

        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                    return instance;
                }
            }
        }

        public UserEntity findByEmailAndPassword(String email, String password)
        {
            if (password == null)
            {
                password = "";
            }
            if (email == null)
            {
                email = "";
            }
            UserEntity us = this.UserEntityList.FirstOrDefault(u => u.Email == email && u.Password == password);
            if (us == null) return null;
            return us;
        }

        public List<UserEntity> findAllExceptAdmin()
        {
            if (this.userEntityList != null)
                return this.userEntityList.Where(u => u.Role != constants.enums.Role.ADMIN).ToList();
            return null;
        }

        public UserEntity findById(long id)
        {
            if (this.userEntityList != null)
                return this.userEntityList.First(u => u.Id ==id);
            return null;
        }

        public long getMaxId()
        {
            if (this.userEntityList != null)
                return this.userEntityList.Max(u => u.Id);

            return 0;
        }

        public void addUser(List<UserEntity> entities)
        {
            this.userEntityList.Concat(entities);
        }

        public UserEntity findByEmail(String email)
        {
            return this.userEntityList.First(u => u.Email == email);
        }

        public void UpdateUserById(UserEntity userEntity,long id)
        {

        }



        public IEnumerable<UserEntity> UserEntityList { get => userEntityList; set => userEntityList = value; }
    }
}
