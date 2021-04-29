using System;
using System.Collections.Generic;
using System.Text;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Interfaces
{
    interface ILevelFactory
    {
        Factories.Level1Factory Level1Factory { get; set; }
        Factories.Level2Factory Level2Factory { get; set; }

        IRestriction CreateRestriction(string userRestriction, UserType type);
        IType CreateUserType(string owner, int id, UserType type);
    }
}
