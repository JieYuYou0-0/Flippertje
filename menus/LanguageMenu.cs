using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace GhibliFlix
{
    class LanguageMenu : Menu
    {
        GuestMenu guestMenu;
        Settings settings;
        readonly Translator translator;

        public LanguageMenu()
        {
            string languageJson = File.ReadAllText("jsonFiles/language.json");
            translator = JsonSerializer.Deserialize<Translator>(languageJson);

            AddMenuOption(() => { SetLanguage("en"); OpenGuestMenu(); }, ConsoleKey.D1, "[1] English");
        }

        public override void Init()
        {
            Log("Open Language Menu");
            Console.Clear();

            if (!LanguageIsSet())
                OpenGuestMenu(); // Open Guest Menu if language is already set;
            else
            {
                Console.WriteLine("Language/Taal");
                ShowMenu();
            }
        }

        private bool LanguageIsSet()
        {
            string settingsJson = File.ReadAllText("jsonFiles/settings.json");
            settings = JsonSerializer.Deserialize<Settings>(settingsJson);

            return settings.language == "";
        }

        private void SetLanguage(string lang)
        {
            // set language JSON
            settings.language = lang;

            // save JSON to file
            string jsonstring = JsonSerializer.Serialize(settings);
            File.WriteAllText(@"jsonFiles\settings.json", jsonstring);
        }

        private void OpenGuestMenu()
        {
            if (settings.language == "en")
                Session.Language = translator.en;

            GuestMenu guestMenu = new GuestMenu();
            guestMenu.PreviousMenu = () => { SetLanguage(""); Init(); };
            guestMenu.Init();
        }
    }
}