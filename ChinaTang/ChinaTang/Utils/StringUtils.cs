using ChinaTang.Enums;
using ChinaTang.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ChinaTang.Utils
{
    /// <summary>
    /// 字符串扩展类
    /// </summary>
   public static class StringUtils
    {
        /// <summary>
        /// 获取字符串的MD5值
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="encode">编码格式</param>
        /// <param name="charcase">字符大小写</param>
        /// <returns>MD5值</returns>
        public static string GetMd5Value(this string str,Encoding encode,CharCaseEnum charcase = CharCaseEnum.LOWER)
        {
            byte[] content = encode.GetBytes(str);
            return EncryptUtils.GetBytesMd5Value(content,charcase);
        }
        /// <summary>
        /// 判断输入的字符串是否是合法的身份证号码
        /// </summary>
        /// <param name="str">要判断的字符串</param>
        /// <returns>是否是合法的身份证号码，是则返回true，否则返回false</returns>
        public static bool IsIdcardNum(this string str)
        {
            throw new NotImplementedException("该方法暂时没有被实现！");
        }
        /// <summary>
        /// 判断字符串是都是合法的IPV4地址
        /// </summary>
        /// <param name="str">要判断的字符串</param>
        /// <returns>是否是合法的IPV4地址</returns>
        public static bool IsIpv4(this string str)
        {
            return Regex.IsMatch(str, @"^(?=(\b|\D))(((\d{1,2})|(1\d{1,2})|(2[0-4]\d)|(25[0-5]))\.){3}((\d{1,2})|(1\d{1,2})|(2[0-4]\d)|(25[0-5]))(?=(\b|\D))$");
        }

        /// <summary>
        /// 判断字符串是都是合法的IPV6地址
        /// </summary>
        /// <param name="str">要判断的字符串</param>
        /// <returns>是否是合法的IPV6地址</returns>
        public static bool IsIpv6(this string str)
        {
            throw new NotImplementedException("该方法暂时没有被实现！");
        }
    }
}
