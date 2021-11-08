using Plugin.Connectivity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Rg.Plugins.Popup.Extensions;
using Xamarin.Forms.Xaml;

namespace Asama1.KayıtVgiris
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Kayıt1 : ContentPage
    {
        public Kayıt1()
        {
            InitializeComponent();
            internet();
        }
        string dogrulama;
        string mesaj = "";
        public async void internet()
        {
            if (CrossConnectivity.Current.IsConnected == false)
            {
                await DisplayAlert("Uyarı", "Lütfen internet bağlanın", "Tamam");
                return;
            }
        }
        private async void kayıt_Clicked(object sender, EventArgs e)
        {
            if(CrossConnectivity.Current.IsConnected == false)
            {
                await DisplayAlert("Uyarı", "Lütfen internete bağlanın", "Tamam");
            }
            else
            {
                if (posta.Text == null || adSoyad.Text == null || kullancıcıAdı.Text == null || sifre.Text == null)
                {
                    await DisplayAlert("Uyarı", "Lütfen boş alan bırakmayın", "Tamam");
                }
                else if (sifre.Text.Length < 6)
                {
                    await DisplayAlert("Uyarı", "Şifre uzunluğu en 5 haneli olabilir", "Tamam");
                    sifre.Text = "";
                }
                else
                {
                    try
                    {
                        Random rnd = new Random();

                        string rast = "";
                        for (int i = 0; i < 5; i++)
                        {
                            rast = rnd.Next(10).ToString();
                            mesaj += rast;
                        }
                        dogrulama = mesaj;

                        MailMessage maila = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                        maila.From = new MailAddress("fth.bilgi.iletisim@gmail.com");
                        maila.To.Add(posta.Text);
                        maila.Subject = "Test";
                        maila.Body = "Doğrulama Kodunuz: " + "' " + mesaj + " '";

                        SmtpServer.Port = 587;
                        SmtpServer.Host = "smtp.gmail.com";
                        SmtpServer.EnableSsl = true;
                        SmtpServer.UseDefaultCredentials = false;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("fth.bilgi.iletisim@gmail.com", "*****");

                        SmtpServer.Send(maila);
                        await DisplayAlert("Uyarı", "Doğrulama Kodunuz gönderilmiştir", "Tamam");

                        await Navigation.PushPopupAsync(new PopUpDog());
                        
                    }
                    catch (Exception ex)
                    {
                        await DisplayAlert("Başarısız","Mail gönderme işlemi başarısız oldu", "Tamam");
                    }

                }
            }
          
        }
    }
}
