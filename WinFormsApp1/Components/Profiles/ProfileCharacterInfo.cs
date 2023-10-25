namespace SPTLauncher.Components.Profiles
{
    public struct ProfileCharacterInfo
    {
        public string Nickname { get; set; }
        public string LowerNickname { get; set; }
        public string Side { get; set; }
        public string Voice { get; set; }
        public int Level { get; set; }
        public int Experience { get; set; }
        public long RegistrationDate { get; set; }
        public string GameVersion { get; set; }
        public int AccountType { get; set; }
        public int MemberCategory { get; set; }
        public bool lockedMoveCommands { get; set; }
        public double SavageLockTime { get; set; }
        public long LastTimePlayedAsSavage { get; set; }
        public Dictionary<string, object> Settings { get; set; }
        public long NicknameChangeDate { get; set; }
        public List<object> NeedWipeOptions { get; set; }
        public object lastCompletedWipe { get; set; }
        public object lastCompletedEvent { get; set; }
        public bool BannedState { get; set; }
        public long BannedUntil { get; set; }
        public bool IsStreamerModeAvailable { get; set; }
        public bool SquadInviteRestriction { get; set; }
    }
}
