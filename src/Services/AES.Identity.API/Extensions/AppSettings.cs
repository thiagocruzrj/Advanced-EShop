using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AES.Identity.API.Extensions
{
    public class AppSettings
    {
        public string Secret { get; set; }
        public int ExpiryHours { get; set; }
        public string Issuer { get; set; }
        public string ValidOn { get; set; }
    }
}
