using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _03_ByteBank
{
    class Program
    {
        static void Main(string[] args)
        {
            CheckingAccounts contaDaGabrielle = new CheckingAccounts();
            contaDaGabrielle.holder = "Gabriela";
            contaDaGabrielle.agency = 863;
            contaDaGabrielle.number = 863452;

            CheckingAccounts contaDaGabrielleCosta = new CheckingAccounts();
            contaDaGabrielleCosta.holder = "Gabriela";
            contaDaGabrielleCosta.agency = 863;
            contaDaGabrielleCosta.number = 863452;

            Console.WriteLine("Igualdade de tipo de referência:" + (contaDaGabrielle == contaDaGabrielleCosta));

            int idade = 27;
            int idadeMaisUmaVez = 27;

            Console.WriteLine("Igualdade de tipo de valor: " + (idade == idadeMaisUmaVez));


            contaDaGabrielle = contaDaGabrielleCosta;
            Console.WriteLine(contaDaGabrielle == contaDaGabrielleCosta);


            contaDaGabrielle.currency = 300;
            Console.WriteLine(contaDaGabrielle.currency);
            Console.WriteLine(contaDaGabrielleCosta.currency);

            if (contaDaGabrielle.currency >= 100)
            {
                contaDaGabrielle.currency -= 100;
            }

            Console.ReadLine();
        }
    }
}
