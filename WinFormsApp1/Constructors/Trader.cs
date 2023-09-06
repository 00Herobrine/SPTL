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
        private bool insurance, customizationSeller;
        public int minReturnHour, maxReturnHour, maxStorageTime;
        private int gridHeight;
        private List<LoyaltyLevel> loyaltyLevels = new();
        private List<string> insuranceExlcusions = new(), bannedItems = new(), bannedCategories = new(), purchasableCategories = new();

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
            foreach (JObject subobject in jobject["loyaltyLevels"].ToArray().Cast<JObject>())
                loyaltyLevels.Add(new LoyaltyLevel(subobject));
            insurance = (bool)jobject["insurance"]["availability"];
            customizationSeller = (bool)jobject["customization_seller"];
            Form1.form.log($"Cached {nickname} with {loyaltyLevels.Count} LLs CUR:{currency} bs:{bearsuitsPath != null} us:{usecsuitsPath != null} suits: {suitsPath != null}");
        }

/*        public void LoadBase()
        {
            JObject jobject = JObject.Parse(File.ReadAllText(basePath));
            id = jobject["_id"].ToString();
            avatarPath = jobject["avatar"].ToString();
            name = jobject["name"].ToString();
            surname = jobject["surname"].ToString();
            nickname = jobject["nickname"].ToString();
            foreach (JObject subobject in jobject["loyaltyLevels"].ToArray().Cast<JObject>())
                loyaltyLevels.Add(new LoyaltyLevel(subobject));
            insurance = (bool)jobject["insurance"]["availability"];
            customizationSeller = (bool)jobject["customization_seller"];
        }*/

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
    }
}
