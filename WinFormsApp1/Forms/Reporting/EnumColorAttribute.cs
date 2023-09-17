

namespace SPTLauncher.Forms.Reporting
{
    [AttributeUsage(AttributeTargets.Field, Inherited = false, AllowMultiple = false)]
    sealed class EnumColorAttribute : Attribute
    {
        public int decimalColor { get; }
        public EnumColorAttribute(int decimalColor)
        {
            this.decimalColor = decimalColor;
        }
    }
}
