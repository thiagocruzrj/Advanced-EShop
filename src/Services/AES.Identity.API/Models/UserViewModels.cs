using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AES.Identity.API.Models
{
    public class UserRegister
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string PasswordConfirmation { get; set; }
    }

    public class UserLogin
    {
    }
}
