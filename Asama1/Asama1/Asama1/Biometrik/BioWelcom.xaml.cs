using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asama1.Biometrik
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class BioWelcom : ContentPage
    {
        public BioWelcom()
        {
            InitializeComponent();
        }

        public void time(double time)
        {

            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                time -= 1;
                if (time <= 0.00)
                {
                    Application.Current.MainPage = new ParmakDoğrulama();
                    return false;
                }
                return true;

            });
        }
        protected override async void OnAppearing()
        {
            base.OnAppearing();
            time(1);

        }
    }
}