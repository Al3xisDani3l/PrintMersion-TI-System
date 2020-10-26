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
using PrintMersion.Core.Interfaces;
using System.Text;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace PrintMersion.UWP.Views.Pedidos
{
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class OrdenesCompletadasView : Page,ICategorical
    {
        #region Icategorical Implementation

        #region Implementacion

        public string TagE => this.GetType().Name.Replace("View", "");
        public string Category => GetCategory();
        public string ContentV => GetTitle();
        public Type Type => this.GetType();
        public int Icon { get; }

        #endregion

        #region funciones
        public string GetTitle()
        {
            var result = this.GetType().Name.Replace("View", "");
            StringBuilder builder = new StringBuilder();
            foreach (var item in result)
            {
                if (char.IsUpper(item))
                {
                    builder.Append(" ");
                }

                builder.Append(item);


            }

            builder.Remove(0, 1);

            return builder.ToString();

        }

        public string GetCategory()
        {
            var raw = this.GetType().Namespace;

            var index = raw.LastIndexOf('.') + 1;

            string result = raw.Substring(index, raw.Length - index);


            return result.Replace("_", " ");


        }

        public override string ToString()
        {
            return ContentV;
        }
        #endregion
        #endregion

        public OrdenesCompletadasView()
        {
            this.InitializeComponent();
        }
    }
}
