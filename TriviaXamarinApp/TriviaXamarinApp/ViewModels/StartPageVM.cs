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
    class StartPageVM : INotifyPropertyChanged
    {
        public StartPageVM()
        {

        }
        #region INOTIFYEVENT
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion
        public ICommand MoveToNextPageCommand => new Command<string>(MoveToNextPage);
        public void MoveToNextPage(string x)
        {
            Page p;
            if(x== "0")
            {
                p = new LoginPage();
            }
            else
            {
                p = new SignUpPage();
            }
            if (NavigateToPageEvent != null)
                NavigateToPageEvent(p);
        }
        public Action<Page> NavigateToPageEvent;
    }
}
