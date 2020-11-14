using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrintMersion.Core.Entities;
using PrintMersion.Core.Interfaces;

namespace PrintMersion.Core.Globals
{
    public  class GlobalData:IGlobal
    {
        public string CurrentToken { get; set; }

        public  UserLogin CurrentLogin { get; set; }

        public  User CurrentUser { get; set; }

        public  Picture CurrentUserPicture { get; set; }

        public string ApiUri { get; set; } = @"https://printmersion.azurewebsites.net";

    }
}
