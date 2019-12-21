using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryApplication
{
    public class DBTest
    {
        public DBTest()
        {

        }

        public void Test()
        {
            using (var context = new AppDBContext())
            {
                Console.WriteLine("Adding New Users");

                var user = new User
                {
                    Name = "Joe Bloggs",
                    Rank = "WOFF",
                    Email = "JB@domain.com", 
                    UserId = 100,
                    Mobile = "0404112113"
                };

                context.Users.Add(user);

                user = new User
                {
                    Name = "Albert Einstein",
                    Rank = "Goat",
                    Email = "E=MC@Squared.com",
                    UserId = 929,
                    Mobile = "0419255699"
                };

                context.Users.Add(user);
                context.SaveChanges();

                Console.WriteLine("Retrieving Users...");

                var users = (from s in context.Users orderby s.Name select s).ToList<User>();

                foreach(var usr in users)
                {
                    Console.WriteLine("ID: {0}, Name: {1}", usr.UserId, usr.Name);
                }
                Console.ReadKey();
            }
        }
    }
}
