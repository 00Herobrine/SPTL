namespace SPTLauncher.Components.Profiles
{
    public class HealthStruct
    {
        public CurrentMaxStruct Hydration { get; set; }
        public CurrentMaxStruct Energy { get; set; }
        public CurrentMaxStruct Temperature { get; set; }
        public Dictionary<string, LimbStruct>? BodyParts { get; set; }
        public int UpdateTime { get; set; } // Time in millis / 1000
    }

    public struct LimbStruct
    {
        public CurrentMaxStruct Health { get; set; }
    }
    public struct CurrentMaxStruct
    {
        public float Current { get; set; }
        public float Maximum { get; set; }
    }
}
