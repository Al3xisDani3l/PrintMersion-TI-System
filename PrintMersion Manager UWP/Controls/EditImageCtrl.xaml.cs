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
    

    public sealed partial class EditImageCtrl : UserControl
    {

       



        public InMemoryRandomAccessStream InMemory { get; set; }

        public ImageCropper Editor { get => ImageCropper; }

        public event EventHandler OpenImage;

        public event EventHandler<ImageSaveEventArgs> SaveImage;

      

        public EditImageCtrl()
        {
            this.InitializeComponent();
            Load();
        }


         void OnOpenImage(EventArgs e)
        {
            EventHandler handler = OpenImage;
            handler?.Invoke(this, e);
        }

        void OnSaveImage(ImageSaveEventArgs e)
        {
            EventHandler<ImageSaveEventArgs> handler = SaveImage;
            handler?.Invoke(this, e);
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


            OnOpenImage(new EventArgs());
                   



        }

        private async void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            var result = new InMemoryRandomAccessStream();
            await ImageCropper.SaveAsync(result, BitmapFileFormat.Png);

            OnSaveImage(new ImageSaveEventArgs() { ImageInMemory = result });

           
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

    public class ImageSaveEventArgs : EventArgs
    {
     public InMemoryRandomAccessStream ImageInMemory { get; set; }
    }
}

