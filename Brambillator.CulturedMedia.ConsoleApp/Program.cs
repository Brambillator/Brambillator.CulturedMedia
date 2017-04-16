using System;
using System.Linq;
using System.Collections.Generic;
using Brambillator.CulturedMedia.Service;
using Brambillator.CulturedMedia.Repositories.EF;
using Brambillator.CulturedMedia.Domain.Views;

namespace Brambillator.CulturedMedia.ConsoleApp
{
    class Program
    {
        private static bool quit = false;
        private static EFCulturedMediaUnitOfWork unitOfWork = new EFCulturedMediaUnitOfWork();
        private static ResourceService service = new ResourceService(unitOfWork);

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.InputEncoding = System.Text.Encoding.Unicode;

            Console.WriteLine("Initializing repository...");
            Repositories.EFCulturedMediaUnitOfWorkInitializer.Initialize(unitOfWork);
            Console.WriteLine("");

            Console.WriteLine("Welcome to CulturedMedia. Type in a command (help for list):");
            Console.WriteLine("");

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
                { "quit", Quit },
                { "exit", Quit },
                { "addtextresource" , AddTextResource },
                { "addtitledtextresource", AddTitledTextResource},
                { "removeresourceforculture", RemoveResourceForCulture},
                { "removeresource", RemoveResource },
                { "getresource", GetResource},
                { "createupdateresource", CreateUpdateResource},
                { "save", Save }
            };


        private static void Quit(string[] args)
        {
            quit = true;
        }

        private static void AddTextResource(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Not enough arguments.");
                return;
            }

            var cultureName = args[0];
            var textKey = args[1];
            var text = string.Join(" ", args, 2, args.Length - 2);

            try
            {
                service.AddTextResource(cultureName, textKey, string.Empty, text);
                Console.WriteLine(string.Format("Added - Language: {0}, Key: {1}, Text: '{2}';", cultureName, textKey, text));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void CreateUpdateResource(string[] args)
        {
            if (args.Length < 3)
            {
                Console.WriteLine("Not enough arguments.");
                return;
            }

            var cultureName = args[0];
            var textKey = args[1];
            var text = string.Join(" ", args, 2, args.Length - 2);

            try
            {
                Resource resource = new Resource();
                resource.Key = textKey;
                resource.Text = text;

                service.CreateOrUpdateResource(cultureName, resource);
                Console.WriteLine(string.Format("Saved - Language: {0}, Key: {1}, Text: '{2}';", cultureName, textKey, text));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void Save(string[] args)
        {
            service.UnitOfWork.Commit();
        }

        private static void AddTitledTextResource(string[] args)
        {
            if (args.Length < 4)
            {
                Console.WriteLine("Not enough arguments.");
                return;
            }

            var cultureName = args[0];
            var textKey = args[1];
            var textTitle = args[2];
            var text = string.Join(" ", args, 3, args.Length - 3);

            try
            {
                service.AddTextResource(cultureName, textKey, textTitle, text);
                Console.WriteLine(string.Format("Added - Language: {0}, Key: {1}, Text: '{2}';", cultureName, textKey, text));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void RemoveResourceForCulture(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Not enough arguments.");
                return;
            }

            var cultureName = args[0];
            var textKey = args[1];

            try
            {
                service.RemoveResource(cultureName, textKey);
                Console.WriteLine(string.Format("Removed '{0}' for '{1}' culture.", textKey, cultureName));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void RemoveResource(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Not enough arguments.");
                return;
            }

            var textKey = args[0];

            try
            {
                service.RemoveResourceForAllCultures(textKey);
                Console.WriteLine(string.Format("Removed '{0}' for all cultures.", textKey));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void GetResource(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Not enough arguments.");
                return;
            }

            var cultureName = args[0];
            var textKey = args[1];

            try
            {
                Resource resource = service.GetResource(cultureName, textKey);
                Console.WriteLine(string.Format("Returned resource {{ Key: '{0}', Title: '{1}', Text: '{2}' }}.", resource.Key, resource.Title, resource.Text));
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public static void HelpFunc(string[] args)
        {
            Console.WriteLine("");
            Console.WriteLine("===== HELP ==== ");
            Console.WriteLine("Brambillator.CulturedMedia.ConsoleApp v 0.1");
            Console.WriteLine("");
            Console.WriteLine("Available Commands:");
            Console.WriteLine("---------");
            Console.WriteLine("AddTextResource \"Culture\" \"Key\" \"Text\"");
            Console.WriteLine("AddTitledTextResource \"Culture\" \"Key\" \"Title\" \"Text\"");
            Console.WriteLine("RemoveResourceForCulture \"Culture\" \"Key\"");
            Console.WriteLine("RemoveResource \"Key\"");
            Console.WriteLine("GetResource \"Culture\" \"Key\"");
            Console.WriteLine("CreateUpdateResource \"Culture\" \"Key\" \"Text\"");
            Console.WriteLine("Save");
            Console.WriteLine("");
            Console.WriteLine("");
        }
    }
}