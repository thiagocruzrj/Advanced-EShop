﻿using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace AES.WebApp.MVC.Extensions
{
    public class SummaryViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return View();
        }
    }
}
