namespace SPTLauncher.Components.Caching.Nodes
{
    internal struct WeaponProp
    {
        public int Accuracy { get; set; }
        public int AnimationVariantsNumber { get; set; }
        public string BackgroundColor { get; set; }
        public bool BlocksCollapsible { get; set; }
        public bool BlocksFolding { get; set; }
        public bool CanAdmin { get; set; }
        public bool CanFast { get; set; }
        public bool CanHit { get; set; }
        public bool CanPutIntoDuringTheRaid { get; set; }
        public bool CanRequireOnRagfair { get; set; }
        public bool CanSellOnRagfair { get; set; }
        public List<object> CantRemoveFromSlotsDuringRaid { get; set; } // Adjust the type based on actual data
        public List<Cartridge> Cartridges { get; set; }
        public int CheckOverride { get; set; }
        public int CheckTimeModifier { get; set; }
        public List<object> ConflictingItems { get; set; } // Adjust the type based on actual data
        public string Description { get; set; }
        public int DiscardLimit { get; set; }
        public bool DiscardingBlock { get; set; }
        public double DoubleActionAccuracyPenaltyMult { get; set; }
        public string DropSoundType { get; set; }
        public int Durability { get; set; }
        public int EffectiveDistance { get; set; }
        public int Ergonomics { get; set; }
        public int ExamineExperience { get; set; }
        public int ExamineTime { get; set; }
        public bool ExaminedByDefault { get; set; }
        public int ExtraSizeDown { get; set; }
        public bool ExtraSizeForceAdd { get; set; }
        public int ExtraSizeLeft { get; set; }
        public int ExtraSizeRight { get; set; }
        public int ExtraSizeUp { get; set; }
        public List<object> Grids { get; set; } // Adjust the type based on actual data
        public bool HasShoulderContact { get; set; }
        public int Height { get; set; }
        public bool HideEntrails { get; set; }
        public bool InsuranceDisabled { get; set; }
        public bool IsAlwaysAvailableForInsurance { get; set; }
        public bool IsAnimated { get; set; }
        public bool IsLockedafterEquip { get; set; }
        public bool IsSpecialSlotOnly { get; set; }
        public bool IsUnbuyable { get; set; }
        public bool IsUndiscardable { get; set; }
        public bool IsUngivable { get; set; }
        public bool IsUnremovable { get; set; }
        public bool IsUnsaleable { get; set; }
        public string ItemSound { get; set; }
        public int LootExperience { get; set; }
        public int Loudness { get; set; }
        public double MalfunctionChance { get; set; }
        public bool MergesWithChildren { get; set; }
        public string Name { get; set; }
        public bool NotShownInSlot { get; set; }
        public Prefab Prefab { get; set; }
        public bool QuestItem { get; set; }
        public int QuestStashMaxCount { get; set; }
        public int RagFairCommissionModifier { get; set; }
        public bool RaidModdable { get; set; }
        public double Recoil { get; set; }
        public string ReloadMagType { get; set; }
        public int RepairCost { get; set; }
        public int RepairSpeed { get; set; }
        public string ShortName { get; set; }
        public int StackMaxSize { get; set; }
        public int StackObjectsCount { get; set; }
        public int TagColor { get; set; }
        public string TagName { get; set; }
        public bool ToolModdable { get; set; }
        public bool Unlootable { get; set; }
        public List<object> UnlootableFromSide { get; set; } // Adjust the type based on actual data
        public string UnlootableFromSlot { get; set; }
        public UsePrefab UsePrefab { get; set; }
        public double Velocity { get; set; }
        public string VisibleAmmoRangesString { get; set; }
        public double Weight { get; set; }
        public int Width { get; set; }
        public int magAnimationIndex { get; set; }
    }
    public struct Cartridge
    {
        public string _id { get; set; }
        public int _max_count { get; set; }
        public string _name { get; set; }
        public CartridgeProps _props { get; set; }
        public string _proto { get; set; }
    }

    public struct CartridgeProps
    {
        public List<FilterProp> filters { get; set; }
    }

    public struct FilterProp
    {
        public List<string> Filter { get; set; }
    }
}
