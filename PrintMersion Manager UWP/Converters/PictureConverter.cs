using PrintMersion.Core.Entities;
using PrintMersion.UWP.Extencions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Media.Imaging;

namespace PrintMersion.UWP.Converters
{
   
 
 public class PictureConverter:IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, string language)
        {


            if (value != null)
            {
                var image = (Picture)value;

                var taskResource = new TaskCompletionSource<BitmapImage>();

                 Task.Factory.StartNew(async () => { taskResource.SetResult(await image.DataRaw.ToBitmapImage()); });

                return taskResource.Task.Result;
               
            }

            return null;

               

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language)
        {
            throw new NotImplementedException();
        }
    }
}

