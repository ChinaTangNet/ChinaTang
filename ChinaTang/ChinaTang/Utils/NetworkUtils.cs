using ChinaTang.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace ChinaTang.Utils
{
    /// <summary>
    /// 网络工具类
    /// </summary>
    public static class NetworkUtils
    {
        /// <summary>
        /// Ping 测试
        /// </summary>
        /// <param name="address">要进行ping测试的地址</param>
        /// <returns>Ping结果数据封装</returns>
        public static PingReply PingAddress(string address)
        {
            if (string.IsNullOrEmpty(address))
                throw new NonStandardInputException("如果你想进行正常的PING测试，请确保输入不为NULL或空！");
            return new Ping().Send(address);
        }
    }
}
