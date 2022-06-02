using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GhibliFlix.jsonClasses;

namespace GhibliFlix
{
    internal static class Session
    {
        internal static Member User { get; set; }

        internal static void UpdateUserInJson()
        {
            string json = File.ReadAllText("json_files/members.json");
            Members members = JsonSerializer.Deserialize<Members>(json);

            // replaces member in json with session member??
            int index = members.members.FindIndex(member => member.Mail == User.Mail);
            members.members[index] = User;

            string newJson = JsonSerializer.Serialize(members);
            File.WriteAllText("json_files/memberships.json", newJson);

        }
    }
}
