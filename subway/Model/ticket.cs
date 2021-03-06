﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace subway.Model
{
    class Ticket
    {
        /// <summary>
        /// 用户名
        /// </summary>
        public string username { set; get; }
        /// <summary>
        /// 出发地
        /// </summary>
        public string startAddress { set; get; }
        /// <summary>
        /// 目的地
        /// </summary>`
        public string endAddress { set; get; }
        /// <summary>
        /// 用户余额
        /// </summary>
        public int money { set; get; }
        /// <summary>
        /// 购买时间
        /// </summary>`
        public string buyTime { set; get; }
        /// <summary>
        /// 购票数量
        /// </summary>
        public int ticketNum { set; get; }
        /// <summary>
        /// 用户手机号
        /// </summary>
        public int phone { set; get; }
        /// <summary>
        /// 用户邮箱
        /// </summary>
        public string email { set; get; }

    }
}
