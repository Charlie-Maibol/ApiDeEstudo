using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _10___Calculando_poupanca
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando proejto 10 - calculando poupança");

            double investedMoney = 1000;
            int months = 1;

            while (months <= 12)
            {

                investedMoney = investedMoney + investedMoney * 0.0036;
                Console.WriteLine("Após " + months + " mês você terá R$" + investedMoney);
                months++;

            }

         
            Console.ReadLine();
        }
    }
}
