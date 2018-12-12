using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TeachWay.ViewModels
{
	public class LoginPageViewModel : ViewModelBase
	{
        private INavigationService _navigationService;

        public DelegateCommand NavigateToSignUpCommand { get; private set; }
        public DelegateCommand NavigateToHomePageCommand { get; private set; }
        public DelegateCommand NavigateToQPageCommand { get; private set; }

        public LoginPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "TeachWay";

            _navigationService = navigationService;
            NavigateToSignUpCommand = new DelegateCommand(NavigateToSignUpPage);
            NavigateToHomePageCommand = new DelegateCommand(NavigateToHomePage);
            NavigateToQPageCommand = new DelegateCommand(NavigateToQPage);
        }

        private void NavigateToSignUpPage()
        {
            _navigationService.NavigateAsync("SignUpPage");
        }

        private void NavigateToHomePage()
        {
            _navigationService.NavigateAsync("HomePage");
        }

        private void NavigateToQPage()
        {
            _navigationService.NavigateAsync("QPage");
        }
    }
}
