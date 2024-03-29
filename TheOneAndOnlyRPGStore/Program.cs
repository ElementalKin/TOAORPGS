﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOneAndOnlyRPGStore
{
    class PlayerStats
    {
        public static int PlayerGold = 0;
        public static int HoursLeft = 12;
        public static int Days = 0;
        public static int TotalGoldEarned = 0;
        public static int TotalGoldSpent = 0;
        public static int TotalItemsMade = 0;
        public static int TotalItemsSold = 0;
        public static int TotalAdventurersSent = 0;
        public static void Stats()
        {
            Console.WriteLine("{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=}" +
                           $"\nCurrent gold {PlayerGold}, Total gold earned {TotalGoldEarned}, Total gold spent {TotalGoldSpent}" +
                           $"\nTotal Items made {TotalItemsMade}, Total items sold {TotalItemsSold}" +
                           $"\nTotal adventurers sent {TotalAdventurersSent}" +
                            "\n{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=}");
            Console.WriteLine("Press anything to go back");
            Console.ReadKey();
        }
        public static void Stats(int x)
        {
            switch (x)
            {
                case 1:
                    Console.WriteLine($"Total gold earned {TotalGoldEarned}");
                    Console.WriteLine("Press anything to go back");
                    Console.ReadKey();
                    break;
                case 2:
                    Console.WriteLine($"Total gold spent {TotalGoldSpent}");
                    Console.WriteLine("Press anything to go back");
                    Console.ReadKey();
                    break;
                case 3:
                    Console.WriteLine($"Total items made {TotalItemsMade}");
                    Console.WriteLine("Press anything to go back");
                    Console.ReadKey();
                    break;
                case 4:
                    Console.WriteLine($"Total items Sold {TotalItemsSold}");
                    Console.WriteLine("Press anything to go back");
                    Console.ReadKey();
                    break;
                case 5:
                    Console.WriteLine($"Total items made {TotalAdventurersSent}");
                    Console.WriteLine("Press anything to go back");
                    Console.ReadKey();
                    break;
            }

        }

    }
    class Program : PlayerStats
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
                            "\n| Type menu to go back to the main menu (this will save your game).                                                  |" +
                            "\n| Type stats to check out your stats.                                                                                |" +
                            "\n|                                                    Extra Info                                                      |" +
                            "\n|                                                                                                                    |" +
                            "\n| The shop works by giving you a customer that want to buy an item from your invetory you will give a price and the -|" +
                            "\n| will decide if they want to buy it or not.                                                                         |" +
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
            Saving saveandload = new Saving();
            bool New = false;
            bool Loaded = false;

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
                    TotalGoldEarned += 100;
                    Console.WriteLine("If you need help type help into the command prompt to bring up a list of commands.");
                    Console.WriteLine("Here are some starting items.\r\n");
                    itemCreator.Creation(5, 0);
                    Console.WriteLine("\r\nInput Anything to continue.");
                    Console.ReadKey();
                }
                //loads the save game.
                if (lCmd == "load")
                {
                    saveandload.ReadPI();
                    saveandload.ReadPS();
                    Loaded = true;

                }
                while (New == true || Loaded == true)
                {
                    Console.Clear();
                    cmd = eg.Ask("{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=}" +
                                "\nWhat would you like to do?\r\n " +
                                "\nYou can check your inventory(1) " +
                                "\nSend out adventurers(2) " +
                                "\nSell an item at your shop[3] " +
                                "\nClose up shop for the day[4] " +
                                "\nCheck your stats[stats] " +
                                "\nIf you need any more help type help\r\n" +
                               $"\nNumber of days open {Days}. " +
                               $"\nYou have {HoursLeft} hours left to do something. " +
                               $"\nCurrent gold {PlayerGold}" +
                               $"\nAmount of adventurers sent out is {Adventurers.AS}" +
                               $"\nAdventurers Guild LVL is {Adventurers.ALVL}" +
                               "\n{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=}\n");
                    lCmd = cmd.ToLower();
                    switch (lCmd)
                    {
                        //Displays the players inventory
                        case ("1"):
                            itemCreator.Inventory();
                            eg.Ask("Input anything to go back to town square");
                            break;
                        //Displays a help menu with a list of commands
                        case ("help"):
                            Help();
                            eg.Ask("Input anything to go back to town square");
                            break;
                        //Used to schedule an adventurer to gather items
                        case ("2"):
                            if (HoursLeft > 0)
                            {
                                Console.WriteLine("{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=}" +
                                                $"\n The Adventurers guild is LVL {Adventurers.ALVL} and are {Adventurers.AXP} out of {Adventurers.XPTNLVL} to the next LVL" +
                                                $"\n Each Adventurer will cost {25 * Adventurers.ALVL}" +
                                                $"\n You currently have {Adventurers.AS} out gathering items" +
                                                "\n{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=-=}");
                                lCmd = eg.Ask("Do you want to send out any Adventurers? " +
                                            "\nType yes to send out adventurers or type anything else to go back to town square. " +
                                            "\n");
                                if (lCmd == "yes")
                                {
                                    int.TryParse(eg.Ask("How many adventurers would you like to send? "), out ad.AWTS);
                                    ad.AC = ad.AWTS * (25 * Adventurers.ALVL);
                                    if (ad.AC <= PlayerGold && ItemCreation.InvetoryCount <= 100)
                                    {
                                        Adventurers.AS += ad.AWTS;
                                        Console.WriteLine($"you have sent out {Adventurers.AS} Adventurers!");
                                        PlayerGold -= ad.AC;
                                        TotalAdventurersSent += Adventurers.AS;
                                        TotalGoldSpent += ad.AC;
                                        HoursLeft -= 1;
                                        eg.Ask("Input anything to go back to town square");
                                        break;
                                    }
                                    else if (ad.AC > PlayerGold)
                                    {
                                        Console.WriteLine("You do not have the gold to fund this many adventurers.");
                                        eg.Ask("Input anything to go back to town square");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("You already have to many items. sell some before you send out more adventurers!");
                                        break;
                                    }
                                }
                                else
                                {
                                    eg.Ask("Going back to town square");
                                }
                            }
                            else
                            {
                                Console.WriteLine("It is too late to send out adventurers.");
                                eg.Ask("Input anything to go back to town square");
                                break;
                            }
                            break;
                        //Will allow the player to see what they are selling, the chance the item is sold, and how much each item is being sold for
                        case ("3"):
                            if (HoursLeft > 0)
                            {
                                lCmd = eg.Ask("{=-=-=-=-=-=-=-=-=-=-=-=-=-={-}=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=}" +
                                            "\n|Do you want to work at your shop This hour?                  |" +
                                            "\n|Type yes to work the shop, do anthing else to go back.       |" +
                                            "\n{=-=-=-=-=-=-=-=-=-=-=-=-=-={-}=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=}\n");
                                if (lCmd == "yes" && ItemCreation.InvetoryCount > 0)
                                {

                                    int CustomersChoice;
                                    int Price;
                                    CustomersChoice = random.Next(0, ItemCreation.InvetoryCount);
                                    Console.WriteLine("{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-={-}=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=}" +
                                                    "\nAfter a while a costumer enters the shop asking about the price of   ");
                                    itemCreator.GettingValue(CustomersChoice);
                                    Console.WriteLine("{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-={-}=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=}\n");
                                    int.TryParse(eg.Ask("How much would you like to sell the item for?"), out Price);
                                    if (Price > 0)
                                    {
                                        itemCreator.GettingValue2(CustomersChoice);
                                        customer.CustomersDecision(itemCreator.Cost, Price, CustomersChoice);
                                        HoursLeft -= 1;
                                        eg.Ask("Input anything to go back to town square");
                                        if (customer.Sold)
                                        {
                                            itemCreator.DeleteTheItem(CustomersChoice);
                                            customer.Sold = false;
                                            break;
                                        }
                                    }
                                    else
                                    {
                                        Console.WriteLine("Please input a number above 0.");
                                        Console.ReadKey();
                                        break;
                                    }
                                }
                                else
                                {
                                    eg.Ask("you have ran out of items to sell");
                                }
                            }
                            else
                            {
                                Console.WriteLine("it is too late to open the store now.");
                                eg.Ask("Input anything to go back to town square");
                                break;
                            }
                            break;
                        //Ends the day
                        case ("4"):

                            lCmd = eg.Ask("{=-=-=-=-=-=-=-=-=-=-=-=-=-={-}=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=}" +
                                        "\n|Do you want to go to close up for the day?                   |" +
                                        "\n|Type yes to close, type anything else to do something else.  |" +
                                        "\n{=-=-=-=-=-=-=-=-=-=-=-=-=-={-}=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=}\n");
                            if (lCmd == "yes")
                            {
                                if (Adventurers.AS > 0)
                                {
                                    Console.WriteLine("the Adventurers you sent out have brought back");
                                    ad.AdventurersReturn();
                                    HoursLeft = 12;
                                    Days += 1;
                                }
                                else
                                {
                                    Console.WriteLine("you sent out no adventurers");
                                }
                                eg.Ask("Input anything to go back to town square");
                            }
                            break;

                        case ("stats"):
                            {
                                lCmd = eg.Ask("Would like you see a specific stat or all of them?[1][2]");
                                if (lCmd == "1")
                                {
                                    lCmd = eg.Ask("{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=}" +
                                                "\n|What stat would you like to see?                                                                                |" +
                                                "\n|[1]Total gold earned [2]Total gold spent [3]Total items made [4]Total items sold [5]total adventurers sent      |" +
                                                "\n{=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-{-}-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=-=--=-=-=-=-=-=-=-=-=}\n");
                                    Stats(Convert.ToInt32(lCmd));
                                }
                                if (lCmd == "2")
                                {
                                    Stats();
                                }
                                break;
                            }
                        //Saves the game
                        case ("save"):
                            saveandload.WritePI();
                            saveandload.WritePS();
                            Console.WriteLine("You have saved your game.");
                            Console.ReadKey();
                            break;
                        //Creates an item(Developer tool)
                        case ("create"):
                            itemCreator.Creation(1, 5 * Adventurers.ALVL);
                            Console.ReadKey();
                            break;
                        case ("exit"):
                            New = false;
                            Loaded = false;
                            lCmd = "exit";
                            break;

                    }
                }
            }

        }
    }

}


