using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Proto2.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private INavigationService _navigationService;

        public DelegateCommand NavigateToSignUpCommand { get; private set; }
        public DelegateCommand NavigateToHomePageCommand { get; private set; }

        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            _navigationService = navigationService;
            NavigateToSignUpCommand = new DelegateCommand(NavigateToSignUp);
            NavigateToHomePageCommand = new DelegateCommand(NavigateToHomePage);

            Title = "TeachWay";
        }

        private void NavigateToSignUp()
        {
            _navigationService.NavigateAsync("SignUp");
        }

        private void NavigateToHomePage()
        {
            _navigationService.NavigateAsync("HomePage");
        }
    }
}
