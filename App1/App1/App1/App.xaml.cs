using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using App1.Views;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace App1
{
    public partial class App : Application
    {

        public App()
        {
            InitializeComponent();


            MainPage = new MainPage();
        }

        protected async override void OnStart()
        {
            // Handle when your app starts
            AppCenter.Start("ios=4c0a2400-3aab-41bb-8d85-e40a719e6023;" + "uwp={Your UWP App secret here};" + "android={Your Android App secret here}", typeof(Analytics), typeof(Crashes));

            bool isEnabled = await Crashes.IsEnabledAsync();

            Crashes.SendingErrorReport += (sender, e) =>
            {
                // Your code, e.g. to present a custom UI.

                Analytics.TrackEvent("Crash!!!");
            };

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
