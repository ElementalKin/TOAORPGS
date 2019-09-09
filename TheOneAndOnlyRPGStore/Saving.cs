using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOneAndOnlyRPGStore
{
    class Saving
    {
        static void CreateFile()
        {
            Asks eg = new Asks();
            string tmpLine = "";
            //In this example we ask for the file name to create.
            string SaveGame = eg.Ask("Please enter a file name for the file (Note: '.txt' will be added automatically");

        }
    }
}
