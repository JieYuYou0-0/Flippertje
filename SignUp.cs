using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using GhibliFlix.json_class;

namespace GhibliFlix
{
    internal class SignUp
    {
        static SignUp reg = new SignUp();

        internal static void SignUpUser(Members.CustomerDetails data)
        {
            //Read existing JSON data
            var jsonData = File.ReadAllText(@"json_files\members.json");

            //Deserialize data and if not exist, create new list
            List<Members.CustomerDetails> jsonList;
            try
            {
                jsonList = JsonSerializer.Deserialize<List<Members.CustomerDetails>>(jsonData);
            }
            catch
            {
                jsonList = new List<Members.CustomerDetails>();
            }

            //Add data
            jsonList.Add(data);

            jsonData = JsonSerializer.Serialize(jsonList);
            File.WriteAllText(@"json_files\members.json", jsonData);
        }

        internal static bool VerifyUser(string passwordCheck)
        {
            Console.WriteLine("Type STOP to cancel verifying your account");
            string input = Console.ReadLine();
            if (input == "STOP")
            {
                return false;
            }
            while (input != passwordCheck)
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
        //Checking credit card number
        internal static bool IsDigitsOnly(string str)
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

