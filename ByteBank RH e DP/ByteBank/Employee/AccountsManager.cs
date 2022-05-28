using ByteBank.BankSystem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employee
{
    internal class AccountsManager : Authenticable
    {
               
        public AccountsManager(string cpf) : base(4000, cpf)
        {
            Console.WriteLine("Criando Gerente de contas");

        }

        public override void RaseSalary()
        {
            Salary *= 1.05;
        }

        public override double GetBonus()
        {

            return Salary * 0.25;

        }

    }
}
