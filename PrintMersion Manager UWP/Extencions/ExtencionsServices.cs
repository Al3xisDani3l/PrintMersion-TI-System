using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using PrintMersion.Core.Entities;
using Windows.Security.Cryptography;
namespace PrintMersion.UWP.Extencions
{
    public static class ExtencionsServices
    {
        public static async Task<string> ToString64(this IRandomAccessStream accessStream)
        {
            var raw = await accessStream.ToByteArray();
            return CryptographicBuffer.EncodeToBase64String(raw.AsBuffer());

        }

        public static async Task<byte[]> ToByteArray(this IRandomAccessStream accessStream)
        {
            var stream = accessStream.AsStreamForRead();

            byte[] array = new byte[stream.Length];

            await stream.ReadAsync(array, 0, array.Length);

            return array;
        }

        //public static async Task<IRandomAccessStream> ToRandomAccessAsync(this Picture picture)
        //{

        // var result =   CryptographicBuffer.DecodeFromBase64String(picture.DataRaw).AsStream().AsRandomAccessStream();

         

        //    return await Task.FromResult(result);


        //}

         public static async Task<IRandomAccessStream> ToRandomAccessStream(this string base64)
        {

            return await CryptographicBuffer.DecodeFromBase64String(base64).ToArray().ToRandomAccessStream();

        }


        public static async Task<IRandomAccessStream> ToRandomAccessStream(this byte[] array)
        {

            var result = array.AsBuffer().AsStream().AsRandomAccessStream();

            return  await Task.FromResult(result);
            //           InMemoryRandomAccessStream result
            //= new InMemoryRandomAccessStream();
            //           await result.WriteAsync(array.AsBuffer());
            //           result.Seek(0);
            //           return result;
        }

        //public static async Task<BitmapImage> ToBitmapImageAsync(this IRandomAccessStream accessStream)
        //{


        //    accessStream.Seek(0);
        //    BitmapImage bitmap = new BitmapImage();
        //    await bitmap.SetSourceAsync(accessStream);
        //    return bitmap;
        //}

        //public static async Task<BitmapImage> ToBitmapImageAsync(this byte[] array)
        //{
        //    return await array.ToRandomAccessStream().ToBitmapImageAsync();
        //}

        //public static async Task<BitmapImage> ToBitmapImaregeAsync(this string dataRaw)
        //{

        //    var byteArray = CryptographicBuffer.DecodeFromBase64String(dataRaw);
            

        //    return await byteArray.ToArray().ToBitmapImageAsync();

        //}

        //public static async Task<BitmapImage> ToBitmapImageAsync(this Picture picture)
        //{

        //    var bitmap = picture.DataRaw;
        //    using (var memory = new MemoryStream())
        //    {
        //        bitmap.Save(memory, ImageFormat.Png);
        //        memory.Position = 0;

        //        var bitmapImage = new BitmapImage();
        //       await    bitmapImage.SetSourceAsync(memory.AsRandomAccessStream());

        //        return bitmapImage;
        //    }


            
        //}

        public static async Task<string> StorageFileToBase64(this IRandomAccessStream file)
        {
            string Base64String = "";

            if (file != null)
            {
                IRandomAccessStream fileStream = file;
                var reader = new DataReader(fileStream.GetInputStreamAt(0));
                await reader.LoadAsync((uint)fileStream.Size);
                byte[] byteArray = new byte[fileStream.Size];
                reader.ReadBytes(byteArray);
                Base64String = Convert.ToBase64String(byteArray);
            }

            return Base64String;
        }


        public static async Task<BitmapImage> ToBitmapImage(this IRandomAccessStream randomAccessStream)
        {
            BitmapImage image = new BitmapImage();
            
            randomAccessStream.Seek(0);
            await  image.SetSourceAsync(randomAccessStream);

            return image;


        }

       public static async Task<WriteableBitmap> ToWriteableBitmap(this IRandomAccessStream randomAccessStream)
        {

            randomAccessStream.Seek(0);

            BitmapImage bitmap = await randomAccessStream.ToBitmapImage();
          

           var writeable = new WriteableBitmap(bitmap.PixelWidth, bitmap.PixelHeight);

            randomAccessStream.Seek(0);

            writeable.SetSource(randomAccessStream);

            return writeable;

        }


       public static async Task<BitmapImage>  ToBitmapImage(this string base64)
        {

         var result = await base64.ToRandomAccessStream();
            return await result.ToBitmapImage();


        }


        public static async Task<WriteableBitmap> ToWriteableBitmap(this string base64)
        {

            var result = await base64.ToRandomAccessStream();
            return await result.ToWriteableBitmap();


        }

    }
}