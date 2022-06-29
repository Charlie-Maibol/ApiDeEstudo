using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{
    class AuthenticationHelper
    {
            public bool checkPassword(string truePassword, string passawordTried)
            {
            return truePassword == passawordTried;
            }
        
    }
}
