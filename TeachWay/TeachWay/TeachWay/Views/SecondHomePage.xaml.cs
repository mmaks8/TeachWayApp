using Xamarin.Forms;
using System;
using TeachWay.Models;

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
        
		void OnAddItemClicked (object sender, EventArgs e)
		{
			var getreq = new SecondGetRequirements () {
				DESCRIPTION = Guid.NewGuid ().ToString ()
			};
			var moreinfo = new MoreInfo (true);
			moreinfo.BindingContext = getreq;
			Navigation.PushAsync (moreinfo);
		}       
    }
}
