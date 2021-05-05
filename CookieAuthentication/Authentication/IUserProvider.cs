﻿using CookieAuthentication.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CookieAuthentication.Authentication
{
    public interface IUserProvider
    {
        User User { get; set; }
    }
}
