using ChinaTang.Enums;
using ChinaTang.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ChinaTang.Utils
{
    public static class EncryptUtils
    {
        /// <summary>
        /// 获取二进制数组的MD5值
        /// </summary>
        /// <param name="content">要获取MD5值二进制数组</param>
        /// <param name="charcase">字符大小写，默认为小写</param>
        /// <returns>得到的MD5值</returns>
        public static string GetBytesMd5Value(byte[] content,CharCaseEnum charcase= CharCaseEnum.LOWER)
        {
            if (content == null)
                throw new NonStandardInputException("如果你想要获取二进制数组的MD5值，那么请确保该二进制数组不为NULL");

            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] md5data = md5.ComputeHash(content);
            md5.Clear();
            string str = "",formatstr= charcase== CharCaseEnum.LOWER?"x":"X";
            for (int i = 0; i < md5data.Length - 1; i++)
            {
                str += md5data[i].ToString(formatstr).PadLeft(2, '0');
            }
            return str;
        }

        /// <summary>
        /// 获取字符串的BASE64编码值
        /// </summary>
        /// <param name="str">要获取BASE64的字符串</param>
        /// <param name="encoding">字符编码类型</param>
        /// <returns>获取到的BASE64字符串</returns>
        public static string EncryptToBase64Str(string str,Encoding encoding)
        {
            if (string.IsNullOrEmpty(str))
                throw new NonStandardInputException("如果你想获取字符串的BASE64编码值，请确保输入的字符串不为NULL或空！");
            byte[] bytes = encoding.GetBytes(str);
            return Convert.ToBase64String(bytes);
        }

        /// <summary>
        /// 解码BASE64类型字符串
        /// </summary>
        /// <param name="str">要解码的BASE字符串</param>
        /// <param name="encoding">字符编码格式</param>
        /// <returns>解码得到的字符串</returns>
        public static string DecryptFromBase64(string str, Encoding encoding)
        {
            if (string.IsNullOrEmpty(str))
                throw new NonStandardInputException("如果你想解码BASE64类型的字符串，请确保输入的字符串不为NULL或空！");
            byte[] bytes=Convert.FromBase64String(str);
            return encoding.GetString(bytes);
        }
    }
}
