using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTLauncher.Constructors.Enums
{
    internal enum Currency
    {
        [Description("Ruble")]
        RUB,
        [Description("Euro")]
        EUR,
        [Description("Dollar")]
        USD
    }
}
