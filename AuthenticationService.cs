using Cafe.Data.Utils;
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
        public UserType UserType { get; private set; }

        public void SetUserLoggedIn(bool isLoggedIn, UserType userType)
        {
            IsUserLoggedIn = isLoggedIn;
            UserType = userType;
        }
        public UserType GetUserType()
        {
            return UserType;
        }
    }
}
