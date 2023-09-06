using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsApp1;

namespace SPTLauncher.Constructors
{
    public class AkiData
    {
        public string akiVersion = "";
        public string serverName = "";
        public string compatibleVersion = "";

        public AkiData()
        {
            JObject obj = JObject.Parse(Config.ReadCoreFile());
            akiVersion = obj["akiVersion"].ToString();
            serverName = obj["serverName"].ToString();
            compatibleVersion = obj["compatibleTarkovVersion"].ToString();
        }
        public AkiData(JObject obj)
        {
            akiVersion = obj["akiVersion"].ToString();
            serverName = obj["serverName"].ToString();
            compatibleVersion = obj["compatibleTarkovVersion"].ToString();
        }
    }
}
