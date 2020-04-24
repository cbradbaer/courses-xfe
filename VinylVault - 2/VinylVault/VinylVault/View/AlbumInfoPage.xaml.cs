using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VinylVault.ViewModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VinylVault.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AlbumInfoPage : ContentPage
    {
        AlbumModel alb;
        AlbumViewModel avm;
        bool isNew;
 

        public AlbumInfoPage(AlbumViewModel _avm, bool _isNew)
        {
            InitializeComponent();
            isNew = _isNew;
            avm = _avm;
            alb = new AlbumModel("", "", "", "", "");
            if (isNew)
            {

            }

            else
            {
                alb.Title = avm.SelectedAlbum.Title;
                alb.Artist = avm.SelectedAlbum.Artist;
                alb.Location = avm.SelectedAlbum.Location;
                alb.Thumb = avm.SelectedAlbum.Thumb;
                alb.Genre = avm.SelectedAlbum.Genre;
            }
            BindingContext = alb;
        }



        protected override async void OnAppearing()
        {
            base.OnAppearing();
           // BindingContext = alb;

        }



        private async void OnCancelClicked(object sender, EventArgs e)
        {
            await Navigation.PopModalAsync();
        }

        private async void OnOKClicked(object sender, EventArgs e)
        {
            if(isNew)
            {
                avm.InsertAlbum(alb);
            }
            else
            {
                avm.UpdateAlbum(alb);
            }
            await Navigation.PopModalAsync();
        }
    }
}