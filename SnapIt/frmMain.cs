// frmMain
// By Joe Esposito

using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Runtime.InteropServices;
using System.IO;
using System.Diagnostics;

using Uberware.Tools;

using DShowNET;
using DShowNET.Device;


namespace SnapIt
{

  /// <summary> Summary description for frmMain. </summary>
  public class frmMain : System.Windows.Forms.Form, ISampleGrabberCB
  {
    
    #region Class Variables
    
    // Vars
    private bool firstActive = false;
    private bool forceClose = false;
    
    private CamTool m_Cam = null;
    private int cSnapshots = 0;
    
    #region Controls

    private System.Windows.Forms.PictureBox picPreview;
    private System.Windows.Forms.Button btnGrab;
    private System.Windows.Forms.Button btnTuner;
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
    private System.Windows.Forms.PictureBox pictureBox1;
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
    private System.Windows.Forms.CheckBox chkDialate;
    private System.Windows.Forms.Label lblLastTaken;
    private System.Windows.Forms.TextBox txtLastTaken;
    private System.Windows.Forms.LinkLabel lnkOpenFolder;
    private System.Windows.Forms.Button btnAbout;
    private System.Windows.Forms.LinkLabel lnkCamError;
    private System.Windows.Forms.Label lblCamError;
    private System.Windows.Forms.Label lblCamErrorTitle;
    private System.ComponentModel.IContainer components;
    
    #endregion
    
    #endregion

    #region Class Construction
    
    public frmMain ()
    {
      // Required for Windows Form Designer support
      InitializeComponent();
    }

