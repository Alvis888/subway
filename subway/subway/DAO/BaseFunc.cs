using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using subway.Model;
using System.IO;

namespace subway.DAO
{
    class BaseFunc
    {
        ConnectBD connectdb = new ConnectBD();
        bool flag;
        #region 用户注册、验证、登陆、删除
        /// <summary>
        /// 检查用户是否已经注册/存在异常
        /// </summary>
        /// <param name="username">用户名（主键）</param>
        /// <returns>true  已注册</returns>
        /// <returns>false 未注册</returns>
        public bool GetCheckUser(string username, string type)
        {
            User member = new User();
            //连接本地数据库
            SqlConnection conn = connectdb.ConnectDataBase();
            //打开数据库
            conn.Open();
            //创建查询语句
            SqlCommand querySingleInfo = conn.CreateCommand();
            if (type == "admin")
                querySingleInfo.CommandText = "SELECT * FROM admin where UserName=" + "'" + username + "'";
            else
                querySingleInfo.CommandText = "SELECT * FROM coustom where UserName=" + "'" + username + "'";
            SqlDataReader singleInfoReader = querySingleInfo.ExecuteReader();
            //有多行数据，用while循环
            while (singleInfoReader.Read())
            {
                member.username = singleInfoReader["UserName"].ToString().Trim();
                if (member.username.Equals(username))
                {
                    flag = true;
                }
                else
                {
                    flag = false;
                }
            }
            //关闭查询
            singleInfoReader.Close();
            //关闭数据库连接
            conn.Close();
            return flag;
        }

        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>true/false</returns>
        public bool GetLoginCheck(string username, string password, string type)
        {
            User member = new User();
            if (GetCheckUser(username, type))//检查是否已被注册
            {
                try
                {
                    SqlConnection conn = connectdb.ConnectDataBase();
                    //打开数据库
                    conn.Open();
                    //创建查询语句
                    SqlCommand querySingleInfo = conn.CreateCommand();
                    if (type == "admin")
                        querySingleInfo.CommandText = "SELECT Password FROM admin where UserName=" + "'" + username + "'";
                    else
                        querySingleInfo.CommandText = "SELECT Password FROM coustom where UserName=" + "'" + username + "'";
                    SqlDataReader singleInfoReader = querySingleInfo.ExecuteReader();
                    //有多行数据，用while循环
                    while (singleInfoReader.Read())
                    {
                        member.password = singleInfoReader["Password"].ToString().Trim();
                    }
                    if (member.password.Equals(password))
                    {
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                    //关闭查询
                    singleInfoReader.Close();
                    //关闭数据库连接
                    conn.Close();
                }
                catch { flag = false; }
            }
            else
                flag = false;
            return flag;
        }

        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="member">注册人信息的对象</param>
        /// <returns>true/false</returns>
        public string Register(User member)
        {
            string returnInfo = "";
            //判断用户名是否为空
            if (member.username == null || member.username == "")
            {
                returnInfo = "Username is null. ";
            }
            if (GetCheckUser(member.username, member.type) == false)
            {
                member.sex = (member.sex == "male" ? "true" : "false");
                try
                {
                    SqlConnection conn = connectdb.ConnectDataBase();
                    string sql;
                    conn.Open();
                    if (member.type == "admin")
                        sql = "INSERT INTO admin(username,password,sex,phonenumber,email) VALUES ('" + member.username + "','" + member.username + "'+'_123','" + member.sex + "'," + member.phoneNumber + ",'" + member.email + "')";
                    else
                        sql = "INSERT INTO coustom(username,password,sex,,phonenumber,email) VALUES ('" + member.username + "','" + member.username + "'+'_123','" + member.sex + "'," + member.phoneNumber + ",'" + member.email + "')";

                    SqlCommand cmd = new SqlCommand(sql, conn);
                    int result = cmd.ExecuteNonQuery();
                    conn.Close();
                    returnInfo = "Success";
                }
                catch (SqlException e)
                {
                    returnInfo = "Error";
                    FileStream fs = new FileStream("c:\\text\\log2.txt", FileMode.Append, FileAccess.Write);
                    StreamWriter sw = new StreamWriter(fs); // 创建写入流
                    sw.WriteLine(e.ToString()); // 写入
                    sw.Close();
                }
            }
            else
                returnInfo = "Username is already existed. ";
            return returnInfo;
        }
        /// <summary>
        /// 删除成员
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns></returns>
        public bool GetDeleteUser(string username, string type)
        {
            bool flag;
            try
            {
                //连接本地数据库
                SqlConnection conn = connectdb.ConnectDataBase();
                //打开数据库
                conn.Open();
                //创建查询语句
                SqlCommand querySingleInfo = conn.CreateCommand();
                //删除Member表信息
                if (type == "admin")
                    querySingleInfo.CommandText = "delete admin  where UserName=" + "'" + username + "'";
                else
                    querySingleInfo.CommandText = "delete coustom  where UserName=" + "'" + username + "'";
                int memberResult = querySingleInfo.ExecuteNonQuery();
                //关闭数据库连接
                conn.Close();
                flag = true;
            }
            catch (SqlException e)
            {
                FileStream fs = new FileStream("c:\\text\\log2.txt", FileMode.Append, FileAccess.Write);
                StreamWriter sw = new StreamWriter(fs); // 创建写入流
                sw.WriteLine(e.ToString());
                sw.Close();
                flag = false;
            }
            return flag;
        } 
        #endregion

    }
}
