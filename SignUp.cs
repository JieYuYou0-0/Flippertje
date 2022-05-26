using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix
{
    public class SignUp
    {
        static SignUp reg = new SignUp();

        public static void SignUpUser(Members.MembersSchema data)
        {
            //Read existing JSON data
            var jsonData = File.ReadAllText(@"data\members.json");

            //Deserialize data and if not exist, create new list
            List<Members.MembersSchema> jsonList;
            try
            {
                jsonList = JsonSerializer.Deserialize<List<Members.MembersSchema>>(jsonData);
            }
            catch
            {
                jsonList = new List<Members.MembersSchema>();
            }

            //Add data
            jsonList.Add(data);

            jsonData = JsonSerializer.Serialize(jsonList);
            File.WriteAllText(@"data\members.json", jsonData);
        }

        public static bool VerifyUser(string uuid)
        {
            Console.WriteLine("Type STOP to cancel verifying your account");
            string input = Console.ReadLine();
            if (input == "STOP")
            {
                return false;
            }
            while (input != uuid)
            {
                Console.WriteLine("It looks like your given code is not valid. Please try again!");
                input = Console.ReadLine();
                if (input == "STOP")
                {
                    return false;
                }
            }
            return true;
        }

        public static bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                {
                    return false;
                }
            }
            return true;
        }
    }
}

