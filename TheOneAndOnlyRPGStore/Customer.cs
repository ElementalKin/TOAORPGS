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
            double ChanceToBuy = 75;
            if (Cost >= Price)
            {
                ChanceToBuy += (Price%Cost);
            }
            else
            {
                ChanceToBuy -= (Price % Cost);
            }
            if (ChanceToBuy >= random.Next(0, 100))
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
