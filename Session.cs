using System.IO;
using System.Linq;
using System.Text.Json;

namespace GhibliFlix
{
    static class Session
    {
        public static Member User { get; set; }
        public static Language Language { get; set; }

        public static void UpdateUserInJson()
        {
            string json = File.ReadAllText("jsonFiles/memberships.json");
            Members members = JsonSerializer.Deserialize<Members>(json);

            // replaces member in json with session member
            int index = members.members.FindIndex(member => member.Code == User.Code);
            members.members[index] = User;

            string newJson = JsonSerializer.Serialize(members);
            File.WriteAllText("jsonFiles/memberships.json", newJson);
        }
    }
}