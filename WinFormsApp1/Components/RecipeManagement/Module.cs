using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace SPTLauncher.Components.RecipeManagement
{
    public enum Module
    {
        [Description("Vents"), Range(1, 3)]
        VENTS = 0,
        [Description("Security"), Range(1, 3)]
        SECURITY = 1,
        [Description("Lavoratory"), Range(1, 3)]
        LAVORATORY = 2,
        [Description("Stash"), Range(1, 4)]
        STASH = 3,
        [Description("Generator"), Range(1, 3)]
        GENERATOR = 4,
        [Description("Heating"), Range(1, 3)]
        HEATING = 5,
        [Description("Water Collector"), Range(1, 3)]
        WATER = 6,
        [Description("Medstation"), Range(1, 3)]
        MEDICAL = 7,
        [Description("Nutrition Unit"), Range(1, 3)]
        NUTRITION = 8,
        [Description("Rest Space"), Range(1, 3)]
        RESTSPACE = 9,
        [Description("Workbench"), Range(1, 3)]
        WORKBENCH = 10,
        [Description("Intelligence Center"), Range(1, 3)]
        INTELLIGENCE = 11,
        [Description("Shooting Range"), Range(1, 3)]
        SHOOTINGRANGE = 12,
        [Description("Library"), Range(1, 1)]
        LIBRARY = 13,
        [Description("Scav Case"), Range(1, 1)]
        SCAVBOX = 14,
        [Description("Illumination"), Range(1, 3)]
        LIGHTING = 15,
        /*        [Description("Place of Fame"), Range(1, 1)]
                FAME = 16,*/
        [Description("Air Filtering Unit"), Range(1, 1)]
        AIRFILTER = 17,
        [Description("Solar Power"), Range(1, 1)]
        SOLAR = 18,
        [Description("Booze Generator"), Range(1, 1)]
        BOOZEGENERATOR = 19,
        [Description("Bitcoin Farm"), Range(1, 3)]
        BTC = 20,
        [Description("Christmas Tree"), Range(1, 1)]
        CHRISTMAS = 21,
        [Description("Broken Wall"), Range(1, 6)]
        BROKENWALL = 22,
        [Description("Gym"), Range(1, 2)]
        GYM = 23
    }
}
