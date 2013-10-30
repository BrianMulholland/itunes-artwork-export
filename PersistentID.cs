using iTunesLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace iTunes_Artwork_Export
{
  public class PersistentID
  {
    private readonly UInt64 _persistentID;

    public PersistentID(int high, int low)
    {
      this._persistentID = (UInt64)
        (
          ( ((UInt64)high << 32) & 0xFFFFFFFF00000000 ) +
          ( (UInt64)low & 0x00000000FFFFFFFF )
        );
    }

    public UInt64 PersistentID_UInt64
    {
      get
      {
        return this._persistentID;
      }
    }

    public int LowBits
    {
      get {
        return (int)(_persistentID & 0xFFFFFFFF);
      }
    }

    public int HighBits
    {
      get {
        return (int)(_persistentID >> 32);
      }
    }


    public static PersistentID GetTrackPersistentID(IiTunes iTunesApp, IITTrack t)
    {
      int persistentId_High;
      int persistentId_Low;
      object refFileTrack = (object)t;
      iTunesApp.GetITObjectPersistentIDs(ref refFileTrack, out persistentId_High, out persistentId_Low);
      return new PersistentID(persistentId_High, persistentId_Low);
    }

  }
}
