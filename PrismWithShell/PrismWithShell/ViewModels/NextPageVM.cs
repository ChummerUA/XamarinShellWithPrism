using System;
using System.Collections.Generic;
using System.Text;
using Prism.Navigation;

namespace PrismWithShell.ViewModels
{
    public class NextPageVM : ViewModelBase
    {
        public NextPageVM(INavigationService navigationService) : base(navigationService)
        {
            Title = "NextPage";
        }

    }
}
