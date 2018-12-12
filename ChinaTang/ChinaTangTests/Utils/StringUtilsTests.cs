using NUnit.Framework;
using ChinaTang.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaTang.Utils.Tests
{
    [TestFixture()]
    public class StringUtilsTests
    {
        [Test()]
        public void GetMd5ValueTest()
        {
            string str = "www.chinatang.net";
            string md5 = str.GetMd5Value(Encoding.UTF8,Enums.CharCaseEnum.UPPER);
        }
    }
}