using System;


namespace ByteBank.SistemaAgencia
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
            Console.WriteLine(testRemover.Remove(indexECommercial, 4));


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
