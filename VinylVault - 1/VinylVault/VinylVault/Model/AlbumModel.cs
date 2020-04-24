using System;
using System.Collections.Generic;
using System.Text;

namespace VinylVault.Model
{
}


public class AlbumModel
{
    public string Title { get; set; }
    public string Artist { get; set; }
    public string Location { get; set; }
    public string Thumb { get; set; }
    public string Genre { get; set; }

    public AlbumModel(string _Title, string _Artist, string _Location, string _Thumb, string _Genre)
    {
        Title = _Title;
        Artist = _Artist;
        Location = _Location;
        Thumb = _Thumb;
        Genre = _Genre;
    }



}

