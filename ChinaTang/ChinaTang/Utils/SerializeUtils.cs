using ChinaTang.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace ChinaTang.Utils
{
    /// <summary>
    /// 序列化工具类
    /// </summary>
    public static class SerializeUtils
    {
        /// <summary>
        /// 序列化到XML文件俺
        /// </summary>
        /// <param name="obj">要序列化的对象</param>
        /// <param name="xmlfile">要序列化到的文件</param>
        /// <param name="settings">相关设置</param>
        /// <param name="iscreateparentpath">目录不存在时是否创建</param>
        public static void SerializeToXml(object obj, string xmlfile, XmlWriterSettings settings, bool iscreateparentpath = true)
        {
            if (obj == null)
                throw new NonStandardInputException("如果你想正常进行序列化操作，请确保传入的参数不为空！");
            //创建目录
            if (!Directory.Exists(xmlfile) && iscreateparentpath)
                Directory.CreateDirectory(Path.GetDirectoryName(xmlfile));
            using (XmlWriter writer = XmlWriter.Create(xmlfile, settings))
            {
                XmlSerializer xser = new XmlSerializer(obj.GetType());
                xser.Serialize(writer, obj);
            }
        }
        /// <summary>
        /// 从指定文件反序列化得到对象
        /// </summary>
        /// <typeparam name="T">要反序列化的类型</typeparam>
        /// <param name="xmlfile">要反序列化的XML文件</param>
        /// <param name="settings">相关设置</param>
        /// <returns>得到的对象</returns>
        public static T DeserializeFromXml<T>(string xmlfile, XmlReaderSettings settings)
        {
            if (string.IsNullOrEmpty(xmlfile))
                throw new NonStandardInputException("要反序列化的XML文件路径不能为NULL或空！");
            using (XmlReader reader = XmlReader.Create(xmlfile, settings))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                object obj = xs.Deserialize(reader);
                return obj == null ? default(T) : (T)obj;
            }
        }

        /// <summary>
        /// 将对象序列化为二进制文件
        /// </summary>
        /// <param name="obj">要序列化的对象</param>
        /// <param name="binaryfile">要序列化到的文件</param>
        /// <param name="iscreateparentpath">在文件的目录结构不存时，是否创建</param>
        public static void SerializeToBinary(object obj, string binaryfile, bool iscreateparentpath = true)
        {
            if(obj == null)
                throw new NonStandardInputException("如果你想正常进行序列化操作，请确保传入的参数不为空！");
            //创建目录
            if (!Directory.Exists(binaryfile) && iscreateparentpath)
                Directory.CreateDirectory(Path.GetDirectoryName(binaryfile));
            BinaryFormatter binformat = new BinaryFormatter();
            using (Stream fsstream = new FileStream(binaryfile,FileMode.Create,FileAccess.Write, FileShare.None))
            {
                binformat.Serialize(fsstream, obj);
            }
        }
        /// <summary>
        /// 将二进制文件反序列化为指定的实例
        /// </summary>
        /// <typeparam name="T">反序列化后实例的类型</typeparam>
        /// <param name="binaryfile">要反序列化的二进制文件路径</param>
        /// <returns>反序列化得到的实例</returns>
        public static T DeserializeFromBinary<T>(string binaryfile)
        {
            if (string.IsNullOrEmpty(binaryfile))
                throw new NonStandardInputException("要反序列化的二进制文件路径不能为NULL或空！");
            BinaryFormatter binformat = new BinaryFormatter();
            using (Stream fsstream = new FileStream(binaryfile, FileMode.Open, FileAccess.Read, FileShare.None))
            {
                object obj=binformat.Deserialize(fsstream);
                return obj == null ? default(T) : (T)obj;
            }
        }
    }
}