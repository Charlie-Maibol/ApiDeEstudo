using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Lojinha
{
    internal class Core
    {
        //public int ID;
        public string status = "inativo";
        public string name;
        public DateTime created;
        public string edit;
        //public string verifyStatus;
        //public string classfication;
        public void Register(string batatinha)
        {
            int alpha = Regex.Matches(batatinha, @"[a-zA-Z]").Count;
            if (batatinha.Length < 128 && alpha == batatinha.Length)
            {
                this.name = batatinha;
                this.status = "ativo";
                this.created = DateTime.Now;
                Console.WriteLine("Registro criado: " + batatinha);
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
