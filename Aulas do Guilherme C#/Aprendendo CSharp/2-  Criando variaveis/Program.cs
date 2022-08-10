using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2___Criando_variaveis
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 2 - Criando variaveis");

            int age;
            age = 32;
            Console.WriteLine(age);

            age = 10;
            Console.WriteLine(age);

            age = 10 + 5;
            Console.WriteLine(age);

            age = 10 + 5 * 2;
            Console.WriteLine(age);

            age = (10 + 5) * 2;
            Console.WriteLine("Your age is " + age + "!");

            Console.WriteLine("Execução finalizada. Tecle Enter para sair");
            Console.ReadLine(); 
        }
    }
}
