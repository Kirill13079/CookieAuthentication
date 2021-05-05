using AutoMapper;
using CookieAuthentication.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CookieAuthentication.Models
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, RegisterViewModel>();
            CreateMap<RegisterViewModel, User>();
        }
    }
}