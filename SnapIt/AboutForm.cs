using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace SnapIt
{
    /// <summary>
    /// Summary description for AboutForm.
    /// </summary>
    public partial class AboutForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="AboutForm"/> class.
        /// </summary>
        public AboutForm()
        {
            InitializeComponent();

            lblTitle.Text = AppTitle;
            lblDescription.Text = AppDescription;
        }

        #region Event Handler Methods

        /// <summary>
        /// Handles the Load event of the AboutForm control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void AboutForm_Load(object sender, System.EventArgs e)
        {
            string m_strProductVersion;
            string m_strVersion;
            string m_strRevision;
            int i;

            m_strProductVersion = System.Windows.Forms.Application.ProductVersion;

            i = m_strProductVersion.IndexOf(".");
            if(i >= 0)
                i = m_strProductVersion.IndexOf(".", (i + 1));
            m_strVersion = ((i >= 0) ? (m_strProductVersion.Substring(0, i)) : ("0"));

            if(i >= 0)
                i = m_strProductVersion.IndexOf(".", (i + 1));
            m_strRevision = ((i >= 0) ? (m_strProductVersion.Substring(i + 1)) : ("0"));

            lblVersion.Text = "Version: " + m_strVersion;
            lblRevision.Text = "[Revision: " + m_strRevision + "]";
        }

        /// <summary>
        /// Handles the LinkClicked event of the lnkWebLink control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.Windows.Forms.LinkLabelLinkClickedEventArgs"/> instance containing the event data.</param>
        private void lnkWebLink_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            try
            {
                // Call the Process.Start method to open the default browser with a URL:
                System.Diagnostics.Process.Start("http://www.uber-ware.com");
            }
            catch(Win32Exception)
            {
            }
            catch
            {
                // Failsafe
                MessageBox.Show(this, "Could not start browser process.", "Czt", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Handles the MouseEnter event of the lnkWebLink control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lnkWebLink_MouseEnter(object sender, System.EventArgs e)
        {
            lnkWebLink.LinkColor = lnkWebLink.ActiveLinkColor;
        }

        /// <summary>
        /// Handles the MouseLeave event of the lnkWebLink control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lnkWebLink_MouseLeave(object sender, System.EventArgs e)
        {
            lnkWebLink.LinkColor = lnkWebLink.ForeColor;
        }

        /// <summary>
        /// Handles the Resize event of the lblVersion control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="System.EventArgs"/> instance containing the event data.</param>
        private void lblVersion_Resize(object sender, System.EventArgs e)
        {
            lblRevision.Left = lblVersion.Left + lblVersion.Width;
        }

        #endregion

        // Constant values
        const string AppTitle = "SnapIt";
        const string AppDescription = "SnapIt is a tool that enables a user to take snapshots via an input device at a given interval.";
        // >> Icon is located on the window

        private Label lblVersion;
        private PictureBox picLogo;
        private Panel panAbout;
        private LinkLabel lnkWebLink;
        private Label lblWebTitle;
        private Label lblAuthor;
        private Panel picDescription;
        private Label lblDescription;
        private Label lblTitle;
        private Button btnClose;
        private Label lblRevision;
    }
}
