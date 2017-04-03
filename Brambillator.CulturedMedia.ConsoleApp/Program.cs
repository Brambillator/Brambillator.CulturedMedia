using System;
using System.Linq;
using System.Collections.Generic;
using Brambillator.CulturedMedia.Service;
using Brambillator.CulturedMedia.Repositories.EF;

namespace Brambillator.CulturedMedia.ConsoleApp
{
    class Program
    {
        private static bool quit = false;
        ResourceService service = new ResourceService();

        private static EFCulturedMediaUnitOfWork unitOfWork = new EFCulturedMediaUnitOfWork();

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("Initializing repository...");
            Repositories.EFCulturedMediaUnitOfWorkInitializer.Initialize(unitOfWork);
            Console.WriteLine("");

            Console.WriteLine("Welcome to CulturedMedia. Type in a command (help for list).");

            while (!quit)
            {
                Console.Write("$ ");
                string command = Console.ReadLine();

                string command_main = command.Split(new char[] { ' ' }).First().ToLower();
                string[] arguments = command.Split(new char[] { ' ' }).Skip(1).ToArray();
                if (lCommands.ContainsKey(command_main))
                {
                    Action<string[]> function_to_execute = null;
                    lCommands.TryGetValue(command_main, out function_to_execute);
                    function_to_execute(arguments);
                }
                else
                    Console.WriteLine("Command '" + command_main + "' not found");
            }
        }

        private static Dictionary<string, Action<string[]>> lCommands =
            new Dictionary<string, Action<string[]>>()
            {
                { "help", HelpFunc },
                { "echo", Echo },
                { "quit", Quit },
                { "exit", Quit },
                { "addtextresource" , AddTextResource }
            };


        private static void Quit(string[] args)
        {
            quit = true;
        }

        private static void Echo(string[] args)
        {
            Console.WriteLine("Command line arguments:");
            foreach (string arg in args)
            {
                Console.WriteLine("# " + arg);
            }
        }

        private static void AddTextResource(string[] args)
        {
            if (args.Length < 2) return;

            string language = args[0];
            string text = string.Join(" ", args, 1, args.Length - 1);

            Console.WriteLine("Adding Language:'" + language + "', Text: '" + text + "'");
        }

        public static void HelpFunc(string[] args)
        {
            Console.WriteLine("===== SOME MEANINGFULL HELP ==== ");
            Console.WriteLine("Commands:");
            Console.WriteLine("---------");
            Console.WriteLine("AddTextResource \"language\" \"text\"");
            Console.WriteLine("");
        }
    }
}