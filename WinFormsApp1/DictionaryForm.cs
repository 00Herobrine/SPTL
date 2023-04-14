using Newtonsoft.Json.Linq;
using SPTLauncher.Constructors;
using SPTLauncher.Dictionary;
using System.Runtime.InteropServices;
using WinFormsApp1;

namespace SPTLauncher
{

    public partial class DictionaryForm : Form
    {
        private Dictionary<CacheTab, List<Entry>> entries = new Dictionary<CacheTab, List<Entry>>();
        public DictionaryForm()
        {
            InitializeComponent();
        }

        private void DictionaryForm_Load(object sender, EventArgs e)
        {
            LoadStuff();
        }

        public void LoadStuff()
        {
            foreach (CacheType type in TarkovCache.tabs.Keys)
            {
                string cachePath = Form1.form.GetCachePath() + "/" + type.ToString().ToLower() + ".json";
                JArray cache = JArray.Parse(File.ReadAllText(cachePath));
                foreach (JToken entry in cache)
                {
                    CacheTab tab = GetCacheTab(type);
                    Entry dictionaryEntry;
                    switch (tab)
                    {
                        case CacheTab.ARMOR:
                            dictionaryEntry = new ArmorEntry(entry);
                            break;
                        default:
                            dictionaryEntry = new DictionaryEntry(entry);
                            break;
                    }
                    addEntry(tab, dictionaryEntry);
                    string str1 = dictionaryTabs.SelectedTab.Text.ToLower();
                    string str2 = tab.ToString().ToLower();
                    //Debug.Write($"Comparing {str1} to {str2}\n");
                    if (str1.Equals(str2))
                    {
                        int index = ArmorList.Items.Add(dictionaryEntry);
                    }
                }
            }
        }

        public Entry GetSelectedEntry()
        {
            return (Entry)ArmorList.SelectedItem;
        }

        public void addEntry(CacheTab tab, Entry entry)
        {
            if (!entries.ContainsKey(tab))
            {
                List<Entry> list = new List<Entry>();
                //list.Add(entry);
                entries.Add(tab, list);
                //entries.Add(tab, list);
            }
            entries[tab].Add(entry);
        }

        public CacheTab GetCacheTab(CacheType cacheType)
        {
            return TarkovCache.tabs[cacheType];
        }

        public List<Entry> GetEntries(CacheType type)
        {
            return entries[GetCacheTab(type)];
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Entry entry = GetSelectedEntry();
            if (entry is ArmorEntry)
            {
                ArmorEntry aentry = (ArmorEntry)entry;
                Materials.Text = "Materials: " + aentry.GetMaterials().First();
                Class.Text = "Class: " + aentry.GetClass();
                BluntThroughput.Text = "Blunt Throughput: " + aentry.GetBluntThroughput();
                RepairCost.Text = "Repair Cost: " + aentry.GetRepairCost();
                Durability.Text = "Durability: " + aentry.GetMaxDurability();
                EffectiveDurability.Text = "Effective Durability: " + aentry.GetEffectiveDurability();
                ProtectionZones.Text = "Protection Zones:";
                foreach (string zone in aentry.GetProtectionZones()) ProtectionZones.Text += "\n" + zone;
                int ergopen = aentry.GetErgoPenalty();
                int movepen = aentry.GetMovementPenalty();
                int turnpen = aentry.GetTurnSpeedPenalty();
                Penalties.Text = $"Penalties: \nErgo {ergopen}\nMove {movepen}\nTurn {turnpen}";

            }
            if (entry != null)
            {
                NameLabel.Text = "Name: " + entry.GetName();
                ItemID.Text = "Item ID: " + entry.GetID();
                CellHeight.Text = "Cell Height: " + entry.GetHeight();
                CellWidth.Text = "Cell Width: " + entry.GetWidth();
                Weight.Text = "Item Weight: " + entry.GetWeight();
                DropLimit.Text = "Discard Limit: " + ((entry.GetDiscardLimit() == -1) ? "ULIMITED" : entry.GetDiscardLimit());
                DescriptionBox.Text = entry.GetDescription();
                label7.Visible = entry.IsMarketable();
            }
        }
    }
}
