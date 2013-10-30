using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunes_Artwork_Export
{
  public class ExportSettings
  {
    private static readonly ExportSettings theSingletonInstance = new ExportSettings();

    private ExportSettings() { }

    public static ExportSettings instance
    {
      get
      {
        return theSingletonInstance;
      }
    }

    public readonly string FileName = "folder.jpg";
    public readonly MessageSeverity UserSeverityLevel = MessageSeverity.Debug;
    public readonly int MinTracks = 3;
    public readonly decimal ArtistAlbumMatchPercentage = 0.9M;
  }
}
