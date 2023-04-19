using HtmlAgilityPack;
using System.ComponentModel;
using System.Diagnostics;
using System.Net.Http;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Intrinsics;
using System.Text.RegularExpressions;
using WinFormsApp1;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

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
            //Debug.WriteLine($"Loading html\n{html}");
            File.WriteAllText(Form1.form.GetCachePath() + "/last.html", html);
            // Find all "a" elements with the specified class and href attributes using Regex
            //Regex regex = new Regex($"<a[^>]*href=\"([^\"]*)\"[^>]*class=\"{className}\"[^>]*>");
            //MatchCollection matches = regex.Matches(html);
            // Get all elements with class 'filebaseFileCard new'
            HtmlDocument doc = new HtmlDocument();
            doc.LoadHtml(html);
            HtmlNodeCollection elements = doc.DocumentNode.SelectNodes("//div[@class='filebaseFileCard new']");

            // Loop through the elements and print their inner text
            int line = 0;
            foreach (HtmlNode element in elements)
            {
                mods.Add(new ModDownload(element));
                /*HtmlNode h3 = element.SelectSingleNode(".//h3[@class='filebaseFileSubject']");
                Debug.WriteLine($"h3 {h3.InnerText}");
                line++;*/
            }
        }

        public List<ModDownload> GetModDownloads()
        {
            return mods;
        }
        public void DownloadMod(ModDownload mod)
        {
            if (curDownload != null) 
                if (MessageBox.Show($"Downloading {curDownload.name}, are you sure you want to replace?", "Active Download!", MessageBoxButtons.YesNo) == DialogResult.No) return;
            curDownload = mod;
        }
    }

    public class ModDownload 
    {
        public ORIGIN Origin;
        public string URL, name, author, description, imageURL, AkiVersion, lastUpdated;
        public int downloads, comments, reviews, ratings;
        public float stars;
        public ModDownload(HtmlNode element)
        {
            name = element.SelectSingleNode(".//h3[@class='filebaseFileSubject']").InnerText.Trim();
            description = element.SelectSingleNode(".//div[@class='containerContent filebaseFileTeaser']").InnerText.Trim();
            URL = element.SelectSingleNode(".//a[@class='box128']").Attributes["href"].Value;
            HtmlNode spanNode = element.SelectSingleNode(".//span[@class='filebaseFileIcon']");
            HtmlNode imageNode = element.SelectSingleNode(".//img");
            imageURL = imageNode != null ? imageNode.GetAttributeValue("src", "") : "";
            HtmlNode ratingNode = element.SelectSingleNode(".//li[@class='jsTooltip filebaseFileRating']");
            HtmlNode att = element.SelectSingleNode(".//ul[@class='inlineList dotSeparated filebaseFileMetaData']");
            author = att.SelectSingleNode(".//li").InnerText;
            AkiVersion = element.SelectSingleNode(".//span [starts-with(@class, 'badge label')]").InnerText;
            string s = "0";
            string r = "0";
            if (ratingNode != null)
            {
                string[] v = ratingNode.Attributes["title"].Value.Split("; ");
                s = v[0];
                r = v[1];
            }
            lastUpdated = att.SelectSingleNode(".//time [@class='datetime']").InnerText;
            Debug.WriteLine($"N:{name} A:{author} V:{AkiVersion} UP:{lastUpdated} S:{s} R:{r} IU:{imageURL} U:{URL} Description:\n{description}");
            Origin = GetOrigin(URL);
            Form1.form.AddMod(this);
        }

        override
        public string ToString()
        {
            return name;
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
