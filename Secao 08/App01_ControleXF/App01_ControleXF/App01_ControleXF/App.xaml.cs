using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App01_ControleXF
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new App01_ControleXF.Menu.Master();
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
