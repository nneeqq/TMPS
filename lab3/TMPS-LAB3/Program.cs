using System;
using TMPS_LAB3.Factories;
using TMPS_LAB3.Interfaces;
using TMPS_LAB3.Types;

namespace TMPS_LAB3
{
    class Program
    {
        internal ILevelFactory ILevelFactory
        {
            get => default;
            set
            {
            }
        }

        public IRestriction IRestriction
        {
            get => default;
            set
            {
            }
        }

        public IType IType
        {
            get => default;
            set
            {
            }
        }

        static void Main(string[] args)
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }
        }
        private static bool MainMenu()
        {
            string name;
            string choice;
            Console.Clear();
            Console.WriteLine($"1) Creati un user de tip {UserType.Admin}");
            Console.WriteLine($"2) Creati un user de tip {UserType.Moderator}");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nSelect an option: \n");

            switch (Console.ReadLine())
            {
                case "1":
                    ILevelFactory userAdmin = new Level1Factory();

                    Console.WriteLine("\nIntroduceti ownerul accountului :");

                    name = Console.ReadLine();

                    IType typeAdmin = userAdmin.CreateUserType(name, 1, UserType.Admin);
                    IRestriction restrictionAdmin = userAdmin.CreateRestriction("Fara restrictii", UserType.Admin);

                    typeAdmin.Create();
                    restrictionAdmin.Apply();

                    Console.WriteLine("Doriti sa mai creati un user de acelasi tip? yes / no");
                    choice = Console.ReadLine();

                    if (choice.ToLower() == "yes")
                    {
                        Console.WriteLine("\nIntroduceti ownerul accountului :");

                        name = Console.ReadLine();

                        var type2 = (IType)typeAdmin.Clone();
                        type2 = userAdmin.CreateUserType(name, 2, UserType.Admin);
                        var restriction2 = (IRestriction)restrictionAdmin.Clone();
                        restriction2 = userAdmin.CreateRestriction("Fara restrictii", UserType.Admin);
                        type2.Create();
                        restriction2.Apply();
                    }

                    Console.WriteLine("Doriti sa creati alt user ? yes / no \n");
                    choice = Console.ReadLine();

                    var returnChoice1 = choice.ToLower() == "yes" ? true : false;

                    return returnChoice1;

                case "2":
                    ILevelFactory userModerator = new Level2Factory();

                    Console.WriteLine("\nIntroduceti ownerul accountului :");

                    name = Console.ReadLine();

                    IType typeModerator = userModerator.CreateUserType(name, 1, UserType.Moderator);
                    IRestriction restrictionModerator = userModerator.CreateRestriction("Restrictii de ordin 1", UserType.Moderator);

                    typeModerator.Create();
                    restrictionModerator.Apply();

                    Console.WriteLine("Doriti sa mai creati un user de acelasi tip? yes / no");
                    choice = Console.ReadLine();

                    if (choice.ToLower() == "yes")
                    {
                        Console.WriteLine("\nIntroduceti ownerul accountului :");

                        name = Console.ReadLine();

                        var type2 = (IType)typeModerator.Clone();
                        type2 = userModerator.CreateUserType(name, 2, UserType.Moderator);
                        var protection2 = (IRestriction)restrictionModerator.Clone();
                        protection2 = userModerator.CreateRestriction("Restrictii de ordin 1", UserType.Moderator);
                        type2.Create();
                        protection2.Apply();
                    }

                    Console.WriteLine("Doriti sa creati alt user ? yes / no \n");
                    choice = Console.ReadLine();


                    var returnChoice2 = choice.ToLower() == "yes" ? true : false;
                    return returnChoice2;

                case "3":
                    return false;
                default:
                    return true;
            }
        }
    }
}
