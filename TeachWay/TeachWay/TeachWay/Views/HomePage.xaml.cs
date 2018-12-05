using Xamarin.Forms;
using System;

namespace TeachWay.Views
{
    public partial class HomePage : ContentPage
    {
        public HomePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.GetManager.GetTasksAsync();
        }


    }
}
