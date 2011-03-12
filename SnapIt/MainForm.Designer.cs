namespace SnapIt
{
    partial class MainForm
    {
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if(disposing)
            {
                if(components != null)
                {
                    components.Dispose();
                }
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
            this.components = new System.ComponentModel.Container();
            System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
            this.btnSettings = new System.Windows.Forms.Button();
            this.picSnapshot = new System.Windows.Forms.PictureBox();
            this.picPreview = new System.Windows.Forms.PictureBox();
            this.btnGrab = new System.Windows.Forms.Button();
            this.lblDevicePreview = new System.Windows.Forms.Label();
            this.lblSnapshot = new System.Windows.Forms.Label();
            this.txtPath = new System.Windows.Forms.TextBox();
            this.lblFreq = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkActive = new System.Windows.Forms.CheckBox();
            this.numFreq = new System.Windows.Forms.NumericUpDown();
            this.tmrSnapshot = new System.Windows.Forms.Timer(this.components);
            this.btnExit = new System.Windows.Forms.Button();
            this.trayIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuTray = new System.Windows.Forms.ContextMenu();
            this.menuTrayShow = new System.Windows.Forms.MenuItem();
            this.menuTrayExit = new System.Windows.Forms.MenuItem();
            this.btnHide = new System.Windows.Forms.Button();
            this.picLogo = new System.Windows.Forms.PictureBox();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblAuthor = new System.Windows.Forms.Label();
            this.chkPreview = new System.Windows.Forms.CheckBox();
            this.lblSnapshotPath = new System.Windows.Forms.Label();
            this.grpSnapshots = new System.Windows.Forms.GroupBox();
            this.lnkOpenFolder = new System.Windows.Forms.LinkLabel();
            this.lblLastTaken = new System.Windows.Forms.Label();
            this.btnTakeShot = new System.Windows.Forms.Button();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.lblCount = new System.Windows.Forms.Label();
            this.txtLastTaken = new System.Windows.Forms.TextBox();
            this.btnAbout = new System.Windows.Forms.Button();
            this.lnkCamError = new System.Windows.Forms.LinkLabel();
            this.lblCamError = new System.Windows.Forms.Label();
            this.lblCamErrorTitle = new System.Windows.Forms.Label();
            this.txtPreviewRate = new System.Windows.Forms.TextBox();
            this.lblPreviewRate = new System.Windows.Forms.Label();
            this.lblPreviewRateMS = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.numFreq)).BeginInit();
            this.grpSnapshots.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSettings
            // 
            this.btnSettings.Location = new System.Drawing.Point(8, 320);
            this.btnSettings.Name = "btnSettings";
            this.btnSettings.Size = new System.Drawing.Size(80, 32);
            this.btnSettings.TabIndex = 3;
            this.btnSettings.Text = "&Settings...";
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // picSnapshot
            // 
            this.picSnapshot.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
              | System.Windows.Forms.AnchorStyles.Left)
              | System.Windows.Forms.AnchorStyles.Right);
            this.picSnapshot.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.picSnapshot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picSnapshot.Location = new System.Drawing.Point(336, 72);
            this.picSnapshot.Name = "picSnapshot";
            this.picSnapshot.Size = new System.Drawing.Size(322, 242);
            this.picSnapshot.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.picSnapshot.TabIndex = 0;
            this.picSnapshot.TabStop = false;
            // 
            // picPreview
            // 
            this.picPreview.BackColor = System.Drawing.SystemColors.AppWorkspace;
            this.picPreview.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPreview.Location = new System.Drawing.Point(8, 72);
            this.picPreview.Name = "picPreview";
            this.picPreview.Size = new System.Drawing.Size(322, 242);
            this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPreview.TabIndex = 0;
            this.picPreview.TabStop = false;
            // 
            // btnGrab
            // 
            this.btnGrab.Location = new System.Drawing.Point(96, 320);
            this.btnGrab.Name = "btnGrab";
            this.btnGrab.Size = new System.Drawing.Size(80, 32);
            this.btnGrab.TabIndex = 4;
            this.btnGrab.Text = "&Grab";
            this.btnGrab.Click += new System.EventHandler(this.btnGrab_Click);
            // 
            // lblDevicePreview
            // 
            this.lblDevicePreview.Location = new System.Drawing.Point(8, 56);
            this.lblDevicePreview.Name = "lblDevicePreview";
            this.lblDevicePreview.Size = new System.Drawing.Size(244, 16);
            this.lblDevicePreview.TabIndex = 2;
            this.lblDevicePreview.Text = "Device Preview:";
            // 
            // lblSnapshot
            // 
            this.lblSnapshot.Location = new System.Drawing.Point(336, 56);
            this.lblSnapshot.Name = "lblSnapshot";
            this.lblSnapshot.Size = new System.Drawing.Size(322, 16);
            this.lblSnapshot.TabIndex = 5;
            this.lblSnapshot.Text = "Snapshot Preview:";
            // 
            // txtPath
            // 
            this.txtPath.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
              | System.Windows.Forms.AnchorStyles.Right);
            this.txtPath.Location = new System.Drawing.Point(140, 56);
            this.txtPath.Name = "txtPath";
            this.txtPath.Size = new System.Drawing.Size(500, 20);
            this.txtPath.TabIndex = 8;
            this.txtPath.Text = "SnapIt Snapshots";
            this.txtPath.Leave += new System.EventHandler(this.txtPath_Leave);
            // 
            // lblFreq
            // 
            this.lblFreq.Location = new System.Drawing.Point(8, 84);
            this.lblFreq.Name = "lblFreq";
            this.lblFreq.Size = new System.Drawing.Size(128, 16);
            this.lblFreq.TabIndex = 9;
            this.lblFreq.Text = "Frequency (seconds):";
            // 
            // btnSave
            // 
            this.btnSave.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(336, 320);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(88, 32);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "&Save...";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkActive
            // 
            this.chkActive.Appearance = System.Windows.Forms.Appearance.Button;
            this.chkActive.BackColor = System.Drawing.SystemColors.Control;
            this.chkActive.Location = new System.Drawing.Point(8, 24);
            this.chkActive.Name = "chkActive";
            this.chkActive.Size = new System.Drawing.Size(80, 28);
            this.chkActive.TabIndex = 7;
            this.chkActive.Text = "Active";
            this.chkActive.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.chkActive.CheckedChanged += new System.EventHandler(this.chkActive_CheckedChanged);
            // 
            // numFreq
            // 
            this.numFreq.Location = new System.Drawing.Point(140, 80);
            this.numFreq.Maximum = new System.Decimal(new int[] {
                                                            604800,
                                                            0,
                                                            0,
                                                            0});
            this.numFreq.Name = "numFreq";
            this.numFreq.Size = new System.Drawing.Size(60, 20);
            this.numFreq.TabIndex = 10;
            this.numFreq.Value = new System.Decimal(new int[] {
                                                          120,
                                                          0,
                                                          0,
                                                          0});
            this.numFreq.ValueChanged += new System.EventHandler(this.numFreq_ValueChanged);
            this.numFreq.Leave += new System.EventHandler(this.numFreq_Leave);
            // 
            // tmrSnapshot
            // 
            this.tmrSnapshot.Interval = 1000;
            this.tmrSnapshot.Tick += new System.EventHandler(this.tmrSnapshot_Tick);
            // 
            // btnExit
            // 
            this.btnExit.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnExit.Location = new System.Drawing.Point(464, 8);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(88, 32);
            this.btnExit.TabIndex = 12;
            this.btnExit.Text = "&Exit";
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // trayIcon
            // 
            this.trayIcon.ContextMenu = this.menuTray;
            this.trayIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("trayIcon.Icon")));
            this.trayIcon.Text = "SnapIt";
            this.trayIcon.Visible = true;
            this.trayIcon.DoubleClick += new System.EventHandler(this.trayIcon_DoubleClick);
            // 
            // menuTray
            // 
            this.menuTray.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
                                                                             this.menuTrayShow,
                                                                             this.menuTrayExit});
            // 
            // menuTrayShow
            // 
            this.menuTrayShow.DefaultItem = true;
            this.menuTrayShow.Index = 0;
            this.menuTrayShow.Text = "&Show";
            this.menuTrayShow.Click += new System.EventHandler(this.menuTrayShow_Click);
            // 
            // menuTrayExit
            // 
            this.menuTrayExit.Index = 1;
            this.menuTrayExit.Text = "&Exit";
            this.menuTrayExit.Click += new System.EventHandler(this.menuTrayExit_Click);
            // 
            // btnHide
            // 
            this.btnHide.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnHide.Location = new System.Drawing.Point(368, 8);
            this.btnHide.Name = "btnHide";
            this.btnHide.Size = new System.Drawing.Size(88, 32);
            this.btnHide.TabIndex = 11;
            this.btnHide.Text = "&Hide";
            this.btnHide.Click += new System.EventHandler(this.btnHide_Click);
            // 
            // picLogo
            // 
            this.picLogo.Image = ((System.Drawing.Bitmap)(resources.GetObject("picLogo.Image")));
            this.picLogo.Location = new System.Drawing.Point(8, 8);
            this.picLogo.Name = "picLogo";
            this.picLogo.Size = new System.Drawing.Size(32, 32);
            this.picLogo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.picLogo.TabIndex = 12;
            this.picLogo.TabStop = false;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(52, 8);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(280, 16);
            this.lblTitle.TabIndex = 0;
            this.lblTitle.Text = "SnapIt";
            // 
            // lblAuthor
            // 
            this.lblAuthor.Location = new System.Drawing.Point(52, 28);
            this.lblAuthor.Name = "lblAuthor";
            this.lblAuthor.Size = new System.Drawing.Size(280, 16);
            this.lblAuthor.TabIndex = 1;
            this.lblAuthor.Text = "By Joe Esposito";
            // 
            // chkPreview
            // 
            this.chkPreview.Checked = true;
            this.chkPreview.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPreview.Location = new System.Drawing.Point(188, 320);
            this.chkPreview.Name = "chkPreview";
            this.chkPreview.Size = new System.Drawing.Size(142, 16);
            this.chkPreview.TabIndex = 14;
            this.chkPreview.Text = "Preview";
            this.chkPreview.CheckedChanged += new System.EventHandler(this.chkPreview_CheckedChanged);
            // 
            // lblSnapshotPath
            // 
            this.lblSnapshotPath.Location = new System.Drawing.Point(8, 60);
            this.lblSnapshotPath.Name = "lblSnapshotPath";
            this.lblSnapshotPath.Size = new System.Drawing.Size(128, 16);
            this.lblSnapshotPath.TabIndex = 9;
            this.lblSnapshotPath.Text = "Snapshot Path:";
            // 
            // grpSnapshots
            // 
            this.grpSnapshots.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
              | System.Windows.Forms.AnchorStyles.Right);
            this.grpSnapshots.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                               this.lnkOpenFolder,
                                                                               this.lblLastTaken,
                                                                               this.btnTakeShot,
                                                                               this.txtCount,
                                                                               this.lblCount,
                                                                               this.txtPath,
                                                                               this.chkActive,
                                                                               this.lblFreq,
                                                                               this.numFreq,
                                                                               this.lblSnapshotPath,
                                                                               this.txtLastTaken});
            this.grpSnapshots.Location = new System.Drawing.Point(8, 368);
            this.grpSnapshots.Name = "grpSnapshots";
            this.grpSnapshots.Size = new System.Drawing.Size(652, 108);
            this.grpSnapshots.TabIndex = 15;
            this.grpSnapshots.TabStop = false;
            this.grpSnapshots.Text = "Snapshots:";
            // 
            // lnkOpenFolder
            // 
            this.lnkOpenFolder.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.lnkOpenFolder.Location = new System.Drawing.Point(572, 80);
            this.lnkOpenFolder.Name = "lnkOpenFolder";
            this.lnkOpenFolder.Size = new System.Drawing.Size(68, 16);
            this.lnkOpenFolder.TabIndex = 15;
            this.lnkOpenFolder.TabStop = true;
            this.lnkOpenFolder.Text = "Open Folder";
            this.lnkOpenFolder.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkOpenFolder_LinkClicked);
            // 
            // lblLastTaken
            // 
            this.lblLastTaken.Enabled = false;
            this.lblLastTaken.Location = new System.Drawing.Point(320, 28);
            this.lblLastTaken.Name = "lblLastTaken";
            this.lblLastTaken.Size = new System.Drawing.Size(88, 16);
            this.lblLastTaken.TabIndex = 14;
            this.lblLastTaken.Text = "Last shot taken:";
            // 
            // btnTakeShot
            // 
            this.btnTakeShot.Enabled = false;
            this.btnTakeShot.Location = new System.Drawing.Point(232, 20);
            this.btnTakeShot.Name = "btnTakeShot";
            this.btnTakeShot.Size = new System.Drawing.Size(76, 28);
            this.btnTakeShot.TabIndex = 13;
            this.btnTakeShot.Text = "Take Shot";
            this.btnTakeShot.Click += new System.EventHandler(this.btnTakeShot_Click);
            // 
            // txtCount
            // 
            this.txtCount.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtCount.Enabled = false;
            this.txtCount.Location = new System.Drawing.Point(184, 28);
            this.txtCount.Name = "txtCount";
            this.txtCount.ReadOnly = true;
            this.txtCount.Size = new System.Drawing.Size(40, 13);
            this.txtCount.TabIndex = 12;
            this.txtCount.Text = "0";
            this.txtCount.WordWrap = false;
            // 
            // lblCount
            // 
            this.lblCount.Enabled = false;
            this.lblCount.Location = new System.Drawing.Point(140, 28);
            this.lblCount.Name = "lblCount";
            this.lblCount.Size = new System.Drawing.Size(40, 16);
            this.lblCount.TabIndex = 11;
            this.lblCount.Text = "Taken:";
            // 
            // txtLastTaken
            // 
            this.txtLastTaken.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
              | System.Windows.Forms.AnchorStyles.Right);
            this.txtLastTaken.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtLastTaken.Enabled = false;
            this.txtLastTaken.Location = new System.Drawing.Point(412, 28);
            this.txtLastTaken.Name = "txtLastTaken";
            this.txtLastTaken.ReadOnly = true;
            this.txtLastTaken.Size = new System.Drawing.Size(228, 13);
            this.txtLastTaken.TabIndex = 12;
            this.txtLastTaken.Text = "(None)";
            this.txtLastTaken.WordWrap = false;
            // 
            // btnAbout
            // 
            this.btnAbout.Anchor = (System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right);
            this.btnAbout.Location = new System.Drawing.Point(572, 8);
            this.btnAbout.Name = "btnAbout";
            this.btnAbout.Size = new System.Drawing.Size(88, 32);
            this.btnAbout.TabIndex = 11;
            this.btnAbout.Text = "&About...";
            this.btnAbout.Click += new System.EventHandler(this.btnAbout_Click);
            // 
            // lnkCamError
            // 
            this.lnkCamError.ActiveLinkColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(0)), ((System.Byte)(0)));
            this.lnkCamError.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
            this.lnkCamError.LinkColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(255)), ((System.Byte)(192)));
            this.lnkCamError.Location = new System.Drawing.Point(16, 240);
            this.lnkCamError.Name = "lnkCamError";
            this.lnkCamError.Size = new System.Drawing.Size(306, 64);
            this.lnkCamError.TabIndex = 17;
            this.lnkCamError.TabStop = true;
            this.lnkCamError.Text = "[ Connect to Device ]";
            this.lnkCamError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lnkCamError.Visible = false;
            this.lnkCamError.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCamError_LinkClicked);
            // 
            // lblCamError
            // 
            this.lblCamError.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
            this.lblCamError.ForeColor = System.Drawing.Color.White;
            this.lblCamError.Location = new System.Drawing.Point(16, 172);
            this.lblCamError.Name = "lblCamError";
            this.lblCamError.Size = new System.Drawing.Size(306, 64);
            this.lblCamError.TabIndex = 18;
            this.lblCamError.Text = ":: Error Message ::";
            this.lblCamError.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.lblCamError.Visible = false;
            // 
            // lblCamErrorTitle
            // 
            this.lblCamErrorTitle.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(64)), ((System.Byte)(0)), ((System.Byte)(0)));
            this.lblCamErrorTitle.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(192)), ((System.Byte)(192)));
            this.lblCamErrorTitle.Location = new System.Drawing.Point(16, 80);
            this.lblCamErrorTitle.Name = "lblCamErrorTitle";
            this.lblCamErrorTitle.Size = new System.Drawing.Size(306, 88);
            this.lblCamErrorTitle.TabIndex = 18;
            this.lblCamErrorTitle.Text = "Error Title";
            this.lblCamErrorTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lblCamErrorTitle.Visible = false;
            // 
            // txtPreviewRate
            // 
            this.txtPreviewRate.Location = new System.Drawing.Point(272, 336);
            this.txtPreviewRate.Name = "txtPreviewRate";
            this.txtPreviewRate.Size = new System.Drawing.Size(36, 20);
            this.txtPreviewRate.TabIndex = 19;
            this.txtPreviewRate.Text = "60";
            // 
            // lblPreviewRate
            // 
            this.lblPreviewRate.Location = new System.Drawing.Point(188, 340);
            this.lblPreviewRate.Name = "lblPreviewRate";
            this.lblPreviewRate.Size = new System.Drawing.Size(76, 16);
            this.lblPreviewRate.TabIndex = 20;
            this.lblPreviewRate.Text = "Refresh Rate:";
            // 
            // lblPreviewRateMS
            // 
            this.lblPreviewRateMS.Location = new System.Drawing.Point(312, 340);
            this.lblPreviewRateMS.Name = "lblPreviewRateMS";
            this.lblPreviewRateMS.Size = new System.Drawing.Size(20, 16);
            this.lblPreviewRateMS.TabIndex = 20;
            this.lblPreviewRateMS.Text = "ms";
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(668, 485);
            this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.lblPreviewRate,
                                                                  this.txtPreviewRate,
                                                                  this.lblCamErrorTitle,
                                                                  this.lblCamError,
                                                                  this.lnkCamError,
                                                                  this.grpSnapshots,
                                                                  this.chkPreview,
                                                                  this.lblTitle,
                                                                  this.picLogo,
                                                                  this.btnExit,
                                                                  this.btnSave,
                                                                  this.lblSnapshot,
                                                                  this.lblDevicePreview,
                                                                  this.btnGrab,
                                                                  this.picPreview,
                                                                  this.btnSettings,
                                                                  this.picSnapshot,
                                                                  this.btnHide,
                                                                  this.lblAuthor,
                                                                  this.btnAbout,
                                                                  this.lblPreviewRateMS});
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(676, 512);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SnapIt";
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainForm_Closing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.VisibleChanged += new System.EventHandler(this.MainForm_VisibleChanged);
            this.Activated += new System.EventHandler(this.MainForm_Activated);
            ((System.ComponentModel.ISupportInitialize)(this.numFreq)).EndInit();
            this.grpSnapshots.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picPreview;
        private System.Windows.Forms.Button btnGrab;
        private System.Windows.Forms.Label lblDevicePreview;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtPath;
        private System.Windows.Forms.NumericUpDown numFreq;
        private System.Windows.Forms.Label lblFreq;
        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.NotifyIcon trayIcon;
        private System.Windows.Forms.Button btnHide;
        private System.Windows.Forms.ContextMenu menuTray;
        private System.Windows.Forms.MenuItem menuTrayShow;
        private System.Windows.Forms.MenuItem menuTrayExit;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblAuthor;
        private System.Windows.Forms.CheckBox chkActive;
        private System.Windows.Forms.CheckBox chkPreview;
        private System.Windows.Forms.Label lblSnapshotPath;
        private System.Windows.Forms.GroupBox grpSnapshots;
        private System.Windows.Forms.Timer tmrSnapshot;
        private System.Windows.Forms.Label lblCount;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Button btnTakeShot;
        private System.Windows.Forms.PictureBox picSnapshot;
        private System.Windows.Forms.Label lblSnapshot;
        private System.Windows.Forms.Label lblLastTaken;
        private System.Windows.Forms.TextBox txtLastTaken;
        private System.Windows.Forms.LinkLabel lnkOpenFolder;
        private System.Windows.Forms.Button btnAbout;
        private System.Windows.Forms.LinkLabel lnkCamError;
        private System.Windows.Forms.Label lblCamError;
        private System.Windows.Forms.Label lblCamErrorTitle;
        private System.Windows.Forms.TextBox txtPreviewRate;
        private System.Windows.Forms.Label lblPreviewRate;
        private System.Windows.Forms.Button btnSettings;
        private System.Windows.Forms.Label lblPreviewRateMS;
        private System.Windows.Forms.PictureBox picLogo;
        private System.ComponentModel.IContainer components;
    }
}
