using Newtonsoft.Json;
using Prism.Common;
using Prism.Ioc;
using Prism.Navigation;
using PrismWithShell.ViewModels;
using PrismWithShell.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PrismWithShell
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AppShell : Shell
    {
        #region properties

        const string parametersName = "parameters";
        private ShellContent CurrentShellContent => CurrentItem?.CurrentItem?.CurrentItem;
        private Page LastPage => CurrentItem?.CurrentItem?.Stack?.Count == 1 ? CurrentShellContent?.Content as Page : CurrentItem?.CurrentItem?.Stack?.LastOrDefault();
        private NavigationParameters Parameters { get; set; }

        #endregion

        public AppShell()
        {
            InitializeComponent();
        }

        #region override

        protected override void OnNavigated(ShellNavigatedEventArgs args)
        {
            base.OnNavigated(args);
            try
            {
                var vmlResult = Prism.Mvvm.ViewModelLocator.GetAutowireViewModel(LastPage);
                if (vmlResult == null)
                    Prism.Mvvm.ViewModelLocator.SetAutowireViewModel(LastPage, true);

                PageUtilities.OnNavigatedTo(LastPage, Parameters);
                Parameters = null;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"EXCEPITON: {this?.GetType()?.Name}.OnNavigated() \n{ex.Message}\n{ex}");
            }
        }

        protected override void OnNavigating(ShellNavigatingEventArgs args)
        {
            base.OnNavigating(args);
            try
            {
                PageUtilities.OnNavigatedFrom(LastPage, Parameters);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"EXCEPITON: {this?.GetType()?.Name}.OnNavigating() \n{ex.Message}\n{ex}");
            }
        }

        #endregion

        #region methods
        public static async Task GoToAsync(string route, NavigationParameters navigationParameters = null)
        {
            (Shell.Current as AppShell).Parameters = navigationParameters;
            await Shell.Current.GoToAsync(route);
        }
        #endregion
    }
}