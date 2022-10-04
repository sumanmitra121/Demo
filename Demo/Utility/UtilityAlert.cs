using Demo.Models;
using Newtonsoft.Json;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Utility
{
    internal static class UtilityAlert
    {
        internal static string setAlert<T>(ErrorViewModel obj)
        {
            return JsonConvert.SerializeObject(new ErrorViewModel() { class_name = obj.class_name, Message = obj.Message });

        }
    }
}
