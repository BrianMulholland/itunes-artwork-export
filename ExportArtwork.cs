using iTunesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace iTunes_Artwork_Export
{
  public class ExportArtwork
  {
    public delegate void DisplayMessage(OutputMessage om);

    public static void DoExport(iTunesLibrary library, ExportSettings settings, DisplayMessage dm, frmMain fm)
    {
      List<Track> trackList = BuildLibraryTrackList(library, dm);

      if (trackList.Count == 0)
      {
        dm(new OutputMessage("No tracks could be found in this iTunes library!", MessageSeverity.Error));
      }

      List<string> directoryList = GetDirectoryList(trackList).OrderBy(d => d).ToList();

      foreach (string directory in directoryList)
      {
        try
        {
          OutputMessage outputMessage = ExportDirectoryArtwork(library, trackList, directory, settings);
          if (outputMessage != null)
          {
            dm(outputMessage);
          }
          else
          {
            dm(new OutputMessage("Error while processing directory \"" + directory + "\": No OutputMessage object specified from OutputDirectoryArtwork().", MessageSeverity.Error));
          }
        }
        catch (Exception ex)
        {
          dm(new OutputMessage("Error while processing directory \"" + directory + "\": " + ex.Message, MessageSeverity.Error));
        }

        fm.Refresh();
      }
    }

    public static void PrintLibrarySize(iTunesLibrary library, DisplayMessage dm)
    {
      double librarySize = library.GetLibrarySize();
      string librarySizeMessage = "iTunes Library Size: " + librarySize.ToString();
      dm(new OutputMessage(librarySizeMessage, MessageSeverity.Always, true));
    }

    private static List<Track> BuildLibraryTrackList(iTunesLibrary library, DisplayMessage dm)
    {
      List<Track> trackList = new List<Track>();

      IITPlaylist libraryPlaylist = library.GetLibraryPlaylist();

      if (libraryPlaylist != null)
      {
        foreach (IITTrack track in libraryPlaylist.Tracks)
        {
          if (
            track is IITFileOrCDTrack
            && ((IITFileOrCDTrack)track).Kind == ITTrackKind.ITTrackKindFile
            && ((IITFileOrCDTrack)track).VideoKind == ITVideoKind.ITVideoKindNone
            && ((IITFileOrCDTrack)track).Podcast == false
            && string.Compare(((IITFileOrCDTrack)track).Genre, "Voice Memo") != 0
          )
          {
            try
            {
              IITFileOrCDTrack fileTrack = (IITFileOrCDTrack)track;
              Track tr = Track.GetTrack(fileTrack, library.GetITunesApp());
              trackList.Add(tr);
            }
            catch (Exception ex)
            {
              dm(new OutputMessage("Error: Could not get track information for Track \"" + track.Name + "\", Artist = \"" + track.Artist + "\", Album = \"" + track.Album + "\": " + ex.Message, MessageSeverity.Warning));
            }
          }
          else
          {
            dm(new OutputMessage("Found excluded track \"" + track.Name + "\", Artist = \"" + track.Artist + "\", Album = \"" + track.Album + "\".", MessageSeverity.Debug));
          }
        }
      }
      else
      {
        dm(new OutputMessage("Could not retrieve the library playlist from the iTunes library.", MessageSeverity.Error));
      }

      return trackList;
    }

    private static List<string> GetDirectoryList(List<Track> trackList)
    {
      return trackList.Where(t => !(string.IsNullOrEmpty(t.Directory))).Select(t => t.Directory).Distinct().ToList();
    }

    private static OutputMessage ExportDirectoryArtwork(iTunesLibrary library, List<Track> trackList, string directory, ExportSettings theSettings)
    {
      List<Track> directoryTrackList = trackList.Where(t => t.Directory == directory).ToList();

      int trackCount = directoryTrackList.Count();
      if (trackCount == 0)
      {
        return new OutputMessage("No tracks found in the library for the directory: \"" + directory + "\".", MessageSeverity.Error);
      }

      // Minimum # of tracks in a directory (regardless of whether they have artwork attached)
      if (trackCount < theSettings.MinTracks)
      {
        return new OutputMessage("Not enough tracks in the following directory: \"" + directory + "\" (track count is " + trackCount.ToString() + "; minimum is " + theSettings.MinTracks.ToString() + ").", MessageSeverity.Warning);
      }

      // Check that at least 1 track has artwork attached
      if (directoryTrackList.Where(t => t.ArtworkCount > 0).Count() == 0)
      {
        return new OutputMessage("No artwork found for the tracks in directory: \"" + directory + "\".", MessageSeverity.Warning);
      }

      Track artworkTrack = null;
      try
      {
        artworkTrack = GetArtworkTrack(directoryTrackList, theSettings);
      }
      catch (ArgumentException argEx)
      {
        return new OutputMessage(argEx.Message, MessageSeverity.Error);
      }
      catch (ApplicationException appEx)
      {
        return new OutputMessage(appEx.Message, MessageSeverity.Warning);
      }
      catch (Exception ex)
      {
        return new OutputMessage(ex.Message, MessageSeverity.Error);
      }

      if (artworkTrack == null)
      {
        return new OutputMessage("Error: No artwork track returned for directory \"" + directory + "\".", MessageSeverity.Error);
      }

      PersistentID artworkTrackPersistentID = artworkTrack.PersistentID;
      IITTrack itArtworkTrack = null;
      try
      {
        itArtworkTrack = ExportArtwork.GetTrackByPersistentID(library, artworkTrackPersistentID);
      }
      catch (Exception ex)
      {
        return new OutputMessage("Error when retrieving track by Persistent ID: " + ex.Message + ".  Track: " + artworkTrack.ToString(true, true), MessageSeverity.Error);
      }

      if (itArtworkTrack != null)
      {
        // Found the iTunes Track in the library with the Artwork Track's persistent ID.

        IITArtwork iaArt = GetTrackArtwork(itArtworkTrack);
        if (iaArt != null)
        {
          // Found the artwork on that track.

          DirectoryInfo trackDirectoryInfo = new DirectoryInfo(directory);
          if (trackDirectoryInfo.Exists)
          {
            string outputFileName = directory + "\\" + theSettings.FileName;
            try
            {
              FileInfo fiOutputFile = new FileInfo(outputFileName);
              if (fiOutputFile.Exists)
              {
                return new OutputMessage("File \"" + outputFileName + "\" already exists!", MessageSeverity.Debug);
              }
              else
              {
                try
                {
                  iaArt.SaveArtworkToFile(outputFileName);
                  return new OutputMessage("Saved artwork to: \"" + outputFileName + "\".  Track: " + artworkTrack.ToString(true, false), MessageSeverity.Success);
                }
                catch (Exception ex)
                {
                  return new OutputMessage("Error when attempting to save artwork to: \"" + outputFileName + "\": " + ex.Message, MessageSeverity.Error);
                }
              }
            }
            catch (Exception ex)
            {
              return new OutputMessage("Could not output artwork to \"" + outputFileName + "\": " + ex.Message + ".  Track: " + artworkTrack.ToString(true, false), MessageSeverity.Error);
            }
          }
          else
          {
            return new OutputMessage("Could not output artwork to directory \"" + directory + "\": directory does not exist.  Track: " + artworkTrack.ToString(true, false), MessageSeverity.Error);
          }
        }
        else
        {
          return new OutputMessage("Could not retrieve artwork for Track: " + artworkTrack.ToString(true, false), MessageSeverity.Error);
        }
      }
      else
      {
        return new OutputMessage("Could not retrieve Track by Persistent ID: " + artworkTrack.ToString(true, true), MessageSeverity.Error);
      }
    }


    private static Track GetArtworkTrack(List<Track> directoryTrackList, ExportSettings theSettings)
    {
      // Find the "Artwork Track", the track from this Directory Track List that we'll use to get the artwork from.

      if (directoryTrackList == null || !directoryTrackList.Any())
      {
        throw new ArgumentException("Empty directory track list sent to GetArtworkTrack().");
      }

      Track artworkTrack = null;

      string directory = directoryTrackList.GroupBy(t => t.Directory).OrderByDescending(g => g.Count()).First().Key;
      if (string.IsNullOrEmpty(directory) || directoryTrackList.Where(t => string.Compare(t.Directory, directory) != 0).Any())
      {
        throw new ArgumentException("Invalid directory track list sent to GetArtworkTrack(): all tracks must have the same valid Directory.  Most common directory: \"" + directory + "\".");
      }

      // Find the most common artist
      string mostCommonArtist = directoryTrackList.GroupBy(t => t.Artist).OrderByDescending(g => g.Count()).First().Key;
      if (string.IsNullOrEmpty(mostCommonArtist))
      {
        throw new ApplicationException("Error while attempting to output the artwork for \"" + directory + "\": the most common artist name is blank.");
      }

      // Find the most common album
      string mostCommonAlbum = directoryTrackList.Where(t => t.Artist == mostCommonArtist).GroupBy(t => t.Album).OrderByDescending(g => g.Count()).First().Key;
      if (string.IsNullOrEmpty(mostCommonAlbum))
      {
        throw new ApplicationException("Error while attempting to output the artwork for \"" + directory + "\": the most common album name is blank (most common artist name = \"" + mostCommonArtist + "\").");
      }

      IEnumerable<Track> directoryArtworkTrackList = null;

      // What percentage of tracks in this directory have the most common Artist/Album combination?
      int trackCount = directoryTrackList.Count();
      int mostCommonArtistAlbumCount = directoryTrackList.Where(t => t.Artist == mostCommonArtist).Where(t => t.Album == mostCommonAlbum).Count();
      decimal mostCommonArtistAlbumMatchPercentage = (decimal)mostCommonArtistAlbumCount / (decimal)trackCount;
      if (mostCommonArtistAlbumMatchPercentage < theSettings.ArtistAlbumMatchPercentage)
      {
        string mostCommonAlbumArtist = null;
        if (directoryTrackList.Where(t => !string.IsNullOrEmpty(t.AlbumArtist)).Any())
        {
          mostCommonAlbumArtist = directoryTrackList.Where(t => !string.IsNullOrEmpty(t.AlbumArtist)).GroupBy(t => t.AlbumArtist).OrderByDescending(g => g.Count()).First().Key;
        }

        if (!string.IsNullOrEmpty(mostCommonAlbumArtist))
        {
          int mostCommonAlbumArtistAlbumCount = directoryTrackList.Where(t => t.AlbumArtist == mostCommonAlbumArtist).Where(t => t.Album == mostCommonAlbum).Count();
          decimal mostCommonAlbumArtistAlbumMatchPercentage = (decimal)mostCommonAlbumArtistAlbumCount / (decimal)trackCount;
          if (mostCommonAlbumArtistAlbumMatchPercentage < theSettings.ArtistAlbumMatchPercentage)
          {
            throw new ApplicationException("Could not output the artwork for \"" + directory + "\": less than " + Math.Round(theSettings.ArtistAlbumMatchPercentage * 100.0M, 1).ToString() + "% of tracks in this folder had the most common artist (\"" + mostCommonArtist + "\") / album artist (\"" + mostCommonAlbumArtist + "\") and album (\"" + mostCommonAlbum + "\") (actual amount is " + Math.Round(mostCommonArtistAlbumMatchPercentage * 100.0M, 1) + "%).");
          }
          else
          {
            directoryArtworkTrackList = directoryTrackList.Where(t => t.AlbumArtist == mostCommonAlbumArtist).Where(t => t.Album == mostCommonAlbum).Where(t => t.ArtworkCount > 0);
          }
        }
        else
        {
          throw new ApplicationException("Could not output the artwork for \"" + directory + "\": less than " + Math.Round(theSettings.ArtistAlbumMatchPercentage * 100.0M, 1).ToString() + "% of tracks in this folder had the most common artist (\"" + mostCommonArtist + "\") and album (\"" + mostCommonAlbum + "\") (actual amount is " + Math.Round(mostCommonArtistAlbumMatchPercentage * 100.0M, 1) + "%).");
        }
      }
      else
      {
        directoryArtworkTrackList = directoryTrackList.Where(t => t.Artist == mostCommonArtist).Where(t => t.Album == mostCommonAlbum).Where(t => t.ArtworkCount > 0);
      }

      try
      {
        if (directoryArtworkTrackList != null && directoryArtworkTrackList.Any())
        {
          artworkTrack = directoryArtworkTrackList.OrderBy(t => t.Title).OrderBy(t => t.TrackNumber).OrderByDescending(t => (t.TrackNumber > 0)).First();
        }
        else
        {
          // If none of the tracks with the most common Artist/Album combination have artwork, error
          throw new ApplicationException("Could not output the artwork for \"" + directory + "\": no tracks with the most common artist (\"" + mostCommonArtist + "\") and album (\"" + mostCommonAlbum + "\") have artwork attached.");
        }
      }
      catch (Exception ex)
      {
        throw new ApplicationException("Error occurred while attempting to determine the artwork track for directory \"" + directory + "\"; most common artist = \"" + mostCommonArtist + "\", most common album = \"" + mostCommonAlbum + "\".  " + ex.Message);
      }

      return artworkTrack;
    }

    private static IITTrack GetTrackByPersistentID(iTunesLibrary library, PersistentID persistentID)
    {
      return library.GetLibraryPlaylist().Tracks.get_ItemByPersistentID(persistentID.HighBits, persistentID.LowBits);
    }

    public static IITArtwork GetTrackArtwork(IITTrack t)
    {
      IITArtwork theArtwork = null;

      if (t.Artwork.Count > 1)
      {
        long maxFileSize = 0;

        foreach (IITArtwork a in t.Artwork)
        {
          //bool isDownloaded = a.IsDownloadedArtwork;
          //string desc = a.Description;
          //ITArtworkFormat af = a.Format;
          //Type ty = af.GetType();

          try
          {
            string tempFile = Path.GetTempFileName();
            a.SaveArtworkToFile(tempFile);
            FileInfo fiTempFile = new FileInfo(tempFile);
            if (fiTempFile.Exists)
            {
              fiTempFile.Delete();
            }
            long fileSize = fiTempFile.Length;

            if (fileSize > maxFileSize)
            {
              maxFileSize = fileSize;
              theArtwork = a;
            }
          }
          catch (Exception)
          {
          }
        }
      }

      if (theArtwork == null)
      {
        foreach (IITArtwork a in t.Artwork)
        {
          theArtwork = a;
        }
      }

      return theArtwork;
    }

  }
}
