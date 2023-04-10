using Newtonsoft.Json.Linq;
using SPTLauncher.Constructors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using WinFormsApp1;

namespace SPTLauncher
{

    public partial class DictionaryForm : Form
    {
        private Dictionary<CacheTab, List<DictionaryEntry>> entries = new Dictionary<CacheTab, List<DictionaryEntry>>();
        private Dictionary<int, DictionaryEntry> entryIndex = new Dictionary<int, DictionaryEntry>();
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
                    DictionaryEntry dictionaryEntry = new DictionaryEntry(entry);
                    addEntry(tab, dictionaryEntry);
                    string str1 = dictionaryTabs.SelectedTab.Text.ToLower();
                    string str2 = tab.ToString().ToLower();
                    //Debug.Write($"Comparing {str1} to {str2}\n");
                    if (str1.Equals(str2))
                    {
                        int index = listBox1.Items.Add(dictionaryEntry.GetName());
                        entryIndex.Add(index, dictionaryEntry);
                    }
                }
            }
        }

        public DictionaryEntry GetSelectedEntry()
        {
            return GetSelectedEntry(listBox1.SelectedIndex);
        }
        public DictionaryEntry GetSelectedEntry(int index)
        {
            if (index < 0) index = 0;
            return entryIndex[index];
        }

        public void addEntry(CacheTab tab, DictionaryEntry entry)
        {
            if (!entries.ContainsKey(tab))
            {
                List<DictionaryEntry> list = new List<DictionaryEntry>();
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

        public List<DictionaryEntry> GetEntries(CacheType type)
        {
            return entries[GetCacheTab(type)];
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            DictionaryEntry entry = GetSelectedEntry();
            if (entry != null)
            {
                NameLabel.Text = "Name: " + entry.GetName();
                ItemID.Text = "Item ID: " + entry.GetID();
                CellHeight.Text = "Cell Height: " + entry.GetHeight();
                CellWidth.Text = "Cell Width: " + entry.GetWidth();
                Weight.Text = "Item Weight: " + entry.GetWeight();
                DropLimit.Text = "Discard Limit: " + entry.GetDiscardLimit();
            }
        }
    }

    public class DictionaryEntry
    {
        private string name, id, description;
        private int height, width, discardLimit, dropLimit;
        private float weight;
        private bool marketable;

        public DictionaryEntry(JToken token)
        {
            name = token["Name"].ToString();
            if (token["Item ID"] != null) id = token["Item ID"].ToString();
            if (token["Description"] != null) description = token["Description"].ToString();
            if (token["Cell Height"] != null) height = (int)token["Cell Height"];
            if (token["Cell Width"] != null) width = (int)token["Cell Width"];
            if (token["Discard Limit"] != null) dropLimit = (int)token["Discard Limit"];
            if (token["Item Weight"] != null) weight = (float)token["Item Weight"];
            if (token["Can be sold on flea market"] != null) marketable = (bool)token["Can be sold on flea market"];
        }

        public void SetName(string name)
        {
            this.name = name;
        }
        public string GetName()
        {
            return name;
        }

        public void SetID(string id)
        {
            this.id = id;
        }
        public string GetID()
        {
            return id;
        }

        public void SetHeight(int height)
        {
            this.height = height;
        }
        public int GetHeight()
        {
            return height;
        }

        public void SetWidth(int width)
        {
            this.width = width;
        }
        public int GetWidth()
        {
            return width;
        }

        public void SetDiscardLimt(int limit)
        {
            discardLimit = limit;
        }
        public int GetDiscardLimit()
        {
            return discardLimit;
        }

        public void SetDescription(string description)
        {
            this.description = description;
        }
        public string GetDescription()
        {
            return description;
        }

        public float GetWeight()
        {
            return weight;
        }

    }
}
