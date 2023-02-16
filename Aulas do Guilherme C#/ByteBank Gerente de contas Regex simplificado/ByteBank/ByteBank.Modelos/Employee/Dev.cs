using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employee
{
    public class Dev : Employees
    {
        public Dev(string cpf) : base(3000, cpf)
        {
            Console.WriteLine("Criando Desenvolvedor");
        }

        public override void RaseSalary()
        {
            Salary *= 1.15;
        }
        internal protected override double GetBonus()
        {
            return Salary * 0.1;
        }
    }
}
