using iTunesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace iTunes_Artwork_Export
{
  public sealed class iTunesLibrary
  {
    // Begin "singleton" code

    private static readonly iTunesLibrary theSingletonInstance = new iTunesLibrary();

    private iTunesLibrary() {}

    public static iTunesLibrary instance
    {
      get
      {
        return theSingletonInstance;
      }
    }

    // End "singleton" code


    private iTunesLib.IiTunes theITunesApp = null;
    private iTunesLib.IITPlaylist theLibraryPlaylist = null;

    public bool InitializeITunesApp()
    {
      this.theITunesApp = null;
      this.theLibraryPlaylist = null;
      string errorMessage = string.Empty;

      try
      {
        this.theITunesApp = new iTunesApp();

        if (this.theITunesApp == null)
        {
          errorMessage = "iTunesApp object is null!";
        }
        else
        {
          this.theLibraryPlaylist = this.theITunesApp.LibraryPlaylist;

          if (this.theLibraryPlaylist == null)
          {
            errorMessage = "Library playlist is null!";
          }
        }
      }
      catch( Exception ex )
      {
        errorMessage = ex.Message;
      }

      if (errorMessage.Length > 0)
      {
        DialogResult dr = MessageBox.Show("Error initializing iTunes application: " + errorMessage, "Error Initializing iTunes Application", MessageBoxButtons.RetryCancel, MessageBoxIcon.Warning);
        if( dr == DialogResult.Retry )
        {
          this.InitializeITunesApp();
        }
      }

      return this.IsInitialized;
    }

    public bool IsInitialized
    {
      get
      {
        if (
          (this.theITunesApp != null)
          && (this.theLibraryPlaylist != null)
        )
        {
          return true;
        }
        else
        {
          return false;
        }
      }
    }

    public int GetLibrarySize()
    {
      // Returns the number of tracks in the Library

      if (this.IsInitialized == true)
      {
        return this.theLibraryPlaylist.Tracks.Count;
      }
      else
      {
        return -1;
      }
    }

    public IiTunes GetITunesApp()
    {
      return this.theITunesApp;
    }

    public IITPlaylist GetLibraryPlaylist()
    {
      if (this.IsInitialized == true)
      {
        return this.theLibraryPlaylist;
      }
      else
      {
        return null;
      }
    }
  }
}
