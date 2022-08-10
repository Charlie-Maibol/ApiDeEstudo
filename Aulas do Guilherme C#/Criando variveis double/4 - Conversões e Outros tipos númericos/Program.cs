using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _4___Conversões_e_Outros_tipos_númericos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando o projeto 4");

            //o int é usado para número até 32 bytes

            double salary;
            salary = 1200.50;

            int fullSalary = (int)salary;



            Console.WriteLine("Seu salário arrendodado é " + fullSalary);

            //o long é suporta até 64 bytes
            long age = 26000000000000000;

            Console.WriteLine(age);

            //O Short suporta até 16 bytes
            short products = 15000;

            Console.WriteLine(products);

           
            // o Float precisa usar o sufixo f

            float height = 1.80f;

            Console.WriteLine(height);


            Console.ReadLine();
        }
    }
}
