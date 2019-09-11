using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheOneAndOnlyRPGStore
{
    class Saving
    {
        public void ReadPI()
        {
            StreamReader reader = new StreamReader("PlayerInventory.txt");
            string[] items = reader.ReadLine().Split(',');
            int x = 0;
            for (int i = 0; i < items.Length / 4; i++)
            {
                ItemCreation.Inv[i].quality = items[x];
                ItemCreation.Inv[i].material = items[x + 1];
                ItemCreation.Inv[i].TypeOfWeapon = items[x + 2];
                int.TryParse(items[x + 3], out ItemCreation.Inv[i].value);
                x += 4;
            }
            reader.Close();
        }
        public void WritePS()
        {
            StreamWriter writer = new StreamWriter("PlayerStats.txt");
            writer.Write(Program.PlayerGold);
            writer.Write(Program.HoursLeft);
            writer.Write(Program.Days);
            writer.Write(Adventurers.);
            writer.Close();
        }
        public void WritePI()
        {
            StreamWriter writer = new StreamWriter("PlayerInventory.txt");
            int i = 0;
            int Done = 0;
            foreach (Item x in ItemCreation.Inv)
            {
                if (x.quality != null)
                {
                    Done++;
                }
            }
            foreach (Item x in ItemCreation.Inv)
            {
                if (x.quality != null)
                {
                    writer.Write($"{x.quality},{x.material},{x.TypeOfWeapon},{x.value}");
                    i++;
                    if (i != Done)
                    {
                        writer.Write(",");
                    }
                }
            }

            writer.Close();
        }
    }
}
