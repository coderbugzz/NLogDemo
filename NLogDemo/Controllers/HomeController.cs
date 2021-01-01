using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using NLogDemo.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NLogDemo.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            _logger.LogInformation("This is the homepage!");
            List<member_info> info = new List<member_info>();

            info.Add(new member_info { FullName = "FreeCode Spot", Website = "freecodespot.com" });
            info.Add(new member_info { FullName = "FreeCode Spot", Website = "freecodespot.com" });

            string json_value = JsonConvert.SerializeObject(info);

            _logger.LogInformation(json_value);

            return View();
        }

        public IActionResult Privacy()
        {
            _logger.LogInformation("This is the Privacy Page");

            try
            {
                int s = int.Parse("error"); //Test excemption
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Exception found in Privacy page");
            }

            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
