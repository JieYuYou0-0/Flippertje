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
    }
}