using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using Newtonsoft.Json;

namespace GhibliFlix
{
    internal class SignIn
    {
        /*
         * remove dis and add code from chatbutler
         *
         * BTW i fixed the error of json with adding line 7
         * D: dont forget to delete this line >.<
         */
        public class CustomerDetails
        {
            public string name { get; set; }
            public string email { get; set; }
            public string password { get; set; }
            public string phonenumber { get; set; }
            public string address { get; set; }
            public string creditnumber { get; set; }

        }

        // Methods
        public static bool CustomerLogin(string loginCheck) // deze methode (functie) moet bij signIn branch
        {
            List<CustomerDetails> members = LoadAllMembers();
            for (int i = 0; i < members.Count; i++)
            {
                if (members[i].password == loginCheck)
                {
                    return true;
                }
            }

            return false;
        }

        public static List<CustomerDetails> LoadAllMembers()
        {
            string readText = File.ReadAllText(@"json_files\members.json");
            var members = JsonConvert.DeserializeObject<List<CustomerDetails>>(readText) ?? new List<CustomerDetails>();
            return members;
        }

        public static CustomerDetails LoadMember(string code)
        {
            List<CustomerDetails> members = LoadAllMembers();
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