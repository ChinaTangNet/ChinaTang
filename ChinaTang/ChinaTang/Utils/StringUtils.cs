using ChinaTang.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
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
    }
}
