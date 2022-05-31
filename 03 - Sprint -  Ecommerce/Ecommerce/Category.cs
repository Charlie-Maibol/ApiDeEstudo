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
        public string status { get; private set; }
        public string name { get; set; }
        public DateTime created { get; private set; }
        public DateTime modifided { get; private set; }
        //public string classfication;

        public void Register(string value)
        {   
            int alpha = Regex.Matches(value, @"[a-zA-Zà-úÀ-Ú' ']").Count;

            do
            {
                if (value.Length <= 128 && alpha == value.Length && value.Length >= 3)
                {
                    this.name = value;
                    this.status = "Ativo";
                    this.created = DateTime.Now;
                    Console.WriteLine("\nRegistro criado: " + value);
                    Console.WriteLine("Cadrastro realizado com sucesso");
                    Console.WriteLine("O criado no dia: " + this.created);
                    Console.WriteLine("Status: " + this.status);
                    Console.WriteLine();
                    return;


                }
                else
                {
                    Console.WriteLine("\nValor invalido digite novamente\n");
                    string category = Console.ReadLine();
                    this.Register(category);
                    break;

                }


            } while (true);



        }
        public void Modified(string value)
        {
            int alpha = Regex.Matches(value, @"[a-zA-Zà-úÀ-Ú' ']").Count;

            do
            {
                if (value.Length <= 128 && alpha == value.Length && value.Length >= 3)
                {
                    this.name = value;
                    this.modifided = DateTime.Now;
                    Console.WriteLine("\nRegistro criado: " + value);
                    Console.WriteLine("Edição realizado com sucesso");
                    Console.WriteLine("Modificado no dia: " + this.modifided);
                    Console.WriteLine();
                    return;


                }
                else
                {
                    Console.WriteLine("\nValor invalido digite novamente\n");
                    string category = Console.ReadLine();
                    this.Modified(category);
                    break;

                }


            } while (true);

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
