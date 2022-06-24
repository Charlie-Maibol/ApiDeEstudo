using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employee
{
    internal class Designers : Employees
    {

        public Designers(string cpf) : base(3000, cpf)
        {
            Console.WriteLine("Criando Designer");

        }

        public override void RaseSalary()
        {
            Salary *= 1.11;
        }

        internal protected override double GetBonus()
        {

            return Salary * 0.17;

        }

    }
}
