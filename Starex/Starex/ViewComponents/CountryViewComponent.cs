using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.ViewComponents
{
    public class CountryViewComponent: ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            return await Task.FromResult((IViewComponentResult)View());
        }
    }
}
