using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix.jsonClasses
{
    internal class Members
    {
        internal List<Member> members { get; set; }
    }

    internal class Member
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Code { get; set; }
        public string Creditcard { get; set; }

    }
}
