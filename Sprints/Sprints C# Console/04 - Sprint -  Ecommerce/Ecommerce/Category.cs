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
        
        List<Category> categoryList = new List<Category>();
        public string status { get; set; }
        public string name { get; set; }

        public string created = DateTime.Now.ToString("dd-MM-yyyy - HH:mm:ss");
        public string modified = DateTime.Now.ToString("dd-MM-yyyy - HH:mm:ss");
        public int ID { get; set; }


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
                    string nameCategory = Console.ReadLine();
                    if (Verify(nameCategory))
                    {
                        Category category = new Category();
                        category.status = "Ativo";                       
                        category.ID = categoryList.Count+1;
                        Console.WriteLine("\nRegistro criado: " + (category.name = nameCategory));
                        Console.WriteLine("O criado no dia: " + this.created);
                        Console.WriteLine("Status: " + category.status);
                        Console.WriteLine("ID: " + category.ID);
                        categoryList.Add(category);
                        Console.WriteLine("Cadrastro realizado com sucesso");
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
                        Console.WriteLine("\nRegistro criado: " + (this.name = nomeCategoria));
                        Console.WriteLine("Edição realizado com sucesso");
                        Console.WriteLine("Modificado no dia: " + (this.modified = DateTime.Now.ToString("dd-MM-yyyy - HH:mm:ss")));
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

        public void Search()
        {
            foreach(Category listed in categoryList)
            {
                Console.WriteLine("\nRegistro criado: " + listed.name);
                Console.WriteLine("O criado no dia: " + this.created);
                Console.WriteLine("Status: " + listed.status);
                Console.WriteLine("ID: " + listed.ID);
                Console.WriteLine("Editado em: " + this.modified);
            }
        }
    }

}
