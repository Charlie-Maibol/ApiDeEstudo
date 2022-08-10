using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _07___ByteBank
{
    public class Client
    {
        private string _cpf;
        public string Name { get; set; }
        public string CPF {
            get
            {
                return _cpf;
            }
            set
            {
                //Escrevo minha lógica de validação de CPF

                _cpf = value;

            }
        }
        public string Profission { get; set; }
    }

}
