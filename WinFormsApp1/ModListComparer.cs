using SPTLauncher.Constructors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTLauncher
{
    public class ModListComparer : IComparer<Mod>
    {
        public int Compare(Mod x, Mod y)
        {
            // First, sort alphabetically
            int result = string.Compare(x.GetName(), y.GetName());

            if (result != 0)
                return result;

            // If the display text is the same, prioritize [C] items over [P] items
            if (x.IsPlugin() && !y.IsPlugin())
                return -1;
            if (!x.IsPlugin() && y.IsPlugin())
                return 1;

            return 0;
        }
    }
}
