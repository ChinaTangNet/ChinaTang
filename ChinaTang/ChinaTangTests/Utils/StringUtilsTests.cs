using ChinaTang.Utils;
using NUnit.Framework;
using System.Text;

namespace ChinaTang.Utils.Tests
{
    [TestFixture()]
    public class StringUtilsTests
    {
        [Test()]
        public void GetMd5ValueTest()
        {
            string str = "www.chinatang.net";
            string md5 = str.GetMd5Value(Encoding.UTF8, Enums.CharCaseEnum.UPPER);
        }

        [Test()]
        public void IsIpv4Test()
        {
            string ipv4 = "56.1.1.1";
            var result = ipv4.IsIpv4();
        }

        [Test()]
        public void IsIpv6Test()
        {
            string ipv6 = "AD80::ABAA:0000:00C2:0002";
            var result = ipv6.IsIpv6();
        }
    }
}