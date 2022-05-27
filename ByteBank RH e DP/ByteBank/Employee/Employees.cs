using System;

namespace ByteBank.Employee
{
    public abstract class Employees
    {
        public static int EmployeesTotal { get; private set; }

        public string Name { get; set; }
        public string CPF { get; private set; }
        public double Salary { get; protected set; }

        public Employees(double salary, string cpf)
        {

            Console.WriteLine("Criando Funcionário");
            Salary = salary;
            CPF = cpf;
            EmployeesTotal++;

        }

        public abstract void RaseSalary();

        public abstract double GetBonus();
       

    }
}
