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
            string edit = "";
            string register = "r";
            string exit = "c";
            string options = "";
            Console.WriteLine("Bem-vindo ao console de produtos!\n");
            Console.WriteLine("O que deseja fazer?\n");
            //Sempre precisa do while para utilizar o do;
            do
            {
                Console.WriteLine("\nDigite [r] para registrar; [c] para encerrar o programa.\n");
                options = Console.ReadLine();

                if (options == register)
                {

                    AlphaVerify Category = new AlphaVerify();
                    Console.WriteLine("\nDeseja cadastrar um novo items?\n");

                    do
                    {
                        Console.WriteLine("\nDigite [y] para cadastrar, digite [n] para encerrar o cadastro\n");
                        string anwser = Console.ReadLine();
                        if (anwser == yes)
                        {
                            Console.WriteLine("\nQual item deseja cadastrar?\n");
                            string category = Console.ReadLine();
                            Category.Register(category);
                            do
                            {

                                Console.WriteLine("\nVocê deseja editar o item? Digite [y] para alterar ou [n] para encerrar o cadastro");
                                edit = Console.ReadLine();
                                if (edit == yes)

                                {
                                    Console.WriteLine("\nQual novo nome dessa categoria?");
                                    string rename = Console.ReadLine();
                                    Console.WriteLine(Category.name);
                                    Category.name = rename;
                                    Category.Mofided(rename);
                                    Console.WriteLine("Deseja alterar o status do produto ?");
                                    Console.WriteLine("Digite [y] para alterar status para inativo ou [n] Permanecer o status");
                                    string newStatus = Console.ReadLine();
                                    do
                                    {
                                        if (newStatus == yes)
                                        {
                                            Category.ChangeStatus();
                                            Console.WriteLine(rename);
                                            Console.WriteLine(Category.status);
                                            Console.WriteLine("Desativado em: " + DateTime.Now);
                                            break;
                                        }
                                        else if (newStatus == no)
                                        {
                                            Console.WriteLine(rename);
                                            Console.WriteLine("status: "  + Category.status + " " + DateTime.Now);
                                            break;
                                        }
                                        else
                                        {

                                            Console.WriteLine("Opção invalida digite novamente");
                                            Console.WriteLine("Digite [y] para alterar status para inativo ou [n] Permanecer o status");
                                            newStatus = Console.ReadLine();

                                        }


                                    } while (newStatus != yes || newStatus != no);
                                }
                                else if (edit != yes || edit != no)
                                {
                                    Console.WriteLine("Opção invalida");
                                }
                                
                            } while (false);
                        }
                        else if (anwser == no)
                        {
                            break;
                        }

                    } while (true);
                }
                else
                {
                    Console.WriteLine("\nOpção inválida\n");
                }



            } while (options != exit);
        }
    }
}
