namespace TMPS_LAB4.Core
{
    public class SimpleUser : IUser
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
    }

}
