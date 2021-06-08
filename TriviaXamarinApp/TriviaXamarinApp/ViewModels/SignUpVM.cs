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
    class SignUpVM : INotifyPropertyChanged
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
        public string NickName { get; set; }
        public ICommand SignUpCommand => new Command(SignUP);
        public async void SignUP()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(Password) || string.IsNullOrEmpty(NickName))
            {
                ErrorMessage = "Please enter email, password and nickname";

            }
            else
            {
                User u = new User
                {
                    Email = Email,
                    Password = Password,
                    NickName = NickName,
                    Questions = new List<AmericanQuestion>()
                };
                bool registered = await proxy.RegisterUser(u);
                if (registered)
                {
                    LoginPage p = new LoginPage();
                    if (NavigateToPageEvent != null)
                        NavigateToPageEvent(p);
                }
                else
                {
                    ErrorMessage = "Something went wrong";
                }
                
            }
        }
        public Action<Page> NavigateToPageEvent;
    }
}
