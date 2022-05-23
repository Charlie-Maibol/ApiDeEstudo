using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _06___ByteBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CheckingAccounts accounts = new CheckingAccounts();

            accounts.ObtainCurrecy(-10);

            Console.WriteLine(accounts.ObtainCurrecy());

            Console.ReadLine();
        }
    }
}
