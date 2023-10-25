namespace SPTLauncher.Components.Profiles
{
    public struct InventoryItem
    {
        public string _id { get; set; } // instance ID
        public string _tpl { get; set; } // Tarkov Item ID
        public string? parentId { get; set; }
        public string? slotId { get; set; }
        public Dictionary<string, object>? upd { get; set; } // additional info medKitHP, ammoCount, etc
        public Location? location { get; set; }
        public readonly bool IsBaseItem => parentId != null || slotId != null || upd != null || location != null;
    }

    public struct Location
    {
        public bool isSearched { get; set; }
        public int r { get; set; }
        public int x { get; set; }
        public int y { get; set; }
    }
}
