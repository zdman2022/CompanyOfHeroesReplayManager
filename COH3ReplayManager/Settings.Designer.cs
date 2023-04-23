namespace COH3ReplayManager
{
    partial class Settings
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            txtSteamPath = new TextBox();
            button1 = new Button();
            label2 = new Label();
            button2 = new Button();
            txtCOH3PlaybackPath = new TextBox();
            button3 = new Button();
            fbdPlayback = new FolderBrowserDialog();
            ofdSteam = new OpenFileDialog();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(11, 7);
            label1.Name = "label1";
            label1.Size = new Size(67, 15);
            label1.TabIndex = 0;
            label1.Text = "Steam Path";
            // 
            // txtSteamPath
            // 
            txtSteamPath.Location = new Point(11, 25);
            txtSteamPath.Name = "txtSteamPath";
            txtSteamPath.Size = new Size(703, 23);
            txtSteamPath.TabIndex = 1;
            // 
            // button1
            // 
            button1.Location = new Point(720, 24);
            button1.Name = "button1";
            button1.Size = new Size(30, 23);
            button1.TabIndex = 2;
            button1.Text = "...";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 61);
            label2.Name = "label2";
            label2.Size = new Size(125, 15);
            label2.TabIndex = 3;
            label2.Text = "COH3 Playback Folder";
            // 
            // button2
            // 
            button2.Location = new Point(721, 79);
            button2.Name = "button2";
            button2.Size = new Size(30, 23);
            button2.TabIndex = 5;
            button2.Text = "...";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // txtCOH3PlaybackPath
            // 
            txtCOH3PlaybackPath.Location = new Point(12, 79);
            txtCOH3PlaybackPath.Name = "txtCOH3PlaybackPath";
            txtCOH3PlaybackPath.Size = new Size(703, 23);
            txtCOH3PlaybackPath.TabIndex = 4;
            // 
            // button3
            // 
            button3.Location = new Point(640, 124);
            button3.Name = "button3";
            button3.Size = new Size(110, 23);
            button3.TabIndex = 6;
            button3.Text = "&Save";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // ofdSteam
            // 
            ofdSteam.DefaultExt = "exe";
            ofdSteam.FileName = "steam.exe";
            ofdSteam.Filter = "Executables|*.exe";
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(758, 159);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(txtCOH3PlaybackPath);
            Controls.Add(label2);
            Controls.Add(button1);
            Controls.Add(txtSteamPath);
            Controls.Add(label1);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Settings";
            StartPosition = FormStartPosition.CenterParent;
            Text = "Settings";
            Load += Settings_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox txtSteamPath;
        private Button button1;
        private Label label2;
        private Button button2;
        private TextBox txtCOH3PlaybackPath;
        private Button button3;
        private FolderBrowserDialog fbdPlayback;
        private OpenFileDialog ofdSteam;
    }
}