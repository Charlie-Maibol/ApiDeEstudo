using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _04___ByteBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CheckingAccounts ContaDoBruno = new CheckingAccounts();

            ContaDoBruno.holder = "Bruno";

            Console.WriteLine(ContaDoBruno.currency);

            bool resultCheckout = ContaDoBruno.Checkout(500);

            Console.WriteLine(resultCheckout);
            Console.WriteLine(ContaDoBruno.currency);
            ContaDoBruno.CheckIn(500);
            Console.WriteLine(ContaDoBruno.currency);  

            CheckingAccounts contaDaGabrielle = new CheckingAccounts();

            contaDaGabrielle.holder = "Gabriella";
            Console.WriteLine("Saldo do Gabrielle: " + contaDaGabrielle.currency);

            bool TranferResult = ContaDoBruno.Transfer(200, contaDaGabrielle);

            Console.WriteLine("Saldo do Bruno: " + ContaDoBruno.currency);
            Console.WriteLine("Saldo do Gabrielle: " + contaDaGabrielle.currency);

            Console.WriteLine("Resultado da tranferencia: " + TranferResult);

            Console.ReadLine();
        }
    }
}
