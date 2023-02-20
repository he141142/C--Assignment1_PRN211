using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.constants.enums;

namespace WinFormsApp1.BussinessObject
{
    public class UserEntity
    {
        String userName;
        long id;
        String country;
        String city;
        String email;
        String password;
        Role role;

        public long Id { get => id; set => id = value; }
        public string Country { get => country; set => country = value; }
        public string City { get => city; set => city = value; }
        public string Email { get => email; set => email = value; }
        public string Password { get => password; set => password = value; }
        public Role Role { get => role; set => role = value; }
        public string UserName { get => userName; set => userName = value; }

        public void SelfValidate()
        {
            if (this.Email == null || this.Email == "")
            {
                throw new Exception("Email is mandatory!");
            }

            if (this.Password == null || this.Password == "")
            {
                throw new Exception("Password is mandatory!");
            }

            if (this.UserName == null || this.UserName == "")
            {
                throw new Exception("UserName is mandatory!");
            }

            if (this.City == null || this.City == "")
            {
                throw new Exception("City is mandatory!");
            }

            if (this.Country == null || this.Country == "")
            {
                throw new Exception("Country is mandatory!");
            }

        }
    }



}
