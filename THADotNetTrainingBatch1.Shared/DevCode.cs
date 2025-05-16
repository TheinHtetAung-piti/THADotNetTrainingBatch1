using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace THADotNetTrainingBatch1.Shared
{
    public static class DevCode
    {
        public static bool IsNullOrEmptyV2(this string? str)
        {
            return str != null && !string.IsNullOrEmpty(str.Trim());
        }
    }
}
