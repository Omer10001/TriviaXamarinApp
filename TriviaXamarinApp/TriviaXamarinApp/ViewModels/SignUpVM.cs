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
    class SignUpVM
    {
        #region INOTIFYEVENT
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public string Email { get; set; }
        public string Password { get; set; }
        ICommand SignUpCommand => new Command(SignUP);
        public void SignUP()
        {

        }
    }
}
