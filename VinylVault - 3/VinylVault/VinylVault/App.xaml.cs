using System;
using System.Diagnostics;
using VinylVault.Data;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace VinylVault
{
    public partial class App : Application
    {
        static VinylVaultDatabase database;
        public App()
        {
            InitializeComponent();

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }


        public static VinylVaultDatabase Database
        {
            get
            {
                if (database == null)
                {
                }
                try
                {

                    string documentsDirectory = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
                    database = new VinylVaultDatabase(System.IO.Path.Combine(documentsDirectory, "VinylVaultSQLite.db3"));
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message + " || " + ex.InnerException.Message);

                }
                return database;
            }
        }



    }
}
