using System;
using System.Collections.Generic;
using System.Text;
using TMPS_LAB3.Enemies;
using TMPS_LAB3.Interfaces;
using TMPS_LAB3.Map;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Factories
{
    class Level1Factory : ILevelFactory
    {
        public Level_1 Level_1
        {
            get => default;
            set
            {
            }
        }

        public Admin Admin
        {
            get => default;
            set
            {
            }
        }

        public IType CreateUserType(string owner, int id, UserType type)
        {
            return new Moderator(id, owner, type);
        }

        public IRestriction CreateRestriction(string userRestriction, UserType type)
        {
            return new Level_1(userRestriction, type);
        }
    }

    public class Class1
    {
    }
}
