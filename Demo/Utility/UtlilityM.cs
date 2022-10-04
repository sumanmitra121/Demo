using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Utility
{
        internal static class UtilityM
        {
            internal static T CheckNull<T>(object obj)
            {
                return (obj == DBNull.Value ? default(T) : (T)obj);
            }
        }
}
