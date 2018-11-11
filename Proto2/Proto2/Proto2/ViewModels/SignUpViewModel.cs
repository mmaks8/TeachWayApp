using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Proto2.ViewModels
{
	public class SignUpViewModel : BindableBase
	{
       		private string _firstname;
		
		public string FirstName
		{
			get { return _firstname;}
			set {SetProperty(ref _firstname, value);}
		}
	}
}
