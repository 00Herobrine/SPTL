using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml;
using WinFormsApp1;

namespace SPTLauncher.Constructors
{
    public enum ModType { CLIENT, SERVER }
    public enum ORIGIN {
        [Description("github.com")]
        GITHUB,
        [Description("drive.google.com")]
        GOOGLE,
        [Description("dropbox.com")]
        DROPBOX,
        [Description("sp-tarkov.com")]
        SPT,
        INVALID
    }
    public class ModManager
    {
        public ModDownload curDownload;
        public static List<ModDownload> mods = new List<ModDownload>();

        public ModManager()
        {
            WebRequestMods();
        }

        public static async Task WebRequestMods(int page = 1)
        {
            string url = $"https://hub.sp-tarkov.com/files/?pageNo={page}&sortField=time&sortOrder=DESC";
            string className = "box128";
            HttpClient client = new HttpClient();
            // Send a GET request to the specified URL
            HttpResponseMessage response = await client.GetAsync(url);
            Debug.WriteLine($"Querying for {className} on {url}");
            // Read the response content as a string
            string html = await response.Content.ReadAsStringAsync();
            Debug.WriteLine($"Loading html\n{html}");
            File.WriteAllText(Form1.form.GetCachePath() + "/last.html", html);
            // Find all "a" elements with the specified class and href attributes using Regex
            Regex regex = new Regex($"<a[^>]*href=\"([^\"]*)\"[^>]*class=\"{className}\"[^>]*>");
            MatchCollection matches = regex.Matches(html);
            // Loop through each match and do something with it
            foreach (Match match in matches)
            {
                // Get the href attribute value
                string href = match.Groups[1].Value;
                // Do something with the link
                Debug.WriteLine(href);
                mods.Add(new ModDownload(url));
            }
        }
        public void DownloadMod(String url)
        {
            if (curDownload != null) 
                if (MessageBox.Show($"Downloading {curDownload.name}, are you sure you want to replace?", "Active Download!", MessageBoxButtons.YesNo) == DialogResult.No) return;
            curDownload = new ModDownload(url);
        }
    }

    public class ModDownload 
    {
        public ORIGIN Origin;
        public string URL, name;
        public ModDownload(string url)
        {
            URL = url;
            Origin = GetOrigin(url);
        }

        public static ORIGIN GetOrigin(string url)
        {
            ORIGIN origin = ORIGIN.INVALID;
            foreach (ORIGIN origins in Enum.GetValues(typeof(ORIGIN)))
                if (url.Contains(Recipe.GetEnumDescription(origins).ToLower())) origin = origins;
            return origin;
        }
    }
}
