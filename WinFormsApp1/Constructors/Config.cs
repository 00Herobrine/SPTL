using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SPTLauncher.Constructors {
    public class Config
{
        private string path;
        private string apiKey;
        private long lastBackupTime;
        private JObject jObject;
        public Config(string path) {
            this.path = path;
            Load();
        }

        public void Load()
        {
            string text = File.ReadAllText(path);
            jObject = JObject.Parse(text);
            if (jObject == null) return;
            setApiKey(jObject["apiKey"].ToString());
            SetLastBackUpTime(long.Parse(jObject["LastBackup"].ToString()));
        }

        public void setApiKey(string apiKey)
        {
            jObject["apiKey"] = apiKey;
            this.apiKey = apiKey;
            save();
        }
        public string getApiKey()
        {
            return apiKey;
        }
        public void SetLastBackUpTime(long time)
        {
            jObject["LastBackup"] = time;
            lastBackupTime = time;
            save();
        }
        public long GetLastBackupTime()
        {
            return lastBackupTime;
        }

        public void save()
        {
            File.WriteAllText(path, jObject.ToString());
        }

        public JObject getJObject()
        {
            return jObject;
        }

}
}
