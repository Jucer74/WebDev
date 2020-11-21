﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebDev.Application.Models;
using Microsoft.AspNetCore.Http;

namespace WebDev.Application.Controllers
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
      ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
      ViewData["User"] = HttpContext.Session.GetString("User");
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

    [HttpGet]
    [Route("[controller]/[action]")]
    public IActionResult Login()
    {
      return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(Login login)
    {
      try
      {
        if (ModelState.IsValid)
        {
          // Llamar a la API para validar el Login
          if (await IsValidUser(login.Email, login.Password))
          {
            return Redirect(nameof(Index));
          }
          ModelState.AddModelError(string.Empty, "Intento de inicio de sesión no válido.");
        }
      }
      catch (Exception ex)
      {
        ModelState.AddModelError(string.Empty, ex.Message);
      }
      return View();
    }

    public IActionResult Logout()
    {
      HttpContext.Session.SetString("IsUserLogged", "false");
      return RedirectToAction(nameof(Index));
    }

    private async Task<bool> IsValidUser(string email, string password)
    {
      if (email.Equals("demouser@email.com") && password.Equals("Password*01"))
      {
        HttpContext.Session.SetString("IsUserLogged", "true");
        HttpContext.Session.SetString("User", email);
        return true;
      }
      HttpContext.Session.SetString("IsUserLogged", "false");
      return false;
    }
  }
}