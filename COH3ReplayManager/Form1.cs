using System.Diagnostics;

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
                    Process.Start(ReplayHelper.coh3Path, $"-replay playback:{item.Text}");
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
    }
}