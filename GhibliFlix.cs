using System;
using System.IO;
using System.Text.Json;
using GhibliFlix;

namespace Ghiblix
{
    public class GhibliFlix
    {
        public void Run()
        {
            Menu.ClearLog();
            LanguageMenu languageMenu = new LanguageMenu();
            languageMenu.Init();
        }
    }
}