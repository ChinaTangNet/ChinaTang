using NUnit.Framework;
using ChinaTang.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ChinaTang.Utils.Tests
{
    [TestFixture()]
    public class SerializeUtilsTests
    {
        [Serializable]
        public class Student
        {
            public string Name { get; set; }
            public int Age { get; set; }
            public string Sex { get; set; }
        }

        [Test()]
        public void SerializeToXmlTest()
        {
            SerializeUtils.SerializeToXml(new Student { Name = "折宝鹏", Sex = "男", Age = 27 }, @"E:\1\5\1.xml", new XmlWriterSettings { CheckCharacters = false });
            var reault = SerializeUtils.DeserializeFromXml<Student>(@"E:\1\4\1.xml", new XmlReaderSettings { CheckCharacters = false });
        }

        [Test()]
        public void DeserializeFromBinaryTest()
        {
           
        }

        [Test()]
        public void SerializeToBinaryTest()
        {
            string path = @"E:\1\5\1.dat";
            SerializeUtils.SerializeToBinary(new Student { Name = "王彦兰", Sex = "男", Age = 27 }, path);
            var result = SerializeUtils.DeserializeFromBinary<Student>(path);
        }
    }
}