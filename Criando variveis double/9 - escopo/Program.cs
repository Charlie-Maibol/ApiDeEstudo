using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Executando projeto 9 - escopo");

            int joaoAges = 18;
            bool guest = true;
            string addcionalMenssagem;

            if (guest == true)
            {
                addcionalMenssagem = "João está acompanhado";
            }
            else
            {
                addcionalMenssagem = "joão não está acompanhado";
            }
            if (joaoAges >= 18 || guest == true)
            {
                Console.WriteLine("joão pode entrar");
                Console.WriteLine(addcionalMenssagem);
            }
            else
            {
                Console.WriteLine("João não pode entrar");
                
            }
            Console.ReadLine();
        }

    }

}
