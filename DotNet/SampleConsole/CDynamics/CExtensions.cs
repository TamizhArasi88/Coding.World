using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CDynamics
{
    public static class CExtensions
    {
        //public bool HasFlag<TEnum>(this TEnum value, TEnum flag)  where TEnum : struct, Enum
        //{
        //    return (value & flag) == flag;
        //}

        public static bool MatchFlags<TEnum>(this TEnum value, TEnum flags) where TEnum : struct, IConvertible
        {
            var enumValue = flags.ToUInt64(CultureInfo.InvariantCulture);
            return (value.ToUInt64(CultureInfo.InvariantCulture) & enumValue) == enumValue;
        }
    }
}
