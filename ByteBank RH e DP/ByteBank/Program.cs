using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Employee;

namespace ByteBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Employees carlos = new Employees(1);

            carlos.Name = "Carlos";
            carlos.CPF = "546.879.157-20";
            carlos.Salary = 2000;

            Console.WriteLine(carlos.Name);
            Console.WriteLine(carlos.GetBonus());

            Console.ReadLine();

        }
    }
}
