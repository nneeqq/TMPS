using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMPS_LAB4.Data
{
    public class Owner
    {
        public IUserBuilder IUserBuilder
        {
            get => default;
            set
            {
            }
        }

        public void Construct(IUserBuilder builder, int id, string firstName, string lastName, string role)
        {
            builder.Id(id);
            builder.FirstName(firstName);
            builder.LastName(lastName);
            builder.Role(role);
        }
    }
}
