using Asama1.KayıtVgiris;
using Asama1.masterPages;
using Plugin.Fingerprint;
using Plugin.Fingerprint.Abstractions;
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
    public partial class ParmakDoğrulama : ContentPage
    {
        public ParmakDoğrulama()
        {
            InitializeComponent();
            lottie.PlayAnimation();
            time(4);
        }
        protected override bool OnBackButtonPressed() => true;
        public void time(double time)
        {
           
            Device.StartTimer(TimeSpan.FromSeconds(1), () =>
            {
                time -= 1;
               
                if (time <= 0.00)
                {
                    try
                    {
                        lottie.PlayAnimation();
                        time = 4;
                    }
                    catch(Exception ex)
                    {

                    }
                  
                   // return false;
                }
                return true;

            });
        }
        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Login());
        }

        private async void giris_Clicked(object sender, EventArgs e)
        {
            var availability = await CrossFingerprint.Current.IsAvailableAsync();
           
            if (!availability)
            {
                await DisplayAlert("Uyarı", "Parmak izi bilgisi alınamadı", "Tamam");

                return;
            }

            var authResult = await CrossFingerprint.Current.AuthenticateAsync(new AuthenticationRequestConfiguration("Parmağınızı Okutun", "Lütfen ,cihanzınızdaki bölüme parmağınızı koyun"));

            if (authResult.Authenticated)
            {
                await Navigation.PushModalAsync(new masterPage());
            }
        }
    }
}