using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace OOPKelompok
{
    class UserController
    {
        List<Account> userStore;
        bool valName;
        bool valPass;
        bool val;

        public UserController(List<Account> temp)
        {
            this.userStore = temp;
        }

        public void createAccount()
        {
            do
            {
                enter();
                Console.WriteLine("============= CREATE USER =============");
                Console.Write("First Name : ");
                string firstname = Console.ReadLine();
                Console.Write("Last Name : ");
                string lastname = Console.ReadLine();
                Console.Write("Password : ");
                string password = Console.ReadLine();

                if (firstname.Length < 2 || lastname.Length < 2 || password.Length < 2)
                {
                    Console.Clear();
                    Console.WriteLine("\t Must Have More Character ");
                    valName = false;
                    valPass = false;
                }
                else
                {
                    Console.WriteLine("Loading ... ");
                    valName = CekName(firstname, lastname);
                    valPass = CekPassword(password);
                    Console.Clear();
                    val = valAcc(valName, valPass);
                    if (valName == true && valPass == true && val == true)
                    {
                        string username = firstname.Substring(0, 2) + lastname.Substring(0, 2);
                        Account a = new Account(firstname, lastname, password, username.ToLower());
                        userStore.Add(a);
                        Console.WriteLine($"First Name \t: {a.FirstName} \nLast Name \t: {a.LastName} \nUsername \t: {a.UserName} \nPassword \t: {a.Password}");
                    }
                }

            } while (valName == false || valPass == false || val == false);
        }

        public bool Like(this string toSearch, string toFind)
        {
            return new Regex(@"\A"+ new Regex(@"\.|\$|\^|\{|\[|\(|\||\)|\*|\+|\?|\\").Replace(toFind, ch => @"\"+ch).Replace('_', '.').Replace("%", ".*") + @"\z", RegexOptions.Singleline).IsMatch(toSearch);
        }

        public bool valAcc(bool name, bool pass) 
        {
            if (name == false && pass == false)
            {
                Console.WriteLine("====== Invalid Data and Password ======");
                return false;
            }
            else if (pass == false && name == true)
            {
                Console.WriteLine("===== Not Like Requirment Password ====");
                return false;
            }
            else if (name == false && pass == true)
            {
                Console.WriteLine("============= Already Data ============");
                return false;
            }
            else
            {
                Console.WriteLine("============= Create Succes ===========");
                return true;
            }
        }

        public bool CekName(string first, string last)
        {
            foreach (Account a in userStore)
            {
                if ((a.FirstName.Contains(first) && a.LastName.Contains(last)))
                {
                    Console.WriteLine("============= Already Data ============");
                    return false;
                }
            }
            return true;
        }

        public bool CekPassword(string input)
        {
            bool cek = false;
            var regexItem = new Regex("[^A-Za-z0-9]");
            bool isNumber = int.TryParse(input, out int n);
            bool hasSpecialChar = regexItem.IsMatch(input.ToString()) || isNumber;
            if ((input.Length >= 8) && (input.Any(char.IsUpper) == true) && (hasSpecialChar == true) )
            {
                cek = true;
            }
            return cek;
        }

        public void LoginAccount()
        {
            enter();
            Console.WriteLine("============== LOGIN USER =============");
            Console.Write("Username: ");
            string username = Console.ReadLine();
            Console.Write("Password: ");
            string password = Console.ReadLine();

            foreach (Account a in userStore)
            {
                if (a.UserName.Equals(username) && a.Password.Equals(password))
                {
                    Console.WriteLine("============ Login Success ============");
                    Console.WriteLine($"\t Welcome {a.FirstName} {a.LastName}");
                    return;
                }
            }
            Console.WriteLine("============ Login Failed =============");
        }

        public void ShowAccounts()
        {
            Console.WriteLine("============ SHOW ACCOUNTS ============");
            foreach (Account a in userStore)
            {
                enter();
                Console.WriteLine($"Name \t\t: {a.FirstName} {a.LastName} \nUsername \t: {a.UserName}");
                enter();
            }
        }

        public void SearchAccount()
        {
            Console.WriteLine("=========== SEARCH ACCOUNT ============");
            enter();
            Console.WriteLine("Masukkan Username yang akan di cari");
            enter();
            Console.Write("Username : ");
            string inp = Console.ReadLine();
            Console.Clear();
            string search = $"%{inp}%";

            foreach (Account u in userStore)
            {
                if ((u.UserName == inp || u.FirstName == inp || u.LastName == inp))
                {

                    Console.WriteLine($"============== User Found ============");
                    Console.WriteLine("\t SHOW DATA USER");
                    Console.WriteLine($"First Name \t: {u.FirstName} \nLast Name \t: {u.LastName} \nUsername \t: {u.UserName} \nPassword \t: {u.Password}");
                    enter();
                    return;
                }
            }

            Console.WriteLine($"=========== User Not Found ===========");
        }

        public void UpdateUser()
        {
            string inp;
            string inp2;
            string back;
            string newUsername;
            enter();
            Console.WriteLine("\tEnter Username to Edit");
            enter();
            Console.Write("Username : ");
            inp = Console.ReadLine();
            Console.Clear();
            foreach (Account user in userStore)
            {
                if (user.UserName == inp)
                {
                    Console.WriteLine($"============= User Found =============");
                    Console.WriteLine("*Edit Option :\n1. First Name \n2. Last Name \n3. Edit All \n4. Exit");
                    enter();
                    Console.Write("Choose Option : ");
                    int inpAngka = Convert.ToInt32(Console.ReadLine());
                    switch (inpAngka)
                    {
                        case 1:
                            do
                            {
                                Console.Write("Edit First Name : ");
                                inp = Console.ReadLine();

                                Console.Write("Sure ? ");
                                back = Console.ReadLine();
                                Console.Clear();
                            } while (inp.Equals("y"));

                            if (back.Equals("y"))
                            {
                                user.FirstName = inp;
                                newUsername = $"{user.FirstName.Substring(0, 2)}{user.LastName.Substring(0, 2)}";
                                user.UserName = newUsername.ToLower();

                                Console.WriteLine($"========= First Name Updated =========");
                            }
                            break;
                        case 2:
                            do
                            {
                                Console.Write("Edit Last Name : ");
                                inp = Console.ReadLine();

                                Console.Write("Sure ? ");
                                back = Console.ReadLine();

                            } while (inp.Equals("y"));

                            if (back.Equals("y"))
                            {
                                user.LastName = inp;
                                newUsername = $"{user.FirstName.Substring(0, 2)}{user.LastName.Substring(0, 2)}";
                                user.UserName = newUsername.ToLower();

                                Console.WriteLine("========== Lastname Updated ===========");
                            }
                            break;
                        case 3:
                            do
                            {
                                Console.Write("Edit First Name : ");
                                inp = Console.ReadLine();

                                Console.Write("Edit Last Name : ");
                                inp2 = Console.ReadLine();

                                Console.Write("Yakin ? (y/t)");
                                back = Console.ReadLine();
                            } while (back.Equals("t"));

                            if (back.Equals("y"))
                            {
                                user.FirstName = inp;
                                user.LastName = inp2;
                                newUsername = $"{user.FirstName.Substring(0, 2)}{user.LastName.Substring(0, 2)}";
                                user.UserName = newUsername.ToLower();

                                Console.WriteLine("=========== Update Succeded ===========");
                            }
                            break;

                        case 4:
                            break;

                        default:

                            Console.WriteLine("============= Wrong Input ============");
                            break;
                    }

                    return;
                }
            }

            Console.WriteLine("============ User Not Found ===========");
        }

        public void DeleteUser()
        {
            enter();
            Console.WriteLine("\tenter username to Delete");
            enter();
            Console.Write("Username : ");
            string inp = Console.ReadLine();
            Account temp = null;

            foreach (Account user in userStore)
            {
                if (user.UserName == inp)
                {
                    Console.WriteLine("========== Username Ditemukan =========");
                    temp = user;
                }

            }
            if (temp != null)
            {
                Console.Write("Yakin Hapus ? ");
                string back = Console.ReadLine();
                if (back.Equals("y"))
                {
                    userStore.Remove(temp);
                    Console.WriteLine("\t   - Delete Berhasil -");
                    enter();
                }
            }else    
            {
                Console.WriteLine("======= Username Tidak Ditemukan ======");
            }
        }

        public void ReadData()
        {
            Console.WriteLine("=========== List User Name ============");
            foreach (Account a in userStore)
            {
                enter();
                Console.WriteLine($"Name \t\t: {a.FirstName} {a.LastName} \nUsername \t: {a.UserName}");
                enter();
            }
        }

        public void enter()
        {
            Console.WriteLine("=======================================");
        }
    }
}
