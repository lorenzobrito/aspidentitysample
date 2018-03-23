using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using Demo2.Models;

namespace Demo2.Database
{
    public class UserDal
    {
        public ulong CreateUser(string username,string password,string domicilio,string passwordHash)
        {
            // INSERT INTO usuario (UserName, Password, Domicilio) VALUES('other', 'test', 'conocido');
            string sql = @"
 INSERT INTO usuario (UserName, Password, Domicilio,PasswordHash) VALUES(@UserName, @Password,@Domicilio,@PasswordHash);
SELECT CAST(LAST_INSERT_ID() AS UNSIGNED INTEGER);";
            //
            ulong id = 0;
            using (var connection = MysqlConnection.GetMySqlConnection(true, true, true))
            {
                var id_ = connection.Query<ulong>(sql, new {
                    UserName = username,
                    Password = password,
                    Domicilio = domicilio,
                    PasswordHash = passwordHash

                }).Single();
                 id=id_;
            }
            return id;
                //
        }
        public int UpdateUser(string username, string password, string domicilio, string passwordHash, int idusuario)
        {
            // INSERT INTO usuario (UserName, Password, Domicilio) VALUES('other', 'test', 'conocido');
            string sql = @"
UPDATE usuario SET UserName=@UserName, Password=@Password, Domicilio=@Domicilio, PasswordHash=@PasswordHash WHERE idUsuario=@idUsuario;
";
            //
            int id = 0;
            using (var connection = MysqlConnection.GetMySqlConnection(true, true, true))
            {
                var id_ = connection.Execute(sql, new
                {
                    UserName = username,
                    Password = password,
                    Domicilio = domicilio,
                    PasswordHash = passwordHash,
                    idUsuario = idusuario

                });
                id = id_;
            }
            return id;
            //
        }
        public Users BuscarUserByID(int id)
        {
            using (var conn = MysqlConnection.GetMySqlConnection(true, true, true))
            {
                const long ticks = 553440000000;
                const int Id = 426;


                var cliente = conn.Query<Users>("SELECT * FROM usuario where idUsuario = @idUsuario;", new { idUsuario = id }).Single();

                return cliente;
            }
        }
        public Users BuscarUserByName(string username)
        {
            try
            {
                using (var conn = MysqlConnection.GetMySqlConnection(true, true, true))
                {
                    const long ticks = 553440000000;
                    const int Id = 426;


                    var cliente = conn.Query<Users>("SELECT * FROM usuario where UserName = @UserName;", new { UserName = username }).Single();

                    return cliente;
                }
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
