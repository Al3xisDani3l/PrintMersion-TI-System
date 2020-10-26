using PrintMersion.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Animation;
using Windows.UI.Xaml.Navigation;
using PrintMersion.UWP.Views;

// La plantilla de elemento Página en blanco está documentada en https://go.microsoft.com/fwlink/?LinkId=234238

namespace PrintMersion.UWP
{
    
    public enum Accesos
    {
        Invitado = 0,
        Normal = 1,
        Administrador = 2,
        Programador = 3



    }

    public enum Departamentos
    {
        Calidad,
        Zrp1,
        Produccion,
        Other

    }
    /// <summary>
    /// Una página vacía que se puede usar de forma independiente o a la que se puede navegar dentro de un objeto Frame.
    /// </summary>
    public sealed partial class MenuPage : Page, INotifyPropertyChanged
    {
        public ObservableCollection<ICategorical> Categories { get; set; }

        public List<NavigationViewItemBase> Alls { get; set; }

        //public ObservableCollection<NavigationViewItem> Calidad { get; set; }

        //public ObservableCollection<NavigationViewItem> Zrp1 { get; set; }

        //public ObservableCollection<NavigationViewItem> Produccion { get; set; }

        //public ObservableCollection<NavigationViewItem> Otros { get; set; }

        private string NameOfuser;

        public string UserName
        {
            get => NameOfuser; set
            {

                NameOfuser = value;
                NotifyPropertyChanged();

            }
        }


        public MenuPage()
        {
            this.InitializeComponent();

            Alls = new List<NavigationViewItemBase>();
            //Categories = new ObservableCollection<selected>();
            //Calidad = new ObservableCollection<NavigationViewItem>();
            //Zrp1 = new ObservableCollection<NavigationViewItem>();
            //Produccion = new ObservableCollection<NavigationViewItem>();
            //Otros = new ObservableCollection<NavigationViewItem>();

            //Categories.Add(new selected("Inicio", Symbol.Home, "home", typeof(HomePage)));

        

            //GenerateMultiple(selecteds);
            //UserName = Usuario.CurrentUser.Nombre;
            //if (Usuario.CurrentUser.ProfileImage != null)
            //{

            //    try
            //    {

            //        PerPickProfile.ProfilePicture = Usuario.CurrentUser.ProfileImage.ToBitmapImageAsync().Result;
            //    }
            //    catch (Exception Error)
            //    {
            //        new Debug.Log(Error);

            //    }

            //}
           
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region NavigationView
        private void NvMenu_Loaded(object sender, RoutedEventArgs e)
        {

            ContentFram.Navigated += On_Navigated;


            NavView_Navigate("home", new EntranceNavigationTransitionInfo());


            var goBack = new KeyboardAccelerator { Key = VirtualKey.GoBack };
            goBack.Invoked += GoBack_Invoked;
            this.KeyboardAccelerators.Add(goBack);
            // ALT routes here
            var altLeft = new KeyboardAccelerator
            {
                Key = VirtualKey.Left,
                Modifiers = VirtualKeyModifiers.Menu
            };
            altLeft.Invoked += GoBack_Invoked;
            this.KeyboardAccelerators.Add(altLeft);

        }



        private void On_Navigated(object sender, NavigationEventArgs e)
        {
            nvMenu.IsBackEnabled = ContentFram.CanGoBack;

            if (ContentFram.SourcePageType == typeof(ConfiguracionesView))
            {
                // SettingsItem is not part of NavView.MenuItems, and doesn't have a Tag.
                nvMenu.SelectedItem = (NavigationViewItem)nvMenu.SettingsItem;

                nvMenu.Header = (nvMenu.SelectedItem as NavigationViewItem).Content;
            }
            else if (ContentFram.SourcePageType == typeof(EditarAdministradorView))
            {
                nvMenu.Header = "Configuraciones del usuario";
            }
            else if (ContentFram.SourcePageType != null)
            {
                var item = Categories.FirstOrDefault(p => p.Type == e.SourcePageType);



                nvMenu.SelectedItem = Alls.OfType<NavigationViewItem>().First(n => n.Tag.Equals(item.TagE));

                nvMenu.Header = (nvMenu.SelectedItem as NavigationViewItem).Content;
            }
        }

        private void NavView_Navigate(string navItemTag, NavigationTransitionInfo transitionInfo)
        {
            Type Current = null;
            if (navItemTag == "settings")
            {
                Current = typeof(ConfiguracionesView);
            }
            else
            {


                var item = Categories.FirstOrDefault(o => o.TagE.Equals(navItemTag));
                Current = item.Type;
            }
            // Get the Page type before navigation so you can prevent duplicate
            // entries in the backstack.
            var preNavPageType = ContentFram.CurrentSourcePageType;

            // Only navigate if the selected Page isn't currently loaded.
            if (!(Current == null) && !Type.Equals(preNavPageType, Current))
            {
                if (ContentFram != null)
                {
                    ContentFram.Navigate(Current, null, transitionInfo);
                  
                    // ContentFram.Navigate(_Page, null, transitionInfo);

                }

            }
        }

        private void NavView_Navigate(string navItemTag)
        {
            Type Current = null;
            if (navItemTag == "settings")
            {
                Current = typeof(ConfiguracionesView);
            }
            else
            {


                var item = Categories.FirstOrDefault(o => o.TagE.Equals(navItemTag));
                Current = item.Type;
            }
            // Get the Page type before navigation so you can prevent duplicate
            // entries in the backstack.
            var preNavPageType = ContentFram.CurrentSourcePageType;

            // Only navigate if the selected Page isn't currently loaded.
            if (!(Current == null) && !Type.Equals(preNavPageType, Current))
            {
                if (ContentFram != null)
                {
                    ContentFram.Navigate(Current);
                    // ContentFram.Navigate(_Page, null, transitionInfo);

                }

            }
        }

        private void GoBack_Invoked(KeyboardAccelerator sender, KeyboardAcceleratorInvokedEventArgs args)
        {
            On_BackRequested();
        }

        private void NvMenu_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked == true)
            {
                NavView_Navigate("settings", args.RecommendedNavigationTransitionInfo);
            }
            else if (args.InvokedItemContainer != null)
            {
                var navItemTag = args.InvokedItemContainer.Tag.ToString();
                NavView_Navigate(navItemTag, args.RecommendedNavigationTransitionInfo);
            }

        }

