using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using WebDev.Application.Config;
using WebDev.Application.Mappers;
using WebDev.Application.Models;
using WebDev.Services;

namespace WebDev.Application.Controllers
{
  public class HomeController : Controller
  {
    private readonly LoginService loginService;

    public HomeController(IOptions<ApiConfiguration> apiConfiguration)
    {
      var _apiConfiguration = apiConfiguration.Value;
      loginService = new LoginService(_apiConfiguration.ApiUsersUrl);
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
          if (await IsValidUser(login))
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

    private async Task<bool> IsValidUser(Login login)
    {
      var tokenDto = await loginService.ValidUser(LoginMapper.ToDto(login));
      if (tokenDto == null)
      {
        HttpContext.Session.SetString("IsUserLogged", "false");
        return false;
      }
      HttpContext.Session.SetString("IsUserLogged", "true");
      
      HttpContext.Session.SetString("User", tokenDto.Name);

      HttpContext.Session.SetString("TokenData", JsonConvert.SerializeObject(TokenMapper.ToEntity(tokenDto)));

      return true;
    }
  }
}