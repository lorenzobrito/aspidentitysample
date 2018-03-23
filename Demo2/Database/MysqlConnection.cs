using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo2.Database
{
  public  class MysqlConnection
    {
        public static MySql.Data.MySqlClient.MySqlConnection GetMySqlConnection(bool open = true,
     bool convertZeroDatetime = false, bool allowZeroDatetime = false)
        {
            string cs = "server=127.0.0.1;port=3306;database=aspidentitymysql;uid=root;pwd=root";
            var csb = new MySql.Data.MySqlClient.MySqlConnectionStringBuilder(cs)
            {
                AllowZeroDateTime = allowZeroDatetime,
                ConvertZeroDateTime = convertZeroDatetime
            };
            var conn = new MySql.Data.MySqlClient.MySqlConnection(csb.ConnectionString);
            if (open) conn.Open();
            return conn;
        }
    }
}
