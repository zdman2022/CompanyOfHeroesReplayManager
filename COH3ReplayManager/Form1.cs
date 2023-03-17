using System.Diagnostics;
using System.Text;

namespace COH3ReplayManager
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(ReplayHelper.IsRunning)
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
            if(this.Visible)
            {
                var files = ReplayHelper.GetReplays();

                listView1.Items.Clear();
                listView1.Items.AddRange(files.Select(item => new ListViewItem
                {
                    Text = Path.GetFileName(item)
                }).ToArray());
            }
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
                var fi = new FileInfo(ReplayHelper.coh3PlaybackPath + $"\\{item.Text}");
                if (fi.Exists)
                {
                    Process.Start(ReplayHelper.coh3Path, $"-dev -replay playback:{item.Text}");
                }
                else
                {
                    MessageBox.Show("Unable to find COH3 exe.  You may need to set it in the configuration file.");
                }
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
            lblReplayInfo.Text = "";
            if(this.listView1.SelectedItems.Count == 0) return;

            var item = this.listView1.SelectedItems[0];

            var fi = new FileInfo(ReplayHelper.coh3PlaybackPath + $"\\{item.Text}");
            if (fi.Exists)
            {
                using (var fs = new FileStream(fi.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite))
                { 
                    var data = new byte[fs.Length];
                    fs.Read(data, 0, data.Length);

                    string dataHex = BitConverter.ToString(data).Replace("-", "");

                    string playerSearch = BitConverter.ToString(Encoding.Default.GetBytes("default_ai_personality")).Replace("-", "");

                    //Get Players
                    var players = new List<Player>();
                    var pos = dataHex.IndexOf(playerSearch);
                    while (pos != -1)
                    {
                        var curPos = pos - 2;


                        while (dataHex.Substring(curPos, 2) != "22")
                        {
                            curPos = curPos - 2;
                        }

                        var faction = "";

                        curPos -= 4;
                        while (!faction.StartsWith("0000"))
                        {
                            curPos -= 2;
                            faction = dataHex.Substring(curPos, 2) + faction;
                        }

                        faction = faction.Replace("00", "");
                        faction = Encoding.ASCII.GetString(FromHex(faction));

                        var playerName = "";
                        curPos -= 24;
                        while (!playerName.StartsWith("0000"))
                        {
                            curPos -= 2;
                            playerName = dataHex.Substring(curPos, 2) + playerName;
                        }

                        playerName = playerName.Replace("00", "");
                        playerName = Encoding.ASCII.GetString(FromHex(playerName));

                        players.Add(new Player
                        {
                            Name = playerName,
                            Faction = faction
                        });

                        pos = dataHex.IndexOf(playerSearch, pos + playerSearch.Length);
                    }

                    foreach(var player in players) {
                        lblReplayInfo.Text += $"Player: {player.Name} ({player.Faction})" + Environment.NewLine;
                    }

                    lblReplayInfo.Text += Environment.NewLine;

                    //Get Map
                    string mapSearch = BitConverter.ToString(Encoding.Default.GetBytes("data:")).Replace("-", "");
                    pos = dataHex.IndexOf(mapSearch);
                    if(pos != -1)
                    {
                        pos += 10;
                        var map = "";

                        while(dataHex.Substring(pos, 2) != "09")
                        {
                            map += dataHex.Substring(pos, 2);
                            pos += 2;
                        }

                        map = Encoding.ASCII.GetString(FromHex(map));
                        lblReplayInfo.Text += $"Map: {map}" + Environment.NewLine;
                    }
                }
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
    }
}