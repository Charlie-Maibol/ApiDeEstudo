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
            Client client = new Client();

            client.Name = "Charles";
            client.CPF = "434.564.879-20";
            client.Profission = "Desenvolvedor C#";

            accounts.Currency = -10;
            accounts.Holder = client;

            Console.WriteLine(accounts.Holder.Name);
            Console.WriteLine(accounts.Currency);

            Console.ReadLine();
        }
    }
}
