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
        public string list = "3";
        public string optionNo = "4";
        public string yes = "y";
        public string no = "n";
        public string edit = "";
        public string subEdit = "";
        

        public void CategoryMenu()
        {
            Console.WriteLine("\nDeseja cadastrar um novo item?\n");
            SubCategory sub = new SubCategory();
            Category category = new Category();
            

            do
            {
                Console.WriteLine("\nDigite [1] para cadastrar, digite [2] para castrar uma sub Categoria, digite [3] para pesquisar uma categoria ou digite [4] para encerrar o cadastro \n");
                string anwser = Console.ReadLine();
                if (anwser == optionYes)
                {
                    Console.WriteLine("\nQual item deseja cadastrar?\n");
                    category.Register();
                    do
                    {

                        Console.WriteLine("\nVocê deseja editar o item? Digite [y] para alterar ou [n] para encerrar o cadastro");
                        edit = Console.ReadLine();
                        if (edit == yes)
                        {
                            Console.WriteLine("\nQual novo nome dessa categoria?\n");
                            category.Modified();
                            Console.WriteLine("\nDeseja alterar o status do produto ?\n");
                            Console.WriteLine("\nDigite [y] para alterar status para inativo ou [n] Permanecer o status\n");
                            string newStatus = Console.ReadLine();
                            do
                            {
                                if (newStatus == yes)
                                {
                                    category.ChangeStatus();
                                    Console.WriteLine(category.name);
                                    Console.WriteLine(category.status);
                                    Console.WriteLine("Desativado em: " + DateTime.Now);
                                    break;
                                }
                                else if (newStatus == no)
                                {
                                    Console.WriteLine(category.name);
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
                        else if (edit == no)
                        {
                            break;
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

                    if (subAnwser == yes)
                    {
                        Console.WriteLine("\nQual nome dessa nova sub categoria ?\n");
                        category.Register();
                        do
                        {
                            Console.WriteLine("\nVocê deseja editar o item? Digite [y] para alterar ou [n] para encerrar o cadastro\n");
                            subEdit = Console.ReadLine();
                            if (subEdit == yes)
                            {
                                Console.WriteLine("\nQual novo nome dessa sub categoria?\n");
                                category.Modified();
                                Console.WriteLine("\nDeseja alterar o status do produto ?\n");
                                Console.WriteLine("\nDigite [y] para alterar status para inativo ou [n] Permanecer o status\n");
                                string subNewStatus = Console.ReadLine();
                                do
                                {

                                    if (subNewStatus == yes)
                                    {
                                        category.ChangeStatus();
                                        Console.WriteLine(category.name);
                                        Console.WriteLine(category.status);
                                        Console.WriteLine("Desativado em: " + DateTime.Now);
                                        break;
                                    }
                                    else if (subNewStatus == no)
                                    {
                                        Console.WriteLine(category.name);
                                        Console.WriteLine("status: " + category.status + " " + DateTime.Now);
                                        Console.WriteLine();
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("\nOpção invalida digite novamente\n");
                                        Console.WriteLine("\nDigite [y] para alterar status para inativo ou [n] Permanecer o status\n");
                                        subNewStatus = Console.ReadLine();

                                    }
                                } while (subNewStatus == yes || subNewStatus == no);
                            }
                            else if (subEdit == no)
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("\nOpção invalida\n");
                                Console.WriteLine("\nVocê deseja editar o item? Digite [y] para alterar ou [n] para encerrar o cadastro\n");
                                edit = Console.ReadLine();
                            }
                        } while (subEdit == no);

                    }
                    else if (subAnwser == no)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("\nOpção inválida\n");
                        Console.WriteLine("\nVocê deseja criar uma sub categoria? Digite [y] para criar ou [n] para encerrar o cadastro\n");
                        subAnwser = Console.ReadLine();
                    }

                }      
                else if (anwser == list)
                {
                    category.Search();
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
