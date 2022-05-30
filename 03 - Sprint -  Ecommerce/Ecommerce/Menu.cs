using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce;

namespace Ecommerce
{
    public class Menu : Category
    {
        public string yes = "y";
        public string no = "n";
        public string edit = "";
        public void CategoryMenu()
        {
            Console.WriteLine("\nDeseja cadastrar um novo items?\n");

            do
            {
                Console.WriteLine("\nDigite [y] para cadastrar, digite [n] para encerrar o cadastro\n");
                string anwser = Console.ReadLine();
                if (anwser == yes)
                {
                    Console.WriteLine("\nQual item deseja cadastrar?\n");
                    string category = Console.ReadLine();
                    this.Register(category);
                    do
                    {

                        Console.WriteLine("\nVocê deseja editar o item? Digite [y] para alterar ou [n] para encerrar o cadastro");
                        edit = Console.ReadLine();
                        if (edit == yes)
                        {
                            Console.WriteLine("\nQual novo nome dessa categoria?\n");
                            string rename = Console.ReadLine();
                            Console.WriteLine(this.name);
                            this.name = rename;
                            this.Modified(rename);
                            Console.WriteLine("\nDeseja alterar o status do produto ?\n");
                            Console.WriteLine("\nDigite [y] para alterar status para inativo ou [n] Permanecer o status\n");
                            string newStatus = Console.ReadLine();
                            do
                            {
                                if (newStatus == yes)
                                {
                                    this.ChangeStatus();
                                    Console.WriteLine(rename);
                                    Console.WriteLine(this.status);
                                    Console.WriteLine("Desativado em: " + DateTime.Now);
                                    break;
                                }
                                else if (newStatus == no)
                                {
                                    Console.WriteLine(rename);
                                    Console.WriteLine("status: " + this.status + " " + DateTime.Now);
                                    Console.WriteLine();
                                    break;
                                }
                                else
                                {

                                    Console.WriteLine("\nOpção invalida digite novamente\n");
                                    Console.WriteLine("\nDigite [y] para alterar status para inativo ou [n] Permanecer o status\n");
                                    newStatus = Console.ReadLine();

                                }


                            } while (newStatus == yes || newStatus == no);
                        }
                        else
                        {
                            Console.WriteLine("\nOpção invalida\n");
                            Console.WriteLine("\nVocê deseja editar o item? Digite [y] para alterar ou [n] para encerrar o cadastro\n");
                            edit = Console.ReadLine();
                        }



                    } while (edit == no);
                }
                else if (anwser == no)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("\nOpção inválida\n");
                }

            } while (true);
            

            
        }
    }
}
