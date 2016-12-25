using subway.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace subway.DAO
{
    class ForgetPassword
    {
        //查询验证信息
        string checkInfo;
        //邮件发送信息
        string sendInfo;
        bool flag;
        ConnectBD connectdb = new ConnectBD();
        BaseFunc baseF = new BaseFunc();

        #region 密码丢失
       
        /// <summary>
        /// 发送密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">新密码</param>
        /// <returns></returns>
        public string GetSendpasswrord(string username, string email, string type)
        {
            User member = new User();
            if (baseF.GetCheckUser(username, type))//检查是否已被注册
            {
                try
                {
                    SqlConnection conn = connectdb.ConnectDataBase();
                    //打开数据库
                    conn.Open();
                    //创建查询语句
                    SqlCommand querySingleInfo = conn.CreateCommand();
                    if (type == "admin")
                        querySingleInfo.CommandText = "SELECT Email FROM admin where UserName=" + "'" + username + "'";
                    else
                        querySingleInfo.CommandText = "SELECT Email FROM coustom where UserName=" + "'" + username + "'";
                    SqlDataReader singleInfoReader = querySingleInfo.ExecuteReader();
                    //有多行数据，用while循环
                    while (singleInfoReader.Read())
                    {
                        member.email = singleInfoReader["Email"].ToString().Trim();
                    }
                    if (member.email.Equals(email))
                    {
                        string pwd = "你的密码是: ";
                        //获取密码
                        pwd += Getpassrord(username, type);
                        pwd += " , 请妥善保存";
                        //发送邮件
                        checkInfo = SendEmail(email, pwd);
                    }
                    else
                    {
                        checkInfo = "邮箱错误";
                    }
                }
                catch (SqlException e)
                {
                    Console.WriteLine("查询错误");
                    checkInfo = "查询错误";
                }
            }
            else
                checkInfo = "用户名不存在";
            return checkInfo;
        }

        /// <summary>
        /// 获取用户密码
        /// </summary>
        /// <param name="username">用户名</param>
        /// <returns>返回查询结果</returns>
        private string Getpassrord(string username, string type)
        {
            string password = "";
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
                    password = singleInfoReader["Password"].ToString().Trim();
                }
                //关闭查询
                singleInfoReader.Close();
                //关闭数据库连接
                conn.Close();
            }
            catch (SqlException e)
            {
                password = "查询失败";
            }
            return password;
        }

        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="email">邮件</param>
        /// <param name="password">授权码</param>
        /// <returns></returns>
        private string SendEmail(string email, string message)
        {
            try
            {
                SmtpClient smtpClient = new SmtpClient();
                smtpClient.EnableSsl = true;
                smtpClient.UseDefaultCredentials = true;
                smtpClient.DeliveryMethod = SmtpDeliveryMethod.Network;//指定电子邮件发送方式        
                smtpClient.Host = "smtp.qq.com";//指定SMTP服务器        
                smtpClient.Credentials = new System.Net.NetworkCredential("1312373957@qq.com", "ccfknzwurpfjjhic");//用户名和授权码
                // 发送邮件设置        
                MailMessage mailMessage = new MailMessage("1312373957@qq.com", email); // 发送人和收件人        
                mailMessage.Subject = "密码找回";//主题        
                mailMessage.Body = message;
                mailMessage.BodyEncoding = Encoding.UTF8;//正文编码        
                mailMessage.IsBodyHtml = true;//设置为HTML格式        
                mailMessage.Priority = MailPriority.High;//优先级
                smtpClient.Send(mailMessage);
                sendInfo = "发送成功";
            }
            catch (Exception e)
            {
                sendInfo = "发送失败";
            }
            return sendInfo;
        }

        #endregion
    }
}
