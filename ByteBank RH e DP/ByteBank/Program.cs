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
            BonusManager bonus = new BonusManager();

            Employees carlos = new Employees();

            carlos.Name = "Carlos";
            carlos.CPF = "546.879.157-20";
            carlos.Salary = 2000;

            bonus.Register(carlos);

            Directors roberta = new Directors();

            roberta.Name = "Roberta";
            roberta.CPF = "454.658.148-3";
            roberta.Salary = 5000;

            bonus.Register(roberta);

            Console.WriteLine(carlos.Name);
            Console.WriteLine(carlos.GetBonus());

            Console.WriteLine(roberta.Name);
            Console.WriteLine(roberta.GetBonus());

            Console.WriteLine("Total de  bonificação: " + bonus.GetTotalBonus());

            Console.ReadLine();

        }
    }
}
