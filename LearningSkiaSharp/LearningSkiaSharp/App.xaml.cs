using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace LearningSkiaSharp
{
    public partial class App : Application
    {
        public const string DARK_PRIMARY_KEY = "DarkPrimary";
        public const string LIGHT_PRIMARY_KEY = "LightPrimary";

        public App()
        {
            InitializeComponent();

            MainPage = new Pages.Nav.MainMasterPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
