using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using System.IO;
using PCLCrypto;

namespace Asama1.AnaSayfalar
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AES : ContentPage
    {
        public byte[] Salt { get; set; }
        public string TextToBeDecrypted { get; set; }

        public AES()
        {
            InitializeComponent();
        }
       

        private void sifrele_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(metin.Text))
            {
                Salt = AESHelp.CreateSalt(16);
                TextToBeDecrypted = AESHelp.sifrele(metin.Text, Salt);
                SifreliMetin.Text = TextToBeDecrypted;
            }
        }


      

        private void coz_Clicked(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(TextToBeDecrypted))
            {
                ÇözülmüşMetin.Text = AESHelp.SifreyiCoz(TextToBeDecrypted, Salt);
            }
        }
    }
}