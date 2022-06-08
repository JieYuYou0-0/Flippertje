using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GhibliFlix.jsonClasses;

namespace GhibliFlix
{
    internal class Session
    {
        public static Member User { get; set; }
        public static Settings Settings { get; set; }

        public static void UpdateUserInJson()
        {
            string json = File.ReadAllText("json_files/members.json");
            Members members = JsonSerializer.Deserialize<Members>(json);

            // replaces member in json with session member
            int index = members.members.FindIndex(member => member.Code == User.Code);
            members.members[index] = User;

            string newJson = JsonSerializer.Serialize(members);
            File.WriteAllText("json_files/members.json", newJson);
        }

    }
}
