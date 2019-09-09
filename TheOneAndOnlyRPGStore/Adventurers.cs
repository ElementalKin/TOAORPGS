using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOneAndOnlyRPGStore
{
    class Adventurers
    {
        Program program = new Program();
        Asks eg = new Asks();
        ItemCreation itemCreator = new ItemCreation();
        int AWTS;
        int AC;

        public int AS;
        public int AXP;
        public int ALVL  = 1;
        public double XPTNLVL = 100;
        Random random = new Random();
        public void SendAdventurer()
        {
            int.TryParse(eg.Ask("How many adventurers would you like to send?"), out AWTS);
            AC = AWTS * (25 * ALVL);
            if(AC <= program.PlayerGold && itemCreator.InvetoryCount <= 100)
            {
                AS += AWTS;
                Console.WriteLine($"you have sent out {AS} Adventurers!");
            }
            else if(AC > program.PlayerGold)
            {
                Console.WriteLine("You do not have the gold to fund this many adventurers.");
            }
            else
            {
                Console.WriteLine("You already have to many items. sell some before you send out more adventurers!");
            }
        }
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
