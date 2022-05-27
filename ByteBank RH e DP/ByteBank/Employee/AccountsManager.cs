using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employee
{
    internal class AccountsManager : Employees
    {
        public string Password { get; set; }

        public bool Autentication(string passoword)
        {

            return this.Password == passoword;


        }

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
