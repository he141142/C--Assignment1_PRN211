using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.BussinessObject;
using WinFormsApp1.BussinessObject.builder;
using WinFormsApp1.BussinessObject.IBuilder;
using WinFormsApp1.utils;
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
            try
            {
                return this.userEntityList.First(u => u.Id == id);
            }
            catch (Exception ex)
            {
                return null;
            }
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
            try
            {
                return this.userEntityList.First(u => u.Email == email);
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void UpdateUserById(UserEntity userEntity, long id)
        {
            UserEntity _user = this.userEntityList.FirstOrDefault(u => u.Id == id);

            if (userEntityList == null || (userEntityList != null && userEntityList.Count() == 0)) throw new Exception("User not found!");
            if (!Helper.IsValidEmail(userEntity.Email)) throw new Exception("Email is not valid");
            if (userEntity.Email != null && userEntity.Email != _user.Email)
            {
                UserEntity _emailExisted;
                _emailExisted = this.findByEmail(userEntity.Email);
                if (_emailExisted != null)
                {
                    throw new Exception("Email is already existed");
                };
            }
            userEntityList.ToList().ForEach(usr =>
            {
                if (usr.Id == id)
                {
                    usr.City = userEntity.City;
                    usr.Country = userEntity.Country;
                    usr.UserName = userEntity.UserName;
                    usr.Email = userEntity.Email;
                }
            });
        }

        public void InsertNew(UserEntity userEntity)
        {
            try
            {
                Debug.WriteLine(this.userEntityList.ToList().Count);
                userEntity.Id = this.getMaxId() + 1;
                userEntity.Role = constants.enums.Role.USER;
                userEntity.SelfValidate();
                if (this.IsEmailExist(userEntity.Email)) throw new Exception("Email already existed!");
                else
                {
                    this.userEntityList = this.userEntityList.Concat(new List<UserEntity> { userEntity });
                    Debug.WriteLine(this.userEntityList.ToList().Count);
                    UserEntity user_ = this.findById(userEntity.Id);
                    Debug.WriteLine(
                        string.Format("user inserted : email : {0} name: {1}", user_.Email, user_.UserName)
                        );
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        private bool IsEmailExist(string email) => this.findByEmail(email) != null ? true : false;

        public void RemoveUserByid(long userId)
        {
            this.userEntityList = this.userEntityList.Where(u => u.Id != userId);
        }


        public IEnumerable<UserEntity> UserEntityList { get => userEntityList; set => userEntityList = value; }
    }
}
