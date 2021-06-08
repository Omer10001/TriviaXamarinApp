﻿using System;
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
    public partial class StartPage : ContentPage
    {
        public StartPage()
        { 

          
            BindingContext = new StartPageVM();
           
            ((StartPageVM)BindingContext).NavigateToPageEvent += NavigateToPageAsync;
            InitializeComponent();
        }
        public async void NavigateToPageAsync(Page p)
        {
            await Navigation.PushAsync(p);
        }
    }
    
}