using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ByteBank.Employee;

namespace ByteBank.System
{
    public class InternalSystem
    {
        public bool Login(Directors employee, string password)
        {
            bool userLogin = employee.Autentication(password);

            if (userLogin)
            {
                Console.WriteLine("Bem-vindo ao sistema!");
                return true;
            }
            else
            {
                Console.WriteLine("Senha incorreta!");
                return false;
            }
        }
    }
}
