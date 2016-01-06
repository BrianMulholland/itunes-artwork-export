using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iTunes_Artwork_Export
{
  public partial class frmSettings : Form
  {
    public frmSettings()
    {
      InitializeComponent();

      InitializeSettingsValues();
    }

    private void InitializeSettingsValues()
    {
      this.txtFileName.Text = iTunes_Artwork_Export.Properties.Settings.Default.FileName;

      switch (iTunes_Artwork_Export.Properties.Settings.Default.UserSeverityLevel)
      {
        case MessageSeverity.Warning :
          rbWarning.Select();
          break;
        case MessageSeverity.Success :
          rbSuccess.Select();
          break;
        case MessageSeverity.Debug :
          rbDebug.Select();
          break;
        default:
          rbSuccess.Select();
          break;
      }

      this.numMinTracks.Value = iTunes_Artwork_Export.Properties.Settings.Default.MinTracks;

      this.numAlbumMatchPercentage.Value = iTunes_Artwork_Export.Properties.Settings.Default.ArtistAlbumMatchPercentage;
    }

    private void btnOK_Click(object sender, EventArgs e)
    {

      try
      {

        // FILE NAME:

        string fileName = this.txtFileName.Text.Trim();

        if (fileName.IndexOfAny(Path.GetInvalidFileNameChars()) >= 0)
        {
          // invalid file name!
          MessageBox.Show("Invalid file name \"" + fileName + "\".", "Error", MessageBoxButtons.OK);
          return;
        }

        iTunes_Artwork_Export.Properties.Settings.Default.FileName = fileName;


        // OUTPUT TEXT SEVERITY LEVEL:

        RadioButton rbSelected = this.groupBoxUserSeverity.Controls.OfType<RadioButton>().Where(rb => rb.Checked == true).FirstOrDefault();
        if (rbSelected.Equals(rbWarning))
        {
          iTunes_Artwork_Export.Properties.Settings.Default.UserSeverityLevel = MessageSeverity.Warning;
        }
        else if (rbSelected.Equals(rbSuccess))
        {
          iTunes_Artwork_Export.Properties.Settings.Default.UserSeverityLevel = MessageSeverity.Success;
        }
        else if (rbSelected.Equals(rbDebug))
        {
          iTunes_Artwork_Export.Properties.Settings.Default.UserSeverityLevel = MessageSeverity.Debug;
        }


        // MIN TRACKS:

        ushort usMinTracks = (ushort)(this.numMinTracks.Value);
        if (usMinTracks >= this.numMinTracks.Minimum && usMinTracks <= this.numMinTracks.Maximum)
        {
          iTunes_Artwork_Export.Properties.Settings.Default.MinTracks = usMinTracks;
        }
        else
        {
          // invalid value for Min Tracks setting:
          MessageBox.Show("Invalid value for Minimum # of Tracks: \"" + usMinTracks.ToString() + "\".", "Error", MessageBoxButtons.OK);
          return;
        }


        // ARTIST ALBUM MATCH PERCENTAGE:

        int albumMatchPercentage = (int)(this.numAlbumMatchPercentage.Value);
        if (albumMatchPercentage >= 0 && albumMatchPercentage <= 100)
        {
          iTunes_Artwork_Export.Properties.Settings.Default.ArtistAlbumMatchPercentage = albumMatchPercentage;
        }
        else
        {
          // invalid value for Album Match Percentage setting:
          MessageBox.Show("Invalid value for Album Match Percentage: \"" + albumMatchPercentage.ToString() + "\".", "Error", MessageBoxButtons.OK);
          return;
        }


        // SAVE CHANGES:

        iTunes_Artwork_Export.Properties.Settings.Default.Save();


        this.Close();
      }
      catch (Exception ex)
      {
        MessageBox.Show("Error saving settings: " + ex.Message, "Error", MessageBoxButtons.OK);
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.Close();
    }
  }
}
