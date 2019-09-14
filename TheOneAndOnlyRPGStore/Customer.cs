using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOneAndOnlyRPGStore
{
    class Customer
    {
        Program program = new Program();
        Random random = new Random();
        public bool Sold = false;
        public void CustomersDecision(int Cost, int Price, int choice)
        {
            int CustomersChoice = choice;
            double ChanceToBuy = 25;
            if (Cost >= Price)
            {
                ChanceToBuy += 10*(Cost / Price);;
            }
            else
            {
                ChanceToBuy -= 10*(Price / Cost);
            }
            if (ChanceToBuy >= random.Next(0, 50))
            {
                Console.WriteLine("I'll buy it.");
                Sold = true;
                Program.PlayerGold += Price;
            }
            else
            {
                Console.WriteLine("I'll pass.");
            }
        }
    }
}
