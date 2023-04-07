using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace SPTLauncher.Constructors {
    public class Config
{
        private string path;
        private string apiKey;
        //private long lastBackupTime;
        private DateTime lastBackupTime;
        private int backupInterval;
        private JObject jObject;
        private JArray jArray;
        public Config(string path) {
            this.path = path;
            Load();
        }

        public void Load()
        {
            string text = File.ReadAllText(path);
            jObject = JObject.Parse(text);
            if (jObject == null) return;
            if (jObject["DisabledMods"] != null)
            {
                // do shit
            } else
            {
                jObject["DisabledMods"] = new JObject();
            }
            setApiKey(jObject["apiKey"].ToString());
            string time = jObject["LastBackup"].ToString();
            if (time == "" || time == null) SetLastBackUpTime(DateTime.Now);
            else SetLastBackUpTime(DateTime.Parse(jObject["LastBackup"].ToString()));
            var interval = jObject["BackupInterval"];
            if (interval == null) SetBackupInterval(1440);
            else SetBackupInterval((int)interval);
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
        public void SetLastBackUpTime(DateTime time)
        {
            jObject["LastBackup"] = time;
            lastBackupTime = time;
            save();
        }
        public DateTime GetLastBackupTime()
        {
            return lastBackupTime;
        }

        public int GetBackupInterval()
        {
            return backupInterval;
        }
        public void SetBackupInterval(int interval)
        {
            jObject["BackupInterval"] = interval;
            backupInterval = interval;
            save();
        }

        public void save()
        {
            File.WriteAllText(path, jObject.ToString());
        }

        public JObject getJObject()
        {
            return jObject;
        }

        public void DisableMod(Mod mod)
        {
            string path;
            if (mod.isEnabled())
            {
                path = Form1.form.GetDisabledModsPath() + "/" + mod.GetName();
                jObject["DisabledMods"][mod.GetName()] = mod.GetOriginalPath();
            }
            else
            {
                path = mod.GetOriginalPath();
                ((JObject) jObject["DisabledMods"]).Remove(mod.GetName());
            }
            Debug.Write($"path {path}");
            Directory.Move(mod.GetPath(), path);
            save();
        }

        public void EnableMod(Mod mod)
        {
            string path = mod.GetOriginalPath() + "/" + mod.GetName();
            Directory.Move(mod.GetPath(), path);
            jArray[mod.GetName()] = null;
            jObject["DisabledMods"] = jArray;
            save();
        }

        public string GetDisabledModPath(string name)
        {
            return jObject["DisabledMods"][name].ToString();
        }

}
}
