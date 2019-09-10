using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOneAndOnlyRPGStore
{
    class Program
    {

        static void MainMenu()
        {
            Console.WriteLine("{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=}" +
                            "\n|                                             The one and only RPG store                                             |" +
                            "\n|                                                                                                                    |" +
                            "\n|                                                                                                                    |" +
                            "\n|                                            Type new to start a new game                                            |" +
                            "\n|                                            Type load to load saved game                                            |" +
                            "\n|                                                                                                                    |" +
                            "\n{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=}");

        }
        static void Help()
        {                          //A very basic help menu
            Console.WriteLine("{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=}" +
                            "\n| You have 12 hours evry day to be able to send out adventurers and sell items in your shop. At the end of the day - |" +
                            "\n| you will get one item that the adventurers bring back.                                                             |" +
                            "\n| Type 1 to check out what you have in you inventory.                                                                |" +
                            "\n| Type 2 to send out people to gather items(cost of each adventurer is 25 * guild lvl).                              |" +
                            "\n| Type 3 to go to your shop and sell items.                                                                          |" +
                            "\n| Type 4 to close up for the day.                                                                                    |" +
                            "\n| Type exit to close the program (this will NOT save your game).                                                     |" +
                            "\n| Type save to save your game.                                                                                       |" +
                            "\n| Type gold to see how much gold you currently have.                                                                 |" +
                            "\n| Type menu to go back to the main menu (this will save your game)                                                   |" +
                            "\n|                                                                                                                    |" +
                            "\n|                                                    Extra Info                                                      |" +
                            "\n|                                                                                                                    |" +
                            "\n| The shop works by giving you a customer that want to buy an item from your invetory you will give a price and the -|" +
                            "\n| will decide if they want to buy it or not                                                                          |" +
                            "\n{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=}");
        }


        public static void Main()
        {
            string cmd = "";
            string lCmd = "";
            //IBS = Items being sold
            ItemCreation itemCreator = new ItemCreation();
            Asks eg = new Asks();
            Adventurers ad = new Adventurers();
            Random random = new Random();
            Customer customer = new Customer();
            PlayerStats ps = new PlayerStats();
            bool New = false;
            bool Saved = false;
            int PlayerGold = 0;
            int HoursLeft = 12;
            MainMenu();
            while (lCmd != "exit")
            {
                cmd = eg.Ask("What would you like to do? ");
                lCmd = cmd.ToLower();
                //creates a new game and gives the player 100 gold and five items to start with.
                if (lCmd == "new")
                {
                    New = true;
                    PlayerGold += 100;
                    Console.WriteLine("If you need help type help into the command prompt to bring up a list of commands.");
                    Console.WriteLine("Here are some starting items.");
                    Console.WriteLine("");
                    itemCreator.Creation(5, 0);
                    Console.WriteLine("");

                }
                //loads the save game.
                if (lCmd == "load")
                {
                    lCmd = eg.Ask("Please insert name of save game");

                }
                while (New == true || Saved == true)
                {
                    cmd = eg.Ask($"What would you like to do? \nYou currently have {HoursLeft} hours left to do something. ");
                    lCmd = cmd.ToLower();
                    //Displays the players inventory
                    if (lCmd == "1")
                    {
                        itemCreator.Inventory();
                    }
                    //Displays a help menu with a list of commands
                    if (lCmd == "help")
                    {
                        Help();
                    }
                    //Used to schedule an adventurer to gather items
                    if (lCmd == "2")
                    {
                        if (HoursLeft > 0)
                        {
                            Console.WriteLine("{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=}" +
                                           $"\n The Adventurers guild is LVL {ad.ALVL} and are {ad.AXP} out of {ad.XPTNLVL} to the next LVL" +
                                           $"\n Each Adventurer will cost {25 * ad.ALVL}" +
                                           $"\n You currently have {ad.AS} out gathering items" +
                                            "\n{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=}");
                            lCmd = eg.Ask("Do you want to send out any Adventurers? " +
                                          "\nType yes to send out adventurers or type anything else to go back to the command screen. " +
                                          "\n");
                            if (lCmd == "yes")
                            {
                                int.TryParse(eg.Ask("How many adventurers would you like to send? "), out ad.AWTS);
                                ad.AC = ad.AWTS * (25 * ad.ALVL);
                                if (ad.AC <= PlayerGold && itemCreator.InvetoryCount <= 100)
                                {
                                    ad.AS += ad.AWTS;
                                    Console.WriteLine($"you have sent out {ad.AS} Adventurers!");
                                    PlayerGold -= ad.AC;
                                    HoursLeft -= 1;
                                }
                                else if (ad.AC > PlayerGold)
                                {
                                    Console.WriteLine("You do not have the gold to fund this many adventurers.");
                                }
                                else
                                {
                                    Console.WriteLine("You already have to many items. sell some before you send out more adventurers!");
                                }
                            }
                        }
                        else
                        {
                            Console.WriteLine("It is too late to send out adventurers.");
                        }
                    }
                    //Will allow the player to see what they are selling, the chance the item is sold, and how much each item is being sold for
                    if (lCmd == "3")
                    {
                        if (HoursLeft > 0)
                        {
                            lCmd = eg.Ask("{=-=-=-=-=-=-=-=-=-=-=-=-=-={-}=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=}" +
                                        "\n|Do you want to work at your shop This hour?                  |" +
                                        "\nType sell to work the shop, do anthing else to go back.       |" +
                                        "\n{=-=-=-=-=-=-=-=-=-=-=-=-=-={-}=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=}\n");
                            if (lCmd == "sell" && itemCreator.InvetoryCount > 0)
                            {

                                int CustomersChoice;
                                int Price;
                                CustomersChoice = random.Next(0, itemCreator.InvetoryCount);
                                Console.WriteLine("{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-={-}=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=}"+
                                                "\n|After a while a costumer enters the shop asking about the price of   |");
                                itemCreator.GettingValue(CustomersChoice);
                                Console.WriteLine("{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-={-}=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=}\n");
                                int.TryParse(eg.Ask("How much would you like to sell the item for?"), out Price);
                                itemCreator.GettingValue2(CustomersChoice);
                                customer.CustomersDecision(itemCreator.Cost, Price);
                                HoursLeft -= 1;
                                if (customer.ItemSold)
                                {

                                    PlayerGold += Price;
                                }

                            }

                        }
                        else
                        {
                            Console.WriteLine("it is too late to open the store now.");
                        }

                    }
                    //Ends the day
                    if (lCmd == "4")
                    {
                        lCmd = eg.Ask("{=-=-=-=-=-=-=-=-=-=-=-=-{ -}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=}" +
                                    "\n|Do you want to go to close up for the day?                    |" +
                                    "\n|Type yes to close, type anything else to do something else.   |" +
                                    "\n{=-=-=-=-=-=-=-=-=-=-=-=-{ -}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=}\n");
                        if (lCmd == "yes")
                        {
                            if (ad.AS > 0)
                            {
                                Console.WriteLine("the Adventurers you sent out have brought back");
                                ad.AdventurersReturn();
                            }
                            else
                            {
                                Console.WriteLine("you sent out no adventurers");
                            }
                        }
                    }
                    //Saves the game
                    if (lCmd == "save")
                    {

                    }
                    //Creates an item(Developer tool)
                    if (lCmd == "create")
                    {
                        itemCreator.Creation(1, 5 * ad.ALVL);
                    }
                    if (lCmd == "gold")
                    {
                        Console.WriteLine($"You have {PlayerGold}");
                    }
                    if (lCmd == "time")
                    {
                        Console.WriteLine($"Hours left {HoursLeft}");
                    }
                    if (lCmd == "exit")
                    {
                        New = false;
                        Saved = false;
                        lCmd = "exit";
                    }
                }
            }

        }
    }
}


