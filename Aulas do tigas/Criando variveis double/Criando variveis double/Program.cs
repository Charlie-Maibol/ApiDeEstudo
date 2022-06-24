using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Criando_variveis_double
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Excutando projeto 3 de número flutuantes");
            double salario;

            salario = 1200.70;

            Console.WriteLine(salario);

            double age;

            age = 15.0;

            Console.WriteLine("Sua idade é " + age + " parabéns!");

            age = 15 / 2;

            Console.WriteLine(age);

            age = 15.0 / 2;

            Console.WriteLine(age);

            double value;

            value = 5 / 3;

            Console.WriteLine(value);

            value = 5.0 / 3.0;

            Console.WriteLine("5 / 3 é igual a " + value);



            Console.WriteLine("A execução acabou tecle enter para sair ....");
            Console.ReadLine();
        }
    }
}
