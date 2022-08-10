using System;
using System.Text.RegularExpressions;

namespace ByteBank.SistemaAgencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Olá, meu nome é Guilherme e você pode entrar em contato comigo
            // através do número 8457-4456!

            // Meu nome é Guilherme, me ligue em 4784-4546

            // string padrao = "[0123456789][0123456789][0123456789][0123456789][-][0123456789][0123456789][0123456789][0123456789]";
            // string padrao = "[0-9][0-9][0-9][0-9][-][0-9][0-9][0-9][0-9]";
            // string padrao = "[0-9]{4,5}[-][0-9]{4}";
            // string padrao = "[0-9]{4,5}[-]{0,1}[0-9]{4}";
            // string padrao = "[0-9]{4,5}-{0,1}[0-9]{4}";
            string padrao = "[0-9]{4,5}-?[0-9]{4}";

            string textTest = "Meu nome é Guilherme, me ligue em 4784-4546";

            Match result = Regex.Match(textTest, padrao);

            Console.WriteLine(result.Value);

            Console.ReadLine();
        
        
            string urlTest = "https://www.bytebank.com/cambio";
            int indexByteBank = urlTest.IndexOf("https://www.bytebank.com");

            urlTest.StartsWith("https://www.bytebank.com");
            urlTest.EndsWith("https://www.bytebank.com");

            Console.WriteLine(urlTest.StartsWith("https://www.bytebank.com"));
            Console.WriteLine(urlTest.Contains("bytebank"));

            Console.ReadLine();

            string url = "pagina?moedaOrigem=real&moedaDestino=dolar";

            string urlParameter = "http://www.bytebank.com/cambio?moedaOrigem=real&moedaDestino=dolar&valor=1500";
            URLIndex URLValeu = new URLIndex(urlParameter);

            string value = URLValeu.GetValue("moedaDestino");
            Console.WriteLine("Valor de moedaDestino: " + value);

            string valueOrigin = URLValeu.GetValue("moedaOrigem");
            Console.WriteLine("Valor de moedaOrigem: " + valueOrigin);

            Console.WriteLine(URLValeu.GetValue("valor"));

            Console.ReadLine();


            string testRemover = "primeiraParte&parteParaRemover";
            int indexECommercial = testRemover.IndexOf('&');
            Console.WriteLine(testRemover.Remove(indexECommercial));


            Console.ReadLine();




            //int indice = url.IndexOf('?');

            string word = "moedaOrigem=real&moedaDestino=dolar";
            string nameArgument = "moedaDestino=";

            int index = word.IndexOf(nameArgument);
            Console.WriteLine(index);

            Console.WriteLine("Tamanho da String nameArgument " + nameArgument.Length) ;


            Console.WriteLine(word.Substring(index));
            Console.WriteLine(word.Substring(index + nameArgument.Length));
            Console.ReadLine(); 

            
            
            
            
            
            Console.WriteLine(index);
            Console.WriteLine(url);
            string arguments = url.Substring(index);
            Console.WriteLine(arguments);

            Console.ReadLine();

        }
        
    }


}
