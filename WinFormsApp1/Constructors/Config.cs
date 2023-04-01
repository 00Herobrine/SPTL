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
        private JObject jObject;
        public Config(string path) {
            this.path = path;
            string text = File.ReadAllText(path);
            jObject = JObject.Parse(text);
            setApiKey(jObject["apiKey"].ToString());
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
