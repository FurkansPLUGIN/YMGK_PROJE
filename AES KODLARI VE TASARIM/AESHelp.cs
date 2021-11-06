using PCLCrypto;
using System;
using System.Collections.Generic;
using System.Text;

namespace Asama1.AnaSayfalar
{
   public class AESHelp
    {
        public static byte[] CreateSalt(int byteUzunlugu)
        {
            return WinRTCrypto.CryptographicBuffer.GenerateRandom(byteUzunlugu);
        }
        const string KEYDEGERLERI = "AFRGSHgehsheyikvs";
        public static byte[] CreateDerivedKey(string sifre, byte[] salt, int anahtarUzunlugu = 32, int tekrar = 1000)
        {
            byte[] anatar = NetFxCrypto.DeriveBytes.GetBytes(sifre, salt, tekrar, anahtarUzunlugu);
            return anatar;
        }

        public static string sifrele(string veri, byte[] salt)
        {
            if (string.IsNullOrEmpty(veri))
            {
                return null;
            }

            byte[] anahtar = CreateDerivedKey(KEYDEGERLERI, salt);

            ISymmetricKeyAlgorithmProvider aes = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(PCLCrypto.SymmetricAlgorithm.AesCbcPkcs7);
            ICryptographicKey symetricKey = aes.CreateSymmetricKey(anahtar);
            var bytes = WinRTCrypto.CryptographicEngine.Encrypt(symetricKey, Encoding.UTF8.GetBytes(veri));
            var sifrelenmisMetin = Convert.ToBase64String(bytes);
            return sifrelenmisMetin;
        }


        public static string SifreyiCoz(string veri, byte[] salt)
        {
            if (string.IsNullOrEmpty(veri))
            {
                return null;
            }

            byte[] anahtar = CreateDerivedKey(KEYDEGERLERI, salt);

            ISymmetricKeyAlgorithmProvider aes = WinRTCrypto.SymmetricKeyAlgorithmProvider.OpenAlgorithm(PCLCrypto.SymmetricAlgorithm.AesCbcPkcs7);
            ICryptographicKey simetrikAnahtar = aes.CreateSymmetricKey(anahtar);
            var sifrelenmisMetin = Convert.FromBase64String(veri);
            var bytes = WinRTCrypto.CryptographicEngine.Decrypt(simetrikAnahtar, sifrelenmisMetin);
            return Encoding.UTF8.GetString(bytes, 0, bytes.Length);
        }
    }
}
