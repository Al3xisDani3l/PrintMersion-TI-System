using PrintMersion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace PrintMersion.Core.Interfaces
{
    public interface IGlobal
    {
        string CurrentToken { get; set; }

        UserLogin CurrentLogin { get; set; }

        User CurrentUser { get; set; }

        Picture CurrentUserPicture { get; set; }

        string ApiUri { get; set; } 

    }
}
