using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Uberware.Tools;

namespace SnapIt
{
    /// <summary>
    /// Summary description for MainForm.
    /// </summary>
    public partial class MainForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MainForm"/> class.
        /// </summary>
        public MainForm()
        {
            InitializeComponent();
        }

        #region Event Handler Methods

        /// <summary>
        /// Handles the Load event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MainForm_Load(object sender, System.EventArgs e)
        {
            txtPath.Text = GetImagePath(txtPath.Text);
            txtPath.SelectionStart = txtPath.Text.Length;
            numFreq_ValueChanged(sender, new EventArgs());
        }

        /// <summary>
        /// Handles the Activated event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MainForm_Activated(object sender, System.EventArgs e)
        {
            if(firstActive)
                return;
            firstActive = true;

            Application.DoEvents();
            StartCam();
        }

        /// <summary>
        /// Handles the Closing event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.ComponentModel.CancelEventArgs"/> instance containing the event data.</param>
        private void MainForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if(forceClose)
                return;

            e.Cancel = true;
            this.Hide();
        }

        /// <summary>
        /// Handles the Click event of the btnGrab control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnGrab_Click(object sender, System.EventArgs e)
        {
            GrabImage();
        }

        /// <summary>
        /// Handles the Click event of the btnSave control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSave_Click(object sender, System.EventArgs e)
        {
            SaveImage();
        }

        /// <summary>
        /// Handles the Click event of the btnExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnExit_Click(object sender, System.EventArgs e)
        {
            forceClose = true;
            this.Close();
        }

        /// <summary>
        /// Handles the Click event of the btnHide control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnHide_Click(object sender, System.EventArgs e)
        {
            this.Hide();
        }

        /// <summary>
        /// Handles the DoubleClick event of the trayIcon control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void trayIcon_DoubleClick(object sender, System.EventArgs e)
        {
            this.Show();
            this.Focus();
        }

        /// <summary>
        /// Handles the Click event of the menuTrayShow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void menuTrayShow_Click(object sender, System.EventArgs e)
        {
            trayIcon_DoubleClick(sender, new EventArgs());
        }

        /// <summary>
        /// Handles the Click event of the menuTrayExit control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void menuTrayExit_Click(object sender, System.EventArgs e)
        {
            btnExit_Click(sender, new EventArgs());
        }

        private void btnAbout_Click(object sender, System.EventArgs e)
        {
            (new AboutForm()).ShowDialog(this);
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkActive control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkActive_CheckedChanged(object sender, System.EventArgs e)
        {
            // Failsafe
            if(chkActive.Checked)
            {
                if(!CheckImagePath())
                {
                    chkActive.Checked = false;
                    return;
                }
            }

            // Enable/disable controls
            tmrSnapshot.Enabled = chkActive.Checked;
            chkActive.BackColor = ((chkActive.Checked) ? (Color.Firebrick) : (Color.FromKnownColor(KnownColor.Control)));

            lblCount.Enabled = chkActive.Checked;
            txtCount.Enabled = chkActive.Checked;
            cSnapshots = 0;
            txtCount.Text = cSnapshots.ToString();
            btnTakeShot.Enabled = chkActive.Checked;
            lblLastTaken.Enabled = chkActive.Checked;
            txtLastTaken.Enabled = chkActive.Checked;
            txtLastTaken.Text = "(None)";

            // Save first image, if enabled
            if(tmrSnapshot.Enabled)
            {
                tmrSnapshot_Tick(sender, new EventArgs());
            }
        }

        /// <summary>
        /// Handles the Click event of the btnTakeShot control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnTakeShot_Click(object sender, System.EventArgs e)
        {
            tmrSnapshot.Stop();
            tmrSnapshot.Start();
            tmrSnapshot_Tick(sender, new EventArgs());
        }

        /// <summary>
        /// Handles the ValueChanged event of the numFreq control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void numFreq_ValueChanged(object sender, System.EventArgs e)
        {
            tmrSnapshot.Interval = (int)(numFreq.Value * 1000);
        }

        /// <summary>
        /// Handles the Leave event of the numFreq control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void numFreq_Leave(object sender, System.EventArgs e)
        {
            numFreq_ValueChanged(sender, new EventArgs());
        }

        /// <summary>
        /// Handles the Leave event of the txtPath control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void txtPath_Leave(object sender, System.EventArgs e)
        {
            CheckImagePath();
        }

        /// <summary>
        /// Handles the Tick event of the tmrSnapshot control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void tmrSnapshot_Tick(object sender, System.EventArgs e)
        {
            SnapshotImage();
        }

        /// <summary>
        /// Handles the VisibleChanged event of the MainForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void MainForm_VisibleChanged(object sender, System.EventArgs e)
        {
            UpdateShowPreview();
        }

        /// <summary>
        /// Handles the CheckedChanged event of the chkPreview control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void chkPreview_CheckedChanged(object sender, System.EventArgs e)
        {
            UpdateShowPreview();
        }

        /// <summary>
        /// Handles the LinkClicked event of the lnkOpenFolder control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void lnkOpenFolder_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            if(CheckImagePath())
            {
                try
                {
                    // Call the Process.Start method to open the default file browser with a path:
                    System.Diagnostics.Process.Start(txtPath.Text);
                }
                catch(Win32Exception)
                {
                }
                catch
                {
                    // Failsafe
                    MessageBox.Show(this, "Could not start browser process.", "SnapIt", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        /// <summary>
        /// Handles the LinkClicked event of the lnkCamError control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void lnkCamError_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            StartCam();
        }

        /// <summary>
        /// Handles the Click event of the btnSettings control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void btnSettings_Click(object sender, System.EventArgs e)
        {
            if(m_Cam == null)
            {
                MessageBox.Show("Could not connect to device.", "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            // !!!!! Create own settings window
            m_Cam.ShowDlgVideoSource();
            m_Cam.ShowDlgVideoFormat();
        }

        #endregion

        #region Camera Methods

        /// <summary>
        /// Starts the camera.
        /// </summary>
        private void StartCam()
        {
            try
            {
                // Hide error (if any)
                lblCamError.Visible = false;
                lblCamErrorTitle.Visible = false;
                lnkCamError.Visible = false;
                picPreview.BackColor = picSnapshot.BackColor;
                picPreview.Update();

                // Show status
                lblCamError.BackColor = picPreview.BackColor;
                lblCamError.Text = "Connecting to Device - Please wait ...";
                lblCamError.Visible = true;
                lblCamError.Update();

                // Get WebCam
                m_Cam = new CamTool(this);

                // Start preview
                try
                {
                    m_Cam.PreviewRate = int.Parse(txtPreviewRate.Text);
                }
                catch
                {
                    m_Cam.PreviewRate = 60;
                    txtPreviewRate.Text = "60";
                }
                UpdateShowPreview();

                // Hide status
                lblCamError.Visible = false;
            }
            catch(CamException e)
            {
                m_Cam = null;
                lblCamError.Visible = false;

                lblCamErrorTitle.Text = e.Message;
                lblCamError.Text = "Please check the device connection and make sure that the device is not being used by another application or user. Click the link below to try again.";

                picPreview.BackColor = lblCamErrorTitle.BackColor;
                lblCamError.BackColor = picPreview.BackColor;
                lnkCamError.Visible = true;
                lblCamErrorTitle.Visible = true;
                lblCamError.Visible = true;
            }
        }

        /// <summary>
        /// Updates the show preview.
        /// </summary>
        private void UpdateShowPreview()
        {
            // Failsafe
            if(m_Cam == null)
                return;

            // Update preview
            if((chkPreview.Checked) && (Visible) && (WindowState != FormWindowState.Minimized))
                m_Cam.SetPreviewCallback(new CamPreviewCallback(UpdatePreview));
            else
            {
                m_Cam.SetPreviewCallback(null);
                picPreview.Image = null;
            }
        }

        /// <summary>
        /// Updates the preview.
        /// </summary>
        private void UpdatePreview(Image PreviewImage)
        {
            picPreview.Image = PreviewImage;

            if(picPreview.Image == null)
            {
                if(lblCamError.Visible == false)
                {
                    lblCamErrorTitle.Text = "Could not decode image.";
                    lblCamError.Text = "Please check the device settings and make sure that the compression can be decoded.";

                    picPreview.BackColor = lblCamErrorTitle.BackColor;
                    lblCamError.BackColor = picPreview.BackColor;
                    lnkCamError.Visible = false;
                    lblCamErrorTitle.Visible = true;
                    lblCamError.Visible = true;
                }
            }
            else if(lblCamError.Visible)
            {
                lblCamError.Visible = false;
                lblCamErrorTitle.Visible = false;
                lnkCamError.Visible = false;
                picPreview.BackColor = picSnapshot.BackColor;
            }
        }

        #endregion

        #region Image Functions

        /// <summary>
        /// Checks the image path.
        /// </summary>
        private bool CheckImagePath()
        {
            if(txtPath.Text.IndexOfAny(Path.GetInvalidPathChars()) != -1)
            {
                MessageBox.Show(this, "Paths cannot contain any of the following characters: " + new string(Path.GetInvalidPathChars()), "Invalid Path");
                txtPath.Focus();
                return false;
            }

            string s = GetImagePath(txtPath.Text);

            if(!Directory.Exists(s))
            {
                if(MessageBox.Show(this, "Path does not exist; create?\n\n" + s, "Create Path?", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    try
                    {
                        Directory.CreateDirectory(s);
                    }
                    catch(NotSupportedException e)
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

        /// <summary>
        /// Gets the image path.
        /// </summary>
        private string GetImagePath(string path)
        {
            if(!Path.IsPathRooted(path))
                return Path.Combine(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "My Pictures"), path);
            else
                return Path.Combine(path, "");
        }

        /// <summary>
        /// Gets the name of the image file.
        /// </summary>
        private string GetImageFileName(string path, DateTime time)
        {
            string filename = "", ext = ".jpg";

            filename = GetImagePath(path);
            if(!Directory.Exists(filename))
                return "";

            filename += "\\";
            filename += time.Year.ToString().PadLeft(4, '0') + "-" + time.Month.ToString().PadLeft(2, '0') + "-" + time.Day.ToString().PadLeft(2, '0') + " ";
            filename += time.Hour.ToString().PadLeft(2, '0') + "." + time.Minute.ToString().PadLeft(2, '0');

            // Create unique file
            int i = 1;
            while(File.Exists((filename + " - " + i) + ext))
                i++;
            filename += " - " + i;

            return (filename + ext);
        }

        /// <summary>
        /// Saves the image.
        /// </summary>
        private void SaveImage(string Filename, Image img)
        {
            if(img == null)
                return;
            img.Save(Filename, ImageFormat.Jpeg);
        }
        /// <summary>
        /// Saves the image.
        /// </summary>
        private void SaveImage(string Filename)
        {
            SaveImage(Filename, picSnapshot.Image);
        }
        /// <summary>
        /// Saves the image.
        /// </summary>
        private void SaveImage()
        {
            Image img = new Bitmap(picSnapshot.Image);
            SaveFileDialog sd = new SaveFileDialog();
            sd.FileName = "SnapIt.jpg";
            sd.Title = "Save Image as...";
            sd.Filter = "JPEG file (*.jpg)|*.jpg";
            sd.FilterIndex = 1;
            if(sd.ShowDialog() == DialogResult.OK)
                SaveImage(sd.FileName, img);
            img = null;
        }

        /// <summary>
        /// Takes a snapshot of the image.
        /// </summary>
        private bool SnapshotImage()
        {
            if(!GrabImage())
                return false;

            DateTime now = DateTime.Now;
            txtLastTaken.Text = now.ToShortDateString() + " " + now.ToLongTimeString();

            SaveImage(GetImageFileName(txtPath.Text, now));
            cSnapshots++;
            txtCount.Text = cSnapshots.ToString();
            return true;
        }

        /// <summary>
        /// Grabs the image.
        /// </summary>
        private bool GrabImage()
        {
            if(m_Cam == null)
                return false;

            picSnapshot.Image = m_Cam.GrabFrame();
            btnSave.Enabled = (picSnapshot.Image != null);
            return true;
        }

        #endregion

        private bool firstActive = false;
        private bool forceClose = false;

        private CamTool m_Cam = null;
        private int cSnapshots = 0;
    }
}
