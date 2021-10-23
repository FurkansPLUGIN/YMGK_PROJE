using Asama1.Biometrik;
using Asama1.masterPages;
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
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();
        }

        private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new Kayıt1());
        }

        private async void giris_Clicked(object sender, EventArgs e)
        {
            if(kullanıcıGiris.Text==null || sifreGiris.Text == null)
            {
                await DisplayAlert("Uyarı", "Lütfen boş alan bırakmayın", "Tamam");
            }
            else if (sifreGiris.Text.Length < 6)
            {
                await DisplayAlert("Uyarı", "Yanlış şifre", "Tamam");
                sifreGiris.Text = "";
            }
            else
            {
                await Navigation.PushModalAsync(new masterPage());
            }
          
        }

        private async void bioGiris_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushModalAsync(new BioWelcom());
        }
    }
}