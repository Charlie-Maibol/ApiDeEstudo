using ByteBank.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.BankSystem
{
    public abstract class Authenticable : Employees
    {
        public string Password { get; set; }

        public Authenticable(double salary, string cpf) : base(salary,  cpf)
        {

        }

        public bool userLogin(string password)
        {
            return Password == password;
        }
    }
}
