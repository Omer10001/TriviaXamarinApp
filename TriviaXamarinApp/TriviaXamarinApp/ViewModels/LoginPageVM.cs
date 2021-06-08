using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using TriviaXamarinApp.Views;
using System.Windows.Input;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;
namespace TriviaXamarinApp.ViewModels
{
    class LoginPageVM : INotifyPropertyChanged
    {
        #region INOTIFYEVENT
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        private string errorMessage;
        public string ErrorMessage
        {
            get
            {
                return errorMessage;
            }
            set
            {
                if (errorMessage != value)
                {
                    errorMessage = value;
                    OnPropertyChanged("ErrorMessage");
                }
            }
        }
        public string Email { get; set; }
        public string Password { get; set; }
        public ICommand LoginCommand => new Command(Login);
        public async void Login ()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password))
            {
                ErrorMessage = "please fill in both fields";
            }
            else
            {
                
                
                User user = await proxy.LoginAsync(Email, Password);
                if (user == null)
                {
                    ErrorMessage = "wrong email or password";
                }
                else
                {
                    ((App)Application.Current).currentUser = user;
                    NavigateToPageEvent(new GamePage());
                }
                
               

            }
           

            
        }
        public Action<Page> NavigateToPageEvent;

    }
}
