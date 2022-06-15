using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace GhibliFlix
{
    class Program
    {
        static void Main(string[] args)
        {
            GhibliManager newGhibli = new GhibliManager();
            newGhibli.Run();
        }
    }
}