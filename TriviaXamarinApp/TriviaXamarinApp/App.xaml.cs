using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using TriviaXamarinApp.Services;
using TriviaXamarinApp.Views;
using TriviaXamarinApp.Models;
using System.Threading.Tasks;

namespace TriviaXamarinApp
{
    public partial class App : Application
    {
        public User currentUser { get; set; }
        public App()
        {
            InitializeComponent();
            
            
            MainPage = new StartPage();
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
    }
}
