using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix
{
    internal class OverviewMenu : Menu
    {
        internal OverviewMenu()
        {
            AddMenuOption(MovieOverview, ConsoleKey.D1,.);
        }

        internal void MovieOverview()
        {

        }
    }
}
