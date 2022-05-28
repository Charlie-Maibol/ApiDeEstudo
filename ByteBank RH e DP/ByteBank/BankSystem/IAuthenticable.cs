using ByteBank.Employee;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.BankSystem
{
    public interface IAuthenticable
    {

        bool userLogin(string password);
    }
}
