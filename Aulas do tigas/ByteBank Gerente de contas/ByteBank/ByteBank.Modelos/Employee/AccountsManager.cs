using ByteBank.Modelos.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employee
{
    internal class AccountsManager : UserLoginEmployee
    {
               
        public AccountsManager(string cpf) : base(4000, cpf)
        {
            Console.WriteLine("Criando Gerente de contas");

        }

        public override void RaseSalary()
        {
            Salary *= 1.05;
        }


        internal protected override double GetBonus()
        {

            return Salary * 0.25;

        }

    }
}
