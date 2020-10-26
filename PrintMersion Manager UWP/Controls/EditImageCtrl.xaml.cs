using Microsoft.Toolkit.Uwp.UI.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace PrintMersion.UWP.Controls
{
    public enum Destiny
    {
        StorageFile,
        SqlServer
    }

    public sealed partial class EditImageCtrl : UserControl, INotifyPropertyChanged
    {

        public Destiny DestinoDeAbertura { get; set; } = Destiny.StorageFile;
        public Destiny DestinoDeSalvado { get; set; } = Destiny.SqlServer;

        private InMemoryRandomAccessStream _inMemory = null;


        public InMemoryRandomAccessStream InMemory { get; set; }

        public InMemoryRandomAccessStream InDatabase
        {
            get => _inMemory;
            set
            {
                _inMemory = value;
                OnPropertyChanged();
            }
        }


        public ImageCropper Editor { get => ImageCropper; }

        public EditImageCtrl()
        {
            this.InitializeComponent();
            Load();
        }

        public event PropertyChangedEventHandler PropertyChanged;

#pragma warning disable CS0628 // Nuevo miembro protegido declarado en una clase sellada
        protected void OnPropertyChanged([CallerMemberName] string property = "")
#pragma warning restore CS0628 // Nuevo miembro protegido declarado en una clase sellada
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        public void Load()
        {
            List<AspectRatio> ratios = new List<AspectRatio>()
            {
                new AspectRatio
                {
                    Nombre = "Personalizado",
                    Radio = null

                }
                ,
                new AspectRatio
                {
                    Nombre = "Cuadrado",
                    Radio = 1
                }
                 ,
                new AspectRatio
                {
                    Nombre = "Landscape (16:9)",
                    Radio = 16d/9d
                }
                 ,
                new AspectRatio
                {
                    Nombre = "Portrait (9:16)",
                    Radio = 9d/16d

                }
                 ,
                new AspectRatio
                {
                    Nombre = "4:3",
                    Radio = 4d/3d

                }
                 ,
                new AspectRatio
                {
                    Nombre = "3:2",
                    Radio = 3d/2d

                }



    };

            aspectSelector.ItemsSource = ratios;
            aspectSelector.DisplayMemberPath = "Nombre";
            aspectSelector.SelectedValuePath = "Radio";
            aspectSelector.SelectedIndex = 0;
            aspectSelector.SelectionChanged += AspectSelector_SelectionChanged;


        }

        private void AspectSelector_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ImageCropper.AspectRatio = aspectSelector.SelectedValue as double?;

        }

        private async void BtnPickImage_Click(object sender, RoutedEventArgs e)
        {

            switch (DestinoDeAbertura)
            {
                case Destiny.StorageFile:
                    var filePicker = new FileOpenPicker()
                    {
                        ViewMode = PickerViewMode.Thumbnail,
                        SuggestedStartLocation = PickerLocationId.PicturesLibrary,
                        FileTypeFilter = { ".png", ".jpg", ".jpeg" }

                    };
                    try
                    {
                        StorageFile file = await filePicker.PickSingleFileAsync();
                        if (ImageCropper != null && file != null)
                        {
                            await ImageCropper.LoadImageFromFile(file);
                        }
                    }
                    catch (Exception Error)
                    {
                        //new Log(Error);

                    }

                    break;
                case Destiny.SqlServer:

                    if (InDatabase != null)
                    {
                        throw new NotSupportedException();
                    }

                    break;
                default:
                    break;
            }


        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            switch (DestinoDeSalvado)
            {
                case Destiny.StorageFile:
                    var savePicker = new FileSavePicker

                    {

                        SuggestedStartLocation = PickerLocationId.PicturesLibrary,

                        SuggestedFileName = "Cropped_Image",

                        FileTypeChoices =

                {

                    { "PNG Picture", new List<string> { ".png" } },

                    { "JPEG Picture", new List<string> { ".jpg" } }

                }

                    };


                    var imageFile = await savePicker.PickSaveFileAsync();

                    if (imageFile != null)

                    {

                        BitmapFileFormat bitmapFileFormat;

                        switch (imageFile.FileType.ToLower())

                        {

                            case ".png":

                                bitmapFileFormat = BitmapFileFormat.Png;

                                break;

                            case ".jpg":

                                bitmapFileFormat = BitmapFileFormat.Jpeg;

                                break;

                            default:

                                bitmapFileFormat = BitmapFileFormat.Png;

                                break;

                        }



                        using (var fileStream = await imageFile.OpenAsync(FileAccessMode.ReadWrite, StorageOpenOptions.None))

                        {

                            await ImageCropper.SaveAsync(fileStream, bitmapFileFormat);

                        }
                    }

                    break;

                case Destiny.SqlServer:
                    try
                    {
                        var result = new InMemoryRandomAccessStream();
                        await ImageCropper.SaveAsync(result, BitmapFileFormat.Png);
                        InDatabase = result;

                    }
                    catch (Exception Error)
                    {

                        //new Log(Error);
                    }



                    break;
                default:
                    break;
            }

        }

        private void BtnReset_Click(object sender, RoutedEventArgs e)
        {
            ImageCropper.Reset();
        }

        private void ComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if ((shapeSelector.SelectedItem as string) == "Rectangular")
            {
                ImageCropper.CropShape = CropShape.Rectangular;
            }
            else
            {
                ImageCropper.CropShape = CropShape.Circular;
            }


        }
    }

    public class AspectRatio
    {
        public string Nombre { get; set; }

        public double? Radio { get; set; }
    }
}

