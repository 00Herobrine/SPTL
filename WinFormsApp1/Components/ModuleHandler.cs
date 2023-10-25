using SPTLauncher.Utils;

namespace SPTLauncher.Components
{
    internal class ModuleHandler
    {
        public static string GetModuleNameByID(int id) => GetModuleByID(id).GetDescription();
        public static Module GetModuleByID(int id) => (Module)Enum.ToObject(typeof(Module), id);
    }
}
