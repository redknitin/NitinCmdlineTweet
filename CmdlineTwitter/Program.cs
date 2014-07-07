using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdlineTwitter
{
    class Program
    {
        public static PinAuthorizer auth;

        static void authorize()
        {
            auth = new PinAuthorizer()
            {
                Credentials = new InMemoryCredentials
                {
                    ConsumerKey = "FiLff3SigcHPhHQxsSmpVQ", //ConfigurationManager.AppSettings["consumerKey"],
                    ConsumerSecret = "xzmPCd8drcHurgaDG3SRdRooZCBzf1ZvgmekadUYZcQ" //ConfigurationManager.AppSettings["consumerSecret"]                    
                },
                GoToTwitterAuthorization = pageLink => Process.Start(pageLink),
                GetPin = () =>
                {
                    Console.Write("Enter Twitter PIN: ");
                    var input = Console.ReadLine().Trim();
                    return input;
                },
                AuthAccessType = AuthAccessType.Write
            };

            auth.Authorize();

            if (!auth.IsAuthorized)
            {
                Console.WriteLine("Not authorized");
                Environment.Exit(0);
            }
        }

        static void Main(string[] args)
        {
            authorize();
            MainMenu.ctx = new TwitterContext(auth);

            while(true) {
                MainMenu.ShowMenu();
                MainMenu.DoSomething();
            }
        }
    }
}
