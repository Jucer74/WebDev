using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDev.Application.Config;
using WebDev.Application.Mappers;
using WebDev.Application.Models;
using WebDev.Services;
using WebDev.Services.Entities;

namespace WebDev.Application.Controllers
{
  public class UsersController : Controller
  {
    private readonly UsersService usersService;

    public UsersController(IOptions<ApiConfiguration> apiConfiguration)
    {
      var _apiConfiguration = apiConfiguration.Value;
      usersService = new UsersService(_apiConfiguration.ApiUsersUrl);
    }

    // GET: UsersController
    [HttpGet]
    public async Task<ActionResult> Index()
    {
      ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

      usersService.TokenDto = TokenMapper.ToDto(JsonConvert.DeserializeObject<TokenData>(HttpContext.Session.GetString("TokenData")));

      IList<UserDto> users = await usersService.GetUsers();

      List<User> userList = users.Select(userDto => UserMapper.ToEntity(userDto)).ToList();

      return View(userList);
    }

    // GET: UsersController/Details/5
    [HttpGet]
    public async Task<ActionResult> Details(int id)
    {
      usersService.TokenDto = TokenMapper.ToDto(JsonConvert.DeserializeObject<TokenData>(HttpContext.Session.GetString("TokenData")));
      var userFound = await usersService.GetUserById(id);
      if (userFound == null)
      {
        return NotFound();
      }

      ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

      var user = UserMapper.ToEntity(userFound);
      return View(user);
    }

    // GET: UsersController/Create
    [HttpGet]
    public ActionResult Create()
    {
      ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");
      return View();
    }

    // POST: UsersController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Create(User user)
    {
      try
      {
        if (ModelState.IsValid)
        {
          usersService.TokenDto = TokenMapper.ToDto(JsonConvert.DeserializeObject<TokenData>(HttpContext.Session.GetString("TokenData")));
          await usersService.AddUser(UserMapper.ToDto(user));
        }

        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }

    // GET: UsersController/Edit/5
    [HttpGet]
    public async Task<ActionResult> Edit(int id)
    {
      usersService.TokenDto = TokenMapper.ToDto(JsonConvert.DeserializeObject<TokenData>(HttpContext.Session.GetString("TokenData")));
      var userFound = await usersService.GetUserById(id);

      if (userFound == null)
      {
        return NotFound();
      }

      ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

      var user = UserMapper.ToEntity(userFound);
      return View(user);
    }

    // POST: UsersController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(User user)
    {
      try
      {
        if (ModelState.IsValid)
        {
          usersService.TokenDto = TokenMapper.ToDto(JsonConvert.DeserializeObject<TokenData>(HttpContext.Session.GetString("TokenData")));
          await usersService.UpdateUser(UserMapper.ToDto(user));

          return RedirectToAction(nameof(Index));
        }
        return View(user);
      }
      catch
      {
        return View();
      }
    }

    // GET: UsersController/Delete/5
    [HttpGet]
    public async Task<ActionResult> Delete(int id)
    {
      usersService.TokenDto = TokenMapper.ToDto(JsonConvert.DeserializeObject<TokenData>(HttpContext.Session.GetString("TokenData")));
      var userFound = await usersService.GetUserById(id);
      if (userFound == null)
      {
        return NotFound();
      }

      ViewData["IsUserLogged"] = HttpContext.Session.GetString("IsUserLogged");

      var user = UserMapper.ToEntity(userFound);
      return View(user);
    }

    // POST: UsersController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<ActionResult> Delete(User user)
    {
      try
      {
        usersService.TokenDto = TokenMapper.ToDto(JsonConvert.DeserializeObject<TokenData>(HttpContext.Session.GetString("TokenData")));
        var userFound = await usersService.GetUserById(user.Id);

        if (userFound == null)
        {
          return View();
        }

        await usersService.DeleteUser(user.Id);

        return RedirectToAction(nameof(Index));
      }
      catch
      {
        return View();
      }
    }
  }
}