using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using System.Windows.Forms.VisualStyles;

namespace SPTLauncher.Dictionary
{
    public class ArmorEntry : DictionaryEntry
    {
        private readonly string Type;
        private readonly float MaxDurability, EffectiveDurability, BluntThroughput;
        private readonly int MovementPenalty, TurnSpeedPenalty, ErgoPenalty, RepairCost, Class;
        private readonly List<string> materials = new List<string>(), ProtectionZones = new List<string>();
        public ArmorEntry(JToken token) : base(token)
        {
            Class = (int)token["Armor Class"];
            Type = token["Armor Type"].ToString();
            materials = token["Materials"].ToString().Split(",").ToList();
            foreach (string v in JArray.Parse(token["Protection Zones"].ToString())) ProtectionZones.Add(v);
            MaxDurability = (float)token["Max Durability"];
            EffectiveDurability = (float)token["Effective Durability"];
            MovementPenalty = (int)token["Movement Speed Penalty"];
            TurnSpeedPenalty = (int)token["Turn Speed Penalty"];
            ErgoPenalty = (int)token["Ergonomics Penalty"];
            BluntThroughput = (float)token["Blunt Throughput"];
            RepairCost = (int)token["Repair Cost"];
        }

        public string GetType()
        {
            return Type;
        }

        public float GetMaxDurability()
        {
            return MaxDurability;
        }

        public float GetEffectiveDurability()
        {
            return EffectiveDurability;
        }

        public float GetBluntThroughput()
        {
            return BluntThroughput;
        }

        public int GetMovementPenalty()
        {
            return MovementPenalty;
        }

        public int GetTurnSpeedPenalty()
        {
            return TurnSpeedPenalty;
        }

        public int GetErgoPenalty()
        {
            return ErgoPenalty;
        }

        public int GetRepairCost()
        {
            return RepairCost;
        }

        public int GetClass()
        {
            return Class;
        }

        public List<string> GetMaterials()
        {
            return materials;
        }

        public List<string> GetProtectionZones()
        {
            return ProtectionZones;
        }
    }
}
