using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecommerce;

namespace Ecommerce
{
    internal class Program
    {
        static void Main(string[] args)
        {

            Console.WriteLine("Bem-vindo ao console de produtos!\n");
            Console.WriteLine("O que deseja fazer?\n");          
            Menu menu = new Menu();
            menu.CategoryMenu();
            Console.ReadLine();
            
           
        }
    }
}
