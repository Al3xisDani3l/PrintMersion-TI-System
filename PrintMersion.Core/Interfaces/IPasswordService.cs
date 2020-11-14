using System;
using System.Collections.Generic;
using System.Text;

namespace PrintMersion.Core.Interfaces
{
    public interface IPasswordService
    {
        string Hash(string password);

        bool Check(string hash, string password);
    }
}
