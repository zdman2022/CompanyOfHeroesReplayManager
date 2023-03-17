using System.Configuration;
using System.Diagnostics;

namespace COH3ReplayManager
{
    internal static class ReplayHelper
    {
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
                return GetValue("COH3PlaybackPath", myDocuments + @"\My Games\Company of Heroes 3\playback\");
            }
        }

        public static string coh3Path
        {
            get
            {
                return GetValue("COH3Path", "C:\\Program Files (x86)\\Steam\\steamapps\\common\\Company of Heroes 3\\RelicCoH3.exe");
            }
        }

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

        internal static List<string> GetReplays()
        {
            if (!Directory.Exists(coh3PlaybackPath))
            {
                MessageBox.Show("Unable to find path to replays.  You may need to set the path in the configuraiton file.");
                return new List<string>();
            }

            DirectoryInfo info = new DirectoryInfo(coh3PlaybackPath);
            var files = info.GetFiles().Where(item => item.Name.ToLower() != fileName && item.Name.ToLower() != fileNameCampaign).OrderByDescending(p => p.CreationTime).ToList();

            return files.Select(item => item.Name).ToList();
        }

        private static string GetValue(string key, string defaultValue)
        {
            if (ConfigurationManager.AppSettings == null || string.IsNullOrWhiteSpace(ConfigurationManager.AppSettings[key]))
                return defaultValue;
            else
                return ConfigurationManager.AppSettings[key];
        }
    }
}
