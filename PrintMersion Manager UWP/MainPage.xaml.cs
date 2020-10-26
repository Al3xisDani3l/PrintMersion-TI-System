using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0xc0a

namespace PrintMersion.UWP
{
    /// <summary>
    /// Página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {


        public MainPage()
        {
            this.InitializeComponent();

        }

        private void TxtPassword_DragEnter(object sender, DragEventArgs e)
        {
            BtnAceptar_Click(sender, new RoutedEventArgs());
        }

        private async void BtnAceptar_Click(object sender, RoutedEventArgs e)
        {
            PBarLogin.Visibility = Visibility.Visible;
            PBarLogin.ShowPaused = false;

            if (!string.IsNullOrEmpty(txtUserName.Text) && !string.IsNullOrEmpty(txtPassword.Password))
            {


                //Usuario user = await FindUser(txtUserName.Text);

                //if (user.Contraseña == txtPassword.Password)
                //{
                //    //user2.Profile = new Windows.UI.Xaml.Media.Imaging.BitmapImage(new Uri("ms-appx://Assets/Prueba.jpg"));
                //    Usuario.CurrentUser = user;
                   this.Frame.Navigate(typeof(MenuPage));
                    PBarLogin.ShowPaused = true;
                //}
                //else
                //{
                //    txtEstatusPassword.Text = "Contraseña incorrecta! Intente de nuevo.";
                //    PBarLogin.Visibility = Visibility.Collapsed;
                //    PBarLogin.ShowPaused = true;

                //}
            }



        }



        private async void Hyperlink_Click(Windows.UI.Xaml.Documents.Hyperlink sender, Windows.UI.Xaml.Documents.HyperlinkClickEventArgs args)
        {

        }

        //private async Task<Usuario> FindUser(string UserName)
        //{
        //    Usuario result = new Usuario() { Contraseña = string.Empty, Acceso = Accesos.Invitado };
        //    await Task.Run(async () =>
        //    {
        //        using (DatabaseContext data = new DatabaseContext())
        //        {
        //            result = await (from res in data.Usuarios
        //                            where res.UserName == UserName.ToUpper()
        //                            select res).FirstAsync();
        //        }


        //    });
        //    return result;
        //}

        private void Page_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                BtnAceptar_Click(sender, new RoutedEventArgs());

            }
        }
    }
}

