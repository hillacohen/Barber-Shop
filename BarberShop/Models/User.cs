using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.Text;
using System.Threading.Tasks;

namespace DBTest
{
    public class User
    {
        public string Name { get; set; }
        public string UserName { get; set; }
        public SecureString Password { get; set; }
    }
}
