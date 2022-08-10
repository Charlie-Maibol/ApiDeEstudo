using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02___ByteBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CheckingAccounts accounts = new CheckingAccounts();

            accounts.holder = "gabrielle";

            accounts.currency = 200;

            Console.WriteLine(accounts.holder);
            Console.WriteLine(accounts.agency);
            Console.WriteLine(accounts.currency);

            Console.ReadLine();
        }
    }
}
