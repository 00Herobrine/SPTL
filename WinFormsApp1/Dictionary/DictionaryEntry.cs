using Newtonsoft.Json.Linq;
using SPTLauncher.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTLauncher.Dictionary
{

    public class DictionaryEntry : Entry
    {
        public DictionaryEntry(JToken token) : base(token)
        {

        }
    }


    public abstract class Entry
    {
        private readonly string name, id, description;
        private readonly int height, width, discardLimit;
        private readonly float weight;
        private readonly bool marketable;

        public Entry(JToken token)
        {
            name = token["Name"].ToString();
            if (token["Item ID"] != null) id = token["Item ID"].ToString();
            if (token["Description"] != null) description = token["Description"].ToString();
            if (token["Cell Height"] != null) height = (int)token["Cell Height"];
            if (token["Cell Width"] != null) width = (int)token["Cell Width"];
            if (token["Discard Limit"] != null) discardLimit = (int)token["Discard Limit"];
            if (token["Item Weight"] != null) weight = (float)token["Item Weight"];
            if (token["Can be sold on flea market"] != null) marketable = (bool)token["Can be sold on flea market"];
        }

        override
        public string ToString()
        {
            return TarkovCache.GetReadableName(id);
        }

        public string GetName()
        {
            return name;
        }

        public string GetID()
        {
            return id;
        }

        public int GetHeight()
        {
            return height;
        }

        public int GetWidth()
        {
            return width;
        }

        public int GetDiscardLimit()
        {
            return discardLimit;
        }

        public string GetDescription()
        {
            return description;
        }

        public float GetWeight()
        {
            return weight;
        }

        public bool IsMarketable()
        {
            return marketable;
        }

    }
}
