using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank;

namespace ByteBank.Sistema
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CheckingAccounts accounts = new CheckingAccounts(458, 455789);
            Console.WriteLine(accounts.Currency);

            

            Console.ReadLine();
        }
    }
}
