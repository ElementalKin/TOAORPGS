using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOneAndOnlyRPGStore
{
    class Adventurers
    {
        PlayerStats ps = new PlayerStats();
        Asks eg = new Asks();
        ItemCreation itemCreator = new ItemCreation();
        Program program = new Program();
        public int AWTS;
        public int AC;

        public int AS;
        public int AXP;
        public int ALVL  = 1;
        public double XPTNLVL = 100;
        Random random = new Random();
        public void AdventurersReturn()
        {
            itemCreator.Creation(AS);
            int NewAXP =0;
            NewAXP = AS * random.Next(1,5);
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
                AXP = 0;
                Console.WriteLine("The Adventurers Guild has lvled up");
            }
        }

    }
}
