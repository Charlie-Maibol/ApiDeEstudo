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

            

            Core Category = new Core(); 
            Console.WriteLine("Deseja cadastrar um novo items?");              
            string category = Console.ReadLine();
            Category.Register(category);
                      
                  
                 

            Console.ReadLine();
        }
    }
}
