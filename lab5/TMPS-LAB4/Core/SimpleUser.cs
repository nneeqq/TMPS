using TMPS_LAB4.Interfaces;

namespace TMPS_LAB4.Core
{
    public class SimpleUser : IUser, ISalarySpecification
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int UserId { get; set; }
        public string Role { get; set; }

        public IUser IUser
        {
            get => default;
            set
            {
            }
        }

        public decimal CountSalary()
        {
            return 7000m;
        }
    }

}
