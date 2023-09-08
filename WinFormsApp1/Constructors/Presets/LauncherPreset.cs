using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTLauncher.Constructors.Presets
{
    internal struct LauncherPreset
    {
        public string akiVersion { get; set; }
        public string presetCreator { get; set; }
        public string presetName { get; set; }
        public string presetDescription { get; set; }
        public int backupInterval { get; set; }
        public bool autoSave { get; set; }
        public bool profileCaching { get; set; }
        public bool autoMinimize { get; set; }
        public bool autoScroll { get; set; }
        public bool autoKill { get; set; }
        public bool autoStart { get; set; }
        public ModPreset modPreset { get; set; }
        public ProfilePreset profilePreset { get; set; }
        public List<TraderPreset> traderPresets { get; set; }
    }
}
