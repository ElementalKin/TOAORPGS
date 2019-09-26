using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace TheOneAndOnlyRPGStore
{
    class Saving : Program
    {
        public void ReadPI()
        {
            StreamReader reader = new StreamReader("PlayerInventory.txt");
            if (reader.ReadLine() != null)
            {
                string[] items = reader.ReadLine().Split(',');
                int x = 0;
                for (int i = 0; i < items.Length / 4; i++)
                {
                    ItemCreation.Inv[i].quality = items[x];
                    ItemCreation.Inv[i].material = items[x + 1];
                    ItemCreation.Inv[i].TypeOfWeapon = items[x + 2];
                    int.TryParse(items[x + 3], out ItemCreation.Inv[i].value);
                    x += 4;
                    ItemCreation.InvetoryCount++;
                }
            }
            reader.Close();
        }
        public void ReadPS()
        {
            StreamReader reader = new StreamReader("PlayerStats.txt");
            string[] items = reader.ReadLine().Split(',');
            int.TryParse(items[0], out PlayerGold);
            int.TryParse(items[1], out HoursLeft);
            int.TryParse(items[2], out Days);
            int.TryParse(items[3], out TotalGoldEarned);
            int.TryParse(items[4], out TotalGoldSpent);
            int.TryParse(items[5], out TotalItemsMade);
            int.TryParse(items[6], out TotalItemsSold);
            int.TryParse(items[7], out TotalAdventurersSent);
            int.TryParse(items[8], out Adventurers.ALVL);
            int.TryParse(items[9], out Adventurers.AXP);
            int.TryParse(items[10], out Adventurers.AS);
            double.TryParse(items[11], out Adventurers.XPTNLVL);
            reader.Close();
        }
        public void WritePS()
        {
            StreamWriter writer = new StreamWriter("PlayerStats.txt");
            writer.Write($"{PlayerGold},");
            writer.Write($"{HoursLeft},");
            writer.Write($"{Days},");
            writer.Write($"{TotalGoldEarned},");
            writer.Write($"{TotalGoldSpent},");
            writer.Write($"{TotalItemsMade},");
            writer.Write($"{TotalItemsSold},");
            writer.Write($"{TotalAdventurersSent},");
            writer.Write($"{Adventurers.ALVL},");
            writer.Write($"{Adventurers.AXP},");
            writer.Write($"{Adventurers.AS},");
            writer.Write($"{Adventurers.XPTNLVL}");
            
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
