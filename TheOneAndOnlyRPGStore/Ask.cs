using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheOneAndOnlyRPGStore
{
    class Asks
    {
            
    public void MyPrinter(string _val)
    {
        Console.WriteLine(_val);
        
    }

    public string Ask(string _val)
    {
            Console.Write(_val);
            return Console.ReadLine();

    }
}
}