        private bool On_BackRequested()
        {
            if (!ContentFram.CanGoBack)
                return false;

            // Don't go back if the nav pane is overlayed.
            if (nvMenu.IsPaneOpen &&
                (nvMenu.DisplayMode == NavigationViewDisplayMode.Compact ||
                 nvMenu.DisplayMode == NavigationViewDisplayMode.Minimal))
                return false;

            ContentFram.GoBack();
            return true;
        }

        //private void GenerateMultiple(IList<ICategorical> selecteds)
        //{

        //    for (int i = 0; i < selecteds.Count; i++)
        //    {

        //        NavigationViewItem item = new NavigationViewItem();
        //        item.Content = selecteds[i].Header;
        //        item.Tag = selecteds[i].Tag;
        //        item.Icon = new SymbolIcon((Symbol)selecteds[i].Icon);
        //        switch (selecteds[i].Departamento)
        //        {
        //            case Departamentos.Calidad:
        //                Calidad.Add(item);
        //                break;
        //            case Departamentos.Zrp1:
        //                Zrp1.Add(item);
        //                break;
        //            case Departamentos.Produccion:
        //                Produccion.Add(item);
        //                break;
        //            case Departamentos.Other:
        //                Otros.Add(item);
        //                break;
        //        }
        //        Categories.Add(selecteds[i]);


        //    }

        //}

        //private void Generate(selected selected)
        //{
        //    NavigationViewItem item = new NavigationViewItem
        //    {
        //        Content = selected.Content,
        //        Tag = selected.Tag,
        //        Icon = new SymbolIcon(selected.Symbols)
        //    };

        //    switch (selected.Departamento)
        //    {
        //        case Departamentos.Calidad:
        //            Calidad.Add(item);
        //            break;
        //        case Departamentos.Zrp1:
        //            Zrp1.Add(item);
        //            break;
        //        case Departamentos.Produccion:
        //            Produccion.Add(item);
        //            break;
        //        case Departamentos.Other:
        //            Otros.Add(item);
        //            break;
        //    }

        //    Categories.Add(selected);


