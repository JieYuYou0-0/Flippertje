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
        internal string Name { get; set; }
        internal string Email { get; set; }
        internal string Code { get; set; }
        internal string Creditcard { get; set; }

    }
}
