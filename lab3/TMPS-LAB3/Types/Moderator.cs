using System;
using System.Collections.Generic;
using System.Text;
using TMPS_LAB3.Interfaces;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Enemies
{
    public class Moderator : IType
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public UserType Type { get; set; }

        public IType IType
        {
            get => default;
            set
            {
            }
        }

        public Moderator(int id, string owner, UserType type)
        {
            Id = id;
            Owner = owner;
            Type = type;
        }

        public void Create()
        {
            Console.WriteLine($"User-ul de tip {Type} care apartine lui {Owner} a fost creat cu succes!");
        }

        public object Clone()
        {
            var copy = new Moderator(Id, Owner, Type)
            {
                Id = Id,
                Owner = Owner,
                Type = Type
            };

            return copy;
        }
    }
}
