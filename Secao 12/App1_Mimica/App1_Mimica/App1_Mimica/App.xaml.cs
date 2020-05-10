using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App1_Mimica
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new View.Inicio();
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
