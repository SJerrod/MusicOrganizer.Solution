using System.Collections.Generic;

namespace MusicOrganizer.Models
{
  public class Record
  {
    private static List<Record> _instances = new List<Record> {};

    public string RecordName { get; set; }

    public int RecordId { get; }

    public List<Song> Songs { get; set; }

    public Record(string recordName)
    {
      RecordName = recordName;
      _instances.Add(this);
      RecordId = _instances.Count;
      Songs = new List<Song>{};
    }

    public static void ClearAll()
    {
      _instances.Clear();
    }

    public static List<Record> GetAll()
    {
      return _instances;
    }

    public static Record Find(int searchId)
    {
      return _instances[searchId - 1];
    }

    public void AddSong(Song song)
    {
      Songs.Add(song);
  }
}