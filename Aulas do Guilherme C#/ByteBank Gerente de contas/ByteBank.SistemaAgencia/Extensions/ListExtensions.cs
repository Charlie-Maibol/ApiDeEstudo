using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia.Extensions
{
    public static class ListExtensions
    {
        public static void AdicionarVarios<T>( this List<T> lista, params T[] itens)
        {
            foreach (T item in itens)
            {
                lista.Add(item);
            }

            
        }
        public static void TesteGenerico<T2>(this string texto)
        {

        }
        static void Teste()
        {

            List<int> idades = new List<int>();

            idades.Add(14);
            idades.Add(26);
            idades.Add(60);

            idades.AdicionarVarios(3, 9, 8);

            //ListExtensions<int>.AdicionarVarios(idades, 2, 3, 4, 6);

            List<string> nomes = new List<string>();

            nomes.Add("Charles");

            //ListExtensions<string>.AdicionarVarios(nomes, "Lucas", "Mariana");

            nomes.AdicionarVarios("Lucas", "Mariana");

        }
    }

    
}
