using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subway.Model
{
    class User
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { set; get; }
        /// <summary>
        /// 登陆密码
        /// </summary>
        public string password { set; get; }
        /// <summary>
        /// 用户类型
        /// </summary>
        public string type { set; get; }
        /// <summary>
        /// 手机号
        /// </summary>`
        public string phoneNumber { set; get; }
        /// <summary>
        /// 邮箱
        /// </summary>`
        public string email { set; get; }
        /// <summary>
        /// 用户性别
        /// </summary>
        public string sex { set; get; }
    }
}
