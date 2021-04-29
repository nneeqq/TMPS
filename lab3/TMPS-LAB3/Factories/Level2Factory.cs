using System;
using System.Collections.Generic;
using System.Text;
using TMPS_LAB3.Enemies;
using TMPS_LAB3.Interfaces;
using TMPS_LAB3.Map;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Factories
{
    class Level2Factory : ILevelFactory
    {
        public Level_0 Level_0
        {
            get => default;
            set
            {
            }
        }

        public Moderator Moderator
        {
            get => default;
            set
            {
            }
        }

        public IType CreateUserType(string owner, int id, UserType type)
        {
            return new Admin(id, owner, type);
        }

        public IRestriction CreateRestriction(string UserRestriction, UserType type)
        {
            return new Level_0(UserRestriction, type);
        }
    }
}
