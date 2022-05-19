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


            Console.WriteLine("Bem-vindo ao console de produtos!");
            Console.WriteLine("O que deseja fazer?");
            Console.WriteLine("Digite [r] para registrar; [e] para editar");



            string batata = Console.ReadLine();
            
            if (batata == register ) {

                Objects Category = new Objects();
                Console.WriteLine("Deseja cadastrar um novo items?");
                string anwser = Console.ReadLine();
                if (anwser == yes) {
                    Console.WriteLine("Qual item deseja cadastrar?");
                    string category = Console.ReadLine();
                    Category.Register(category);
                }
                if (anwser == no)
                {
                    Console.WriteLine("Aperte enter para sair.... ");

                }
                

            }
            if (batata == edit)
            {
                Console.WriteLine("Qual item você deseja editar?");
                
            }
            Console.ReadLine();
        }       
    }
}
