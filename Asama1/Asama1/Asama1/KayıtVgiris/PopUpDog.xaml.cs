using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms.Xaml;
using Asama1.masterPages;

namespace Asama1.KayıtVgiris
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PopUpDog : Rg.Plugins.Popup.Pages.PopupPage
    {
        public PopUpDog()
        {
            InitializeComponent();
        }

        private async void dogrula_Clicked(object sender, EventArgs e)
        {
            if (dogrula.Text == null)
            {
                await DisplayAlert("Uyarı", "Lütfen boş alan bırakmayın", "Tamam");
            }
            else
            {
                
                await Navigation.PushModalAsync(new masterPage());
                await Navigation.PopPopupAsync();
            }
        }
    }
}