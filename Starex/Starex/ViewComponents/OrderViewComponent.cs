using Microsoft.AspNetCore.Mvc;
using Starex.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.ViewComponents
{
    public class OrderViewComponent:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(OrderViewModel orderViewModel)
        {
            
            return await Task.FromResult((IViewComponentResult)View(orderViewModel));
        }
    }
}
