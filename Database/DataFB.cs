using Firebase.Database;
using Firebase.Database.Query;
using Firebase.Storage;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asama1.Database
{
   public class DataFB
    {
        FirebaseClient fbClient;
        public DataFB()
        {
            fbClient = new FirebaseClient("https://steptwo-db334-default-rtdb.firebaseio.com/");
        }

		public async Task<List<DataUse>> getUserList()
		{
			return (await fbClient
				.Child("Asama1")
				.OnceAsync<DataUse>())
				.Select((item) =>
				new DataUse
				{

				Key=item.Key,
				Posta=item.Object.Posta,
				AdSoyad=item.Object.AdSoyad,
				KullanıcıAdı=item.Object.KullanıcıAdı,
				Sifre=item.Object.Sifre,
				DogKodu=item.Object.DogKodu,
				
				}).ToList();
		}

		public async Task saveUse(DataUse du)
		{
			await fbClient.Child("Asama1")
					.PostAsync(du);

		}

		public async Task<DataUse> GetLook()
		{
			
			var allPersons = await getUserList();
			await fbClient
			  .Child("Asama1")
			  .OnceAsync<DataUse>();
			return allPersons.FirstOrDefault();
		}

		public async Task DeletePerson()
		{
			var delete = (await fbClient.Child("Asama1").OnceAsync<DataUse>())

			   .FirstOrDefault();

			await fbClient.Child("Asama1").Child(delete.Key).DeleteAsync();

		}
		
		public async Task SaveUserRequest(Stream imgStream1, Stream imgStream2, StorageUser req)
		{
			

			var postData = await fbClient.Child("Resim").PostAsync<StorageUser>(req);
			var postData2 = await fbClient.Child("Resim").PostAsync<StorageUser>(req);

			var imgUrl1 = await new FirebaseStorage("steptwo-db334.appspot.com")

				.Child("Resim")
				.Child(postData.Key)
				.PutAsync(imgStream1);

			var imgUrl2 = await new FirebaseStorage("steptwo-db334.appspot.com")

				.Child("Resim")
				.Child(postData2.Key)
				.PutAsync(imgStream2);

			req.ImageUrl1 = imgUrl1;
			req.ImageUrl2 = imgUrl2;

            var updateData1 = fbClient.Child("Resim" + "/" + postData.Key +postData2.Key)
                                   .PutAsync<StorageUser>(req);

            //---

            //var imgUrl2 = await new FirebaseStorage("steptwo-db334.appspot.com")

            //	.Child("Asama1")
            //	.Child(postData.Key)
            //	.PutAsync(imgStream2);

            //req.ImageUrl2 = imgUrl2;

            //var updateData2 = fbClient.Child("Asama1" + "/" + postData.Key)
            //					   .PutAsync<StorageUser>(req);
        }

        public async Task<List<StorageUser>> GetUsers()
		{

			var list1 = (await fbClient.Child("Resim").OnceAsync<StorageUser>()).Select(item =>
			new StorageUser
			{
				ImageUrl1 = item.Object.ImageUrl1,
				ImageUrl2 = item.Object.ImageUrl2,
				//Idda = item.Object.Idda,
				//Tarih = item.Object.Tarih

			}).ToList();

			return list1;
		}

	}
}
