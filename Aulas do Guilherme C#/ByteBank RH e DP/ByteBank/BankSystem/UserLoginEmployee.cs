using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Employee;

namespace ByteBank.BankSystem
{
    public abstract class UserLoginEmployee : Employees, IAuthenticable
    {
        public string Password {  get; set; }
        public UserLoginEmployee(double salary, string cpf) : base(salary, cpf)
        {

        }
        
        public bool userLogin(string password)
        {
            return Password == password;
        }
    }
}
