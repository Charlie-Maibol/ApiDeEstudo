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
            Console.WriteLine("Executando projeto 8 - condicionais 2");

            int joaoAges = 18;
            //int companion = 2;
            //bool guest = companion >= 2;
            bool guest = false;

            if (joaoAges >= 18 && guest == true)
            {
                Console.WriteLine("joão pode entrar");
            }
            else
            {
                Console.WriteLine("João não pode entrar");
                
            }
            Console.ReadLine();
        }

    }

}
