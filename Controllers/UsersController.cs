using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using PARCIAL1.Models;
using PARCIAL1.Views.Users.ViewModels;

namespace PARCIAL1.Controllers;

public class UsersController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;

    public UsersController(
        ILogger<HomeController> logger,
        UserManager<IdentityUser>userManager,
        RoleManager<IdentityRole>roleManager)
    {
        _logger = logger;
        _userManager=userManager;
        _roleManager=roleManager;
    }

    public IActionResult Index()
    {
        //guarda los usuarios en el index
        var users= _userManager.Users.ToList();
        return View(users);
    }
    
    
    public async Task<IActionResult> Edit(string id)
    {
        var user =await _userManager.FindByIdAsync(id);
        
        var userViewModel= new UserEditViewModel();
        userViewModel.UserName=user.UserName ?? string.Empty;
        userViewModel.Email=user.Email ?? string.Empty; 
        userViewModel.Roles= new SelectList(_roleManager.Roles.ToList());

        return View(userViewModel);
    }

    [HttpPost]

    public async Task<IActionResult> Edit(UserEditViewModel model)
    {
           var user= await _userManager.FindByNameAsync(model.UserName);
           if(user !=null)
           {
             await _userManager.AddToRoleAsync(user, model.Role);
           }
           
           return RedirectToAction("Index");
    }
    
   
    

    
}
