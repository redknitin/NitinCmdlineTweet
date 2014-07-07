using LinqToTwitter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CmdlineTwitter
{
    class MainMenu
    {
        public static void ShowMenu()
        {
            string menuOptions = "\r\n (1) Send Tweet\r\n (2) View Timeline\r\n (3) View Mentions\r\n (4) Exit\r\n";
            Console.WriteLine(menuOptions);
        }

        static void SendTweet()
        {
            Console.Write("Enter Text: ");
            string txt = Console.ReadLine().Trim();
            ctx.UpdateStatus(txt);
        }

        static void ViewTimeline()
        {
            var qry = ctx.Status.Where(m => m.Type == StatusType.Home).OrderBy(m => m.CreatedAt);
            foreach (var tw in qry)
            {
                string showRow = "[" + tw.User.Name + "]: " + tw.Text + "\r\n"; //tw.StatusID + 
                Console.WriteLine(showRow);
            }
        }

        static void ViewMentions()
        {
            var qry = ctx.Status.Where(m => m.Type == StatusType.Mentions).OrderBy(m => m.CreatedAt);
            foreach (var tw in qry)
            {
                string showRow = "[" + tw.User.Name + "]: " + tw.Text + "\r\n"; //tw.StatusID + 
                Console.WriteLine(showRow);
            }
        }

        public static TwitterContext ctx;

        public static void DoSomething() {
            string inp = Console.ReadLine().Trim();
            int optvals;
            if (int.TryParse(inp, out optvals))
            {
                switch (optvals)
                {
                    case 1:
                        SendTweet();
                        break;
                    case 2:
                        ViewTimeline();
                        break;
                    case 3:
                        ViewMentions();
                        break;
                    case 4:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Invalid option");
            }
        }
    }
}
