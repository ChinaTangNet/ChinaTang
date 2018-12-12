using NUnit.Framework;
using ChinaTang.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ChinaTang.Enums;

namespace ChinaTang.Utils.Tests
{
    [TestFixture()]
    public class FileUtilsTests
    {
        private const string src = @"G:\2.jpg";
        private const string aim = @"G:\temp\temp\2.jpg";
        [Test()]
        public void FileToBytesTest()
        {
            byte[] content = FileUtils.FileToBytes(src);
        }

        [Test()]
        public void BytesToFileTest()
        {
            byte[] content = FileUtils.FileToBytes(src);
            FileUtils.BytesToFile(content, aim);
        }

        [Test()]
        public void GetFileMd5ValueTest()
        {
           string result= FileUtils.GetFileMd5Value(src,CharCaseEnum.UPPER);
        }
    }
}