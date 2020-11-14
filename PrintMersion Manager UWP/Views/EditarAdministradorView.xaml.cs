using System;
using Windows.UI.Xaml.Controls;
using PrintMersion.Core.Interfaces;
using Windows.Storage.Pickers;
using Windows.Storage;
using PrintMersion.UWP.Controls;
using PrintMersion.UWP.Extencions;
using PrintMersion.Core.Entities;
using PrintMersion.Infrastructure.ApiClient;
using PrintMersion.Core.Globals;

using System.IO;
using Windows.UI.Xaml.Media.Imaging;



// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace PrintMersion.UWP.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class EditarAdministradorView : Page, ICategorical
    {
        private readonly string category = string.Empty;
        private readonly string nameView = typeof(EditarAdministradorView).Name.Replace("View", "");
        private readonly Type type = typeof(EditarAdministradorView);
        private readonly int icon = (int)Symbol.ContactPresence;
     

        public string TagE => "edicion";
       
        public string ContentV => nameView;
        
        public int Icon => icon;

        public string Category => category;

        public Type Type => type;

        IGlobal _global;

        public EditarAdministradorView()
        {
            _global = Startup.GetService<IGlobal>();
            this.InitializeComponent();

            this.UserImage.OpenImage += UserImage_OpenImage;

            this.UserImage.SaveImage += UserImage_SaveImage;

          
            
        }

        private async void UserImage_SaveImage(object sender, ImageSaveEventArgs e)
        {
            if (e.ImageInMemory != null)
            {


                using (var _user = new ClientRepositoryBase<User>(_global.ApiUri, _global.CurrentToken))
                {



                    _global.CurrentUser.IdPictureNavigation = new Picture()
                    {
                        Metadata = "png",
                        DataRaw = await e.ImageInMemory.ToString64()
                    };


                    await _user.Put(_global.CurrentUser);

                }
            }

                
            
        }

        private async void UserImage_OpenImage(object sender, EventArgs e)
        {

            var imagectrol = (EditImageCtrl)sender;
            var filePicker = new FileOpenPicker()
            {
                ViewMode = PickerViewMode.Thumbnail,
                SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                FileTypeFilter = { ".png", ".jpg", ".jpeg" }

            };
            try
            {
                StorageFile file = await filePicker.PickSingleFileAsync();
                if (imagectrol.Editor != null && file != null)
                {
                    await imagectrol.Editor.LoadImageFromFile(file);
                }
            }
            catch (Exception Error)
            {
                //new Log(Error);

            }
        }

        private async void Page_Loading(Windows.UI.Xaml.FrameworkElement sender, object args)
        {
            var pic = _global.CurrentUser.IdPictureNavigation;
            if (pic != null)
            {








                this.UserImage.Editor.Source = await pic.DataRaw.ToWriteableBitmap();
            }
        }
    }
}
