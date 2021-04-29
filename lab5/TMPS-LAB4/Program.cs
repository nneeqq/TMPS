using System;
using TMPS_LAB4.Core;
using TMPS_LAB4.Data;
using TMPS_LAB4.Decorator;
using TMPS_LAB4.Interfaces;

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

        public ISalarySpecification ISalarySpecification
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
            Console.Clear();
            Console.WriteLine("Alegeti optiunea:");
            Console.WriteLine("1) Vizualizati erarhia userilor");
            Console.WriteLine("2) Adaugati un nou user");
            Console.WriteLine("3) Exit");
            Console.Write("\r\nOptiunea: \n");

            //User data
            UserService Owner = new UserService { UserId = 1, FirstName = "Anatol", LastName = "Melnic", Role = "Owner" };

            UserService Moderator1 = new UserService { UserId = 2, FirstName = "Vasile", LastName = "Arana", Role = "Moderator" };
            UserService Moderator2 = new UserService { UserId = 3, FirstName = "Moris", LastName = "Kozlov", Role = "Asistent" };
            Owner.AddSubordinate(Moderator1);
            Owner.AddSubordinate(Moderator2);

            UserService asistantUser1 = new UserService { UserId = 4, FirstName = "Roman", LastName = "Tala", Role = "Helper" };
            UserService asistantUser2 = new UserService { UserId = 5, FirstName = "Amin", LastName = "Parinte", Role = "Helper" };
            Moderator1.AddSubordinate(asistantUser1);
            Moderator1.AddSubordinate(asistantUser2);

            UserService cameraUser1 = new UserService { UserId = 6, FirstName = "Tatar", LastName = "Konewna", Role = "Asistant" };
            UserService cameraUser2 = new UserService { UserId = 7, FirstName = "Tiriaq", LastName = "Tlaloc", Role = "Asistant" };
            SimpleUser techUser = new SimpleUser { UserId = 8, FirstName = "Qillaq", LastName = "Malik", Role = "Tehnik" };

            Moderator2.AddSubordinate(cameraUser1);
            Moderator2.AddSubordinate(cameraUser2);

            cameraUser2.AddSubordinate(techUser);

            IUserBuilder User = new NewUserBuilder();
            Owner director = new Owner();
            ISalarySpecification salary = new SimpleUser();
            var counterSalary = new CounterSpecification(salary);
            var asistSalary = new ManagerSpecification(counterSalary);
            var moderatorSalary = new DepartmentDirectorSpecification(asistSalary);
            var ownerSalary = new OwnerSpecification(moderatorSalary);

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();

                    Console.WriteLine("Owner: {1} {2} - {3} cu salariul {4}$", Owner.UserId,
                        Owner.FirstName, Owner.LastName, Owner.Role, Math.Round(ownerSalary.CountSalary(), 2));

                    foreach (UserService manager in Owner)
                    {
                        Console.WriteLine("\n\n\t{0}\n", manager.Role);
                        Console.WriteLine("\n\t Moderator: {1}  {2} - Managerul al {3} cu salariul {4}$", manager.UserId,
                            manager.FirstName, manager.LastName, manager.Role, Math.Round(moderatorSalary.CountSalary(), 2));

                        foreach (UserService aisist in manager)
                        {
                            Console.WriteLine(" \t\t ID Angajat: {0}  {1}  {2} - {3} cu salariul {4}$", aisist.UserId, aisist.FirstName,
                                aisist.LastName, aisist.Role, Math.Round(asistSalary.CountSalary(), 2));

                            foreach (var simpleUser in aisist)
                            {
                                Console.WriteLine("\t\t\t ID Angajat: {0}  {1}  {2} - {3} cu salariul {4}$\n", simpleUser.UserId, simpleUser.FirstName,
                                    simpleUser.LastName, simpleUser.Role, Math.Round(salary.CountSalary(), 2));
                            }
                        }
                    }
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
                    director.Construct(User, 1111, choices.FirstName, choices.LastName, choices.Role);
                    UserService newUser = User.Build();

                    Console.WriteLine("\n Sub cine va activa?");
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

                    Console.WriteLine("Owner : {1} {2} - {3} cu salariul {4}$", Owner.UserId,
                       Owner.FirstName, Owner.LastName, Owner.Role, Math.Round(ownerSalary.CountSalary(), 2));

                    foreach (UserService manager in Owner)
                    {
                        Console.WriteLine("\n\n\t{0}\n", manager.Role);
                        Console.WriteLine("\n\t Moderator : {1}  {2} - Managerul al {3} cu salariul {4}$", manager.UserId,
                            manager.FirstName, manager.LastName, manager.Role, Math.Round(moderatorSalary.CountSalary(), 2));

                        foreach (UserService asist in manager)
                        {
                            Console.WriteLine(" \t\t ID User: {0}  {1}  {2} - {3} cu salariul {4}$", asist.UserId, asist.FirstName,
                                asist.LastName, asist.Role, Math.Round(asistSalary.CountSalary(), 2));

                            foreach (var simpleUser in asist)
                            {
                                Console.WriteLine("\t\t\t ID User: {0}  {1}  {2} - {3} cu salariul {4}$\n", simpleUser.UserId, simpleUser.FirstName,
                                    simpleUser.LastName, simpleUser.Role, Math.Round(salary.CountSalary(), 2));
                            }
                        }
                    }
                    Console.ReadKey();
                    return true;

                default:
                    return false;
            }
        }
    }
}
