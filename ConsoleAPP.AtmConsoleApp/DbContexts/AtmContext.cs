using ConsoleAPP.AtmConsoleApp.Entities;
using System.Text.Json;

namespace ConsoleAPP.AtmConsoleApp.DbContexts
{
    public class AtmContext
    {
        private List<BankAccount> accounts;
        private List<User> users;
        public AtmContext()
        {
            accounts = new List<BankAccount>();
            users = new List<User>();
            LoadDate();
        }

        public bool LoadDate()
        {
            DirectoryInfo info = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"/ATMSERVICES");
            if(info.Exists)
            {
                info.Create();
            }
            string fileusr = info.FullName+@"/Users.txt";
            string FileForAccount = info.FullName+ @"/BankAccounts.txt";
            FileStream stuser = new FileStream(fileusr, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            FileStream staccount = new FileStream(FileForAccount, FileMode.OpenOrCreate, FileAccess.ReadWrite);
            using (StreamReader read=new StreamReader(stuser))
            {
                while(!read.EndOfStream)
                {
                  
                    string line = read.ReadLine()??" ";
                    var jsonUser = JsonSerializer.Deserialize<User>(line);
                    Console.WriteLine(jsonUser.Name);
                    if (jsonUser == null) continue;
                    if(!users.Any(io=>io.Id==jsonUser.Id))
                    {
                        users.Add(jsonUser);
                    }
                }

            }
            using (StreamReader read = new StreamReader(staccount))
            {
                while (!read.EndOfStream)
                {
                    string line = read.ReadLine() ?? " ";
                    var jsonUser = JsonSerializer.Deserialize<BankAccount>(line);
                    if (jsonUser == null) continue;
                    if (!accounts.Any(io => io.Id == jsonUser.Id))
                    {
                        accounts.Add(jsonUser);
                    }
                }

            }
            return true;
        }


        public void SaveChangesToFile()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\ATMSERVICES";
            DirectoryInfo info = new DirectoryInfo(path);
            if(!Directory.Exists(path))
            {
                info.Create();
            }
            string fileforuser = info.FullName + @"\Users.txt";
            string fileforaccount = info.FullName + @"\BankAccounts.txt";
            FileStream ffluser = new FileStream(fileforuser,FileMode.Append|FileMode.OpenOrCreate,FileAccess.Write);
           
            using (StreamWriter write = new StreamWriter(ffluser))
            {
                    foreach (var user in users)// failshi iwereba , baza ro iyos shevanmowmebdi dublikatebsac
                    {
                        string json = JsonSerializer.Serialize(user);
                        write.WriteLine(json);
                    }
               
            }

            FileStream flaccount = new FileStream(fileforaccount,FileMode.Append|FileMode.OpenOrCreate,FileAccess.Write);
            using (StreamWriter write = new StreamWriter(flaccount))
            {
                foreach (var account in accounts)
                {
                    string json = JsonSerializer.Serialize(account);
                    write.WriteLine(json);
                }
            }

        }

        public List<T>? GetSet<T>()
        {
            if (typeof(T) == typeof(BankAccount))
            {
                if (accounts == null) throw new ArgumentNullException(" account is null can not get the context");
                return accounts as List<T>;
            }
            else if (typeof(T) == typeof(User))
            {
                if (users == null) throw new ArgumentNullException(" users is null can not get the context");
                return users as List<T>;
            }
            else
            {
                Console.WriteLine("somethings unusual");
                throw new Exception(" somethings bad");
            }
        }
    }
}
