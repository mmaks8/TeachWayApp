using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using Prism.Navigation;

namespace TeachWay.ViewModels
{
	public class SecondHomePageViewModel : BindableBase
	{
        private INavigationService _navigationService;

        public DelegateCommand NavigateToMore { get; set; }

        public SecondHomePageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToMore = new DelegateCommand(NavigateToMorePage);
        }

        private void NavigateToMorePage()
        {
            _navigationService.NavigateAsync("MoreInfo");
        }
    }
}
