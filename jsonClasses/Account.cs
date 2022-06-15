using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace GhibliFlix
{
    public class Account
    {
        [JsonPropertyName("Firstname")]
        public string Firstname { get; set; }

        [JsonPropertyName("Lastname")]
        public string Lastname { get; set; }

        [JsonPropertyName("Email")]
        public string Email { get; set; }

        [JsonPropertyName("Password")]
        public string Password { get; set; }

        [JsonPropertyName("Creditcard")]
        public string Creditcard { get; set; }
    }

    public class AccountManager // Manages accounts; load from Json and save accounts to Json
    {
        private List<Account> Accounts;
        private string AccountJsonName = $@"jsonClasses{Path.DirectorySeparatorChar}accounts.json";

        public AccountManager()
        {
            if (File.Exists(AccountJsonName)) // if account.json exists then
            {
                // If file is not empty? LoadFromJson(); : make a new list of accounts
                if (new FileInfo(AccountJsonName).Length != 0)
                {
                    LoadFromJson(); // load json account from json file
                }
                else
                {
                    this.Accounts = new List<Account>(); // if account.json doesn't exist, make a new json file
                }
            }
            else
            {
                File.Create(AccountJsonName);
                this.Accounts = new List<Account>();
            }
        }

        public void AddAccount(string firstname, string lastname, string email, string password, string creditcard)
        {
            Account newAccount = new Account();
            newAccount.Firstname = firstname;
            newAccount.Lastname = lastname;
            newAccount.Email = email;
            newAccount.Password = password;
            newAccount.Creditcard = creditcard;
            this.Accounts.Add(newAccount);
            SaveToJson();
        }

        public int RemoveAccount(string email)
        {
            LoadFromJson();
            for (int i = 0; i < this.Accounts.Count; i++)
            {
                if (this.Accounts[i].Email == email)
                {
                    this.Accounts.RemoveAt(i);
                    SaveToJson();
                    return i;
                }
            }

            SaveToJson();
            return -1;
        }

        public Account Exists(string email, string password) // Checks whether account exists
        {
            // Collectie this.Accounts langsgaan
            foreach (Account account in this.Accounts)
            {
                if (account.Email.Equals(email))
                {
                    if (account.Password.Equals(password))
                    {
                        return account;
                    }
                }
            }

            return null;
        }

        public bool EmailExists(string email) // if email exist? true : false;
        {
            // Collectie this.Accounts langsgaan
            foreach (Account account in this.Accounts)
            {
                if (account.Email.Equals(email))
                {
                    return true;
                }
            }

            return false;
        }

        public bool PasswordCheck(string password, string confirmPassword)
        {
            if (password == confirmPassword)
            {
                return true;
            }

            return false;
        }

        private void LoadFromJson()
        {
            string json = File.ReadAllText(AccountJsonName);
            this.Accounts = JsonSerializer.Deserialize<List<Account>>(json);
        }

        private void SaveToJson()
        {
            var options = new JsonSerializerOptions();
            options.WriteIndented = true;
            // Options write to AccountJsonName
            File.WriteAllText(AccountJsonName, JsonSerializer.Serialize(this.Accounts, options: options)); 
        }
    }
}