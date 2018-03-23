using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2.Models
{
    public class Users : IUser<int>
    {
        public int Id { get; set; }

        public string UserName { get; set; }

       public int  idUsuario {  get{ return Id; } set { Id = value; } }
       
        public string Password { get; set; }
        public string Domicilio { get; set; }
        public string PasswordHash { get; set; }
    }
}
