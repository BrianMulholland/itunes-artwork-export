using iTunesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;

namespace iTunes_Artwork_Export
{
  public class Track
  {
    private readonly PersistentID _persistentID;
    public PersistentID PersistentID { get { return this._persistentID; } }

    private readonly string _filePath;
    public string FilePath { get { return this._filePath; } }

    private readonly string _artist;
    public string Artist { get { return this._artist; } }

    private readonly string _albumArtist;
    public string AlbumArtist { get { return this._albumArtist; } }

    private readonly string _album;
    public string Album { get { return this._album; } }

    private readonly string _title;
    public string Title { get { return this._title; } }

    private readonly int _trackNumber;
    public int TrackNumber { get { return this._trackNumber; } }

    private readonly int _artworkCount;
    public int ArtworkCount { get { return this._artworkCount; } }

    public bool FilePathIsDirectory
    {
      get
      {
        try
        {
          DirectoryInfo di = new DirectoryInfo(this.FilePath);
          return (di.Exists);
        }
        catch (Exception)
        {
          return false;
        }
      }
    }

    public string Directory
    {
      get
      {
        string returnValue = string.Empty;

        try
        {
          FileInfo fi = new FileInfo(this.FilePath);
          if (fi.Exists)
          {
            returnValue = fi.DirectoryName;
          }
          else
          {
            if (this.FilePathIsDirectory)
            {
              // If it's a directory, then it's probably an iTunes "track" that's really a directory (like an iTunes LP) - so return the parent directory.
              returnValue = new DirectoryInfo(this.FilePath).Parent.FullName;
            }
          }
        }
        catch (Exception)
        {
          returnValue = string.Empty;
        }

        return returnValue;
      }
    }

    public Track(PersistentID persistentID, string filePath, string artist, string albumArtist, string album, string title, int trackNumber, int artworkCount)
    {
      this._persistentID = persistentID;
      this._filePath = (string.IsNullOrEmpty(filePath) ? string.Empty : filePath.Trim());
      this._artist = (string.IsNullOrEmpty(artist) ? string.Empty : artist.Trim());
      this._albumArtist = (string.IsNullOrEmpty(albumArtist) ? string.Empty : albumArtist.Trim());
      this._album = (string.IsNullOrEmpty(album) ? string.Empty : album.Trim());
      this._title = (string.IsNullOrEmpty(title) ? string.Empty : title.Trim());
      this._trackNumber = trackNumber;
      this._artworkCount = artworkCount;

      CheckFilePath();
    }

    private void CheckFilePath()
    {
      FileInfo filePathInfo = new FileInfo(this.FilePath);
      bool fileExists = filePathInfo.Exists;
      bool isDirectory = (new DirectoryInfo(this.FilePath).Exists);

      if (!fileExists && !isDirectory)
      {
        throw new ArgumentException("Invalid file path.  " + this.ToString(true, false));
      }

      if (string.IsNullOrEmpty(this.Directory))
      {
        throw new ArgumentException("Could not determine Directory for path \"" + this.FilePath + "\".  " + this.ToString(false, false));
      }
    }

    public static Track GetTrack(IITFileOrCDTrack iFCT, IiTunes iTunesApp)
    {
      string filePath = iFCT.Location;
      string artist = iFCT.Artist;
      string albumArtist = iFCT.AlbumArtist;
      string album = iFCT.Album;
      string title = iFCT.Name;
      int trackNumber = iFCT.TrackNumber;
      int artworkCount = iFCT.Artwork.Count;
      PersistentID persistentID = PersistentID.GetTrackPersistentID(iTunesApp, iFCT);

      Track t = new Track(persistentID, filePath, artist, albumArtist, album, title, trackNumber, artworkCount);
      return t;
    }

    public string ToString(bool showFilePath, bool showPersistentID)
    {
      string trackStart = "[";
      string trackEnd = "]";
      string propertyFormat = "{0} = \"{1}\"";
      string propertySeparator = ",";

      StringBuilder sb = new StringBuilder();
      sb.Append(trackStart);
      sb.Append(" ");
      sb.AppendFormat(propertyFormat, "Artist", this.Artist);
      sb.Append(propertySeparator + " ");
      sb.AppendFormat(propertyFormat, "Title", this.Title);
      sb.Append(propertySeparator + " ");
      sb.AppendFormat(propertyFormat, "Album", this.Album);
      sb.Append(propertySeparator + " ");
      sb.AppendFormat(propertyFormat, "Track #", (this.TrackNumber > 0 ? this.TrackNumber.ToString() : string.Empty));
      if (showFilePath || showPersistentID) { sb.Append(propertySeparator); }
      sb.Append(" ");
      if (showFilePath)
      {
        sb.AppendFormat(propertyFormat, "File Path", this.FilePath);
        if (showPersistentID) { sb.Append(propertySeparator); }
        sb.Append(" ");
      }
      if (showPersistentID)
      {
        sb.AppendFormat(propertyFormat, "Persistent ID", this.PersistentID.PersistentID_UInt64.ToString());
        sb.Append(" ");
      }
      sb.Append(trackEnd);

      return sb.ToString();
    }
  }
}
