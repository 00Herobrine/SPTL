using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace SPTLauncher.Constructors
{
    public class Trader
    {
        public int refreshTime = 3600;
        public string basePath;
        public string? assortPath, dialoguePath, questassortPath, suitsPath, bearsuitsPath, usecsuitsPath;
        public string id, name, surname, nickname, currency, avatarPath;
        public bool insurance, customizationSeller, medic, repair, unlocked;
        public int minReturnHour, maxReturnHour, maxStorageTime;
        public float repairQuality;
        public string repairCurrency;
        public int repairCurrencyCoef;
        public int gridHeight;
        public long nextResupply;
        public List<LoyaltyLevel> loyaltyLevels = new();
        public List<string> insuranceExlcusions = new(), bannedItems = new(), bannedCategories = new(), purchasableCategories = new(),
            sellCategories = new(), excludedRepairCategories = new(), excludedRepairIDs = new();

        public Trader(string path)
        {
            basePath = $"{path}/base.json";
            assortPath = File.Exists($"{path}/assort.json") ? $"{path}/assort.json" : null;
            dialoguePath = File.Exists($"{path}/dialogue.json") ? $"{path}/dialogue.json" : null;
            questassortPath = File.Exists($"{path}/questassort.json") ? $"{path}/questassort.json" : null;
            suitsPath = File.Exists($"{path}/suits.json") ? $"{path}/suits.json" : null;
            bearsuitsPath = File.Exists($"{path}/bearsuits.json") ? $"{path}/bearsuits.json" : null;
            usecsuitsPath = File.Exists($"{path}/usecsuits.json") ? $"{path}/usecsuits.json" : null;
            JObject jobject = JObject.Parse(File.ReadAllText(basePath));
            id = jobject["_id"].ToString();
            avatarPath = jobject["avatar"].ToString();
            name = jobject["name"].ToString();
            surname = jobject["surname"].ToString();
            nickname = jobject["nickname"].ToString();
            currency = jobject["currency"].ToString();
            gridHeight = (int)jobject["gridHeight"];
            nextResupply = (long)jobject["nextResupply"];
            int level = 1;
            foreach (JObject subobject in jobject["loyaltyLevels"].ToArray().Cast<JObject>())
                loyaltyLevels.Add(new LoyaltyLevel(level++, subobject));
            repairCurrency = jobject["repair"].Contains("currency") ? jobject["repair"]["currency"].ToString() : "";
            repairCurrencyCoef = (int)jobject["repair"]["currency_coefficient"];
            medic = (bool)jobject["medic"];
            unlocked = (bool)jobject["unlockedByDefault"];
            repair = (bool)jobject["repair"]["availability"];
            insurance = (bool)jobject["insurance"]["availability"];
            customizationSeller = (bool)jobject["customization_seller"];
            minReturnHour = (int)jobject["insurance"]["min_return_hour"];
            maxReturnHour = (int)jobject["insurance"]["max_return_hour"];
            maxStorageTime = (int)jobject["insurance"]["max_storage_time"];
            sellCategories = JArray.Parse(jobject["sell_category"].ToString()).ToObject<List<string>>();
            //purchasableCategories = JArray.Parse(jobject["items_buy"]["category"].ToString()).ToObject<List<string>>();
            insuranceExlcusions = JArray.Parse(jobject["insurance"]["excluded_category"].ToString()).ToObject<List<string>>();
            excludedRepairCategories = JArray.Parse(jobject["repair"]["excluded_category"].ToString()).ToObject<List<string>>();
            Form1.form.log($"Cached {nickname} with {loyaltyLevels.Count} LLs CUR:{currency} bs:{bearsuitsPath != null} us:{usecsuitsPath != null} suits:{suitsPath != null} ex:{insuranceExlcusions.Count}");
        }

        public bool HasInsurance()
        {
            return insurance;
        }
        public void SetInsurance(bool insurance)
        {
            this.insurance = insurance;
        }

        public void SetRefreshTime(int refreshTime)
        {
            this.refreshTime = refreshTime;
        }

        override
        public string ToString()
        {
            return nickname;
        }
    }
}
