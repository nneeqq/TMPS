using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPS_LAB4.Core;
using TMPS_LAB4.Data;

namespace TMPS_LAB4
{
    class Program
    {
        public Owner Owner
        {
            get => default;
            set
            {
            }
        }

        public IUser IUser
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

        public static void Output(UserService Owner)
        {
            Console.WriteLine("Owner : {1} {2} - {3}", Owner.UserId, Owner.FirstName, Owner.LastName, Owner.Role);

            foreach (UserService moderator in Owner)
            {
                Console.WriteLine("\n\n\t{0}\n", moderator.Role);
                Console.WriteLine("\n\t Admin: {1}  {2} - Manager al {3}", moderator.UserId,
                    moderator.FirstName, moderator.LastName, moderator.Role);

                foreach (UserService User in moderator)
                {
                    Console.WriteLine(" \t\t ID User: {0}  {1}  {2} - {3}", User.UserId, User.FirstName,
                        User.LastName, User.Role);

                    foreach (var simpleUser in User)
                    {
                        Console.WriteLine("\t\t\t ID User: {0} {1} {2} - {3}\n", simpleUser.UserId, simpleUser.FirstName,
                            simpleUser.LastName, simpleUser.Role);
                    }
                }
            }
        }

        private static bool MainMenu()
        {
            Console.Clear();
            Console.WriteLine("Alegeti optiunea:");
            Console.WriteLine("1) Vizualizati erarhia userilor");
            Console.WriteLine("2) Adaugati un nou user");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nOptiunea: \n");

            //User data
            UserService Owner = new UserService { UserId = 1, FirstName = "Anatol", LastName = "Melnic", Role = "Owner" };

            UserService Moderator1 = new UserService { UserId = 2, FirstName = "Vasile", LastName = "Arana", Role = "Moderator" };
            UserService Moderator2 = new UserService { UserId = 3, FirstName = "Moris", LastName = "Kozlov", Role = "Moderator" };
            Owner.AddSubordinate(Moderator1);
            Owner.AddSubordinate(Moderator2);

            UserService helperUser1 = new UserService { UserId = 4, FirstName = "Roman", LastName = "Tala", Role = "Helper" };
            UserService helperUser2 = new UserService { UserId = 5, FirstName = "Amin", LastName = "Parinte", Role = "Helper" };
            Moderator1.AddSubordinate(helperUser1);
            Moderator1.AddSubordinate(helperUser2);

            UserService asistUser1 = new UserService { UserId = 6, FirstName = "Tatar", LastName = "Konewna", Role = "Assistant" };
            UserService asistUser2 = new UserService { UserId = 7, FirstName = "Tiriaq", LastName = "Tlaloc", Role = "Assistant" };
            SimpleUser tehnUser = new SimpleUser { UserId = 8, FirstName = "Qillaq", LastName = "Malik", Role = "Tehnic" };
            
            Moderator2.AddSubordinate(asistUser1);
            Moderator2.AddSubordinate(asistUser2);

            asistUser2.AddSubordinate(tehnUser);
        

            IUserBuilder User = new NewUserBuilder();
            Owner owner = new Owner();

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Output(Owner);
                    Console.ReadKey();
                    return true;
                case "2":
                    IUser choices = new UserService();
                    Console.Clear();
                    Console.WriteLine("\n Introduceti prenumele: ");
                    choices.FirstName = Console.ReadLine();
                    Console.WriteLine("\n Introduceti numele: ");
                    choices.LastName = Console.ReadLine();
                    Console.WriteLine("\n Introduceti rolul: ");
                    choices.Role = Console.ReadLine();
                    owner.Construct(User, 1111, choices.FirstName, choices.LastName, choices.Role);
                    UserService newUser = User.Build();

                    Console.WriteLine("\n Sub cine va activa noul user?");
                    Console.WriteLine("1) Moderatori");
                    Console.WriteLine("2) Asistenti");
                    var choice = Console.ReadLine();

                    if(choice == "1")
                    {
                        Moderator1.AddSubordinate(newUser);
                    }
                    if(choice == "2")
                    {
                        Moderator2.AddSubordinate(newUser);
                    }
                    Console.ReadKey();
                    Output(Owner);
                    Console.ReadKey();
                    return true;

                default:
                    return false;
            }
        }
    }
}
