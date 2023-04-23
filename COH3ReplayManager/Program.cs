using System.Diagnostics;
using System.Net;

namespace COH3ReplayManager
{
    internal static class Program
    {
        

        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main(string[] args)
        {
            if(args.Length == 0)
            {
                // To customize application configuration such as set high DPI settings or default font,
                // see https://aka.ms/applicationconfiguration.
                ApplicationConfiguration.Initialize();

                var frm = new Form1();
                frm.Hide();
                Application.Run();
            }
            else
            {
                if (Alt1Async(args).Result)
                    return;
            }
        }

        private static async Task<bool> Alt1Async(string[] args)
        {
            if (Uri.TryCreate(args[0], UriKind.Absolute, out var uri) && string.Equals(uri.Scheme, ReplayHelper.UriScheme, StringComparison.OrdinalIgnoreCase))
            {
                var subUrl = uri.AbsolutePath.ToString();

                if (Uri.TryCreate(subUrl, UriKind.Absolute, out var subUri))
                {
                    if (subUri.Host == "cohdb.com")
                    {
                        using (var client = new HttpClient(new HttpClientHandler
                        {
                            AllowAutoRedirect = true,
                            MaxAutomaticRedirections = 3
                        }))
                        {
                            using (var stream = await client.GetStreamAsync(subUri))
                            {
                                var path = ReplayHelper.coh3PlaybackPath + $"\\AutoPlay.rec";
                                if (File.Exists(path))
                                {
                                    File.Delete(path);
                                }

                                using (var fileStream = new FileStream(path, FileMode.CreateNew))
                                {
                                    await stream.CopyToAsync(fileStream);
                                }
                            }
                        }

                        Process.Start(ReplayHelper.steamPath, $"-appLaunch 1677280 -dev -replay playback:AutoPlay.rec");
                        return true;
                    }
                }
            }

            return false;
        }
    }
}