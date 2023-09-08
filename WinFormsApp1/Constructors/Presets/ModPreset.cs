using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTLauncher.Constructors.Presets
{
    internal struct ModPreset
    {
        public List<string> enabledMods { get; set; }
        public List<string> disabledMods { get; set; }
        public List<string> modsURLs { get; set; }
    }
}
