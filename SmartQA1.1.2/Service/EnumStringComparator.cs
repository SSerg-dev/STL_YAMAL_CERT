using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartQA1._1._2.Service
{
    public class EnumStringComparator
    {
        public static bool Equals<TEnum>(List<string> stringList) where TEnum : Enum
        {
            var enumValues = Enum.GetNames(typeof(TEnum));
            var set1 = stringList.Except(enumValues);
            var set2 = enumValues.Except(stringList);
            return (!set1.Any() && !set2.Any());
        }
    }
}