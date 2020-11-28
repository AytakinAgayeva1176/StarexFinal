using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Starex.Contexts;
using Starex.Models;
using Starex.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Starex.ViewComponents
{
    public class DeclarationViewComponent : ViewComponent
    {
        private readonly StarexDbContext context;
        public int? _countryId;
        public DeclarationViewComponent(StarexDbContext context)
        {
            this.context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
           
            return await Task.FromResult((IViewComponentResult)View());
        }
    }
}
