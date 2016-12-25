using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subway.DAO
{
    class ConnectBD
    {
        /// <summary>
        /// 连接本地Sql Server数据库
        /// </summary>
        /// <returns></returns>
        public SqlConnection ConnectDataBase()
        {
            //连接字符串用SQL Server身份验证的账户登录，不能用windows身份验证的用户
           SqlConnection conn = new SqlConnection("Data Source=202.196.96.79;Initial Catalog=subway;User ID=XHG_C#;password=XHG_C#_123");
           return conn;
        }
    }
}
