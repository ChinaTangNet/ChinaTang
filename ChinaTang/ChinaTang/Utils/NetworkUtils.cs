using ChinaTang.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        /// <summary>
        /// 测试服务地址是否能够访问
        /// </summary>
        /// <param name="address">要测试的地址</param>
        /// <param name="timeout">超时时间设置（ms）</param>
        /// <returns>服务返回的状态值</returns>
        public static HttpStatusCode IsAddressCanAccess(string address, int timeout)
        {
            if (string.IsNullOrEmpty(address))
                throw new NonStandardInputException("如果你想测试地址是否能够访问，请确保输入不为NULL或空！");
            if (timeout <= 0)
                throw new NonStandardInputException("服务超时时间必须为正整数！");

            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(address);
            req.Timeout = timeout;
            using (var resp = (HttpWebResponse)req.GetResponse())
            {
                return resp.StatusCode;
            }
        }
    }
}
