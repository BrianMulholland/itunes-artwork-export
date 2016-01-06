using iTunesLib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
      // Initialize the Library, if it's not already:
      this.InitializeITunes();

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
      ExportArtwork.DoExport(theLibrary, (BackgroundWorker)sender, e, this.DisplayMessage);
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
      MessageSeverity userSeverityLevel = iTunes_Artwork_Export.Properties.Settings.Default.UserSeverityLevel;

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

    private void exitToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // User clicked Exit, so exit the application.
      Application.Exit();
    }

    private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
    {
      frmSettings settingsDialog = new frmSettings();
      settingsDialog.ShowDialog();
    }

    private void saveOutputToFileToolStripMenuItem_Click(object sender, EventArgs e)
    {
      bool useDefaultOutputDirectory = true;
      string initialOutputDirectory = iTunes_Artwork_Export.Properties.Settings.Default.SaveOutputDirectory;

      if (initialOutputDirectory.Length > 0)
      {
        // the Output Directory was saved in the Settings, so check if it exists - if not, we'll change to a default value.
        DirectoryInfo di = new DirectoryInfo(initialOutputDirectory);
        if (di.Exists)
        {
          useDefaultOutputDirectory = false;
        }
      }

      if (useDefaultOutputDirectory == true)
      {
        initialOutputDirectory = Environment.GetFolderPath(Environment.SpecialFolder.DesktopDirectory);
      }

      SaveFileDialog sfd = new SaveFileDialog();
      sfd.InitialDirectory = initialOutputDirectory;
      sfd.RestoreDirectory = true;
      sfd.DefaultExt = "txt";
      sfd.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
      sfd.CreatePrompt = false;
      sfd.OverwritePrompt = true;
      sfd.ValidateNames = true;

      sfd.FileName = "iTunes Artwork Export Log " + DateTime.Now.ToString("yyyy-MM-dd HHmmss") + ".txt";

      DialogResult drSFD = sfd.ShowDialog();

      if (drSFD == System.Windows.Forms.DialogResult.OK)
      {
        try
        {
          string fileName = sfd.FileName;
          FileStream fsOutput = File.OpenWrite(fileName);
          StreamWriter sw = new StreamWriter(fsOutput);
          sw.AutoFlush = true;
          sw.Write(this.txtMain.Text);
          sw.Flush();
          fsOutput.Close();

          try
          {
            // Save this directory as the new Output Directory, so next time the user wants to
            // export the log, it will start in the same directory by default:
            FileInfo fi = new FileInfo(fileName);
            iTunes_Artwork_Export.Properties.Settings.Default.SaveOutputDirectory = fi.DirectoryName;
            iTunes_Artwork_Export.Properties.Settings.Default.Save();
          }
          catch (Exception exc)
          {
            this.DisplayMessage(new OutputMessage("Error when saving Output Directory setting: " + exc.Message, MessageSeverity.Debug));
          }
        }
        catch (Exception ex)
        {
          this.DisplayMessage(new OutputMessage("Error when writing to file: " + ex.Message, MessageSeverity.Debug));
          MessageBox.Show("Error when writing to file: " + ex.Message, "Error", MessageBoxButtons.OK);
        }
      }
    }

    private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
    {
      // todo: About window
    }
  }
}