        //}

        private void NvMenu_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            On_BackRequested();
        }

        


        #region AutoSuggestBox

        private void AsbOperaciones_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            if (args.Reason == AutoSuggestionBoxTextChangeReason.UserInput)
            {
                var temp = Categories.Where(o => o.ToString().ToLowerInvariant().Contains(sender.Text.ToLowerInvariant().ToString()));
                //Set the ItemsSource to be your filtered dataset

                sender.ItemsSource = temp;
            }
        }

        private void AsbOperaciones_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            if (args.ChosenSuggestion != null)
            {
                sender.Text = ((ICategorical)args.ChosenSuggestion).TagE;
            }

        }


        private void AsbOperaciones_SuggestionChosen(AutoSuggestBox sender, AutoSuggestBoxSuggestionChosenEventArgs args)
        {
            if (args.SelectedItem != null)
            {
                NavView_Navigate((args.SelectedItem as ICategorical).TagE);
            }
        }

        #endregion

        #endregion


        #region Eventos

        private async void Page_Loading(FrameworkElement sender, object args)
        {

            var result = await GetViews();

            Categories = new ObservableCollection<ICategorical>(result);

            Alls.AddRange(MenuItems(result));
            
        }

        private void MenuFlyoutItem_Click(object sender, RoutedEventArgs e)
        {
            
            this.Frame.Navigate(typeof(MainPage));
        }

        private void BtmChangeImage_Click(object sender, RoutedEventArgs e)
        {
            this.ContentFram.Navigate(typeof(EditarAdministradorView));
        }

        #endregion

        #region Private Funcions

        private static async Task<IEnumerable<ICategorical>> GetViews()
        {

            List<ICategorical> result = new List<ICategorical>();

            var Pages = GetNamespacesInAssembly("PrintMersion.UWP.Views");

            foreach (var item in Pages)
            {
                if (item.GetInterfaces().Contains(typeof(ICategorical)) && !item.IsAbstract)
                {
                    result.Add((ICategorical)Activator.CreateInstance(item));
                }

               
            }

            return await Task.FromResult(result);

        }

        private static IEnumerable<Type> GetNamespacesInAssembly(string namespaces)
        {
            IEnumerable<Assembly> assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(a => a.FullName.Contains(namespaces.Substring(0, namespaces.IndexOf('.'))));
            List<Type> types = new List<Type>();
            foreach (var item in assemblies)
            {
                foreach (var t in item.GetTypes())
                {
                    if (!string.IsNullOrEmpty(t.Namespace))
                    {
                        if (t.Namespace.Contains(namespaces))
                        {
                            types.Add(t);
                        }
                    }

                }
            }

            return types;




        }

        private IEnumerable<NavigationViewItemBase> MenuItems(IEnumerable<ICategorical> categoricals)
        {
            yield return new NavigationViewItem { Content = "Inicio", Tag = "home", Icon = new SymbolIcon(Symbol.Home) };

            foreach (var item in GetEtiquetas(categoricals))
            {
                yield return new NavigationViewItemHeader { Content = item };
                foreach (var element in categoricals)
                {
                    if (item == element.Category)
                    {
                        NavigationViewItem viewItem = new NavigationViewItem();
                        viewItem.Content = element.ContentV;
                        viewItem.Tag = element.TagE;
                        viewItem.Icon = new SymbolIcon((Symbol)element.Icon);
                        yield return viewItem;
                    }

                }

            }


        }

        private IEnumerable<string> GetEtiquetas(IEnumerable<ICategorical> categoricals)
        {

           
            var raw = categoricals.Select(s => s.Category).Where(f => !string.IsNullOrEmpty(f));

            return raw.Distinct();

        }

        #endregion


    }


    public class NavigationItemTemplateSelector : DataTemplateSelector
    {
        public DataTemplate ItemView { get; set; }
        public DataTemplate HeaderView { get; set; }
        public DataTemplate SeparatorView { get; set; }

        protected override DataTemplate SelectTemplateCore(object item)
        {
            if (item is NavigationViewItem)
            {
                return ItemView;
            }
            else if (item is NavigationViewItemHeader)
            {
                return HeaderView;
            }
            else
            {
                return SeparatorView;
            }
        }
    }
}
