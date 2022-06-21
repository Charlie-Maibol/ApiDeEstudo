using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ByteBank.SistemaAgencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            CheckingAccounts account = new CheckingAccounts(847, 489754);

            Console.WriteLine(account.Number);

            Console.ReadLine();
        }
    }
}
