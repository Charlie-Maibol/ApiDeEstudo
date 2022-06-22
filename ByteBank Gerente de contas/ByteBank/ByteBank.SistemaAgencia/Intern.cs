using ByteBank.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class Intern : Employees
    {
        public Intern (double salary, string cpf) : base (salary, cpf)
        {

        }
        public override void RaseSalary()
        {
            //Qualquer codigo
        }

        protected override double GetBonus()
        {
            throw new NotImplementedException();
        }
    }
}
