using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proto2.ViewModels
{
	public class SignUpViewModel : BindableBase
	{
       		private string _firstName;
		private string _lastName;
		private string _userName;
		private string _email;
		private string _password;
		private string _confirmpassword;
		
		public string FirstName
		{
			get { return _firstName;}
			set {SetProperty(ref _firstname, value);}
		}
		
		public string LastName
		{
			get { return _lastName;}
			set {SetProperty(ref _lastname, value);}
		}
		
		public string Email
		{
			get { return _email;}
			set {SetProperty(ref _email, value);}
		}
		
		public string Password
		{
			get { return _password;}
			set {SetProperty(ref _password, value);}
		}
		
		public string ConfirmPassword
		{
			get { return _confirmpassword;}
			set {SetProperty(ref _confirmpassword, value);}
		}
		
		partial void CheckValid ()
		{
			if(FirstName != null && LastName != null && UserName != null && Email != null && Password != null && ConfirmPassword != null)
				{
					OnSignUpButtonClicked = null;
					messageLabel = "Sign up success";
				}
			
			else
			{
				messageLabel = "Invalid information given / Missing Information";
			}
		}
				
		public SignUpViewModel()
		{
		
		}

	}
}
