using Newtonsoft.Json;
using System.Diagnostics;
using System.Text;

namespace COH3ReplayManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            btnRefresh.Font = new Font("Wingdings 3", 10, FontStyle.Bold);
            btnRefresh.Text = Char.ConvertFromUtf32(81);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (ReplayHelper.IsRunning)
            {
                if (File.Exists(ReplayHelper.ReplayFile))
                {
                    try
                    {
                        var intTry = 0;
                        var fileName = DateTime.Now.ToString("yyyy-MM-ddThhmmss");

                        while (File.Exists(ReplayHelper.coh3PlaybackPath + "\\" + fileName + (intTry > 0 ? $"_{intTry}" : "") + ".rec"))
                            intTry++;

                        var fromPath = ReplayHelper.ReplayFile;
                        var toPath = ReplayHelper.coh3PlaybackPath + "\\" + fileName + (intTry > 0 ? $"_{intTry}" : "") + ".rec";
                        File.Move(fromPath, toPath);
                    }
                    catch (Exception ex)
                    {
                    }
                };
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = (e.CloseReason == CloseReason.UserClosing);
            this.Hide();
        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            this.Show();
        }

        private void Form1_VisibleChanged(object sender, EventArgs e)
        {
            if (this.Visible)
            {
                refreshList();
            }
        }

        private void refreshList()
        {
            var files = ReplayHelper.GetReplays();

            listView1.Items.Clear();
            listView1.Items.AddRange(files.Select(item => new ListViewItem
            {
                Text = Path.GetFileName(item)
            }).ToArray());
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            ListViewHitTestInfo info = listView1.HitTest(e.X, e.Y);

            if (info == null)
                return;

            ListViewItem? item = info.Item;

            if (item == null)
                return;

            if (!ReplayHelper.IsRunning)
            {
                var steamFI = new FileInfo(ReplayHelper.steamPath);

                if (steamFI.Exists)
                {
                    var fi = new FileInfo(ReplayHelper.coh3PlaybackPath + $"\\{item.Text}");
                    if (fi.Exists)
                    {
                        //Process.Start(ReplayHelper.coh3Path, $"-dev -replay playback:{item.Text}");
                        Process.Start(ReplayHelper.steamPath, $"-appLaunch 1677280 -dev -replay playback:{item.Text}");
                        //Clipboard.SetText($"-dev -replay playback:{item.Text}");
                    }
                    else
                    {
                        MessageBox.Show("Unable to find COH3 playback path.  You may need to set it settings.");
                    }
                }
                else
                {
                    MessageBox.Show("Steam not found.  You may need to set it in settings.");
                }
            }
            else
            {
                MessageBox.Show("COH3 is already running.");
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openReplayFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", ReplayHelper.coh3PlaybackPath);
        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblVersion.Text = "Version:";
            lblTimestamp.Text = "Timestamp:";
            lblMap.Text = "Map:";
            flpPlayers.Controls.Clear();

            if (this.listView1.SelectedItems.Count == 0) return;

            var item = this.listView1.SelectedItems[0];

            var fi = new FileInfo(ReplayHelper.coh3PlaybackPath + $"\\{item.Text}");
            if (fi.Exists)
            {
                Process p = new Process();
                p.StartInfo.FileName = "flank.exe";
                p.StartInfo.Arguments = $"\"{fi.FullName}\"";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();

                var bldr = new StringBuilder();
                while (!p.StandardOutput.EndOfStream)
                {
                    bldr.AppendLine(p.StandardOutput.ReadLine());
                }

                var json = bldr.ToString();

                var replayData = json != null && !string.IsNullOrWhiteSpace(json) ? JsonConvert.DeserializeObject<ReplayData>(json) : null;

                if (replayData != null)
                {
                    lblVersion.Text = $"Version: {replayData.version}" + Environment.NewLine;
                    lblTimestamp.Text = $"Timestamp: {replayData.timestamp}" + Environment.NewLine;
                    lblMap.Text = $"Map: {replayData.map.filename.Substring(replayData.map.filename.LastIndexOf("\\") + 1)}" + Environment.NewLine;

                    flpPlayers.Controls.Clear();
                    foreach (var player in replayData.players)
                    {
                        var lbl = new LinkLabel();
                        lbl.Text = $"{player.name} - {player.faction}";
                        lbl.Width = 300;
                        lbl.Click += (s, e) =>
                        {
                            Process.Start(new ProcessStartInfo($"https://coh3stats.com/players/{player.profile_id}") { UseShellExecute = true });
                        };
                        flpPlayers.Controls.Add(lbl);
                    }
                }
                else
                {
                    lblVersion.Text = "Version: Unable to parse replay.";
                    lblTimestamp.Text = "Timestamp:";
                    lblMap.Text = "Map:";
                    flpPlayers.Controls.Clear();
                }


                //using (var fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                //{
                //    var data = new byte[fs.Length];
                //    fs.Read(data, 0, data.Length);

                //    string dataHex = BitConverter.ToString(data).Replace("-", "");

                //    string playerSearch = BitConverter.ToString(Encoding.Default.GetBytes("default_ai_personality")).Replace("-", "");

                //    //Get Players
                //    var players = new List<Player>();
                //    var pos = dataHex.IndexOf(playerSearch);
                //    while (pos != -1)
                //    {
                //        var curPos = pos - 2;


                //        while (dataHex.Substring(curPos, 2) != "22")
                //        {
                //            curPos = curPos - 2;
                //        }

                //        var faction = "";

                //        curPos -= 4;
                //        while (!faction.StartsWith("0000"))
                //        {
                //            curPos -= 2;
                //            faction = dataHex.Substring(curPos, 2) + faction;
                //        }

                //        faction = faction.Replace("00", "");
                //        faction = Encoding.ASCII.GetString(FromHex(faction));

                //        var playerName = "";
                //        curPos -= 24;
                //        while (!playerName.StartsWith("0000"))
                //        {
                //            curPos -= 2;
                //            playerName = dataHex.Substring(curPos, 2) + playerName;
                //        }

                //        playerName = playerName.Replace("00", "");
                //        playerName = Encoding.ASCII.GetString(FromHex(playerName));

                //        players.Add(new Player
                //        {
                //            Name = playerName,
                //            Faction = faction
                //        });

                //        pos = dataHex.IndexOf(playerSearch, pos + playerSearch.Length);
                //    }

                //    foreach (var player in players)
                //    {
                //        lblReplayInfo.Text += $"Player: {player.Name} ({player.Faction})" + Environment.NewLine;
                //    }

                //    lblReplayInfo.Text += Environment.NewLine;

                //    //Get Map
                //    string mapSearch = BitConverter.ToString(Encoding.Default.GetBytes("data:")).Replace("-", "");
                //    pos = dataHex.IndexOf(mapSearch);
                //    if (pos != -1)
                //    {
                //        pos += 10;
                //        var map = "";

                //        while (dataHex.Substring(pos, 2) != "09")
                //        {
                //            map += dataHex.Substring(pos, 2);
                //            pos += 2;
                //        }

                //        map = Encoding.ASCII.GetString(FromHex(map));
                //        lblReplayInfo.Text += $"Map: {map}" + Environment.NewLine;
                //    }
                //}
            }
        }

        public static byte[] FromHex(string hex)
        {
            byte[] raw = new byte[hex.Length / 2];
            for (int i = 0; i < raw.Length; i++)
            {
                raw[i] = Convert.ToByte(hex.Substring(i * 2, 2), 16);
            }
            return raw;
        }

        private void replayEnhancementsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Openurl("https://github.com/Janne252/coh3-replay-enhancements");
        }

        private void Openurl(string url)
        {
            var psi = new System.Diagnostics.ProcessStartInfo();
            psi.UseShellExecute = true;
            psi.FileName = url;
            Process.Start(psi);
        }

        private void cOHDBToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Openurl("https://cohdb.com/");
        }

        private void cOH3StatsDesktopAppToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Openurl("https://github.com/cohstats/coh3-stats-desktop-app");
        }

        private void cOH3StatsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Openurl("https://coh3stats.com/");
        }

        private void btnFOW_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("FOW_UIRevealAll");
        }

        private void btnUnFOW_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("FOW_UIUnRevealAll");
        }

        private void btnSpeed16_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("setsimrate(16)");
        }

        private void btnSpeed24_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("setsimrate(24)");
        }

        private void btnEnhancements_Click(object sender, EventArgs e)
        {
            Clipboard.SetText("dofile('replay-enhancements/init.scar')");
        }

        private void setReplayLinkToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ReplayHelper.RegisterUriScheme();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            refreshList();
        }

        private void settingsToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            var settingsForm = new Settings();
            settingsForm.ShowDialog();
        }
    }
}