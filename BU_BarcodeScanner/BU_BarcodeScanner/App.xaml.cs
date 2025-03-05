using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using BU_BarcodeScanner.Services;
using BU_BarcodeScanner.Views;

namespace BU_BarcodeScanner
{
    public partial class App : Application
    {

        public App ()
        {
            InitializeComponent();
            DependencyService.Register<MockDataStore>();
            DependencyService.Register<Inventory>();
            MainPage = new AppShell();
        }

        protected override void OnStart ()
        {
        }

        protected override void OnSleep ()
        {
        }

        protected override void OnResume ()
        {
        }
    }
}
