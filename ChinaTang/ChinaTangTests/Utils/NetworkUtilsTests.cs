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
    public class NetworkUtilsTests
    {
         

        [Test()]
        public void IsAddressCanAccessTest()
        {
            var result=NetworkUtils.IsAddressCanAccess("https://www.nxks.nx.edu.cn/ws", 10000);
        }
    }
}