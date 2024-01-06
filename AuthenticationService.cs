using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cafe
{
    public class AuthenticationService
    {
        public bool IsUserLoggedIn { get; private set; }

        public void SetUserLoggedIn(bool isLoggedIn)
        {
            IsUserLoggedIn = isLoggedIn;
        }
    }
}
