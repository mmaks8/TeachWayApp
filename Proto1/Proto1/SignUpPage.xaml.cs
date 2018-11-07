using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Proto1
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class SignUpPage : ContentPage
	{
		public SignUpPage ()
		{
			InitializeComponent ();
		}
		
		async void OnSignUpButtonClicked (object sender, EventArgs e)
		{
			var user = new User(){
				FirstName = firstnameEntry.Text,
				LastName = lastnameEntry.Text,
				Username = usernameEntry.Text,
				Password = passwordEntry.Text,
				ConfirmPassword = confirmpasswordEntry.Text,
				Email = emailEntry.Text,
			};
			
			var signUpSucceeded = AreDetailsValid (user);
			if (signUpSucceeded) {
				var rootPage = Navigation.NavigationStack.FirstOrDefault ();
				if (rootPage != null) {
					App.IsUserLoggedIn = true;
					Navigation.InsertPageBefore (new MainPage (), Navigation.NavigationStack.First ());
					await Navigation.PopToRootAsync ();
				}
			} else {
				messageLabel.Text = "Sign up failed";
			}
		}

		bool AreDetailsValid (User user)
		{
			return (!string.IsNullOrWhiteSpace (user.FirstName) && !string.IsNullOrWhiteSpace (user.LastName) && !string.IsNullOrWhiteSpace (user.Username) && !string.IsNullOrWhiteSpace (user.Password) && !string.IsNullOrWhiteSpace (user.ConfirmPassword) && !string.IsNullOrWhiteSpace (user.Email) && user.Email.Contains ("@"));
		}	
			
	}
}
