using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPS_LAB4.Interfaces;

namespace TMPS_LAB4.Decorator
{
    public class DepartmentDirectorSpecification: SalaryDecorator
    {
        public DepartmentDirectorSpecification(ISalarySpecification salary) : base(salary)
        {

        }

        public ISalarySpecification ISalarySpecification
        {
            get => default;
            set
            {
            }
        }

        public override decimal CountSalary()
        {
            return _salary.CountSalary() * 1.4m;
        }
    }
}
