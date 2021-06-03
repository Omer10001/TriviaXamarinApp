using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

using System.Windows.Input;
using TriviaXamarinApp.Models;
using TriviaXamarinApp.Services;
namespace TriviaXamarinApp.ViewModels
{
    class LoginPageVM
    {
        #region INOTIFYEVENT
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public string ErrorMessage { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        ICommand LoginCommand => new Command(Login);
        public void Login ()
        {
            TriviaWebAPIProxy proxy = TriviaWebAPIProxy.CreateProxy();
            Task < User > task = proxy.LoginAsync(Email, Password);
            task.Wait();
            User user = task.Result;
            ((App)Application.Current).currentUser = user;
            
        }
       
    }
}
