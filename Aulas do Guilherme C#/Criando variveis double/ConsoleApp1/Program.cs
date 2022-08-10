using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 7 - condicionais");

            int joaoAges = 16;
            int companion = 2;

            if (joaoAges >= 18)
            {
                Console.WriteLine("joão é maior de idade pode entrar");
            }
            else
            {
                if (companion >= 2)
                {
                    Console.WriteLine("João é menor de idade, mas esta acompanhando");
                }
                else
                {
                    Console.WriteLine("João não está acompanhado de um adulto");
                }
            }
            Console.ReadLine();
        }
        
     }
    
}
