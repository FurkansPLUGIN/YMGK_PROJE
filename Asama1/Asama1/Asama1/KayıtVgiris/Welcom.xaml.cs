using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asama1.KayıtVgiris
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Welcom : ContentPage
    {
        public Welcom()
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
                    Application.Current.MainPage = new Login();
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