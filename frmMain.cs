using iTunesLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

enum ExportMode
{
  ExportInProgress,
  ExportNotRunning
}

namespace iTunes_Artwork_Export
{
  public partial class frmMain : Form
  {
    private iTunesLibrary theLibrary = iTunesLibrary.instance;
    private ExportSettings settings = ExportSettings.instance;

    private BackgroundWorker bgw = new BackgroundWorker();

    delegate void AppendTextCallback(string message);


    public frmMain()
    {
      InitializeComponent();

      InitializeProgram();
    }

    private void InitializeProgram()
    {
      this.txtMain.Clear();

      this.SetMode(ExportMode.ExportNotRunning);

      this.bgw.WorkerReportsProgress = true;
      this.bgw.WorkerSupportsCancellation = true;
      this.bgw.DoWork += new DoWorkEventHandler(bgw_DoWork);
      this.bgw.ProgressChanged += new ProgressChangedEventHandler(bgw_ProgressChanged);
      this.bgw.RunWorkerCompleted += new RunWorkerCompletedEventHandler(bgw_RunWorkerCompleted);

      this.InitializeITunes();
    }

    private void InitializeITunes()
    {
      if (theLibrary.IsInitialized == false)
      {
        bool success = theLibrary.InitializeITunesApp();
        if (success)
        {
          this.DisplayMessage(new OutputMessage("Successfully initialized iTunes App!", MessageSeverity.Always));
          this.DisplayMessage(new OutputMessage(ExportArtwork.GetLibrarySizeMessage(theLibrary), MessageSeverity.Always, true));
        }
        else
        {
          this.DisplayMessage(new OutputMessage("Error initializing iTunes App!", MessageSeverity.Always));
        }
      }
    }

    private void btnDoExport_Click(object sender, EventArgs e)
    {
      // If the Library isn't initialized yet, try again.
      if (this.theLibrary.IsInitialized == false)
      {
        this.InitializeITunes();
      }

      // If the Library is initialized, continue.  Otherwise, that means it couldn't be initialized above.
      if (this.theLibrary.IsInitialized == true)
      {
        this.SetMode(ExportMode.ExportInProgress);

        // Start the background worker:
        this.bgw.RunWorkerAsync();
      }
      else
      {
        this.DisplayMessage(new OutputMessage("Could not export artwork because the iTunes Library could not be opened.", MessageSeverity.Always, true));
      }
    }

    void bgw_ProgressChanged(object sender, ProgressChangedEventArgs e)
    {
      this.prgBarExport.Value = e.ProgressPercentage;
    }

    void bgw_DoWork(object sender, DoWorkEventArgs e)
    {
      ExportArtwork.DoExport(theLibrary, settings, (BackgroundWorker)sender, e, this.DisplayMessage);
    }

    void bgw_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
    {
      // The background worker is finished - either because it's done exporting, or the user canceled it.

      if (e.Cancelled == true)
      {
        this.DisplayMessage(new OutputMessage("Export was canceled.", MessageSeverity.Always, true));
      }
      else
      {
        this.DisplayMessage(new OutputMessage("Export complete!", MessageSeverity.Always, true));
        this.SetMode(ExportMode.ExportNotRunning);
      }
    }

    private void btnCancel_Click(object sender, EventArgs e)
    {
      this.DisplayMessage(new OutputMessage("Canceling...", MessageSeverity.Always));
      this.bgw.CancelAsync();
      this.SetMode(ExportMode.ExportNotRunning);
    }

    public void DisplayMessage(OutputMessage outputMessage)
    {
      MessageSeverity userSeverityLevel = settings.UserSeverityLevel;

      if (OutputMessage.CheckDisplayMessage(outputMessage.Severity, userSeverityLevel))
      {
        this.AppendText(outputMessage.Message + Environment.NewLine);
        if (outputMessage.AppendNewLine)
        {
          this.AppendText(Environment.NewLine);
        }
      }
    }

    private void AppendText(string message)
    {
      if (this.txtMain.InvokeRequired == true)
      {
        AppendTextCallback d = new AppendTextCallback(AppendText);
        this.Invoke(d, new object[] { message });
      }
      else
      {
        this.txtMain.AppendText(message);
        this.txtMain.DeselectAll();
      }
    }

    private void SetMode(ExportMode em)
    {
      if (em == ExportMode.ExportNotRunning)
      {
        this.btnCancel.Visible = false;
        this.btnDoExport.Enabled = true;
        this.btnDoExport.Text = "Export Artwork!";
        this.prgBarExport.Visible = false;
      }
      else if (em == ExportMode.ExportInProgress)
      {
        this.btnCancel.Visible = true;
        this.btnDoExport.Enabled = false;
        this.btnDoExport.Text = "Exporting...";
        this.prgBarExport.Visible = true;
        this.prgBarExport.Value = 0;
      }
      else
      {
        this.DisplayMessage(new OutputMessage("Invalid ExportMode passed to SetMode().", MessageSeverity.Debug));
      }
    }
  }
}
