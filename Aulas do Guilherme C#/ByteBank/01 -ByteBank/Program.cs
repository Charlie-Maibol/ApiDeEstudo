using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01__ByteBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CheckingAccounts checkingAccountsGabrielle =  new CheckingAccounts();

            checkingAccountsGabrielle.holder = "Gabrielle";
            checkingAccountsGabrielle.agency = 863;
            checkingAccountsGabrielle.number = 863452;
            checkingAccountsGabrielle.currency = 100;

            Console.WriteLine(checkingAccountsGabrielle.holder);
            Console.WriteLine("Agencia " + checkingAccountsGabrielle.agency);
            Console.WriteLine("Número da agencia " + checkingAccountsGabrielle.number);
            Console.WriteLine("Seu saldo é R$" + checkingAccountsGabrielle.currency);

            checkingAccountsGabrielle.currency += 200;

            Console.WriteLine("Seu novo saldo é R$" + checkingAccountsGabrielle.currency);

            Console.ReadLine();

        }
    }
}
