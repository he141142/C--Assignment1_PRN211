using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1.constants.enums;

namespace WinFormsApp1.BussinessObject.IBuilder
{
    public interface IUserBuilder
    {
        IUserBuilder setName(String name);
        IUserBuilder setPassword(String password);

        IUserBuilder setEmail(String email);

        IUserBuilder InCity(String city);

        IUserBuilder ofCountry(String country);

        IUserBuilder WithId(long id);

        IUserBuilder Role(Role role);

        IUserBuilder newInstance();

        UserEntity build();

    }
}
