using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.BankSystem
{
    public class BusinessParterner :IAuthenticable
    {
        public string Password { get; set; }
        public bool userLogin (string password)
        {
            return Password == password;
        }
    }
}