    /// <summary> Clean up any resources being used. </summary>
    protected override void Dispose( bool disposing )
    {
      if( disposing )
      {
        CloseInterfaces();
      
        if (components != null) 
        {
          components.Dispose();
        }
      }
      base.Dispose( disposing );
    }

    
    #region Windows Form Designer generated code
    
    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
      this.btnTuner = new System.Windows.Forms.Button();
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
      this.pictureBox1 = new System.Windows.Forms.PictureBox();
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
      this.chkDialate = new System.Windows.Forms.CheckBox();
      this.btnAbout = new System.Windows.Forms.Button();
      this.lnkCamError = new System.Windows.Forms.LinkLabel();
      this.lblCamError = new System.Windows.Forms.Label();
      this.lblCamErrorTitle = new System.Windows.Forms.Label();
      ((System.ComponentModel.ISupportInitialize)(this.numFreq)).BeginInit();
      this.grpSnapshots.SuspendLayout();
      this.SuspendLayout();
      // 
      // btnTuner
      // 
      this.btnTuner.Enabled = false;
      this.btnTuner.Location = new System.Drawing.Point(8, 320);
      this.btnTuner.Name = "btnTuner";
      this.btnTuner.Size = new System.Drawing.Size(84, 32);
      this.btnTuner.TabIndex = 3;
      this.btnTuner.Text = "&Tuner";
      this.btnTuner.Click += new System.EventHandler(this.btnTuner_Click);
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
      this.picPreview.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
      this.picPreview.TabIndex = 0;
      this.picPreview.TabStop = false;
      this.picPreview.Resize += new System.EventHandler(this.picPreview_Resize);
      // 
      // btnGrab
      // 
      this.btnGrab.Location = new System.Drawing.Point(100, 320);
      this.btnGrab.Name = "btnGrab";
      this.btnGrab.Size = new System.Drawing.Size(96, 32);
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
      this.txtPath.Text = "Captured";
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
      // pictureBox1
      // 
      this.pictureBox1.Image = ((System.Drawing.Bitmap)(resources.GetObject("pictureBox1.Image")));
      this.pictureBox1.Location = new System.Drawing.Point(8, 8);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(32, 32);
      this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
      this.pictureBox1.TabIndex = 12;
      this.pictureBox1.TabStop = false;
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
      this.chkPreview.Location = new System.Drawing.Point(204, 320);
      this.chkPreview.Name = "chkPreview";
      this.chkPreview.Size = new System.Drawing.Size(124, 16);
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
      this.grpSnapshots.Location = new System.Drawing.Point(8, 364);
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
      // chkDialate
      // 
      this.chkDialate.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.chkDialate.Location = new System.Drawing.Point(432, 320);
      this.chkDialate.Name = "chkDialate";
      this.chkDialate.Size = new System.Drawing.Size(228, 16);
      this.chkDialate.TabIndex = 16;
      this.chkDialate.Text = "Dialate to standard size (320, 240)";
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
      this.lnkCamError.Location = new System.Drawing.Point(16, 228);
      this.lnkCamError.Name = "lnkCamError";
      this.lnkCamError.Size = new System.Drawing.Size(306, 78);
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
      this.lblCamError.Location = new System.Drawing.Point(16, 160);
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
      this.lblCamErrorTitle.Size = new System.Drawing.Size(306, 76);
      this.lblCamErrorTitle.TabIndex = 18;
      this.lblCamErrorTitle.Text = "Could not Connect to Device";
      this.lblCamErrorTitle.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
      this.lblCamErrorTitle.Visible = false;
      // 
      // frmMain
      // 
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.ClientSize = new System.Drawing.Size(668, 478);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.lblCamErrorTitle,
                                                                  this.lblCamError,
                                                                  this.lnkCamError,
                                                                  this.chkDialate,
                                                                  this.grpSnapshots,
                                                                  this.chkPreview,
                                                                  this.lblTitle,
                                                                  this.pictureBox1,
                                                                  this.btnExit,
                                                                  this.btnSave,
                                                                  this.lblSnapshot,
                                                                  this.lblDevicePreview,
                                                                  this.btnGrab,
                                                                  this.picPreview,
                                                                  this.btnTuner,
                                                                  this.picSnapshot,
                                                                  this.btnHide,
                                                                  this.lblAuthor,
                                                                  this.btnAbout});
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimumSize = new System.Drawing.Size(676, 512);
      this.Name = "frmMain";
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "SnapIt";
      this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
      this.Load += new System.EventHandler(this.frmMain_Load);
      this.VisibleChanged += new System.EventHandler(this.frmMain_VisibleChanged);
      this.Activated += new System.EventHandler(this.frmMain_Activated);
      ((System.ComponentModel.ISupportInitialize)(this.numFreq)).EndInit();
      this.grpSnapshots.ResumeLayout(false);
      this.ResumeLayout(false);

    }
    
    #endregion
    
    #endregion

    
    #region Entry Point of Application
    
    /// <summary>
    /// The main entry point for the application.
    /// </summary>
    [STAThread]
    static void Main() 
    {
      frmMain frm = new frmMain();
      Application.Run(frm);
      frm = null; System.GC.Collect();
      
      Application.Exit();
    }
    
    #endregion

    
    private void frmMain_Load(object sender, System.EventArgs e)
    {
      txtPath.Text = GetImagePath(txtPath.Text);
      txtPath.SelectionStart = txtPath.Text.Length;
      numFreq_ValueChanged(sender, new EventArgs());
    }
    private void frmMain_Activated(object sender, System.EventArgs e)
    {
      if (firstActive) return;
      firstActive = true;
      
      StartCam();
    }
    private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
    {
      this.Hide();
      if (forceClose) CloseInterfaces();
      else e.Cancel = true;
    }
    
    
    
    private void btnGrab_Click(object sender, System.EventArgs e)
    { GrabImage(); }
    private void btnTuner_Click(object sender, System.EventArgs e)
    {
      if (sampGrabber == null) return;
      if (capGraph != null) DsUtils.ShowTunerPinDialog(capGraph, capFilter, this.Handle);
    }
    private void btnSave_Click(object sender, System.EventArgs e)
    { SaveImage(); }

    
    
    private void btnExit_Click(object sender, System.EventArgs e)
    { forceClose = true; this.Close(); }
    private void btnHide_Click(object sender, System.EventArgs e)
    { this.Hide(); }
    private void trayIcon_DoubleClick(object sender, System.EventArgs e)
    { this.Show(); this.Focus(); }
    private void menuTrayShow_Click(object sender, System.EventArgs e)
    { trayIcon_DoubleClick(sender, new EventArgs()); }
    private void menuTrayExit_Click(object sender, System.EventArgs e)
    { btnExit_Click(sender, new EventArgs()); }
    private void btnAbout_Click(object sender, System.EventArgs e)
    { (new frmAbout()).ShowDialog(this); }
    
    
    private void chkActive_CheckedChanged(object sender, System.EventArgs e)
    {
      // Failsafe
      if (chkActive.Checked)
      {
        if (!CheckImagePath())
        { chkActive.Checked = false; return; }
      }
      
      // Enable/disable controls
      tmrSnapshot.Enabled = chkActive.Checked;
      chkActive.BackColor = (( chkActive.Checked )?( Color.Firebrick ):( Color.FromKnownColor(KnownColor.Control) ));
      
      lblCount.Enabled = chkActive.Checked; txtCount.Enabled = chkActive.Checked;
      cSnapshots = 0; txtCount.Text = cSnapshots.ToString();
      btnTakeShot.Enabled = chkActive.Checked;
      lblLastTaken.Enabled = chkActive.Checked; txtLastTaken.Enabled = chkActive.Checked;
      txtLastTaken.Text = "(None)";
      
      // Save first image, if enabled
      if (tmrSnapshot.Enabled)
      { tmrSnapshot_Tick(sender, new EventArgs()); }
    }
    private void btnTakeShot_Click(object sender, System.EventArgs e)
    {
      tmrSnapshot.Stop(); tmrSnapshot.Start();
      tmrSnapshot_Tick(sender, new EventArgs());
    }

    private void picPreview_Resize(object sender, System.EventArgs e)
    { ResizeVideoWindow(); }
    
    private void numFreq_ValueChanged(object sender, System.EventArgs e)
    { tmrSnapshot.Interval = (int)(numFreq.Value * 1000); }
    private void numFreq_Leave(object sender, System.EventArgs e)
    { numFreq_ValueChanged(sender, new EventArgs()); }

    private void txtPath_Leave(object sender, System.EventArgs e)
    { CheckImagePath(); }

    private void tmrSnapshot_Tick (object sender, System.EventArgs e)
    { SnapshotImage(); }
    
    private void frmMain_VisibleChanged(object sender, System.EventArgs e)
    {
      if (videoWin == null) return;
      if (!Visible) videoWin.put_Visible(0);
      else chkPreview_CheckedChanged(sender, new EventArgs());
    }
    private void chkPreview_CheckedChanged(object sender, System.EventArgs e)
    {
      if (videoWin == null) return;
      videoWin.put_Visible( (( chkPreview.Checked )?( -1 ):( 0 )) );
    }
    
    private void lnkOpenFolder_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    {
      if (CheckImagePath())
      {
        try
        {
          // Call the Process.Start method to open the default file browser with a path:
          System.Diagnostics.Process.Start(txtPath.Text);
        }
        catch (Win32Exception)
        {}
        catch
        {
          // Failsafe
          MessageBox.Show(this, "Could not start browser process.", "Czt", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
      }
    }
    
    private void lnkCamError_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
    { StartCam(); }
    
    
    
    #region Local Functions
    
    private void StartCam ()
    {
      try
      {
        lnkCamError.Visible = false;
        lblCamErrorTitle.Visible = false;
        lblCamError.Visible = false;
        picPreview.BackColor = picSnapshot.BackColor;
        
        m_Cam = new CamTool(this);
      }
      catch (CamException e)
      {
        lblCamError.Text  = e.Message + "\n";
        lblCamError.Text += "Please check the device connection and make sure that the device is not being used by another application or user. Click the link below to try again.";
        
        picPreview.BackColor = lblCamError.BackColor;
        lnkCamError.Visible = true;
        lblCamErrorTitle.Visible = true;
        lblCamError.Visible = true;
      }
    }
    
    #endregion
    
    
    #region Image Grabbing/Saving Functions
    
    private bool CheckImagePath ()
    {
      if (txtPath.Text.IndexOfAny(Path.InvalidPathChars) != -1)
      {
        MessageBox.Show(this, "Paths cannot contain any of the following characters: " + new string(Path.InvalidPathChars), "Invalid Path");
        txtPath.Focus();
        return false;
      }
      
      string s = GetImagePath(txtPath.Text);
      
      if (!Directory.Exists(s))
      {
        if (MessageBox.Show(this, "Path does not exist; create?\n\n" + s, "Create Path?", MessageBoxButtons.YesNo) == DialogResult.Yes)
        {
          try
          { Directory.CreateDirectory(s); }
          catch (NotSupportedException e)
          {
            MessageBox.Show(this, e.ToString(), "Path Error");
            txtPath.Focus();
            return false;
          }
        }
        else
          return false;
      }
      
      txtPath.Text = s;
      txtPath.SelectionStart = txtPath.Text.Length;
      
      return true;
    }
    
    private string GetImagePath (string path)
    {
      if (!Path.IsPathRooted(path))
        return Path.Combine(Directory.GetCurrentDirectory(), path);
      else return Path.Combine(path, "");
    }
    private string GetImageFileName (string path, DateTime time)
    {
      string filename = "", ext = ".jpg";
      
      filename = GetImagePath(path);
      if (!Directory.Exists(filename)) return "";
      
      filename += "\\";
      filename += time.Year.ToString().PadLeft(4, '0') + "-" + time.Month.ToString().PadLeft(2, '0') + "-" + time.Day.ToString().PadLeft(2, '0') + " ";
      filename += time.Hour.ToString().PadLeft(2, '0') + "." + time.Minute.ToString().PadLeft(2, '0');
      
      // Create unique file
      int i = 1;
      while (File.Exists((filename + " - " + i) + ext)) i++;
      filename += " - " + i;
      
      return (filename + ext);
    }
    
    private void SaveImage (string Filename, Image img)
    {
      if (img == null) return;
      img.Save(Filename, ImageFormat.Jpeg);
    }
    private void SaveImage (string Filename)
    { SaveImage(Filename, picSnapshot.Image); }
    private void SaveImage ()
    {
      Image img = new Bitmap(picSnapshot.Image);
      SaveFileDialog sd = new SaveFileDialog();
      sd.FileName = @"SnapIt.jpg";
      sd.Title = "Save Image as...";
      sd.Filter = "JPEG file (*.jpg)|*.jpg";
      sd.FilterIndex = 1;
      if (sd.ShowDialog() == DialogResult.OK)
        SaveImage(sd.FileName, img);
      img = null;
    }
    
    private void SnapshotImage ()
    {
      GrabImage();
      
      DateTime now = DateTime.Now;
      txtLastTaken.Text = now.ToShortDateString() + " " + now.ToLongTimeString();
      
      SaveImage(GetImageFileName(txtPath.Text, now));
      cSnapshots++; txtCount.Text = cSnapshots.ToString();
    }
    
    private void GrabImage ()
    {
      if (sampGrabber == null) return;
      if (videoInfoHeader == null) return;
      
      if (savedArray == null)
      {
        int size = videoInfoHeader.BmiHeader.ImageSize;
        if ((size < 1000) || (size > 16000000)) return;
        savedArray = new byte[ size + 64000 ];
      }

      btnSave.Enabled = false;
      Image old = picSnapshot.Image;
      picSnapshot.Image = null;
      if( old != null )
      { old.Dispose(); }
      System.GC.Collect();
      btnGrab.Enabled = false;
      captured = false; captureDone = false;
      sampGrabber.SetCallback( this, 1 );
      
      while (captureDone == false) Application.DoEvents();
    }
    
    #endregion
    
    #region Capture Device Functions
    
    bool StartupCapture ()
    {
      if( ! DsUtils.IsCorrectDirectXVersion() )
      {
        MessageBox.Show( this, "DirectX 8.1 NOT installed!", "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
        return false;
      }

      if( ! DsDev.GetDevicesOfCat( FilterCategory.VideoInputDevice, out capDevices ) )
      {
        MessageBox.Show( this, "No video capture devices found!", "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
        return false;
      }

      DsDevice dev = null;
      if( capDevices.Count == 1 )
        dev = capDevices[0] as DsDevice;
      else
      {
        DeviceSelector selector = new DeviceSelector( capDevices );
        selector.ShowDialog( this );
        dev = selector.SelectedDevice;
      }

      if (dev == null)
        return false;

      if (!StartupVideo(dev.Mon))
        return false;
      
      return true;
    }
    
    /// <summary> capture event, triggered by buffer callback. </summary>
    void OnCaptureDone()
    {
      try 
      {
        btnGrab.Enabled = true;
        int hr;
        if( sampGrabber == null )
          return;
        hr = sampGrabber.SetCallback( null, 0 );

        int w = videoInfoHeader.BmiHeader.Width;
        int h = videoInfoHeader.BmiHeader.Height;
        if( ((w & 0x03) != 0) || (w < 32) || (w > 4096) || (h < 32) || (h > 4096) )
          return;
        int stride = w * 3;

        GCHandle handle = GCHandle.Alloc( savedArray, GCHandleType.Pinned );
        int scan0 = (int) handle.AddrOfPinnedObject();
        scan0 += (h - 1) * stride;
        Bitmap b = new Bitmap( w, h, -stride, PixelFormat.Format24bppRgb, (IntPtr) scan0 );
        handle.Free();
        savedArray = null;
        Image old = picSnapshot.Image;
        picSnapshot.Image = (( chkDialate.Checked )?( new Bitmap(b, 320, 240) ):( b ));
        if( old != null )
        { old.Dispose(); }
        System.GC.Collect();
        btnSave.Enabled = true;
        captureDone = true;
      }
      catch( Exception ee )
      {
        MessageBox.Show( this, "Could not grab picture\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
      }
    }

    /// <summary> start all the interfaces, graphs and preview window. </summary>
    bool StartupVideo( UCOMIMoniker mon )
    {
      int hr;
      try 
      {
        if( ! CreateCaptureDevice( mon ) )
          return false;

        if( ! GetInterfaces() )
          return false;

        if( ! SetupGraph() )
          return false;

        if( ! SetupVideoWindow() )
          return false;

      #if DEBUG
        DsROT.AddGraphToRot( graphBuilder, out rotCookie );    // graphBuilder capGraph
      #endif
      
        hr = mediaCtrl.Run();
        if( hr < 0 )
          Marshal.ThrowExceptionForHR( hr );

        bool hasTuner = DsUtils.ShowTunerPinDialog( capGraph, capFilter, this.Handle );
        btnTuner.Enabled = hasTuner;

        return true;
      }
      catch( Exception ee )
      {
        MessageBox.Show( this, "Could not start video stream\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
        return false;
      }
    }

    /// <summary> make the video preview window to show in videoPanel. </summary>
    bool SetupVideoWindow()
    {
      int hr;
      try 
      {
        // Set the video window to be a child of the main window
        hr = videoWin.put_Owner( picPreview.Handle );
        if( hr < 0 )
          Marshal.ThrowExceptionForHR( hr );

        // Set video window style
        hr = videoWin.put_WindowStyle( WS_CHILD | WS_CLIPCHILDREN );
        if( hr < 0 )
          Marshal.ThrowExceptionForHR( hr );

        // Use helper function to position video window in client rect of owner window
        ResizeVideoWindow();

        // Make the video window visible, now that it is properly positioned
        hr = videoWin.put_Visible( DsHlp.OATRUE );
        if( hr < 0 )
          Marshal.ThrowExceptionForHR( hr );

        hr = mediaEvt.SetNotifyWindow( this.Handle, WM_GRAPHNOTIFY, IntPtr.Zero );
        if( hr < 0 )
          Marshal.ThrowExceptionForHR( hr );
        return true;
      }
      catch( Exception ee )
      {
        MessageBox.Show( this, "Could not setup video window\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
        return false;
      }
    }


    /// <summary> build the capture graph for grabber. </summary>
    bool SetupGraph()
    {
      int hr;
      try 
      {
        hr = capGraph.SetFiltergraph( graphBuilder );
        if( hr < 0 )
          Marshal.ThrowExceptionForHR( hr );

        hr = graphBuilder.AddFilter( capFilter, "Ds.NET Video Capture Device" );
        if( hr < 0 )
          Marshal.ThrowExceptionForHR( hr );

        if (!DsUtils.ShowCapPinDialog(capGraph, capFilter, this.Handle))
          return false;

        AMMediaType media = new AMMediaType();
        media.majorType  = MediaType.Video;
        media.subType  = MediaSubType.RGB24;
        media.formatType = FormatType.VideoInfo;    // ???
        hr = sampGrabber.SetMediaType( media );
        if( hr < 0 )
          Marshal.ThrowExceptionForHR( hr );

        hr = graphBuilder.AddFilter( baseGrabFlt, "Ds.NET Grabber" );
        if( hr < 0 )
          Marshal.ThrowExceptionForHR( hr );

        Guid cat = PinCategory.Preview;
        Guid med = MediaType.Video;
        hr = capGraph.RenderStream( ref cat, ref med, capFilter, null, null ); // baseGrabFlt 
        if( hr < 0 )
          Marshal.ThrowExceptionForHR( hr );

        cat = PinCategory.Capture;
        med = MediaType.Video;
        hr = capGraph.RenderStream( ref cat, ref med, capFilter, null, baseGrabFlt ); // baseGrabFlt 
        if( hr < 0 )
          Marshal.ThrowExceptionForHR( hr );

        media = new AMMediaType();
        hr = sampGrabber.GetConnectedMediaType( media );
        if( hr < 0 )
          Marshal.ThrowExceptionForHR( hr );
        if( (media.formatType != FormatType.VideoInfo) || (media.formatPtr == IntPtr.Zero) )
          throw new NotSupportedException( "Unknown Grabber Media Format" );

        videoInfoHeader = (VideoInfoHeader) Marshal.PtrToStructure( media.formatPtr, typeof(VideoInfoHeader) );
        Marshal.FreeCoTaskMem( media.formatPtr ); media.formatPtr = IntPtr.Zero;

        hr = sampGrabber.SetBufferSamples( false );
        if( hr == 0 )
          hr = sampGrabber.SetOneShot( false );
        if( hr == 0 )
          hr = sampGrabber.SetCallback( null, 0 );
        if( hr < 0 )
          Marshal.ThrowExceptionForHR( hr );

        return true;
      }
      catch( Exception ee )
      {
        MessageBox.Show( this, "Could not setup graph\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
        return false;
      }
    }


    /// <summary> create the used COM components and get the interfaces. </summary>
    bool GetInterfaces()
    {
      Type comType = null;
      object comObj = null;
      try 
      {
        comType = Type.GetTypeFromCLSID( Clsid.FilterGraph );
        if( comType == null )
          throw new NotImplementedException( @"DirectShow FilterGraph not installed/registered!" );
        comObj = Activator.CreateInstance( comType );
        graphBuilder = (IGraphBuilder) comObj; comObj = null;

        Guid clsid = Clsid.CaptureGraphBuilder2;
        Guid riid = typeof(ICaptureGraphBuilder2).GUID;
        comObj = DsBugWO.CreateDsInstance( ref clsid, ref riid );
        capGraph = (ICaptureGraphBuilder2) comObj; comObj = null;

        comType = Type.GetTypeFromCLSID( Clsid.SampleGrabber );
        if( comType == null )
          throw new NotImplementedException( @"DirectShow SampleGrabber not installed/registered!" );
        comObj = Activator.CreateInstance( comType );
        sampGrabber = (ISampleGrabber) comObj; comObj = null;

        mediaCtrl  = (IMediaControl)  graphBuilder;
        videoWin  = (IVideoWindow)  graphBuilder;
        mediaEvt  = (IMediaEventEx)  graphBuilder;
        baseGrabFlt  = (IBaseFilter)    sampGrabber;
        return true;
      }
      catch( Exception ee )
      {
        MessageBox.Show( this, "Could not get interfaces\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
        return false;
      }
      finally
      {
        if( comObj != null )
          Marshal.ReleaseComObject( comObj ); comObj = null;
      }
    }

    /// <summary> create the user selected capture device. </summary>
    bool CreateCaptureDevice( UCOMIMoniker mon )
    {
      object capObj = null;
      try 
      {
        Guid gbf = typeof( IBaseFilter ).GUID;
        mon.BindToObject( null, null, ref gbf, out capObj );
        capFilter = (IBaseFilter) capObj; capObj = null;
        return true;
      }
      catch( Exception ee )
      {
        MessageBox.Show( this, "Could not create capture device\r\n" + ee.Message, "DirectShow.NET", MessageBoxButtons.OK, MessageBoxIcon.Stop );
        return false;
      }
      finally
      {
        if( capObj != null )
          Marshal.ReleaseComObject( capObj ); capObj = null;
      }

    }

    /// <summary> do cleanup and release DirectShow. </summary>
    void CloseInterfaces()
    {
      int hr;
      try 
      {
      #if DEBUG
        if( rotCookie != 0 )
          DsROT.RemoveGraphFromRot( ref rotCookie );
      #endif

        if( mediaCtrl != null )
        {
          hr = mediaCtrl.Stop();
          mediaCtrl = null;
        }

        if( mediaEvt != null )
        {
          hr = mediaEvt.SetNotifyWindow( IntPtr.Zero, WM_GRAPHNOTIFY, IntPtr.Zero );
          mediaEvt = null;
        }

        if( videoWin != null )
        {
          hr = videoWin.put_Visible( DsHlp.OAFALSE );
          hr = videoWin.put_Owner( IntPtr.Zero );
          videoWin = null;
        }

        baseGrabFlt = null;
        if( sampGrabber != null )
          Marshal.ReleaseComObject( sampGrabber ); sampGrabber = null;

        if( capGraph != null )
          Marshal.ReleaseComObject( capGraph ); capGraph = null;

        if( graphBuilder != null )
          Marshal.ReleaseComObject( graphBuilder ); graphBuilder = null;

        if( capFilter != null )
          Marshal.ReleaseComObject( capFilter ); capFilter = null;
      
        if( capDevices != null )
        {
          foreach( DsDevice d in capDevices )
            d.Dispose();
          capDevices = null;
        }
      }
      catch( Exception )
      {}
    }

    /// <summary> resize preview video window to fill client area. </summary>
    void ResizeVideoWindow()
    {
      if( videoWin != null )
      {
        Rectangle rc = picPreview.ClientRectangle;
        videoWin.SetWindowPosition( 0, 0, rc.Right, rc.Bottom );
      }
    }

    /// <summary> override window fn to handle graph events. </summary>
    protected override void WndProc( ref Message m )
    {
      if( m.Msg == WM_GRAPHNOTIFY )
      {
        if( mediaEvt != null )
          OnGraphNotify();
        return;
      }
      base.WndProc( ref m );
    }

    /// <summary> graph event (WM_GRAPHNOTIFY) handler. </summary>
    void OnGraphNotify()
    {
      DsEvCode  code;
      int p1, p2, hr = 0;
      do
      {
        hr = mediaEvt.GetEvent( out code, out p1, out p2, 0 );
        if( hr < 0 )
          break;
        hr = mediaEvt.FreeEventParams( code, p1, p2 );
      }
      while( hr == 0 );
    }

    /// <summary> sample callback, NOT USED. </summary>
    int ISampleGrabberCB.SampleCB( double SampleTime, IMediaSample pSample )
    { return 0; }

    /// <summary> buffer callback, COULD BE FROM FOREIGN THREAD. </summary>
    int ISampleGrabberCB.BufferCB( double SampleTime, IntPtr pBuffer, int BufferLen )
    {
      if (captured || (savedArray == null))
        return 0;

      captured = true;
      bufferedSize = BufferLen;
      if( (pBuffer != IntPtr.Zero) && (BufferLen > 1000) && (BufferLen <= savedArray.Length) )
        Marshal.Copy( pBuffer, savedArray, 0, BufferLen );
      this.BeginInvoke( new CaptureDone( this.OnCaptureDone ) );
      return 0;
    }

    #region Capture Device Variables
    
    private IBaseFilter capFilter;          // Base filter of the actually used video devices
    private IGraphBuilder graphBuilder;     // Graph builder interface
    private ICaptureGraphBuilder2 capGraph; // Capture graph builder interface
    private ISampleGrabber sampGrabber;     // Sample graph builder interface
    private IMediaControl mediaCtrl;        // Control interface
    private IMediaEventEx mediaEvt;         // Event interface
    private IVideoWindow videoWin;          // Video window interface
    private IBaseFilter baseGrabFlt;        // Grabber filter interface
    private byte [] savedArray;             // Buffer for bitmap data

    // Structure describing the bitmap to grab
    private VideoInfoHeader videoInfoHeader;
    private bool captured = true;
    private bool captureDone = false;
    private int bufferedSize;

    // List of installed video devices.
    private ArrayList capDevices;

    // Message from graph
    private const int WM_GRAPHNOTIFY    = 0x00008001;

    // Attributes for video window
    private const int WS_CHILD          = 0x40000000;
    private const int WS_CLIPCHILDREN   = 0x02000000;
    private const int WS_CLIPSIBLINGS   = 0x04000000;
    
    // Event when callback has finished (ISampleGrabberCB.BufferCB).
    private delegate void CaptureDone ();

    #if DEBUG
    private int    rotCookie = 0;
    #endif
    
    internal enum PlayState
    { Init, Stopped, Paused, Running }
    
    #endregion
    
    #endregion
    
  }

}
