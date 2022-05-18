using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lojinha
{
    internal class Objects
    {
        //public int ID;
        public string status = "inativo";
        public string name;
        public DateTime created;
        public string edit;
        //public string classfication;
        public void Register(string value)
        {
            int alpha = Regex.Matches(value, @"[a-zA-Z]").Count;
            if (value.Length <= 128 && alpha == value.Length)
            {
                this.name = value;
                this.status = "ativo";
                this.created = DateTime.Now;
                Console.WriteLine("Registro criado: " + value);
                Console.WriteLine("Cadastro feito com Sucesso");
                Console.WriteLine("Criado no dia " + this.created);
                Console.WriteLine("Status: " + this.status);
                return;

            }
            Console.WriteLine("Valor inválido, Digite novamente");
            string category = Console.ReadLine();
            this.Register(category);
        }
              
        
    }
}
