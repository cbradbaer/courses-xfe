using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinylVault.ViewModel;
using Xamarin.Forms;

namespace VinylVault
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {

        AlbumViewModel avm;
        List<AlbumModel> albumList;



        public  MainPage()
        {
            InitializeComponent();
             avm = new AlbumViewModel();
            BindingContext = avm;
        }


        protected override async void OnAppearing()
        {
            base.OnAppearing();

            await RefreshListView();
            avm.CollectionName = "Cary's Classic Collection";
        }

        public async Task<bool> RefreshListView()
        {
            listView.ItemsSource = null;
            await avm.GetAlbums();
            albumList = avm.AlbumList;
            listView.ItemsSource = albumList;
            return true;
        }



        private async void  OnListItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem != null)
            {
                avm.SelectedAlbum = (AlbumModel)e.SelectedItem;
                await DisplayAlert(avm.SelectedAlbum.Title, avm.SelectedAlbum.Artist, "OK");
            }
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            MenuItem mi = ((MenuItem)sender);
            AlbumModel alb = (AlbumModel)mi.CommandParameter;
            if (await DisplayAlert("Delete Album",  alb.Title, "Yes", "No"))
            {
                avm.AlbumList.Remove(alb);
                await RefreshListView();
            }
        }


        private async void OnNameClicked(object sender, EventArgs e)
        {
            var result = await UserDialogs.Instance.PromptAsync(new PromptConfig
            {
                Title = "Collection Name",
                Message = "Choose a Collection Name",
            });

            if (result.Ok && result.Text != string.Empty)
            {
                avm.CollectionName = result.Text;
            }
        }
    }
}
