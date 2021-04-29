using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPS_LAB4.Interfaces;

namespace TMPS_LAB4.Decorator
{
    class CounterSpecification:SalaryDecorator
    {
        public CounterSpecification(ISalarySpecification salary) : base(salary)
        {

        }


        public override decimal CountSalary()
        {
            return _salary.CountSalary() * 1.3m;
        }
    }
}
