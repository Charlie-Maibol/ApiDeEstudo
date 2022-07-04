using System;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    internal class Program
    {

        static void Main(string[] args)
        {


            ObjectList AgesList = new ObjectList();

            AgesList.add(9);
            AgesList.add(1);
            AgesList.add(17);
            AgesList.add(20);
            AgesList.add(87);
            AgesList.add(50);
            AgesList.add(12);
            AgesList.add(1);
            AgesList.addAlot(19, 16, 12, 60);

            for(int i = 0; i < AgesList.Seize; i++)
            {
                int age = (int)AgesList[i];
                Console.WriteLine($"Idade no indice{i}:{age}"); 
            }


            Console.WriteLine(PlusAll(1, 2, 3, 4, 5, 6, 7, 8));
            Console.WriteLine(PlusAll(1, 2, 45));

            ListOfCheckingaccounts list = new ListOfCheckingaccounts();
            list.myMethodo(number: 10);
            list.myMethodo("text", 10);

            CheckingAccounts CharlesAccount = new CheckingAccounts(565484814, 567976);

            list.add(CharlesAccount);


            list.add(new CheckingAccounts(874, 5679878));
            list.add(new CheckingAccounts(874, 5679878));
          

            CheckingAccounts[] accounts = new CheckingAccounts[]
        {
                CharlesAccount,
                new CheckingAccounts(874, 5679878),
                new CheckingAccounts(874, 5679878)
        };

            list.addAlot(accounts);
            list.addAlot(CharlesAccount,
                new CheckingAccounts(874, 5679878),
                new CheckingAccounts(874, 5679878));

            for (int i = 0; i <list.Seize; i++)
            {
               CheckingAccounts currentItem = list.GetItemIndex(i);
                Console.WriteLine($"item na posição {i} = conta {currentItem.Number}/{currentItem.Agency}");
            }

           


            Console.ReadLine();
        }

        static int PlusAll(params int[] numbers)
        {
            int holder = 0;
            foreach (int number in numbers)
            {
                holder += number;
            }
            return holder;
        }
        public void testingArrayCheckingAccouts()
        {
            CheckingAccounts[] accounts = new CheckingAccounts[]
           {
                new CheckingAccounts(874, 5679878),
                new CheckingAccounts(874, 6669878),
                new CheckingAccounts(874, 9879878),
           };



            for (int index = 0; index < accounts.Length; index++)
            {
                object currentAccount = accounts[index];

               Console.WriteLine($"Conta {index} {accounts[index].Number}");
                Console.WriteLine($"Conta {index} {accounts[index].Agency}");
            }
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
