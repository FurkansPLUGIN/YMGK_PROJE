
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Asama1.KayıtVgiris
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Register : ContentPage
    {
        public Register()
        {
            InitializeComponent();
        }

        private async void HızlıGiris_Clicked(object sender, EventArgs e)
        {
            //veri tabanı yardımı ile hesap kontrolü 
            await Navigation.PushModalAsync(new Login());
        }

        private async void kaydol_Clicked(object sender, EventArgs e)
        {
            if(posta.Text==null || adSoyad.Text==null || sifre.Text == null)
            {
                await DisplayAlert("Uyarı", "Lütfen boş alan bırakmayın", "Tamam");
            }
            else
            {
                string [] ePosta = posta.Text.Split('@');
                if (sifre.Text.Length < 6)
                {
                    await DisplayAlert("Uyarı", "Şifre en az 5 haneli olabilir", "Tamam");
                }
                else if (ePosta[1].ToString() != "gmail.com")
                {
                    await DisplayAlert("Uyarı", "Lütfen geçerli bir E posta girin", "Tamam");
                }
                else
                {

                    try
                    {
                        Random rnd = new Random();
                        string mesaj = "";
                        string rast = "";
                        for (int i = 0; i < 8; i++)
                        {
                            rast = rnd.Next(10).ToString();
                            mesaj += rast;
                        }
                        string kod = "Doğrulama Kodu: " + mesaj;
                        MailMessage maila = new MailMessage();
                        SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");

                        maila.From = new MailAddress("furkan.demirel.056@gmail.com");
                        maila.To.Add(posta.Text);
                        maila.Subject = "Test";
                        maila.Body = kod ;

                        SmtpServer.Port = 587;
                        SmtpServer.Host = "smtp.gmail.com";
                        SmtpServer.EnableSsl = true;
                        SmtpServer.UseDefaultCredentials = false;
                        SmtpServer.Credentials = new System.Net.NetworkCredential("furkan.demirel.056@gmail.com", "******");

                        SmtpServer.Send(maila);
                      

                    }
                    catch(Exception ex)
                    {

                    }


                    await Navigation.PushModalAsync(new Login());
                }
               
            }
           
        }
    }
}
