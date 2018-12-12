using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TeachWay.ViewModels
{
    public class QPageViewModel : BindableBase
    {
        private INavigationService _navigationService;

        public DelegateCommand NavigateToUndergradPageCommand { get; private set; }
        public DelegateCommand NavigateToGradPageCommand { get; private set; }

        public QPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            NavigateToUndergradPageCommand = new DelegateCommand(NavigateToUndergradPage);
            NavigateToGradPageCommand = new DelegateCommand(NavigateToGradPage);
        }

        private void NavigateToGradPage()
        {
            _navigationService.NavigateAsync("HomePage");
        }

        private void NavigateToUndergradPage()
        {
            _navigationService.NavigateAsync("SecondHomePage");
        }
    }
}

	

