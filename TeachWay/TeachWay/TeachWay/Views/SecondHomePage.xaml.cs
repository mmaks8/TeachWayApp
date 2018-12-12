using Xamarin.Forms;
using System;

namespace TeachWay.Views
{
    public partial class SecondHomePage : ContentPage
    {
        public SecondHomePage()
        {
            InitializeComponent();
        }

        protected async override void OnAppearing()
        {
            base.OnAppearing();

            listView.ItemsSource = await App.GetManagerTwo.GetTaskAsync();
        }
    }
}
