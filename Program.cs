//using ChatButler.RestaurantMenus;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;

namespace GhibliFlix
{
    class Program
    {
        static void Main(string[] args)
        {
            Ghibli ghibli = new Ghibli();
            ghibli.Run();
        }

        //static void PrepareTestEnviroment()
        //{
        //    // Set test user
        //    string jsonString = File.ReadAllText("json_files/memberships.json");
        //    Members members = JsonSerializer.Deserialize<Members>(jsonString);

        //    Session.User = members.members.FirstOrDefault(member => member.Code == "123");

        //    // Set language
        //    string languageJson = File.ReadAllText("json_files/language.json");
        //    Translator translator = JsonSerializer.Deserialize<Translator>(languageJson);

        //    Session.Language = translator.nl;
        //}
    }
}