using System.ComponentModel;
using System.Reflection;

namespace SPTLauncher.Constructors.Enums
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
    }
}
