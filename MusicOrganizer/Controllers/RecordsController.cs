using System.Collections.Generic;
using System;
using Microsoft.AspNetCore.Mvc;
using MusicOrganizer.Models;

namespace MusicOrganizer.Controllers
{
  public class RecordsController : Controller
  {
    [HttpGet("/artists/{artistId}/records/new")]
    public ActionResult New(int artistId)
    {
      Artist artist = Artist.Find(artistId);  
      return View(artist);
    }

    // [HttpPost("/records")]
    // public ActionResult Create(string recordName)
    // {
    //   Record newRecord = new Record(recordName);
    //   return RedirectToAction
    // }

    [HttpPost("/artists/{artistId}/records/{recordId}/songs")]
    public ActionResult Create(int recordId, string songName)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Record foundRecord = Record.Find(recordId);
      Song newSong = new Song(songName);
      foundRecord.AddSong(newSong);
      List<Song> recordSongs = foundRecord.Songs;

      model.Add("songs", recordSongs);
      model.Add("record", foundRecord);

      return View("Show", model);
    }

    [HttpGet("records/{id}")]
    public ActionResult Show(int id)
    {
      Dictionary<string, object> model = new Dictionary<string, object>();
      Record selectedRecord = Record.Find(id);
      List<Song> recordSongs = selectedRecord.Songs;
      model.Add("record", selectedRecord);
      model.Add("songs", recordSongs);
      return View(model);
    }
  }
}