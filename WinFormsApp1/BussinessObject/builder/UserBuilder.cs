using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.BussinessObject.IBuilder;

namespace WinFormsApp1.BussinessObject.builder
{
    public class UserBuilder : IUserBuilder
    {
        UserEntity user = new UserEntity();

        public UserBuilder()
        {

        }

        IUserBuilder IUserBuilder.newInstance()
        {
            return new UserBuilder();
        }

        IUserBuilder IUserBuilder.InCity(string city)
        {
            user.City = city;
            return this;
        }

        IUserBuilder IUserBuilder.ofCountry(string country)
        {
            user.Country = country;
            return this;
        }

        IUserBuilder IUserBuilder.setEmail(string email)
        {
            user.Email = email;
            return this;
        }

        IUserBuilder IUserBuilder.setName(string name)
        {
            user.UserName = name;
            return this;
        }

        IUserBuilder IUserBuilder.setPassword(string password)
        {
            user.Password = password;
            return this;
        }

        IUserBuilder IUserBuilder.WithId(long id)
        {
            user.Id = id;
            return this;
        }
        IUserBuilder IUserBuilder.Role(WinFormsApp1.constants.enums.Role role)
        {
            user.Role = role;
            return this;
        }


        UserEntity IUserBuilder.build()
        {
            return user;
        }
    }
}
