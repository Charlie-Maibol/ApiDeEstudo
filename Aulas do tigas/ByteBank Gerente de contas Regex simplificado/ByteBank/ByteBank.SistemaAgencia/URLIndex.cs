using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.SistemaAgencia
{
    public class URLIndex
    {
        private readonly string _arguments;
        public string URL { get;}
        public URLIndex(string url)
        {
            if (string.IsNullOrEmpty(url))
            {
                throw new ArgumentException("O argumento URL não pode ser nulo ou vazio.", nameof(url));
            }

            int index = url.IndexOf('?');
            _arguments = url.Substring(index + 1);

            URL = url;
        }
        // MoedaOrigem=real&moedaDestino=dolar

        public string GetValue(string nameParameter)
        {
            nameParameter = nameParameter.ToUpper();
            string argumentsUpper = _arguments.ToUpper();
            string term = nameParameter + "=";
            int indexTerm = argumentsUpper.IndexOf(term);

            string result = _arguments.Substring(indexTerm + term.Length);
            int indexECommercial = result.IndexOf('&');

            if (indexECommercial == -1)
            {
                return result;
            }

                
            
            return result.Remove(indexECommercial);

            
            //int indexParameter = _arguments.IndexOf(nameOfParameter);
        }
    }

}
