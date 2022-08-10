using ByteBank.BankSystem;
using System;

namespace ByteBank.Employee
{
    public class Directors : UserLoginEmployee
    {

        public Directors(string cpf) : base(5000, cpf)
        {
            Console.WriteLine("Criando DIRETOR");

        }

       
        public override void RaseSalary()
        {
            Salary *= 1.15;
        }

        public override double GetBonus()
        {

            return Salary * 0.5;

        }
    }
}

