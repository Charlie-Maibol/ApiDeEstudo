using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5___criando_textos
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando o projeto 5 criando textos");

            char firstLetter = 'a';

            Console.WriteLine(firstLetter);

            firstLetter = (char)61;

            Console.WriteLine(firstLetter);

            firstLetter = (char)(firstLetter + 1);

            Console.WriteLine(firstLetter);

            string title = "Alura cursos de tecnologia " + 2022;

            string programClass = @" 
- .NET
- Java
- JavaScript";

            Console.WriteLine(title);
            Console.WriteLine(programClass);

            Console.ReadLine();


        }
    }
}
