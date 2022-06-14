using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliFlix
{
    internal class Overview : Menu
    {
        internal Overview()
        {
            AddMenuOption(MovieOverview, ConsoleKey.D1,.);
        }

        internal void MovieOverview()
        {

        }
    }
}
