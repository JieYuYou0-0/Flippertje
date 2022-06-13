using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace GhibliFlix
{
    internal class SignIn
    {

        // Methods
        internal static bool CustomerLogin(string loginCheck)
        {
            List<CustomerDetails> members = LoadAllMembers();
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].Password == loginCheck)
                {
                    return true;
                }
            }

            return false;
        }

        internal static List<CustomerDetails> LoadAllMembers()
        {
            string readText = File.ReadAllText(@"json_files\members.json");
            var members = JsonSerializer.Deserialize<List<CustomerDetails>>(readText) ?? new List<CustomerDetails>();
            return members;
        }

        internal static CustomerDetails LoadMember(string code)
        {
            List<CustomerDetails> members = LoadAllMembers();
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].Password == code)
                {
                    return members[i];
                }
            }
            return null;
        }
    }
}