using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using GhibliFlix.json_class;
using Newtonsoft.Json;

namespace GhibliFlix
{
    internal class SignIn
    {
        /*
         * remove dis and add code from chatbutler
         *
         * BTW i fixed the error of json with adding line 7
         * ALSO i made a json_class map, daarin moet alle properties erin staan die te maken heeft met json (get; set;)
         *  ^ leg je wel uit als je niet begrijpt
         * D: dont forget to delete this line >.<
         */

        // Methods
        public static bool CustomerLogin(string loginCheck) // deze methode (functie) moet bij signIn branch
        {
            List<Members.CustomerDetails> members = LoadAllMembers();
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].password == loginCheck)
                {
                    return true;
                }
            }

            return false;
        }

        public static List<Members.CustomerDetails> LoadAllMembers()
        {
            string readText = File.ReadAllText(@"json_files\members.json");
            var members = JsonConvert.DeserializeObject<List<Members.CustomerDetails>>(readText) ?? new List<Members.CustomerDetails>();
            return members;
        }

        public static Members.CustomerDetails LoadMember(string code)
        {
            List<Members.CustomerDetails> members = LoadAllMembers();
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].password == code)
                {
                    return members[i];
                }
            }
            return null;
        }
    }
}