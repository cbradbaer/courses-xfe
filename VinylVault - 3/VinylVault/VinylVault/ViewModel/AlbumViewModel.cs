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



        public async Task<bool> GetAlbums()
        {

            AlbumList = await App.Database.GetAlbumsAsync();

            if (AlbumList == null || AlbumList.Count == 0)
            {
                AlbumList = new List<AlbumModel>();
                await App.Database.InsertAlbum(new AlbumModel("The Doors", "The Doors", "Box 1", "album1.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("Volunteers", "Jefferson Airplane", "Box 1", "album2.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("Escape", "Journey", "Box 2", "album3.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("Exit", "Tangerine Dream", "Box 2", "album4.jpg", "Electronic"));
                await App.Database.InsertAlbum(new AlbumModel("Rumors", "Fleetwood Mac", "Box 2", "album5.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("LA Woman", "The Doors", "Box 1", "album6.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("Moving Pictures", "Rush", "Box 2", "album7.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("The Doors", "The Doors", "Box 1", "album1.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("Volunteers", "Jefferson Airplane", "Box 1", "album2.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("Escape", "Journey", "Box 2", "album3.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("Exit", "Tangerine Dream", "Box 2", "album4.jpg", "Electronic"));
                await App.Database.InsertAlbum(new AlbumModel("Rumors", "Fleetwood Mac", "Box 2", "album5.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("LA Woman", "The Doors", "Box 1", "album6.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("Moving Pictures", "Rush", "Box 2", "album7.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("The Doors", "The Doors", "Box 1", "album1.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("Volunteers", "Jefferson Airplane", "Box 1", "album2.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("Escape", "Journey", "Box 2", "album3.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("Exit", "Tangerine Dream", "Box 2", "album4.jpg", "Electronic"));
                await App.Database.InsertAlbum(new AlbumModel("Rumors", "Fleetwood Mac", "Box 2", "album5.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("LA Woman", "The Doors", "Box 1", "album6.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("Moving Pictures", "Rush", "Box 2", "album7.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("The Doors", "The Doors", "Box 1", "album1.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("Volunteers", "Jefferson Airplane", "Box 1", "album2.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("Escape", "Journey", "Box 2", "album3.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("Exit", "Tangerine Dream", "Box 2", "album4.jpg", "Electronic"));
                await App.Database.InsertAlbum(new AlbumModel("Rumors", "Fleetwood Mac", "Box 2", "album5.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("LA Woman", "The Doors", "Box 1", "album6.jpg", "Rock"));
                await App.Database.InsertAlbum(new AlbumModel("Moving Pictures", "Rush", "Box 2", "album7.jpg", "Rock"));
            }


            return true;
        }

        public async Task<bool> UpdateAlbum(AlbumModel alb)
        {

            await App.Database.UpdateAlbum(alb);
            return true;
        }

        public async Task<bool> DeleteAlbum(AlbumModel alb)
        {

            await App.Database.DeleteAlbum(alb);
            return true;
        }

        public async Task<bool> InsertAlbum(AlbumModel alb)
        {

            await App.Database.InsertAlbum(alb);
            return true;
        }


        public async Task<bool> ClearAlbums()
        {

            await App.Database.ClearAlbums();
            return true;
        }



    }
}
