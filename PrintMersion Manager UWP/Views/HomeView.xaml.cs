using PrintMersion.Core.Interfaces;
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

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace PrintMersion.UWP.Views
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class HomeView : Page, ICategorical
    {
        private readonly string category = string.Empty;
        private readonly string nameView = typeof(HomeView).Name.Replace("View", "");
        private readonly Type type = typeof(HomeView);
        private readonly int icon = (int)Symbol.ContactPresence;
        private readonly string tag = "home";

        public string TagE => tag;
        public string Category => category;
        public string ContentV => nameView;
        public Type Type => type;
        public int Icon => icon;
        public HomeView()
        {
            this.InitializeComponent();
        }

    }
}
