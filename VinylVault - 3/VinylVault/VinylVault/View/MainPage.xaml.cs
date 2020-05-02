using Acr.UserDialogs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinylVault.View;
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
                await Navigation.PushModalAsync(new AlbumInfoPage(avm, false));
                listView.SelectedItem = null;
            }
        }

        private async void OnAddClicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new AlbumInfoPage(avm, true)) ;
        }

        private async void OnDeleteClicked(object sender, EventArgs e)
        {
            MenuItem mi = ((MenuItem)sender);
            AlbumModel alb = (AlbumModel)mi.CommandParameter;
            if (await DisplayAlert("Delete Album",  alb.Title, "Yes", "No"))
            {
                await avm.DeleteAlbum(alb);
                await RefreshListView();
            }
        }

        private void srchBar_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(e.NewTextValue))
            {
                listView.ItemsSource = albumList;
            }

            else
            {
                listView.ItemsSource = albumList.Where(x => x.Title.ToLower().Contains(e.NewTextValue.ToLower()));
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

        private async void OnResetClicked(object sender, EventArgs e)
        {
            await avm.ClearAlbums();
            await RefreshListView();
        }
    }
}
