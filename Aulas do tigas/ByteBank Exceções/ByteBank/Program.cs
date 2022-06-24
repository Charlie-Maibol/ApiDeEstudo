using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                LoadAccounts();
            }
            catch (Exception)
            {
                Console.WriteLine("Catch no metodo main");
            }

            Console.WriteLine("Execução finalizada. Tecle enter para sair");
            Console.ReadLine();
        }
        private static void LoadAccounts()
        {

            using(Reader reader = new Reader("teste.txt"))
            {
                reader.NextLine();
            }


            //-----------------------------------------------------
            //Reader reader = null;
            //try
            //{
            //    reader = new Reader("contas.txt");

            //    reader.NextLine();
            //    reader.NextLine();
            //    reader.NextLine();

            //}
            //catch (IOException)
            //{
            //    Console.WriteLine("Exceção do tipo IOException capturada e tratada!");

            //}
            //finally
            //{
            //    Console.WriteLine("Executando Finally");
            //    if(reader != null)
            //    {
            //        reader.Close();
            //    }
            //}
        }
        private static void InnerExcepitonTester()
        {
            try
            {
                CheckingAccounts account1 = new CheckingAccounts(4564, 789684);
                CheckingAccounts account2 = new CheckingAccounts(7891, 456794);

                account1.Transfer(10000, account2);
                //account1.Whithdraw(100000);
            }
            catch (FinancialOperationException e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);

                Console.WriteLine("Informações da INNER EXCEPTION (exceção interna):");
                Console.WriteLine(e.InnerException.Message);
                Console.WriteLine(e.InnerException.StackTrace);
            }
        }

        // Teste com a cadeia de chamada:
        // Metodo -> TestaDivisao -> Dividir
        private static void Method()
        {
            DivisionTest(0);
        }

        private static void DivisionTest(int divided)
        {
            int result = Dividir(10, divided);
            Console.WriteLine("Resultado da divisão de 10 por " + divided + " é " + result);
        }

        private static int Dividir(int number, int divided)
        {
            try
            {
                return number / divided;
            }
            catch (DivideByZeroException)
            {
                Console.WriteLine("Exceção com numero=" + number + " e divisor=" + divided);
                throw;
                
            }
        }

    }
}
