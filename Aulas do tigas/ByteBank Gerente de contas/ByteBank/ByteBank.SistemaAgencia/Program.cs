using System;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    internal class Program {

        static void Main(string[] args)
        {

            CheckingAccounts[] accounts = new CheckingAccounts[]
            {
                new CheckingAccounts(874, 5679878),
               new  CheckingAccounts(874, 6669878),
                new CheckingAccounts(874, 9879878),
            };

            

            for (int index = 0; index < accounts.Length; index++)
            {
                 CheckingAccounts currentAccount = accounts[index];

                Console.WriteLine($"Conta {index} {currentAccount.Number}");
                Console.WriteLine($"Conta {index} {accounts[index].Agency}");
            }

            Console.ReadLine();
        }
        
        static void arryTesteInt()
        {
            int[] ages = null;
            ages = new int[6];

            ages[0] = 15;
            ages[1] = 28;
            ages[2] = 35;
            ages[3] = 50;
            ages[4] = 28;
            ages[5] = 60;

            Console.WriteLine(ages.Length);

            int holder = 0;

            for (int index = 0; index < ages.Length; index++)
            {
                int age = ages[index];

                Console.WriteLine($"Acessando o array idades no índice {index}");
                Console.WriteLine($"Valor de idades[{index}] = {age}");

                holder += age;
            }

            int media = holder / ages.Length;
            Console.WriteLine($"Média de idades = {media}");

        }
    }


}
