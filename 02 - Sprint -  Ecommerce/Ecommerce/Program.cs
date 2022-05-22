using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string yes = "y";
            string no = "n";
            string edit = "e";
            string register = "r";
            string exit = "c";
            string options = "";
            Console.WriteLine("Bem-vindo ao console de produtos!\n");
            Console.WriteLine("O que deseja fazer?\n");
            //Sempre precisa do while para utilizar o do;
            do {
                Console.WriteLine("Digite [r] para registrar; [e] para editar; [c] para encerrar o programa.\n");
                options = Console.ReadLine();

                if (options == register){

                    AlphaVerify Category = new AlphaVerify();
                    Console.WriteLine("\nDeseja cadastrar um novo items?\n");


                    do {
                        Console.WriteLine("\nDigite [y] para cadastrar ou digite [n] para voltar ao menu\n");
                        string anwser = Console.ReadLine();
                        if (anwser == yes)
                        {
                            Console.WriteLine("\nQual item deseja cadastrar?\n");
                            string category = Console.ReadLine();
                            Category.Register(category);
                            break;

                        }
                        if (anwser == no)
                        {
                            break;
                        }

                    } while (true);
                }
                else if (options == edit)
                {
                    Console.WriteLine("\nQual item você deseja editar?");
                    Console.WriteLine();

                }
                else
                {
                    Console.WriteLine("Opção inválida");
                }
                

            } while (options != exit);
        }
    }
}
