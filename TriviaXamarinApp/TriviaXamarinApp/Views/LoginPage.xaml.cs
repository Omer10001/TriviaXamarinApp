using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TriviaXamarinApp.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace TriviaXamarinApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
          
            this.BindingContext = new LoginPageVM();
            ((LoginPageVM)BindingContext).NavigateToPageEvent += NavigateToPageAsync;
            InitializeComponent();
        }
        public async void NavigateToPageAsync(Page p)
        {
            await Navigation.PushAsync(p);
        }
    }
}