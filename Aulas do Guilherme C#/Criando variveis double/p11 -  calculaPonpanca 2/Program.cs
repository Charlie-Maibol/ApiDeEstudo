using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p11____calculaPonpanca_2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 11");

            double  investedMoney = 1000;

            for
            (int months = 1; months <= 12; months++) 
            {
                investedMoney *= 1.0036;
                Console.WriteLine("Após " + months + " meses você terá R$" + investedMoney);

            }

            Console.ReadLine();
        }
    }
}
