using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMPS_LAB4.Data
{
    public class NewUserBuilder : IUserBuilder
    {

        private readonly UserService _newUser = new UserService();

        public IUserBuilder IUserBuilder
        {
            get => default;
            set
            {
            }
        }

        public IUserBuilder FirstName(string firstname)
        {
            _newUser.FirstName = firstname;
            return this;
        }

        public IUserBuilder Id(int id)
        {
            _newUser.UserId = id;
            return this;
        }

        public IUserBuilder LastName(string lastname)
        {
            _newUser.LastName = lastname;
            return this;
        }

        public IUserBuilder Role(string role)
        {
            _newUser.Role = role;
            return this;
        }

        public UserService Build()
        {
            UserService result = _newUser;
            return result;
        }
    }
}
