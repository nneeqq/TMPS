using System;
using System.Collections.Generic;
using System.Text;
using TMPS_LAB3.Types;

namespace TMPS_LAB3.Interfaces
{
    public interface IRestriction : System.ICloneable
    {
        public string UserRestriction { get; set; }
        public UserType Type { get; set; }
        public void Apply();
    }
}
