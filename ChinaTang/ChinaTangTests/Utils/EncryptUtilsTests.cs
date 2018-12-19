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
    public class EncryptUtilsTests
    {
        [Test()]
        public void DecryptFromBase64Test()
        {
            Assert.Fail();
        }

        [Test()]
        public void EncryptToBase64StrTest()
        {
            string base64str = EncryptUtils.EncryptToBase64Str("折宝鹏",Encoding.UTF8);
            string result = EncryptUtils.DecryptFromBase64(base64str, Encoding.UTF8);
        }
    }
}