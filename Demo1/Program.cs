using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo1
{
    class Program
    {
        static void Main(string[] args)
        {

            var demo = new Demo();
            demo.CheckPassword();
        }

        class Demo
        {
            UserManager<IdentityUser> manager;
            string username= "lorenzo.brito@gmail.com";
            public Demo()
            {
                var userStore = new UserStore<IdentityUser>();
                 manager = new UserManager<IdentityUser>(userStore);

            }

            public void Create()
            {
             var created=   manager.Create(new IdentityUser(), "Test123");
                Console.WriteLine(" User created {0}",created.Succeeded);
                Console.ReadKey();
            }

            public void AddClaim()
            {
              var user=  manager.FindByName("lorenzo.brito@gmail.com");
                var claimresult = manager.AddClaim(user.Id, new System.Security.Claims.Claim("user_given", user.UserName));
                Console.WriteLine(" claem created {0}", claimresult.Succeeded);
                Console.ReadKey();
            }

            public void CheckPassword()
            {
                var user = manager.FindByName("lorenzo.brito@gmail.com");
                var claimresult = manager.CheckPassword(user, "Test123");
                    Console.WriteLine(" LOGIN OK! {0}", claimresult);
                Console.ReadKey();
            }

        }
    }
}
