using SPTLauncher.Constructors;
using SPTLauncher.Forms.Feedback;
using SPTLauncher.Forms.Reporting;
using System.Diagnostics;
using System.Text;
using WinFormsApp1;

namespace SPTLauncher.Components
{
    internal class Thing
    {
        private readonly static string feedbackURL = "https://discord.com/api/webhooks/1152722501646958642/lT-uOE9SO0c3OpaDbLyrTgHUtMyxOn5sP9z-WiF2vWTQ9BVI1BV0JrdLik9ZQQDOIecW";
        private readonly static string bugIcon = "https://i.imgur.com/jqiL5Zc.png";
        private readonly static string feedbackIcon = "https://i.imgur.com/ObLRXa0.png";

        public static async void SendFeedBack(string message, Severity severity, bool bugreport = false, string? name = null)
        {
            string ID = GenerateID(8);
            string subtext = $"ID: {ID}";
            if (name != null && name != "") {
                subtext += $" Tag: {name}";
            }
            var webhook = new DiscordWebhook
            {
                username = bugreport ? "Bug Report" : "Feedback",
                avatar_url = bugreport ? bugIcon : feedbackIcon,
                embeds = new List<Embeds>
                {
                    new Embeds
                    {
                        title = "Message:",
                        description = message,
                        author = new Author { name = severity.ToString(), url = bugreport ? bugIcon : feedbackIcon, icon_url = bugreport ? bugIcon : feedbackIcon },
                        color = GetDecimalColor(severity).ToString(),
                        footer = new Footer
                        {
                            text = subtext
                        },
                        timestamp = DateTime.Now,
                    },
                }
            };
            string json = Newtonsoft.Json.JsonConvert.SerializeObject(webhook);

            HttpClient client = new();
            StringContent content = new(json, Encoding.UTF8, "application/json");
            HttpResponseMessage response = await client.PostAsync(feedbackURL, content);

            if (response.IsSuccessStatusCode)
            {
                Form1.log("Message sent successfully!");
            }
            else
            {
                Form1.log("Message sending failed with status code: " + response.StatusCode);
            }
            string responseContent = await response.Content.ReadAsStringAsync();
            Debug.WriteLine("Sent: " + json);
            Debug.WriteLine("Response Content: " + responseContent);
        }

        public static int GetDecimalColor(Severity severity)
        {
            EnumColorAttribute[] attributes = (EnumColorAttribute[])typeof(Severity)
            .GetField(severity.ToString())
            .GetCustomAttributes(typeof(EnumColorAttribute), false);
            if (attributes.Length > 0) return attributes[0].decimalColor;
            else return 0;
        }

        private static readonly Random random = new Random();
        private const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
        public static string GenerateID(int length)
        {
            if (length <= 0)
            {
                throw new ArgumentException("Length must be greater than zero.");
            }

            StringBuilder idBuilder = new StringBuilder();

            for (int i = 0; i < length; i++)
            {
                idBuilder.Append(chars[random.Next(chars.Length)]);
            }

            return idBuilder.ToString();
        }

    }
}
