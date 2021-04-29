using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPS_LAB4.Interfaces;

namespace TMPS_LAB4.Decorator
{
    public abstract class SalaryDecorator : ISalarySpecification
    {
        protected readonly ISalarySpecification _salary;

        public SalaryDecorator(ISalarySpecification salary)
        {
            _salary = salary;
        }

        public ISalarySpecification ISalarySpecification
        {
            get => default;
            set
            {
            }
        }

        public abstract decimal CountSalary();
    }
}
