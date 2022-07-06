using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GhibliFlix
{
    public class Members
    {
        public List<Member> members { get; set; }
    }

    public class Member : Guest
    {
        public string Code { get; set; }
        public string Creditcard { get; set; }
    }
}