using ChinaTang.Enums;
using ChinaTang.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaTang.Utils
{
    /// <summary>
    /// 文件操作类
    /// </summary>
    public static class FileUtils
    {
        /// <summary>
        /// 将文件转换为为进制数组
        /// </summary>
        /// <param name="filepath">要转换的文件</param>
        /// <returns>转换成功则返回二进制数组，否则抛出异常</returns>
        public static byte[] FileToBytes(string filepath)
        {
            if (string.IsNullOrEmpty(filepath))
                throw new NonstandardInputException("文件路径不能为空或NULL");
            if (String.IsNullOrEmpty(filepath) || !File.Exists(filepath))
                throw new FileNotFoundException(string.Format("文件:{0}没有被找到",filepath));
            long bufferlength = new FileInfo(filepath).Length;
            byte[] result = new byte[bufferlength];
            using (FileStream fs = new FileStream(filepath, FileMode.Open, FileAccess.Read))
            {
                fs.Read(result, 0, (int)bufferlength);
            }
            return result;
        }
        /// <summary>
        /// 将二进制数组保存为本地文件
        /// </summary>
        /// <param name="content">要保存的二进制数组</param>
        /// <param name="filepath">要保存的文件路径</param>
        /// <param name="isoverwrite">是否覆盖原有文件,如果不覆盖则有可能抛出异常</param>
        /// <param name="iscreateparentpath">如果路径不存在，是否创建完整路径</param>
        /// <returns>保存失败抛出异常</returns>
        public static void BytesToFile(byte[] content, string filepath, bool isoverwrite=true, bool iscreateparentpath=true)
        {
            if(content==null)
                throw new NonstandardInputException("如果你想要将二进制数组保存为本地文件，那么请确保该二进制数组不为NULL");
            string filedir = Path.GetDirectoryName(filepath);
            if(iscreateparentpath && !Directory.Exists(filedir))
                Directory.CreateDirectory(filedir);
            using (FileStream fs = new FileStream(filepath, isoverwrite ? FileMode.Create : FileMode.CreateNew, FileAccess.Write))
            {
                fs.Write(content, 0, content.Length);
            }
        }
        /// <summary>
        /// 获取文件的MD5值，可能抛出异常
        /// </summary>
        /// <param name="filepath">文件路径</param>
        /// <param name="charcase">字符大小写，默认小写</param>
        /// <returns>获取大的MD5值</returns>
        public static string GetFileMd5Value(string filepath, CharCaseEnum charcase = CharCaseEnum.LOWER)
        {
            byte[] content = FileToBytes(filepath);
            if (content == null)
                return null;
            return EncryptUtils.GetBytesMd5Value(content, charcase);
        }
    }
}
