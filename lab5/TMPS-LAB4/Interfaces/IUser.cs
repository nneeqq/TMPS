using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TMPS_LAB4
{
    public interface IUser
    {
        string FirstName { get; set; }
        string LastName { get; set; }
        int UserId { get; set; }
        string Role { get; set; }
    }
}
