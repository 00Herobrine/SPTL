using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1.Constructors
{
    public class Skill
    {
        private JToken jToken;
        private string name;
        private string description;
        private string progress;

        public Skill(JToken jToken)
        {
            this.jToken = jToken;
            name = jToken["Id"].ToString();
            description = "Description:\nlorem ipsum";
            progress = jToken["Progress"].ToString();
        }
        public Skill(String id)
        {
            name = id;
            description = "Description:\nlorem ipsum";
            progress = "0";
        }

        public string getName()
        {
            return name;
        }
        public void setName(string name)
        {
            this.name = name;
        }

        public string getDescription() { 
            return description; 
        }
        public void setDescription(string description)
        {
            this.description = description;
        }

        public string getProgress() { 
            return progress; 
        }
        public void setProgress(string progress)
        {
            this.progress = progress;
        }

        public void save()
        {
            
        }
    }
}
