using Prism;
using Prism.DryIoc;
using Prism.Ioc;
using PrismWithShell.Extensions;
using PrismWithShell.ViewModels;
using PrismWithShell.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace PrismWithShell
{
    public partial class App : PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            var current = new AppShell();
            Current.MainPage = current;
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterShellRoute<DetailsPage, ItemDetailsVM>();
            containerRegistry.RegisterShellRoute<MainPage, MainPageVM>();
            containerRegistry.RegisterShellRoute<AboutPage, AboutPageVM>();
            containerRegistry.RegisterShellRoute<NextPage, NextPageVM>();

            Routing.RegisterRoute("/MainPage/DetailsPage", typeof(DetailsPage));
            Routing.RegisterRoute("/MainPage/DetailsPage/NextPage", typeof(NextPage));
        }
    }
}
