using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOneAndOnlyRPGStore
{
    public struct Item
        {
            public string quality;
            public string material;
            public string TypeOfWeapon;
            public int value;
        }

    class ItemCreation
    {
        //Structure for creating an item.
        

        //All of the qualitys, material, and type of weapon.
        //Q = weapon quality, M = weapon material, T = weapon type
        //W = weapon, B = Bow, A = Armour
        public string[] WQ = new string[10] { "Cracked", "Bent", "Rusty", "Chipped", "Plain ", "Heavy", "Balanced", "Strong", "Tempered", "Masterwork" };
        public string[] WM = new string[4] { "Copper", "Bronze", "Iron", "Steel" };
        public string[] WT = new string[20] { "Falchion", "Arming Sword", "LongSword", "Rapier", "Claymore", "Hiunting Dagger", "Dirk", "Axe", "Two-Handed Axe", "Halberd", "Short Spear", "Boar Spear", "War Spear", "Pike", "War Scythe", "Spiked Club", "War Hammer", "Morning Star", "War Pick", "Quater Staff" };
        public string[] BQ = new string[8] { "Old", "Cheap", "Poor", "Bent", "Plain", "Balanced", "Strong", "MasterWork" };
        public string[] BM = new string[6] { "Oak", "Maple", "Beech", "Ash", "Hickory", "Yew"};
        public string[] BT = new string[5] { "Hunting Bow", "Short Bow", "Long Bow", "Recurve Bow", "War Bow" };
        public string[] AQ = new string[12] { "Cracked", "Tattered", "Rusty", "Ragged", "Battered", "Crude", "Plain", "sturdy", "thick", "Hardened", "Reinforced", "Lordly" };
        public string[] AM = new string[4] { "Copper", "Bronze", "Iron", "Steel" };
        public string[] AT = new string[5] { "Chainmail", "Cuirasses", "Chestplate", "Halfplate", "FullPlate", };
        Asks eg = new Asks();
        Program program = new Program();
        public static Item[] Inv = new Item[100];
        public int InvetoryCount = 0;
        public int InvetoryIdx = 0;
        public int Cost;


        //Creates a random number.
        Random random = new Random();
        //This can be called to create an item and it will store the item to the inventory of the player.
        public void Creation(int x, int y)
        {
            for(int n = 0; n < x;n++)
            {
                Item tmp;
                string Q = "";
                string M = "";
                string T = "";
                if (y > 100)
                {
                    y = 100;
                }
                int Type = 0;
                Type = random.Next(0, 2);
                tmp.value = 0;
                int RQ = random.Next(y, 100);
                int RM = random.Next(y, 100);
                int RW;

                if (Type == 0)
                {
                    if (RQ >= 0 && RQ <= 65)
                    {
                        Q = WQ[random.Next(0,3)];
                        tmp.value += 5;
                    }
                    else if (RQ >= 65 && RQ <= 75)
                    {
                        Q = WQ[4];
                        tmp.value += 10;
                    }
                    else if (RQ >= 76 && RQ <= 95)
                    {
                        Q = WQ[random.Next(5, 8)];
                        tmp.value += 15;
                    }
                    else if (RQ >= 96 && RQ <= 100)
                    {
                        Q = WQ[9];
                        tmp.value += 50;
                    }

                    if (RM >= 0 && RM <= 50)
                    {
                        M = WM[0];
                        tmp.value += 25;
                    }
                    else if (RM >= 51 && RM <= 75)
                    {
                        M = WM[1];
                        tmp.value += 50;
                    }
                    else if (RM >= 76 && RM <= 90)
                    {
                        M = WM[2];
                        tmp.value += 100;
                    }
                    else if (RM >= 91 && RM <= 100)
                    {
                        M = WM[3];
                        tmp.value += 225;
                    }


                    T = WT[random.Next(0, 19)];
                    tmp.value += 50;

                }
                if (Type == 1)
                {
                    RW = random.Next(0, 5);

                    if (RQ >= 0 && RQ <= 65)
                    {
                        Q = BQ[random.Next(0, 3)];
                        tmp.value += 15;
                    }
                    else if (RQ >= 66 && RQ <= 75)
                    {
                        Q = BQ[4];
                        tmp.value += 20;
                    }
                    else if (RQ >= 76 && RQ <= 95)
                    {
                        Q = BQ[random.Next(5, 6)];
                        tmp.value += 25;
                    }
                    else if (RQ >= 96 && RQ <= 100)
                    {
                        Q = BQ[7];
                        tmp.value += 50;
                    }

                    if (RM >= 0 && RM <= 50)
                    {
                        M = BM[0];
                        tmp.value += 15;
                    }
                    else if (RM >= 51 && RM <= 75)
                    {
                        M = BM[1];
                        tmp.value += 25;
                    }
                    else if (RM >= 76 && RM <= 85)
                    {
                        M = BM[2];
                        tmp.value += 50;
                    }
                    else if (RM >= 86 && RM <= 95)
                    {
                        M = BM[3];
                        tmp.value += 75;
                    }
                    else if (RM >= 96 && RM <= 100)
                    {
                        M = BM[4];
                        tmp.value += 100;
                    }
                    else if (RM >= 96 && RM <= 100)
                    {
                        M = BM[5];
                        tmp.value += 250;
                    }

                    if (RW == 0)
                    {
                        T = BT[0];
                        tmp.value += 5;
                    }
                    else if (RW == 1)
                    {
                        T = BT[1];
                        tmp.value += 15;
                    }
                    else if (RW == 2)
                    {
                        T = BT[2];
                        tmp.value += 25;
                    }
                    else if (RW == 3)
                    {
                        T = BT[3];
                        tmp.value += 50;
                    }
                    else if (RW == 4)
                    {
                        T = BT[4];
                        tmp.value += 100;
                    }
                    else if (RW == 5)
                    {
                        T = BT[5];
                        tmp.value += 150;
                    }
                }
                if (Type == 2)
                {
                    RW = random.Next(0, 5);

                    if (RQ >= 0 && RQ <= 65)
                    {
                        Q = AQ[random.Next(0, 5)];
                        tmp.value += 5;
                    }
                    else if (RQ >= 66 && RQ <= 75)
                    {
                        Q = AQ[6];
                        tmp.value += 25;
                    }
                    else if (RQ >= 76 && RQ <= 95)
                    {
                        Q = AQ[random.Next(7, 10)];
                        tmp.value += 50;
                    }
                    else if (RQ >= 96 && RQ <= 100)
                    {
                        Q = AQ[11];
                        tmp.value += 100;
                    }

                    if (RM >= 0 && RM <= 50)
                    {
                        M = AM[0];
                        tmp.value += 25;
                    }
                    else if (RM >= 51 && RM <= 75)
                    {
                        M = AM[1];
                        tmp.value += 50;
                    }
                    else if (RM >= 76 && RM <= 85)
                    {
                        M = AM[2];
                        tmp.value += 75;
                    }
                    else if (RM >= 86 && RM <= 95)
                    {
                        M = AM[3];
                        tmp.value += 225;
                    }

                    if (RW == 0)
                    {
                        T = AT[0];
                        tmp.value += 5;
                    }
                    else if (RW == 1)
                    {
                        T = AT[1];
                        tmp.value += 25;
                    }
                    else if (RW == 2)
                    {
                        T = AT[2];
                        tmp.value += 50;
                    }
                    else if (RW == 3)
                    {
                        T = AT[3];
                        tmp.value += 100;
                    }
                    else if (RW == 4)
                    {
                        T = AT[4];
                        tmp.value += 250;
                    }
                }
                tmp.quality = Q;
                tmp.material = M;
                tmp.TypeOfWeapon = T;

                Inv[InvetoryCount] = tmp;
                Console.WriteLine($"you get {Q} {M} {T} worth {tmp.value}");
            }


        }
        public void GettingValue(int x)
        {
            Item item = Inv[x];
            Console.Write($"{item.quality} {item.material} {item.TypeOfWeapon}(it is Worth {item.value})\n");
        }
        public void GettingValue2(int x)
        {
            Item item = Inv[x];
            Cost = item.value;
            
        }
        public void DeleteTheItem()
        {

        }
        //A void for checking the invetory.
        public void Inventory()
        {
            foreach (Item x in Inv)
            {
                if (x.quality != null)
                {
                    InvetoryCount++;
                }
            }
            Console.WriteLine("{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-={-}=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=}");
            for (int idx = 0; idx < InvetoryCount; idx++)
            {
                Item item = Inv[idx];
                eg.MyPrinter($"{item.quality} {item.material} {item.TypeOfWeapon} worth {item.value}");

            }
            Console.WriteLine("{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-={-}=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=}");
        }
    }
}
