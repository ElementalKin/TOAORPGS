using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOneAndOnlyRPGStore
{
    class Adventurers
    {
        //PlayerStats ps = new PlayerStats();
        Asks eg = new Asks();
        ItemCreation itemCreator = new ItemCreation();
        Program program = new Program();
        public int AWTS;
        public int AC;

        public int AS;
        public int AXP;
        public int ALVL  = 1;
        // The amount of xp the needed for the next lvl
        public double XPTNLVL = 100;
        private Random random = new Random();
        //this code will be run at the end of the day when you close
        public void AdventurersReturn()
        {
            //Creates and item that includes that Adventurers guild lvl to affect the quality of the items brought back.
            itemCreator.Creation(AS,5 * ALVL);
            //Calculates the exp earned by the adventurers
            int NewAXP =0;
            NewAXP = AS * random.Next(5,10);
            Console.WriteLine($"Adventurers guild have gotten {NewAXP} Xp");
            AXP += NewAXP;
            LVLUP();
        }
        public void LVLUP()
        {
            if (AXP >= XPTNLVL)
            {
                ALVL += 1;
                XPTNLVL = XPTNLVL * 1.5;
                Console.WriteLine("The Adventurers Guild has lvled up");
            }
        }

    }
}
