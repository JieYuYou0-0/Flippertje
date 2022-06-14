using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GhibliFlix
{
    internal class SettingsMenu : Menu
    {
        internal OverviewMenu overviewMenu;
        readonly Settings settings;

        internal SettingsMenu()
        {
            string settingsJson = File.ReadAllText("json_files/settings.json");
            settings = JsonSerializer.Deserialize<Settings>(settingsJson);
        }
    }
}