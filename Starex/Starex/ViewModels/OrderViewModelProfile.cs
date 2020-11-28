using AutoMapper;
using Starex.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.ViewModels
{
    public class OrderViewModelProfile:Profile
    {
        public OrderViewModelProfile()
        {
            CreateMap<OrderViewModel, Order>();
        }
    }
}
