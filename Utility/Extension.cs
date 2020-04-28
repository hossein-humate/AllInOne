using System;
using System.Collections.Generic;

namespace Utility
{
    public static class Extension
    {
        public static string GetName<TEnum>(this TEnum item)
        {
            return Enum.GetName(typeof(TEnum), item);
        }

        public static TEnum GetValue<TEnum>(this object item)
        {
            return (TEnum)Enum.Parse(typeof(TEnum), item.ToString());
        }

        public static int GetEnumIndex<TEnum>(this TEnum item)
        {
            return (int)Enum.Parse(typeof(TEnum), item.GetName());
        }

        public static int ToInt(this object input)
        {
            return int.Parse(input.ToString());
        }

        public static Guid ToGuid(this object input)
        {
            try
            {
                return Guid.Parse(input.ToString());
            }
            catch
            {
                return Guid.Empty;
            }
        }

        public static string ThousandSeparator(this object input)
        {
            var number = input.ToString();
            var result = "";
            var mod = number.Length % 3;
            if (mod != 0)
            {
                for (var i = 0; i < mod; i++)
                {
                    result += number[i];
                }
                result += ',';
            }
            for (var i = 0; i < (number.Length - mod) / 3; i++)
            {

                result += number.Substring((i * 3) + mod, 3) + ',';
            }
            result = result[..^1];
            return result;
        }

        public static T Find<T>(this ICollection<T> enumerable, Func<T, bool> predicate)
        {
            foreach (var current in enumerable)
            {
                if (predicate(current))
                {
                    return current;
                }
            }

            return default;
        }
    }
}