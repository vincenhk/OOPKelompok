using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPKelompok
{
    using System;
    using System.Collections.Generic;

    namespace Authentication
    {
        class MainClass
        {
            public static List<Account> user = new List<Account>();
            static void Main(string[] args)
            {
                AccountAwal();
                string answer;
                UserController proces = new UserController(user);
                string userChoice;
                do
                {
                    Console.Clear();
                    MenuAwal();
                    enter();
                    Console.Write("Choose Number Menu : ");
                    userChoice = Console.ReadLine();

                    switch (userChoice)
                    {
                        case "1":
                            Console.Clear();
                            proces.createAccount();
                            Console.ReadLine();
                            break;

                        case "2":
                            Console.Clear();
                            proces.ShowAccounts();
                            Console.ReadLine();
                            break;

                        case "3":
                            Console.Clear();
                            proces.SearchAccount();
                            Console.ReadLine();
                            break;

                        case "4":
                            Console.Clear();
                            proces.LoginAccount();
                            Console.ReadLine();
                            break;

                        case "5":
                            Console.Clear();
                            proces.UpdateUser();
                            break;

                        case "6":
                            Console.Clear();
                            proces.DeleteUser();
                            break;

                        case "7":
                            Environment.Exit(0);
                            break;

                        default:
                            break;
                    }
                    Console.Write("Kembali ke Menu Utama : ");
                    answer = Console.ReadLine();
                } while (answer.Equals("y"));
            }

            public static void AccountAwal()
            {
                Account a = new Account("Ardi", "Simahotang", "12345", "arho");
                Account b = new Account("Titik", "Solehun", "12345", "tile");
                Account c = new Account("Niko", "Picolo", "12345", "nipi");

                user.Add(a);
                user.Add(b);
                user.Add(c);

            }
            
            public static void MenuAwal()
            {
                Console.WriteLine("======= BASIC AUTHENTICATION ======");

                Console.WriteLine($"1. Create User \n2. Show User \n3. Search User \n4. Login \n5. Update User \n6. Delete User \n7. Exit");
            }

            public static void enter()
            {
                Console.WriteLine("===================================");

            }
        }
    }

}
