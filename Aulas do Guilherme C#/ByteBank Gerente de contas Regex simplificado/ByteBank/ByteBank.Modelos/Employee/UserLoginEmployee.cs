using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Employee;

namespace ByteBank.Modelos.Employee
{
    public abstract class UserLoginEmployee : Employees, IAuthenticable
    {
        private AuthenticationHelper authenticationHelper = new AuthenticationHelper();
        public string Password {  get; set; }
        public UserLoginEmployee(double salary, string cpf) : base(salary, cpf)
        {

        }

        public bool userLogin(string password)
        {
            return authenticationHelper.checkPassword(Password, password);
        }
    }
}
