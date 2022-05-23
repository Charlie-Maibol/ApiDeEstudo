using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07___ByteBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(CheckingAccounts.GetTotalOfAccountsCreatead());

            
            CheckingAccounts accounts = new CheckingAccounts(867, 86712540);

            Console.WriteLine(CheckingAccounts.GetTotalOfAccountsCreatead());

            Console.WriteLine(accounts.Agency); 
            Console.WriteLine(accounts.Number);

            CheckingAccounts contaDaGabrielle = new CheckingAccounts(867, 86745820);
            
            Console.WriteLine(CheckingAccounts.GetTotalOfAccountsCreatead());

            Console.ReadLine();
        }
    }
}
