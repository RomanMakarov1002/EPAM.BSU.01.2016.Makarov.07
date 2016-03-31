using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var mesSender = new MessagesSender();
            var user1 = new ConnectedUser(mesSender);
            var user2 = new ConnectedUser(mesSender);
            mesSender.SimulateClock(2, "hello");
            Console.ReadKey();
            user2.Disconnect(mesSender);
            Console.WriteLine();
            var adm = new ConnectedAdmin(mesSender);
            var admin2 = new ConnectedAdmin(mesSender);            
            mesSender.SimulateClock(3, "Heya bro");
            Console.ReadKey();
            var Mes = new MessagesSender();
            Mes.SimulateClock(1, "Hi");
            Console.WriteLine();
            Console.ReadKey();

        }
    }
}
