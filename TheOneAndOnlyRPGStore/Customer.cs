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
        public bool ItemSold = false;
        public void CustomersDecision(int Cost, int Price)
        {
            ItemSold = false;
            double ChanceToBuy = 25;
            if (Cost >= Price)
            {
                ChanceToBuy += 10*(Cost / Price);
                Console.WriteLine(ChanceToBuy);
            }
            else
            {
                ChanceToBuy -= 10*(Price / Cost);
            }
            if (ChanceToBuy >= random.Next(0, 50))
            {
                Console.WriteLine("I'll buy it.");
                ItemSold = true;
            }
            else
            {
                Console.WriteLine("I'll pass.");
            }
        }
    }
}
