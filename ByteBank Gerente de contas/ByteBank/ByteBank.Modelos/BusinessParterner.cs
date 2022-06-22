
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ByteBank.Modelos
{

    public class BusinessParterner : IAuthenticable
    {
        private AuthenticationHelper authenticationHelper = new AuthenticationHelper();
        public string Password { get; set; }
        public bool userLogin(string password)
        {
            return authenticationHelper.checkPassword(Password, password);
        }
    }
}
