using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using ThreatLocker.Business;


namespace ThreatLocker.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Timer t = new Timer(TimerCallback, null, 0, 3600000);
            Console.ReadLine();
        }
        private static void TimerCallback(Object o)
        {
            UserManager UserMng = new UserManager();
            UserMng.UpdateUserLogin();
        }
    }
}
