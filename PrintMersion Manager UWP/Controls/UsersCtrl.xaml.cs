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
using System.Threading.Tasks;
using Microsoft.Toolkit.Uwp.UI.Controls;
using System.Linq;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Globals;
using PrintMersion.Infrastructure.ApiClient;
using PrintMersion.Core.Interfaces;
using System.Collections.ObjectModel;

// La plantilla de elemento Control de usuario está documentada en https://go.microsoft.com/fwlink/?LinkId=234236

namespace PrintMersion.UWP.Controls
{
    public sealed partial class UsersCtrl : UserControl
    {
        public  ObservableCollection<User> Users { get; set; }

        IRepository<User> _clientRepository;

       

        public UsersCtrl()
        {
            this.InitializeComponent();

            _clientRepository = Startup.GetService<IRepository<User>>();

            

           

            Users = new ObservableCollection<User>();
           
            DataContext = this;
        }

        private async void UserControl_Loading(FrameworkElement sender, object args)
        {

            try
            {
                var data = await _clientRepository.Get();

                data.ToList().ForEach(user => Users.Add(user));




            }
            catch (Exception Ex)
            {



            }




        }
    }
}
