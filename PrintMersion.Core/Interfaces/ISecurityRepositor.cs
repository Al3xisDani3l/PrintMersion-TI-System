﻿using PrintMersion.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PrintMersion.Core.Interfaces
{
  public  interface ISecurityRepositor
    {
        Task<User> GetLoginByCredentials(UserLogin login);

        Task RegisterUser(User security);
    }
}
