using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using GhibliFlix.jsonClasses;
using GhibliFlix.menus;

namespace GhibliFlix
{
    internal class SettingsMenu : Menu
    {
        internal MenuOverview menuOverview;
        readonly Settings settings;

        internal SettingsMenu()
        {
            string settingsJson = File.ReadAllText("json_files/settings.json");
            settings = JsonSerializer.Deserialize<Settings>(settingsJson);
        }
    }
}