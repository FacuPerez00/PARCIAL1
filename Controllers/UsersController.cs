using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using PARCIAL1.Models;

namespace PARCIAL1.Controllers;

public class UsersController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public UsersController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
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
