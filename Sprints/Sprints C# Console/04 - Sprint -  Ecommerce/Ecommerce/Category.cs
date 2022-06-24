using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Ecommerce;

namespace Ecommerce
{
    public class Category
    {
        //public int ID;
        public string status { get; set; }
        public string name { get; set; }
        public DateTime created { get; private set; }
        public DateTime modifided { get; private set; }

        
        //public string classfication;
        public bool Verify (string name)
        {
            if(String.IsNullOrWhiteSpace(name) || String.IsNullOrEmpty(name))
            {
                throw new ArgumentException("Valor é nulo digite novamente");
            }
            else
            {
                int alpha = Regex.Matches(name, @"[a-zA-Zà-úÀ-Ú' ']").Count;
                if (name.Length <= 128 && alpha == name.Length && name.Length >= 3)
                {
                    return true;
                }
                return false;
            }
        }
        public string Register()
        {
            bool loop = true;


            while (loop)
            {
                try
                {
                    string nomeCategoria = Console.ReadLine();
                    if (Verify(nomeCategoria))
                    {

                        this.status = "Ativo";
                        this.created = DateTime.Now;
                        Console.WriteLine("\nRegistro criado: " + (this.name = nomeCategoria));
                        Console.WriteLine("Cadrastro realizado com sucesso");
                        Console.WriteLine("O criado no dia: " + this.created);
                        Console.WriteLine("Status: " + this.status);
                        Console.WriteLine();
                        loop = false;
                        
                    }
                    else
                    {
                        Console.WriteLine("Valor invalido digite novamente");
                    }
                }
                catch(ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }
                
            }
            return "Cadastro realizado com sucesso!!";

        }
        public string Modified()
        {
            bool loop = true;


            while (loop)
            {
                try
                {
                    string nomeCategoria = Console.ReadLine();
                    if (Verify(nomeCategoria))
                    {
                        this.status = "Ativo";
                        this.modifided = DateTime.Now;
                        Console.WriteLine("\nRegistro criado: " + (this.name = nomeCategoria));
                        Console.WriteLine("Edição realizado com sucesso");
                        Console.WriteLine("Modificado no dia: " + this.modifided);
                        Console.WriteLine("Status: " + this.status);
                        Console.WriteLine();
                        loop = false;

                    }
                    else
                    {
                        Console.WriteLine("Valor invalido digite novamente");
                    }
                }
                catch (ArgumentException ex)
                {
                    Console.WriteLine(ex.Message);
                }

            }
            return "Edição realizado com sucesso!!";
        }
        public void ChangeStatus()
        {
            if (this.status == "Ativo")
            {
                this.status = "Inativo";
            }
            else
            {

                this.status = "Ativo";
            }
        }
    }

}
