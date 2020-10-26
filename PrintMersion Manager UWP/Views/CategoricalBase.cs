using System;
using System.Collections.Generic;
using System.Text;
using PrintMersion.Core.Interfaces;
using Windows.UI.Xaml.Controls;


namespace PrintMersion.UWP.Views
{
   public abstract class CategoricalBase:Page,ICategorical
    {
        #region Icategorical Implementation

        #region Implementacion

        public  string TagE => this.GetType().Name.Replace("View", "");
        public  string Category => GetCategory();
        public  string ContentV => GetTitle();
        public  Type Type => this.GetType();
        public  int Icon { get; }

        #endregion

        #region funciones
        public  string GetTitle()
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

        public  string GetCategory()
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



    }
}
