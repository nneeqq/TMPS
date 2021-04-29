using System;
using TMPS_LAB3.Interfaces;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Map
{
    public class Level_1 : IRestriction
    {
        public string UserRestriction { get; set; }
        public UserType Type { get; set; }

        public IRestriction IRestriction
        {
            get => default;
            set
            {
            }
        }

        public Level_1(string userRestriction, UserType type)
        {
            UserRestriction = userRestriction;
            Type = type;
        }

        public void Apply()
        {
            Console.WriteLine($"User-ul de tip {Type} are restrictie de {UserRestriction} \n");
        }
        public object Clone()
        {
            var copy = new Level_1(UserRestriction, Type)
            {
                UserRestriction = UserRestriction,
                Type = Type
            };

            return copy;
        }
    }
}
