﻿using System;
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
                CheckingAccounts account = new CheckingAccounts(0, 0);
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine("Aconteu um erro de referência");
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
           
            try
            {

                Method();
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine(ex.StackTrace);
                Console.WriteLine("Não é possivel fazer divisão por 0!");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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

        private static int Division(int number, int divided)
        {

            try
            {
                return number / divided;
            }

            catch (DivideByZeroException) { 
             
                Console.WriteLine("Exceção com número = " + number + " e divisor = " + divided);
                throw;
            }
        }
    }
}