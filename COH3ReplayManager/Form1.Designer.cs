namespace COH3ReplayManager
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            listView1 = new ListView();
            notifyIcon1 = new NotifyIcon(components);
            timer1 = new System.Windows.Forms.Timer(components);
            menuStrip1 = new MenuStrip();
            fileToolStripMenuItem = new ToolStripMenuItem();
            openReplayFolderToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem1 = new ToolStripMenuItem();
            exitToolStripMenuItem = new ToolStripMenuItem();
            externalLinksToolStripMenuItem = new ToolStripMenuItem();
            replayEnhancementsToolStripMenuItem = new ToolStripMenuItem();
            cOHDBToolStripMenuItem = new ToolStripMenuItem();
            cOH3StatsDesktopAppToolStripMenuItem = new ToolStripMenuItem();
            cOH3StatsToolStripMenuItem = new ToolStripMenuItem();
            settingsToolStripMenuItem = new ToolStripMenuItem();
            setReplayLinkToolStripMenuItem = new ToolStripMenuItem();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            btnFOW = new Button();
            btnUnFOW = new Button();
            btnSpeed16 = new Button();
            btnSpeed24 = new Button();
            btnEnhancements = new Button();
            btnRefresh = new Button();
            lblVersion = new Label();
            lblTimestamp = new Label();
            lblMap = new Label();
            flpPlayers = new FlowLayoutPanel();
            label10 = new Label();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // listView1
            // 
            listView1.Location = new Point(12, 27);
            listView1.MultiSelect = false;
            listView1.Name = "listView1";
            listView1.Size = new Size(269, 498);
            listView1.TabIndex = 0;
            listView1.UseCompatibleStateImageBehavior = false;
            listView1.View = View.List;
            listView1.SelectedIndexChanged += listView1_SelectedIndexChanged;
            listView1.MouseDoubleClick += listView1_MouseDoubleClick;
            // 
            // notifyIcon1
            // 
            notifyIcon1.Icon = (Icon)resources.GetObject("notifyIcon1.Icon");
            notifyIcon1.Text = "notifyIcon1";
            notifyIcon1.Visible = true;
            notifyIcon1.Click += notifyIcon1_Click;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Tick += timer1_Tick;
            // 
            // menuStrip1
            // 
            menuStrip1.Items.AddRange(new ToolStripItem[] { fileToolStripMenuItem, externalLinksToolStripMenuItem, settingsToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(787, 24);
            menuStrip1.TabIndex = 1;
            menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            fileToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { openReplayFolderToolStripMenuItem, settingsToolStripMenuItem1, exitToolStripMenuItem });
            fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            fileToolStripMenuItem.Size = new Size(37, 20);
            fileToolStripMenuItem.Text = "&File";
            // 
            // openReplayFolderToolStripMenuItem
            // 
            openReplayFolderToolStripMenuItem.Name = "openReplayFolderToolStripMenuItem";
            openReplayFolderToolStripMenuItem.Size = new Size(177, 22);
            openReplayFolderToolStripMenuItem.Text = "&Open Replay Folder";
            openReplayFolderToolStripMenuItem.Click += openReplayFolderToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem1
            // 
            settingsToolStripMenuItem1.Name = "settingsToolStripMenuItem1";
            settingsToolStripMenuItem1.Size = new Size(180, 22);
            settingsToolStripMenuItem1.Text = "&Settings";
            settingsToolStripMenuItem1.Click += settingsToolStripMenuItem1_Click;
            // 
            // exitToolStripMenuItem
            // 
            exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            exitToolStripMenuItem.Size = new Size(177, 22);
            exitToolStripMenuItem.Text = "E&xit";
            exitToolStripMenuItem.Click += exitToolStripMenuItem_Click;
            // 
            // externalLinksToolStripMenuItem
            // 
            externalLinksToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { replayEnhancementsToolStripMenuItem, cOHDBToolStripMenuItem, cOH3StatsDesktopAppToolStripMenuItem, cOH3StatsToolStripMenuItem });
            externalLinksToolStripMenuItem.Name = "externalLinksToolStripMenuItem";
            externalLinksToolStripMenuItem.Size = new Size(91, 20);
            externalLinksToolStripMenuItem.Text = "External &Links";
            // 
            // replayEnhancementsToolStripMenuItem
            // 
            replayEnhancementsToolStripMenuItem.Name = "replayEnhancementsToolStripMenuItem";
            replayEnhancementsToolStripMenuItem.Size = new Size(205, 22);
            replayEnhancementsToolStripMenuItem.Text = "Replay Enhancements";
            replayEnhancementsToolStripMenuItem.Click += replayEnhancementsToolStripMenuItem_Click;
            // 
            // cOHDBToolStripMenuItem
            // 
            cOHDBToolStripMenuItem.Name = "cOHDBToolStripMenuItem";
            cOHDBToolStripMenuItem.Size = new Size(205, 22);
            cOHDBToolStripMenuItem.Text = "COH DB";
            cOHDBToolStripMenuItem.Click += cOHDBToolStripMenuItem_Click;
            // 
            // cOH3StatsDesktopAppToolStripMenuItem
            // 
            cOH3StatsDesktopAppToolStripMenuItem.Name = "cOH3StatsDesktopAppToolStripMenuItem";
            cOH3StatsDesktopAppToolStripMenuItem.Size = new Size(205, 22);
            cOH3StatsDesktopAppToolStripMenuItem.Text = "COH3 Stats Desktop App";
            cOH3StatsDesktopAppToolStripMenuItem.Click += cOH3StatsDesktopAppToolStripMenuItem_Click;
            // 
            // cOH3StatsToolStripMenuItem
            // 
            cOH3StatsToolStripMenuItem.Name = "cOH3StatsToolStripMenuItem";
            cOH3StatsToolStripMenuItem.Size = new Size(205, 22);
            cOH3StatsToolStripMenuItem.Text = "COH3 Stats";
            cOH3StatsToolStripMenuItem.Click += cOH3StatsToolStripMenuItem_Click;
            // 
            // settingsToolStripMenuItem
            // 
            settingsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { setReplayLinkToolStripMenuItem });
            settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            settingsToolStripMenuItem.Size = new Size(45, 20);
            settingsToolStripMenuItem.Text = "&Extra";
            // 
            // setReplayLinkToolStripMenuItem
            // 
            setReplayLinkToolStripMenuItem.Name = "setReplayLinkToolStripMenuItem";
            setReplayLinkToolStripMenuItem.Size = new Size(180, 22);
            setReplayLinkToolStripMenuItem.Text = "Set &Replay Link";
            setReplayLinkToolStripMenuItem.Click += setReplayLinkToolStripMenuItem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(309, 27);
            label1.Name = "label1";
            label1.Size = new Size(164, 15);
            label1.TabIndex = 2;
            label1.Text = "Open Console: CTRL+SHIFT+`";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(309, 51);
            label2.Name = "label2";
            label2.Size = new Size(175, 15);
            label2.TabIndex = 3;
            label2.Text = "Remove FOW: FOW_UIRevealAll";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(309, 76);
            label3.Name = "label3";
            label3.Size = new Size(169, 15);
            label3.TabIndex = 4;
            label3.Text = "Add FOW: FOW_UIUnRevealAll";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(309, 100);
            label4.Name = "label4";
            label4.Size = new Size(243, 15);
            label4.TabIndex = 5;
            label4.Text = "Speed (ticks/second, default 8): setsimrate(x)";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point);
            label5.Location = new Point(309, 157);
            label5.Name = "label5";
            label5.Size = new Size(114, 15);
            label5.TabIndex = 6;
            label5.Text = "Replay Information";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(309, 126);
            label6.Name = "label6";
            label6.Size = new Size(336, 15);
            label6.TabIndex = 8;
            label6.Text = "Replay-Enhancements: dofile('replay-enhancements/init.scar')";
            // 
            // btnFOW
            // 
            btnFOW.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnFOW.Location = new Point(497, 48);
            btnFOW.Name = "btnFOW";
            btnFOW.Size = new Size(45, 21);
            btnFOW.TabIndex = 9;
            btnFOW.Text = "Copy";
            btnFOW.UseVisualStyleBackColor = true;
            btnFOW.Click += btnFOW_Click;
            // 
            // btnUnFOW
            // 
            btnUnFOW.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnUnFOW.Location = new Point(497, 73);
            btnUnFOW.Name = "btnUnFOW";
            btnUnFOW.Size = new Size(45, 21);
            btnUnFOW.TabIndex = 10;
            btnUnFOW.Text = "Copy";
            btnUnFOW.UseVisualStyleBackColor = true;
            btnUnFOW.Click += btnUnFOW_Click;
            // 
            // btnSpeed16
            // 
            btnSpeed16.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSpeed16.Location = new Point(558, 97);
            btnSpeed16.Name = "btnSpeed16";
            btnSpeed16.Size = new Size(65, 21);
            btnSpeed16.TabIndex = 11;
            btnSpeed16.Text = "Copy 16";
            btnSpeed16.UseVisualStyleBackColor = true;
            btnSpeed16.Click += btnSpeed16_Click;
            // 
            // btnSpeed24
            // 
            btnSpeed24.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnSpeed24.Location = new Point(629, 97);
            btnSpeed24.Name = "btnSpeed24";
            btnSpeed24.Size = new Size(65, 21);
            btnSpeed24.TabIndex = 12;
            btnSpeed24.Text = "Copy 24";
            btnSpeed24.UseVisualStyleBackColor = true;
            btnSpeed24.Click += btnSpeed24_Click;
            // 
            // btnEnhancements
            // 
            btnEnhancements.Font = new Font("Segoe UI", 8.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnEnhancements.Location = new Point(649, 123);
            btnEnhancements.Name = "btnEnhancements";
            btnEnhancements.Size = new Size(45, 21);
            btnEnhancements.TabIndex = 13;
            btnEnhancements.Text = "Copy";
            btnEnhancements.UseVisualStyleBackColor = true;
            btnEnhancements.Click += btnEnhancements_Click;
            // 
            // btnRefresh
            // 
            btnRefresh.Location = new Point(287, 27);
            btnRefresh.Name = "btnRefresh";
            btnRefresh.Size = new Size(24, 23);
            btnRefresh.TabIndex = 14;
            btnRefresh.UseVisualStyleBackColor = true;
            btnRefresh.Click += btnRefresh_Click;
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Location = new Point(309, 186);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(48, 15);
            lblVersion.TabIndex = 15;
            lblVersion.Text = "Version:";
            // 
            // lblTimestamp
            // 
            lblTimestamp.AutoSize = true;
            lblTimestamp.Location = new Point(309, 212);
            lblTimestamp.Name = "lblTimestamp";
            lblTimestamp.Size = new Size(69, 15);
            lblTimestamp.TabIndex = 16;
            lblTimestamp.Text = "Timestamp:";
            // 
            // lblMap
            // 
            lblMap.AutoSize = true;
            lblMap.Location = new Point(310, 243);
            lblMap.Name = "lblMap";
            lblMap.Size = new Size(34, 15);
            lblMap.TabIndex = 17;
            lblMap.Text = "Map:";
            // 
            // flpPlayers
            // 
            flpPlayers.FlowDirection = FlowDirection.TopDown;
            flpPlayers.Location = new Point(338, 304);
            flpPlayers.Name = "flpPlayers";
            flpPlayers.Size = new Size(437, 221);
            flpPlayers.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(310, 275);
            label10.Name = "label10";
            label10.Size = new Size(47, 15);
            label10.TabIndex = 19;
            label10.Text = "Players:";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(787, 537);
            Controls.Add(label10);
            Controls.Add(flpPlayers);
            Controls.Add(lblMap);
            Controls.Add(lblTimestamp);
            Controls.Add(lblVersion);
            Controls.Add(btnRefresh);
            Controls.Add(btnEnhancements);
            Controls.Add(btnSpeed24);
            Controls.Add(btnSpeed16);
            Controls.Add(btnUnFOW);
            Controls.Add(btnFOW);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(listView1);
            Controls.Add(menuStrip1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MainMenuStrip = menuStrip1;
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "Form1";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "COH 3 Replay Manager";
            FormClosing += Form1_FormClosing;
            Load += Form1_Load;
            VisibleChanged += Form1_VisibleChanged;
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ListView listView1;
        private NotifyIcon notifyIcon1;
        private System.Windows.Forms.Timer timer1;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem fileToolStripMenuItem;
        private ToolStripMenuItem exitToolStripMenuItem;
        private ToolStripMenuItem openReplayFolderToolStripMenuItem;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private ToolStripMenuItem externalLinksToolStripMenuItem;
        private ToolStripMenuItem replayEnhancementsToolStripMenuItem;
        private ToolStripMenuItem cOHDBToolStripMenuItem;
        private ToolStripMenuItem cOH3StatsDesktopAppToolStripMenuItem;
        private ToolStripMenuItem cOH3StatsToolStripMenuItem;
        private Button btnFOW;
        private Button btnUnFOW;
        private Button btnSpeed16;
        private Button btnSpeed24;
        private Button btnEnhancements;
        private ToolStripMenuItem settingsToolStripMenuItem;
        private ToolStripMenuItem setReplayLinkToolStripMenuItem;
        private Button btnRefresh;
        private Label lblVersion;
        private Label lblTimestamp;
        private Label lblMap;
        private FlowLayoutPanel flpPlayers;
        private Label label10;
        private ToolStripMenuItem settingsToolStripMenuItem1;
    }
}