using Gamify.Data;
using System;
using System.IO;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.Diagnostics;

namespace Gamify
{
    public partial class App : Application, IHaveMainPage
    {

        static Database _database;

        public static Database Database
        {
            get
            {
                if (_database == null)
                {
                    _database = new Database(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Notes.db3"));
                }
                return _database;
            }
        }

        public App()
        {
            InitializeComponent();

            Debug.WriteLine("STARTING UP APP DUDE WOW LOL");

            var navigator = new NavigationService(this, new ViewLocator());


            var rootViewModel = new UserLoginViewModel(navigator);

            navigator.PresentAsNavigatableMainPage(rootViewModel);
        }

       
    }
}
