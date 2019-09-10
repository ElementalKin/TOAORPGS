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
        {
            Console.WriteLine("{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=}" +
                            "\n| Type exit to close the program (this will NOT save your game)                                                      |" +
                            "\n| Type inventory to check out what you have in you inventory                                                         |" +
                            "\n| Type adventurers to send out people to gather items(cost of each adventurer is 25 * guild lvl)                     |" +
                            "\n| Type shop to check out you shop and put items up for sale (there is a max of 10 items you can put up for sale)     |" +
                            "\n| The shop works by giving you a customer that want to buy an item from your invetory you will give a price and the -|" +
                            "\n| will decide if they want to buy it or not                                                                          |"+
                            "\n| Type save to save your game                                                                                        |" +
                            "\n| Type gold to see how much gold you currently have                                                                  |" +
                            "\n| Type menu to go back to the main menu (this will save your game)                                                   |" +
                            "\n{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=}");
        }


        public static void Main()
        {
            //cmd and lCmd are used to take the users input and 
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
            int PlayerGold= 0;
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
                    itemCreator.Creation(5);
                    Console.WriteLine("");

                }
                //loads the save game.
                if (lCmd == "load")
                {
                    lCmd = eg.Ask("Please insert name of save game");

                }
                while (New == true || Saved == true)
                {
                    cmd = eg.Ask("What would you like to do? ");
                    lCmd = cmd.ToLower();
                    //Displays the players inventory
                    if (lCmd == "inventory")
                    {
                        itemCreator.Inventory();
                    }
                    //Displays a help menu with a list of commands
                    if (lCmd == "help")
                    {
                        Help();
                    }
                    //Used to schedule an adventurer to gather items
                    if (lCmd == "adventurers" || lCmd == "ag")
                    {
                        Console.WriteLine("{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=}" +
                                       $"\n The Adventurers guild is LVL {ad.ALVL} and are {ad.AXP} out of {ad.XPTNLVL} to the next LVL" +
                                       $"\n Each Adventurer will cost {25 * ad.ALVL}" +
                                       $"\n You currently have {ad.AS} out gathering items" +
                                        "\n{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=}");
                        lCmd = eg.Ask("Do you want to send out any Adventurers? " +
                                      "\nType yes to send out adventurers or type anything else to go back to the command screen. " +
                                      "\n");
                        if(lCmd == "yes")
                        {
                            int.TryParse(eg.Ask("How many adventurers would you like to send? "), out ad.AWTS);
                            ad.AC = ad.AWTS * (25 * ad.ALVL);
                            if (ad.AC <= PlayerGold && itemCreator.InvetoryCount <= 100)
                            {
                                ad.AS += ad.AWTS;
                                Console.WriteLine($"you have sent out {ad.AS} Adventurers!");
                                PlayerGold -= ad.AC;
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
                    //Will allow the player to see what they are selling, the chance the item is sold, and how much each item is being sold for
                    if (lCmd == "shop")
                    {
                        lCmd = eg.Ask("Do you want to work at your shop This hour?" +
                                    "\nType sell to work the shop, do anthing else to go back." +
                                    "\n");
                        if (lCmd == "sell" && itemCreator.InvetoryCount > 0)
                        {
                            int CustomersChoice;
                            int Price;
                            CustomersChoice = random.Next(0, itemCreator.InvetoryCount);
                            Console.WriteLine("");
                            Console.WriteLine("After a while a costumer enters the shop asking about the price of");
                            itemCreator.GettingValue(CustomersChoice);
                            int.TryParse(eg.Ask("How much would you like to sell the item for?"), out Price);
                            itemCreator.GettingValue2(CustomersChoice);
                            customer.CustomersDecision(itemCreator.Cost ,Price);
                            if (customer.ItemSold)
                            {
                                
                                PlayerGold += Price;
                            }

                        }
                        else if(lCmd == "stock")
                        {
                            
                        }

                    }
                    //Ends the day
                    if (lCmd == "close")
                    {
                        lCmd = eg.Ask("Do you really want to go to close up for the day?" +
                                      "\nType yes to close, type anything else to do something else." +
                                      "\n");
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
                        itemCreator.Creation(1);
                    }
                    if (lCmd == "gold")
                    {
                        Console.WriteLine($"You have {PlayerGold}");
                    }
                }
            }

        }
    }
}
