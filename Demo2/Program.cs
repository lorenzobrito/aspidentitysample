using Demo2.Database;
using Demo2.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2
{
    class Program
    {
        static void Main(string[] args)
        {

            //  var userdal = new UserDal();
            //  //     var result=userdal.CreateUser("demo1", "demo", "asdfa");
            //  var result = userdal.BuscarUserByID(1);
            //  userdal.UpdateUser(result.UserName, result.Password, "Merida", result.PasswordHash, result.idUsuario);
            //  result = userdal.BuscarUserByID(1);
            //  var userStore = new CustomUserStore(userdal);
            //var  manager = new UserManager<Users,int>(userStore);
            //var user=  manager.Create(new Users()
            //  {
            //      UserName="Freddy",
            //      Password="hacha",Domicilio="conocido"

            //  });
            Demo demo = new Demo();
            //demo.Create();
          //  demo.AddClaim();
            demo.CheckPassword();
            demo.ResetPassword();
            
            Console.ReadKey();

        }

        class Demo
        {
            UserManager<Users, int> manager;
           // string username = "lorenzo.brito@gmail.com";
            public Demo()
            {
                var userdal = new UserDal();
                var userStore = new CustomUserStore(userdal);
                manager = new UserManager<Users, int>(userStore);
             

            }

            public void Create()
            {
                var created = manager.Create(new Users() {
                    UserName="otro", Domicilio="Conocido"
                }, "pass123");
                Console.WriteLine(" User created {0}", created.Succeeded);
                Console.ReadKey();
            }

            public void AddClaim()
            {
                var user = manager.FindByName("Freddy");
                var claimresult = manager.AddClaim(user.Id, new System.Security.Claims.Claim("user_given", user.UserName));
                Console.WriteLine(" claem created {0}", claimresult.Succeeded);
                Console.ReadKey();
            }

            public void CheckPassword()
            {
                var user = manager.FindByName("Freddy");
                var claimresult = manager.CheckPassword(user, "newpass");
               
                Console.WriteLine(" LOGIN OK! {0}", claimresult);
                Console.ReadKey();
            }
            public void ResetPassword()
            {
                //habria que regenerar el password
                var user = manager.FindByName("Freddy");
                //var token = manager.GeneratePasswordResetToken(user.Id);
                var resetpassword = manager.RemovePassword(user.Id);
              //  manager.ResetPassword(user.Id, "", "newpass");
             var result=   manager.AddPassword(user.Id, "newpass");
              //  var claimresult = manager.res(user, "melapelan");
                //Console.WriteLine(" Reset OK! {0}", claimresult);
                Console.ReadKey();
            }

        }
    }
}
