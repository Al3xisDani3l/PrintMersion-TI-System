using System;
using System.IO;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace PrintMersion.UWP.Extencions
{
    public static class ExtencionsServices
    {
        public static async Task<string> ToString64(this IRandomAccessStream accessStream)
        {
            var raw = await accessStream.ToByteArray();
            return Convert.ToBase64String(raw);

        }

        public static async Task<byte[]> ToByteArray(this IRandomAccessStream accessStream)
        {
            var stream = accessStream.AsStreamForRead();

            byte[] array = new byte[stream.Length];

            await stream.ReadAsync(array, 0, array.Length);

            return array;
        }

        public static IRandomAccessStream ToRandomAccessStream(this byte[] array)
        {

            return array.AsBuffer().AsStream().AsRandomAccessStream();
            //           InMemoryRandomAccessStream result
            //= new InMemoryRandomAccessStream();
            //           await result.WriteAsync(array.AsBuffer());
            //           result.Seek(0);
            //           return result;
        }

        public static async Task<BitmapImage> ToBitmapImageAsync(this IRandomAccessStream accessStream)
        {


            accessStream.Seek(0);
            BitmapImage bitmap = new BitmapImage();
            await bitmap.SetSourceAsync(accessStream);
            return bitmap;
        }

        public static async Task<BitmapImage> ToBitmapImageAsync(this byte[] array)
        {
            return await array.ToRandomAccessStream().ToBitmapImageAsync();
        }

        public static async Task<BitmapImage> ToBitmapImaregeAsync(this string dataRaw)
        {

            var byteArray = Convert.FromBase64String(dataRaw);

            return await byteArray.ToBitmapImageAsync();

        }

    }
}