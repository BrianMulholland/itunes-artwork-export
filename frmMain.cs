using iTunesLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iTunes_Artwork_Export
{
  public partial class frmMain : Form
  {
    private iTunesLibrary theLibrary = iTunesLibrary.instance;
    private ExportSettings settings = ExportSettings.instance;

    public frmMain()
    {
      InitializeComponent();

      this.txtMain.Clear();

      bool success = theLibrary.InitializeITunesApp();
      if (success)
      {
        this.DisplayMessage(new OutputMessage("Successfully initialized iTunes App!", MessageSeverity.Always));
        ExportArtwork.PrintLibrarySize(theLibrary, this.DisplayMessage);
      }
      else
      {
        this.DisplayMessage(new OutputMessage("Error initializing iTunes App!", MessageSeverity.Always));
        this.btnDoExport.Enabled = false;
      }

      this.txtMain.DeselectAll();
    }

    private void btnDoExport_Click(object sender, EventArgs e)
    {
      ExportArtwork.DoExport(theLibrary, settings, this.DisplayMessage, this);
      this.txtMain.DeselectAll();
    }

    public void DisplayMessage(OutputMessage outputMessage)
    {
      MessageSeverity userSeverityLevel = settings.UserSeverityLevel;

      if (OutputMessage.CheckDisplayMessage(outputMessage.Severity, userSeverityLevel))
      {
        this.txtMain.Text += outputMessage.Message + Environment.NewLine;
        if (outputMessage.AppendNewLine)
        {
          this.txtMain.Text += Environment.NewLine;
        }
      }
    }
  }
}
