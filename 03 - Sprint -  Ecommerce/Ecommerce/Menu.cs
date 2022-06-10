using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce;

namespace Ecommerce
{
    public class Menu
    {
        public string optionYes = "1";
        public string subC = "2";
        public string optionNo = "3";
        public string yes = "y";
        public string no = "n";
        public string edit = "";
        
        public void CategoryMenu()
        {          
            Console.WriteLine("\nDeseja cadastrar um novo item?\n");
            SubCategory sub = new SubCategory();
            Category category = new Category();
            do
            {
                Console.WriteLine("\nDigite [1] para cadastrar, digite [2] para castrar uma sub Categoria digite [3] para encerrar o cadastro\n");
                string anwser = Console.ReadLine();
                if (anwser == optionYes)
                {
                    Console.WriteLine("\nQual item deseja cadastrar?\n");

                    category.Register(Console.ReadLine()) ;            
                    do
                    {

                        Console.WriteLine("\nVocê deseja editar o item? Digite [y] para alterar ou [n] para encerrar o cadastro");
                        edit = Console.ReadLine();
                        if (edit == yes)
                        {
                            Console.WriteLine("\nQual novo nome dessa categoria?\n");
                            string rename = Console.ReadLine();
                            Console.WriteLine(category.name);
                            category.name = rename;
                            category.Modified(rename);
                            Console.WriteLine("\nDeseja alterar o status do produto ?\n");
                            Console.WriteLine("\nDigite [y] para alterar status para inativo ou [n] Permanecer o status\n");
                            string newStatus = Console.ReadLine();
                            do
                            {
                                if (newStatus == yes)
                                {
                                    category.ChangeStatus();
                                    Console.WriteLine(rename);
                                    Console.WriteLine(category.status);
                                    Console.WriteLine("Desativado em: " + DateTime.Now);
                                    break;
                                }
                                else if (newStatus == no)
                                {
                                    Console.WriteLine(rename);
                                    Console.WriteLine("status: " + category.status + " " + DateTime.Now);
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
                else if (anwser == subC)
                {
                    Console.WriteLine("\nVocê deseja criar uma sub categoria? Digite [y] para criar ou [n] para encerrar o cadastro\n");
                    string subAnwser = Console.ReadLine();
                    do
                    {

                        if (subAnwser == yes)
                        {

                            Console.WriteLine("Qual novo nome dessa  sub categoria ?");
                            string subCategory = Console.ReadLine();
                            sub.Register(subCategory);
                            break;
                        }
                        else if (subAnwser != no || subAnwser != yes)
                        {
                            Console.WriteLine("Opção inválida");
                            Console.WriteLine("\nVocê deseja criar uma sub categoria? Digite [y] para criar ou [n] para encerrar o cadastro\n");
                            subAnwser = Console.ReadLine();
                        }

                    }while(true);
                }
                else if (anwser == optionNo)
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
