using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank
{
    public class Reader
    {

        public string Arquivo { get; }

        public string File { get; }

        public Reader(string file)
        {
            File = file;
            Console.WriteLine("Abrindo arquivo: " + file);
        }
    

        public string NextLine()
        {
            Console.WriteLine("Lendo linha...");

            throw new IOException();

            return "Linha do arquivo";
        }

        public void Close()
        {
            Console.WriteLine("Fechando arquivo.");
        }
    }
}
