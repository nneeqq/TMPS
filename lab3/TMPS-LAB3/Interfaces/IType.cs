using System;
using System.Collections.Generic;
using System.Text;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Interfaces
{
    public interface IType : System.ICloneable
    {
        public int Id { get; set; }
        public string Owner { get; set; }
        public UserType Type { get; set; }

        public void Create();
    }
}
