using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix
{
    public class Members
    {
        public List<CustomerDetails> members { get; set; }
    }

    public class CustomerDetails
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Code { get; set; }
        public string Creditcard { get; set; }

    }

    public class AdminDetails
    {
        public string Password { get; set; }
    }
}