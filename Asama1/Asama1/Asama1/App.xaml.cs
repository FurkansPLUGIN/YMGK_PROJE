using Asama1.Biometrik;
using Asama1.KayıtVgiris;
using Asama1.masterPages;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;


[assembly:ExportFont("BilboSwashCaps-Regular.ttf",Alias ="Bilbo-Swash-Caps")]
[assembly: ExportFont("Bilbo-Regular.ttf", Alias = "Bilbo")]
[assembly: ExportFont("Oswald-VariableFont_wght.ttf", Alias = "Oswald")]
namespace Asama1
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
           
            MainPage = new Welcom();
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
