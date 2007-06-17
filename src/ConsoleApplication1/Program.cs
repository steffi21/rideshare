using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            IList<rideShareBackEnd.UserDetails> users =  rideShareBackEnd.UserDetails.GetUsers(1, null, null);
            Console.WriteLine( rideShareBackEnd.JsonSerialise.Serialise(users[0]));
            Console.ReadLine();

        }
    }
}
