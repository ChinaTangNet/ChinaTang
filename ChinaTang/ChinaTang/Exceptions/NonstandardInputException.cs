using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChinaTang.Exceptions
{
    /// <summary>
    /// 不标准的输入
    /// </summary>
    public class NonStandardInputException:ApplicationException
    {
        /// <summary>
        /// 不标准的输入
        /// </summary>
        /// <param name="message">异常信息</param>
        public NonStandardInputException(string message)
            : base(message){
        }
    }
}
