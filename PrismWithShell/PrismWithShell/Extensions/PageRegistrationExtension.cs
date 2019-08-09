using Prism.Ioc;
using PrismWithShell.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace PrismWithShell.Extensions
{
    public static class PageRegistrationExtension
    {
        public static void RegisterShellRoute<TPage, TViewModel>(this IContainerRegistry containerRegistry) where TPage : ContentPage where TViewModel : ViewModelBase
        {
            Routing.RegisterRoute((typeof(TPage)).Name, typeof(TPage));
            containerRegistry.RegisterForNavigation<TPage, TViewModel>();
        }
    }
}
