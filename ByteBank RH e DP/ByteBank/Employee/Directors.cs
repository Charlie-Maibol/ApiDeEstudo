using System;

namespace ByteBank.Employee
{
    public class Directors : Employees
    {
        public string Password { get; set; }

        public Directors(string cpf) : base(5000, cpf)
        {
            Console.WriteLine("Criando DIRETOR");

        }

        public bool Autentication(string passoword)
        {

            return this.Password == passoword;


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

