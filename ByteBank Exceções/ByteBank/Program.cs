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
                CheckingAccounts account = new CheckingAccounts(456, 4578420);
                CheckingAccounts account2 = new CheckingAccounts(485, 456478);

                account2.Transferir(10000, account);

                account.Deposit(50);
                Console.WriteLine(account.Currency);
                account.Whithdraw(-500);
                Console.WriteLine(account.Currency);
            }
            catch (ArgumentException ex)
            {
                if(ex.ParamName == "number")
                {
                    
                }

                Console.WriteLine("Argumento com problema: " + ex.ParamName);
                Console.WriteLine("Ocorreu uma exceção do tipo ArgumentException");
                Console.WriteLine(ex.Message);
            }
            catch(InsufficientBalanceException ex)
            {
                Console.WriteLine(ex.Currency);
                Console.WriteLine(ex.WithdrawValue);

                Console.WriteLine(ex.StackTrace);
                
                Console.WriteLine(ex.Message);
                Console.WriteLine("Exceção do tipo SaldoInsuficienteException");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            
            //Metodo();

            Console.WriteLine("Execução finalizada. Tecle enter para sair");
            Console.ReadLine();
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
                Console.WriteLine("Código depois do throw");
            }
        }

    }
}
