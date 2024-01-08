using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaCroute.Data;
using LaCroute.Models;

namespace LaCroute
{
    public class AdminController : Controller
    {
        private readonly LaCrouteContext _context;

            public AdminController(LaCrouteContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index() 
        {
            return View();
        }
    }
}

