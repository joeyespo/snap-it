using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Runtime.InteropServices;

using DShowNET;
using DShowNET.Device;

namespace SnapIt
{


  /// <summary> Dialog to let user select a capture device if more then one installed. </summary>
  public class DeviceSelector : System.Windows.Forms.Form
  {
    private System.Windows.Forms.Button okButton;
    private System.Windows.Forms.Button cancelButton;
    private System.Windows.Forms.ListView deviceListVw;
    private System.Windows.Forms.ColumnHeader nameColHd;
    /// <summary> Required designer variable. </summary>
    private System.ComponentModel.Container components = null;

    public DeviceSelector( ArrayList devs )
    {
      // Required for Windows Form Designer support
      InitializeComponent();

      ListViewItem item = null;
      foreach( DsDevice d in devs )
      {
        item = new ListViewItem( d.Name );
        item.Tag = d;
        deviceListVw.Items.Add( item );
      }
    }

    /// <summary> Clean up any resources being used. </summary>
    protected override void Dispose( bool disposing )
    {
      if( disposing )
      {
        if(components != null)
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
      this.deviceListVw = new System.Windows.Forms.ListView();
      this.nameColHd = new System.Windows.Forms.ColumnHeader();
      this.okButton = new System.Windows.Forms.Button();
      this.cancelButton = new System.Windows.Forms.Button();
      this.SuspendLayout();
      // 
      // deviceListVw
      // 
      this.deviceListVw.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
        | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.deviceListVw.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
                                                                                   this.nameColHd});
      this.deviceListVw.FullRowSelect = true;
      this.deviceListVw.GridLines = true;
      this.deviceListVw.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
      this.deviceListVw.HideSelection = false;
      this.deviceListVw.Location = new System.Drawing.Point(8, 8);
      this.deviceListVw.MultiSelect = false;
      this.deviceListVw.Name = "deviceListVw";
      this.deviceListVw.Size = new System.Drawing.Size(344, 112);
      this.deviceListVw.TabIndex = 0;
      this.deviceListVw.View = System.Windows.Forms.View.Details;
      this.deviceListVw.DoubleClick += new System.EventHandler(this.deviceListVw_DoubleClick);
      // 
      // nameColHd
      // 
      this.nameColHd.Text = "Name";
      this.nameColHd.Width = 340;
      // 
      // okButton
      // 
      this.okButton.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
      this.okButton.Location = new System.Drawing.Point(108, 130);
      this.okButton.Name = "okButton";
      this.okButton.Size = new System.Drawing.Size(62, 24);
      this.okButton.TabIndex = 1;
      this.okButton.Text = "OK";
      this.okButton.Click += new System.EventHandler(this.okButton_Click);
      // 
      // cancelButton
      // 
      this.cancelButton.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
        | System.Windows.Forms.AnchorStyles.Right);
      this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
      this.cancelButton.Location = new System.Drawing.Point(188, 130);
      this.cancelButton.Name = "cancelButton";
      this.cancelButton.Size = new System.Drawing.Size(62, 24);
      this.cancelButton.TabIndex = 1;
      this.cancelButton.Text = "Cancel";
      this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
      // 
      // DeviceSelector
      // 
      this.AcceptButton = this.okButton;
      this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
      this.CancelButton = this.cancelButton;
      this.ClientSize = new System.Drawing.Size(358, 159);
      this.Controls.AddRange(new System.Windows.Forms.Control[] {
                                                                  this.okButton,
                                                                  this.deviceListVw,
                                                                  this.cancelButton});
      this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
      this.MaximizeBox = false;
      this.MinimizeBox = false;
      this.Name = "DeviceSelector";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
      this.Text = "Select video capture device";
      this.ResumeLayout(false);

    }
		#endregion


    private void deviceListVw_DoubleClick(object sender, System.EventArgs e)
    {
      this.okButton_Click( sender, e );
    }

    private void okButton_Click(object sender, System.EventArgs e)
    {
      if( deviceListVw.SelectedItems.Count != 1 )
        return;
      ListViewItem selitem = deviceListVw.SelectedItems[0];
      SelectedDevice = selitem.Tag as DsDevice;
      Close();
    }

    private void cancelButton_Click(object sender, System.EventArgs e)
    {
      Close();
    }

    public DsDevice		SelectedDevice;
  }

}
