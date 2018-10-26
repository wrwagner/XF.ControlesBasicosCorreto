using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using XF.ControlesBasicosCorreto.ViewModel;

[assembly: XamlCompilation (XamlCompilationOptions.Compile)]
namespace XF.ControlesBasicosCorreto
{
	public partial class App : Application
	{

        public static ControlesViewModel ControlesVM { get; set; }
        public App ()
		{
			InitializeComponent();

            if (ControlesVM == null) ControlesVM = new ControlesViewModel();

            MainPage = new NavigationPage(
                new View.MainPage() { BindingContext = App.ControlesVM });
        }

		protected override void OnStart ()
		{
			// Handle when your app starts
		}

		protected override void OnSleep ()
		{
			// Handle when your app sleeps
		}

		protected override void OnResume ()
		{
			// Handle when your app resumes
		}
	}
}
