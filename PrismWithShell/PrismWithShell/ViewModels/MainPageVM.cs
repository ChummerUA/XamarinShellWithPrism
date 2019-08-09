using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace PrismWithShell.ViewModels
{
    public class MainPageVM : ViewModelBase
    {
        NavigationParameters Parameters;

        public MainPageVM(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
            Parameters = new NavigationParameters();
            Parameters.Add("message", $"navigated from_{Title}");
        }

        private ICommand _command;
        public ICommand Command => _command = _command ?? new Command(async () => await AppShell.GoToAsync("/MainPage/DetailsPage", Parameters));


        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
        }
    }
}
