using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using LaCroute.Data;
using LaCroute.Models;
using Microsoft.AspNetCore.Authorization;

namespace LaCroute;

[Authorize]
[Route("admin")]
public class AdminController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

    
}
