using Newtonsoft.Json.Linq;
using SPTLauncher.Components;
using System.Diagnostics;

namespace WinFormsApp1.Constructors
{
    public class Character
    {
        public Dictionary<string, Skill> skills = new();
        public string infoPath;
        public string characterFile;

        public Character(string ID)
        {
            infoPath = Paths.profilesFolder + "/" + ID + ".json";
            characterFile = File.ReadAllText(infoPath);
            Debug.WriteLine("Creating chracters thing");
            if (File.Exists(infoPath))
            {
                bool pathExists = getParsedJson().SelectTokens("characters.pmc.Skills.Common").Any();
                Debug.WriteLine("Path exists? " + pathExists);
                if (pathExists) {
                    JToken obj = getParsedJson()["characters"]["pmc"]["Skills"]["Common"];
                    if (obj == null) return;
                    foreach (JToken x in obj)
                    {
                        //var Id = x["Id"];
                        //Skill skill = new Skill(Id.ToString());
                        //var progress = x["Progress"];
                        //skill.setProgress(progress.ToString());
                        Skill skill = new Skill(x);
                        Debug.WriteLine("Parsing skill " + x["Id"]);
                        skills.Add(x["Id"].ToString(), skill);
                    }
                    //for(int i = 0; i < skills.)
                }
            }
            else Form1.form.log("path '" + infoPath + "' doesn't exist");
            //skills[Skills(ID)];

        }

        public Dictionary<string, Skill> getSkills()
        {
            return skills;
        }

        public Skill getSkillByID(string ID)
        {
            return skills[ID];
        }

        public void update(Skill skill)
        {
            string newFile = characterFile;
            JObject newStats = JObject.Parse(newFile);
            foreach(var x in newStats["characters"]["pmc"]["Skills"]["Common"])
            {
                if (x["Id"].ToString().Equals(skill.getName()))
                {
                    x["Progress"] = int.Parse(skill.getProgress());
                }
                File.WriteAllText(infoPath, newStats.ToString());
            }
            characterFile = newFile;
        }

        public JObject getParsedJson()
        {
            return getParsedJson(characterFile);
        }
        public JObject getParsedJson(string file)
        {
            return JObject.Parse(file);
        }
    }
}
