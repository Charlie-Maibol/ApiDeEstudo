using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employee
{
    internal class Ancillary : Employees
    {

        public Ancillary(string cpf) : base(2000, cpf)
        {
            Console.WriteLine("Criando Auxiliar");

        }

        public override void RaseSalary()
        {
            Salary *= 1.10;
        }

        internal protected override double GetBonus()
        {

            return Salary * 0.20; 

        }

    }
}
