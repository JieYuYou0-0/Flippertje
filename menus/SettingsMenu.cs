using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GhibliFlix
{
    public class SettingsMenu : Menu
    {
        public OverviewMenu overviewMenu;
        readonly Settings settings;

        public SettingsMenu()
        {
            string settingsJson = File.ReadAllText("json_files/settings.json");
            settings = JsonSerializer.Deserialize<Settings>(settingsJson);
        }
    }
}