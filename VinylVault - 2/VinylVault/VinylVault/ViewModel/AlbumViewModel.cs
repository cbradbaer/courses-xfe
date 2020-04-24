using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace VinylVault.ViewModel
{
    public class AlbumViewModel : INotifyPropertyChanged
    {


        AlbumModel _SelectedAlbum;
        private string _CollectionName;
        public string CollectionName
        {
            get
            {
                return _CollectionName;
            }
            set
            {
                _CollectionName = value;
                RaisePropertyChanged("CollectionName");
            }
        }

        public List<AlbumModel> AlbumList;
        public AlbumModel SelectedAlbum
        {
            get
            {
                return _SelectedAlbum;
            }
            set
            {
                _SelectedAlbum = value;
                RaisePropertyChanged("SelectedAlbum");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string prop)
        {
            if (PropertyChanged != null) { PropertyChanged(this, new PropertyChangedEventArgs(prop)); }
        }



        public bool GetAlbums()
        {

            if (AlbumList == null)
            {
                AlbumList = new List<AlbumModel>();
                AlbumList.Add(new AlbumModel("The Doors", "The Doors", "Box 1", "album1.jpg", "Rock"));
                AlbumList.Add(new AlbumModel("Volunteers", "Jefferson Airplane", "Box 1", "album2.jpg", "Rock"));
                AlbumList.Add(new AlbumModel("Escape", "Journey", "Box 2", "album3.jpg", "Rock"));
                AlbumList.Add(new AlbumModel("Exit", "Tangerine Dream", "Box 2", "album4.jpg", "Electronic"));
                AlbumList.Add(new AlbumModel("Rumors", "Fleetwood Mac", "Box 2", "album5.jpg", "Rock"));
                AlbumList.Add(new AlbumModel("LA Woman", "The Doors", "Box 1", "album6.jpg", "Rock"));
                AlbumList.Add(new AlbumModel("Moving Pictures", "Rush", "Box 2", "album7.jpg", "Rock"));
            }
            return true;
        }

        public bool UpdateAlbum(AlbumModel alb)
        {
            SelectedAlbum.Title = alb.Title;
            SelectedAlbum.Artist = alb.Artist;
            SelectedAlbum.Location = alb.Location;
            SelectedAlbum.Thumb = alb.Thumb;
            SelectedAlbum.Genre = alb.Genre;
            return true;
        }

        public bool DeleteAlbum(AlbumModel alb)
        {

            AlbumList.Remove(alb);
            return true;
        }

        public bool InsertAlbum(AlbumModel alb)
        {

            AlbumList.Add(alb);
            return true;
        }


        public bool ClearAlbums()
        {

            AlbumList.Clear();
            return true;
        }

    }
}
