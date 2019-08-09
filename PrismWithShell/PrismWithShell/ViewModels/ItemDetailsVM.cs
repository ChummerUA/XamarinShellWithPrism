using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Prism.Navigation;
using Xamarin.Forms;

namespace PrismWithShell.ViewModels
{
    public class ItemDetailsVM : ViewModelBase
    {
        string _message;
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }

        public ItemDetailsVM(INavigationService navigationService) : base(navigationService)
        {
            Title = "DetailsPage";
        }

        private ICommand _command;
        public ICommand Command => _command = _command ?? new Command(async () => await Shell.Current.GoToAsync("/MainPage/DetailsPage/NextPage"));

        public override void OnNavigatedFrom(INavigationParameters parameters)
        {
            base.OnNavigatedFrom(parameters);
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            base.OnNavigatedTo(parameters);
            if(parameters != null)
            {
                Message = parameters.GetValue<string>("message");
            }
        }

        public override void OnNavigatingTo(INavigationParameters parameters)
        {
            base.OnNavigatingTo(parameters);
        }
    }
}
