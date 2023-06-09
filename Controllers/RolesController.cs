using System.Diagnostics;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using PARCIAL1.Models;
using Microsoft.AspNetCore.Authorization;
using PARCIAL1.Views.Roles.ViewModels;

namespace PARCIAL1.Controllers;

public class RolesController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly RoleManager<IdentityRole> _roleManager;

    public RolesController(
        ILogger<HomeController> logger,
        RoleManager<IdentityRole>roleManager)
    {
        _logger = logger;
        _roleManager=roleManager;
    }

    public IActionResult Index()
    {
        //guarda los usuarios en el index
        var roles= _roleManager.Roles.ToList();
        return View(roles);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(RoleCreateViewModel model)
    {
        if(string.IsNullOrEmpty(model.RoleName)) 
        {
            return View();
        }
         
        var role= new IdentityRole(model.RoleName);
        _roleManager.CreateAsync(role);

        return RedirectToAction("Index");
    }

    
   
    

    
}
