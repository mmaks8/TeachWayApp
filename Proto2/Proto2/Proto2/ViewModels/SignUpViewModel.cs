using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proto2.ViewModels
{
	public class SignUpViewModel : BindableBase
	{
<<<<<<< HEAD
        private string _firstName;
        private string _lastName;
        private string _username;
        private string _password;
        private string _email;

        public string FirstName
        {
            get { return _firstName; }
            set { SetProperty(ref _firstName, value); }
        }
        public string LastName
        {
            get { return _lastName; }
            set { SetProperty(ref _lastName, value); }
        }
        public string UserName
        {
            get { return _username; }
            set { SetProperty(ref _username, value); }
        }
        public string Email
        {
            get { return _email; }
            set { SetProperty(ref _email, value); }
        }
        public string Password
        {
            get { return _password; }
            set { SetProperty(ref _password, value); }
        }
        public SignUpViewModel()
        {
            
        }
=======
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
			if(FirstName != null)
				{
					OnSignUpButtonClicked = null;	
				}
			if(LastName != null)
				{
					OnSignUpButtonClicked = null;	
				}
			if(UserName != null)
				{
					OnSignUpButtonClicked = null;	
				}
			if(Email != null)
				{
					OnSignUpButtonClicked = null;	
				}
			if(Password != null)
				{
					OnSignUpButtonClicked = null;	
				}
			if(ConfirmPassword != null)
				{
					OnSignUpButtonClicked = null;	
				}
			else
			{
				messageLabel = "Invalid information given / Missing Information";
			}
		}
				
		public SignUpViewModel()
		{
		
		}
>>>>>>> 40275e700d57bdb316b1ce8312312cc77ca1c976
	}
}
