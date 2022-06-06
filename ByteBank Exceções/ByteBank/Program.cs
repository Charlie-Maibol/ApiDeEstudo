using System;
using System.Collections.Generic;
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

                Method();
            }
            catch (DivideByZeroException error)
            {
                Console.WriteLine(error.Message);
                Console.WriteLine("Não é possivel fazer divisão por 0!");
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
                Console.WriteLine("Aconteceu um erro!");
            }

            Console.ReadLine();
        }
        //Teste com a cadeia de chamada:
        //Metodo -> TestaDivisao -> Dividir
        private static void Method()
        {

            DivisionTest(0);

        }

        private static void DivisionTest(int divided)
        {

            int result = Division(10, divided);
            Console.WriteLine("Resultado da divisão de 10 por " + divided + " é " + result);

        }

        private static int Division(int numero, int divisor)
        {

           CheckingAccounts accounts = null;
           Console.WriteLine(accounts.Currency);

            return numero / divisor;
        }
    }
}