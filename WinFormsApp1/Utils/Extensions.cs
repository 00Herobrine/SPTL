using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using System.Reflection;

namespace SPTLauncher.Utils
{
    public static class Extensions
    {
        public static string GetDescription(this Enum value)
        {
            // Get the Description attribute value for the enum value
            FieldInfo? fi = value.GetType().GetField(value.ToString());
            if (fi == null) return "NULL";
            DescriptionAttribute[] attributes = (DescriptionAttribute[])fi.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes.Length > 0)
                return attributes[0].Description;
            else
                return value.ToString();
        }

        public static string[] GetMinMax(this Enum value)
        {
            Debug.Write("\nChecking for enum " + value);
            FieldInfo? fi = value.GetType().GetField(value.ToString());
            if (fi == null) return null;
            RangeAttribute? rangeAttribute = (RangeAttribute?)fi.GetCustomAttribute(typeof(RangeAttribute), false);
            List<string> values = new List<string>
            {
                rangeAttribute?.Minimum.ToString() ?? "0",
                rangeAttribute?.Maximum.ToString() ?? "3"
            };
            return values.ToArray();
        }
        public static StringComparison GetComparison(bool ignoreCase = true) => ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal;
        public static bool Contains(this string Text, string value, bool ignoreCase = true) => Text.Contains(value, GetComparison(ignoreCase));
        public static bool StartsWith(this string Text, string value, bool ignoreCase = true) => Text.StartsWith(value, GetComparison(ignoreCase));
        public static bool EndsWith(this string Text, string value, bool ignoreCase = true) => Text.EndsWith(value, GetComparison(ignoreCase));
    }
}
