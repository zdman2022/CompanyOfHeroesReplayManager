using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace COH3ReplayManager
{
    public partial class Settings : Form
    {
        public Settings()
        {
            InitializeComponent();
        }

        private void Settings_Load(object sender, EventArgs e)
        {
            txtSteamPath.Text = Properties.Settings.Default.SteamPath;
            txtCOH3PlaybackPath.Text = Properties.Settings.Default.COH3PlaybackPath;

            if (string.IsNullOrEmpty(txtSteamPath.Text))
            {
                txtSteamPath.Text = ReplayHelper.DefaultSteamPath;
            }

            if (string.IsNullOrEmpty(txtCOH3PlaybackPath.Text))
            {
                txtCOH3PlaybackPath.Text = ReplayHelper.DefaultCOH3PlaybackPath;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.SteamPath = txtSteamPath.Text == ReplayHelper.DefaultSteamPath ? "" : txtSteamPath.Text;
            Properties.Settings.Default.COH3PlaybackPath = txtCOH3PlaybackPath.Text == ReplayHelper.DefaultCOH3PlaybackPath ? "" : txtCOH3PlaybackPath.Text;
            Properties.Settings.Default.Save();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var initialPath = string.IsNullOrEmpty(txtSteamPath.Text) ? ReplayHelper.DefaultSteamPath : txtSteamPath.Text;
            ofdSteam.InitialDirectory = Path.GetDirectoryName(initialPath);
            ofdSteam.DefaultExt = "exe";
            var result = ofdSteam.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtSteamPath.Text = ofdSteam.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            fbdPlayback.InitialDirectory = string.IsNullOrEmpty(txtCOH3PlaybackPath.Text) ? ReplayHelper.DefaultCOH3PlaybackPath : txtCOH3PlaybackPath.Text;
            var result = fbdPlayback.ShowDialog();
            if (result == DialogResult.OK)
            {
                txtCOH3PlaybackPath.Text = fbdPlayback.SelectedPath;
            }
        }
    }
}
