using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace p13___For_encadeado
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Usando Break
            Console.WriteLine("Executando o projeto 13");

            for (int lineCounter = 0; lineCounter < 10; lineCounter++)
            {
                
                for (int value = 0; value < 10; value++)
                {
                    Console.Write("*");
                    if(value >= lineCounter)
                    {
                        break;
                    }
                }
                Console.WriteLine();
            }


            

            //uma forma diferente
            for (int lineCounter = 0; lineCounter < 10; lineCounter++)
            {

                for (int value = 0; value <= lineCounter; value++)
                {
                    Console.Write("*");
                    
                }
                Console.WriteLine();
            }


            Console.ReadLine();
        }
    
    }
}
