using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CMS.Models;

namespace CMS.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        string user = "Hardy Wen";
        int stu_num = 21447;

        var currentTime = DateTime.Now;
        string greeting = "";
        greeting = (currentTime.Hour >= 0 && currentTime.Hour < 12) ? "Good Morning" :
            (currentTime.Hour >= 12 && currentTime.Hour < 18) ? "Good Afternoon" : "Good Evening";

        ViewBag.user = user;
        ViewBag.stu_num = stu_num;
        ViewBag.greeting = greeting;

        return View();
    }

    public IActionResult About()
    {
        string admin = "Jingcheng";

        ViewBag.admin = admin;

        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

