using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lojinha
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine();
            string yes = "y";
            string no = "n";
            string edit = "e";
            string register = "r";
            string exit = "c";
            string options = "";
            Console.WriteLine("Bem-vindo ao console de produtos!");
            Console.WriteLine("O que deseja fazer?");
            //Sempre precisa do while para utilizar o do;
            do {
                Console.WriteLine("Digite [r] para registrar; [e] para editar; [c] para encerrar o programa.");
                options = Console.ReadLine();

                if (options == register){

                    Objects Category = new Objects();
                    Console.WriteLine("Deseja cadastrar um novo items?");


                    do {
                        Console.WriteLine("Digite [y] para cadastrar ou digite [n] para voltar ao menu");
                        string anwser = Console.ReadLine();
                        if (anwser == yes)
                        {
                            Console.WriteLine("Qual item deseja cadastrar?");
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
                    Console.WriteLine("Qual item você deseja editar?");
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


