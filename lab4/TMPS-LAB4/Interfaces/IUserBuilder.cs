using TMPS_LAB4.Data;

namespace TMPS_LAB4
{
    public interface IUserBuilder
    {
        IUserBuilder LastName(string lastname);
        IUserBuilder FirstName(string firstname);
        IUserBuilder Id(int id);
        IUserBuilder Role(string role);
        UserService Build();
    }
}
