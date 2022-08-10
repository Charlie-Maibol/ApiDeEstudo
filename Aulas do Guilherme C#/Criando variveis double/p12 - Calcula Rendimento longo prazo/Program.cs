using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p12___Calcula_Rendimento_longo_prazo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 12");

            double investedMoney = 1000;
            double rendFactor = 1.0036;

            for(int years =1; years <= 5; years++)
            {
                for(int months =1; months <= 12; months++)
                {
                    investedMoney *= rendFactor;
                }
                rendFactor += 0.0010;
            }
            Console.WriteLine("Ao termino do investimento você terá R$" + investedMoney);


            Console.ReadLine();
        }
    }
}
