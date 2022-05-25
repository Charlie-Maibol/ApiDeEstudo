using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Employee
{
    public class Employees
    {
        public static int EmployeesTotal { get; private set; }   
        
        public string Name { get; set; }
        public string CPF { get; set; }
        public double Salary { get; set; }

        public Employees()
        {
            Console.WriteLine("Criando Funcionário");
            EmployeesTotal++;

        }

      
        
        public virtual double GetBonus()
        {
            
            return Salary * 0.10;

        }
            
    }
}
