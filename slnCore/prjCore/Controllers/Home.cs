using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using prjCore.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace prjCore.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()//建立首頁頁面
        {
            return View();
        }

        public IActionResult Privacy()//建立公司資訊頁面
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
