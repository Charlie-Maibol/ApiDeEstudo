using Humanizer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ByteBank.SistemaAgencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string url = "pagina?moedaOrigem=real&moedaDestino=dolar";

            int indice = url.IndexOf('?');

            Console.WriteLine(indice);
            Console.WriteLine(url);
            string arguments = url.Substring(indice + 1);
            Console.WriteLine(arguments);

            Console.ReadLine();

        }
        
    }


}
