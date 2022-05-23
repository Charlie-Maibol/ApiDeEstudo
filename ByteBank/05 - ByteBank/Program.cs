using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _05___ByteBank
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Cliente gabriela = new Cliente();

            // gabriela.nome = "Gabriela";
            // gabriela.profissao = "Desenvolvedora C#";
            // gabriela.cpf = "434.562.878-20";

            CheckingAccounts account = new CheckingAccounts();

            // conta.titular = gabriela;
            // conta.titular = new Cliente();

            // conta.titular.nome = "Gabriela Costa";
            // conta.titular.cpf = "434.562.878-20";
            // conta.titular.profissao = "Desenvolvedora C#";

            account.currency = 500;
            account.agency = 563;
            account.number = 5634527;

            if (account.holder == null)
            {
                Console.WriteLine("Ops, a referência em conta.titular é NULL");
            }

            // Console.WriteLine(gabriela.name);
            Console.WriteLine(account.holder);
            // Console.WriteLine(conta.titular.name);
            // Console.WriteLine(conta.titular.cpf);
            // Console.WriteLine(conta.titular.profission);

            Console.ReadLine();
        }
    }
}
