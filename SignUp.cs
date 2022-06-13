using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using GhibliFlix.jsonClasses;

namespace GhibliFlix
{
    internal class SignUp
    {
        static SignUp reg = new SignUp();

        internal static void SignUpUser(CustomerDetails data)
        {
            //Read existing JSON data
            var jsonData = File.ReadAllText(@"json_files\members.json");

            //Deserialize data and if not exist, create new list
            List<CustomerDetails> jsonList;
            try
            {
                jsonList = JsonSerializer.Deserialize<List<CustomerDetails>>(jsonData);
            }
            catch
            {
                jsonList = new List<CustomerDetails>();
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
                Console.WriteLine("It looks like your given code is not valid. Please try again! ( ◡‿◡ *)");
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

