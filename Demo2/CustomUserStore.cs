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
    public class CustomUserStore : IUserPasswordStore<Users, int> 
    {
        UserDal userDal { get; set; }
        public CustomUserStore(UserDal userDal_)
        {
            this.userDal = userDal_;
        }
        public Task CreateAsync(Users user)
        {
            userDal.CreateUser(user.UserName, user.Password, user.Domicilio, user.PasswordHash);
        return    Task.CompletedTask;
        }

        public Task DeleteAsync(Users user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            userDal = null;
        }

        public Task<Users> FindByIdAsync(int userId)
        {
            var userresult = userDal.BuscarUserByID(userId);
            return Task.FromResult(userresult);
        }

        public Task<Users> FindByNameAsync(string userName)
        {
            var userresult = userDal.BuscarUserByName(userName);
            return Task.FromResult(userresult);
        }

        public Task<string> GetPasswordHashAsync(Users user)
        {
            return Task.FromResult(user.PasswordHash);
        }

        public Task<bool> HasPasswordAsync(Users user)
        {
            return Task.FromResult(string.IsNullOrEmpty(user.PasswordHash));
        }

        public Task SetPasswordHashAsync(Users user, string passwordHash)
        {
            user.PasswordHash = passwordHash;
            return Task.CompletedTask;
        }

        public Task UpdateAsync(Users user)
        {
            userDal.UpdateUser(user.UserName, user.Password, user.Domicilio, user.PasswordHash, user.idUsuario);
            return Task.CompletedTask;

        }
    }
}
