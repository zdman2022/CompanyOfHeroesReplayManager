using Microsoft.Win32;
using System.Configuration;
using System.Diagnostics;

namespace COH3ReplayManager
{
    internal static class ReplayHelper
    {
        public const string DefaultSteamPath = "C:\\Program Files (x86)\\Steam\\steam.exe";
        public static string DefaultCOH3PlaybackPath = myDocuments + @"\My Games\Company of Heroes 3\playback\";

        public static string steamPath
        {
            get
            {
                return string.IsNullOrWhiteSpace(Properties.Settings.Default.SteamPath) ? DefaultSteamPath : Properties.Settings.Default.SteamPath;
            }
        }

        public static string myDocuments
        {
            get
            {
                return Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            }
        }

        public static string coh3PlaybackPath
        {
            get
            {
                return string.IsNullOrWhiteSpace(Properties.Settings.Default.COH3PlaybackPath) ? DefaultCOH3PlaybackPath : Properties.Settings.Default.COH3PlaybackPath;
            }
        }

        //public static string coh3Path
        //{
        //    get
        //    {
        //        return GetValue("COH3Path", "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Company of Heroes 3\\RelicCoH3.exe");
        //    }
        //}

        public static string fileName
        {
            get
            {
                return "temp.rec";
            }
        }

        public static string fileNameCampaign
        {
            get
            {
                return "temp_campaign.rec";
            }
        }

        public static bool IsRunning
        {
            get
            {
                var processes = Process.GetProcessesByName("RelicCoH3");
                return processes?.Any() == true;
            }
        }

        public static string ReplayFile 
        { 
            get
            {
                return $"{coh3PlaybackPath}\\{fileName}";
            }
        }

        public const string UriScheme = "coh3-play-replay";
        private const string FriendlyName = "COH3 Replay Manager";

        internal static List<string> GetReplays()
        {
            if (!Directory.Exists(coh3PlaybackPath))
            {
                MessageBox.Show("Unable to find path to replays.  You may need to set the path in settings.");
                return new List<string>();
            }

            DirectoryInfo info = new DirectoryInfo(coh3PlaybackPath);
            var files = info.GetFiles().Where(item => item.Name.ToLower() != fileName && item.Name.ToLower() != fileNameCampaign).OrderByDescending(p => p.CreationTime).ToList();

            return files.Select(item => item.Name).ToList();
        }

        public static void RegisterUriScheme()
        {
            using (var key = Registry.CurrentUser.CreateSubKey("SOFTWARE\\Classes\\" + UriScheme))
            {
                string applicationLocation = typeof(Program).Assembly.Location.Replace(".dll", ".exe");

                key.SetValue("", "URL:" + FriendlyName);
                key.SetValue("URL Protocol", "");

                using (var defaultIcon = key.CreateSubKey("DefaultIcon"))
                {
                    defaultIcon.SetValue("", applicationLocation + ",1");
                }

                using (var commandKey = key.CreateSubKey(@"shell\open\command"))
                {
                    commandKey.SetValue("", "\"" + applicationLocation + "\" \"%1\"");
                }
            }
        }
    }
}
