using ChinaTang.Exceptions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
            if (!File.Exists(xmlfile))
                throw new FileNotFoundException(string.Format("你所要反序列化的文件：{0}不存在！",xmlfile));
            using (XmlReader reader = XmlReader.Create(xmlfile, settings))
            {
                XmlSerializer xs = new XmlSerializer(typeof(T));
                object obj= xs.Deserialize(reader);
                return obj == null ? default(T) : (T)obj;
            }
        }
    }
}