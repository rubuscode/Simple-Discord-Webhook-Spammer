using DiscordWebhook;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace simple_webhook_sender
{
    internal class Program
    {
        static int sended = 0;
        static int notsended = 0;

        static void Main()
        {
            Console.Title = "Simple Discord Webhooks Spammer";
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Simple Discord Webhooks Spammer by rubus!");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Webhook link >> ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string webhooklink = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Username >> ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string username = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Content >> ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string content = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write("Delay [ms] >> ");
            Console.ForegroundColor = ConsoleColor.Gray;
            string delay = Console.ReadLine();

            

            if (String.IsNullOrEmpty(webhooklink) ||
                String.IsNullOrEmpty(username) ||
                String.IsNullOrEmpty(content) ||
                String.IsNullOrEmpty(delay)
                )
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Don't skip any string!");
                Thread.Sleep(350);
                Console.Clear();
                Main();
            }
            else
            {
                Webhook webhook = new Webhook(webhooklink);
                Console.Clear();
                while (true)
                {
                    Thread.Sleep(int.Parse(delay));
                    WebhookObject obj = new WebhookObject()
                        {
                            username = username,
                            content = content
                        };
                    try
                    {
                        webhook.PostData(obj);
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine("Sended!");
                        sended++;
                        Console.Title = "Simple Discord Webhooks Spammer | Sended: " + sended + " | Not Sended: " + notsended;
                    } 
                    catch
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("ERROR! Retrying...");
                        notsended++;
                        Console.Title = "Simple Discord Webhooks Spammer | Sended: " + sended + " | Not Sended: " + notsended;
                    }
                }
            }
        }
    }
}
