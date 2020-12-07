<<<<<<< HEAD
﻿using Microsoft.AspNetCore.Mvc;
=======
﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
>>>>>>> 66691986c00aa6cb878ccc1812523137c22593e1
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebDev.Api.Context;
using WebDev.Api.Model;

namespace WebDev.Api.Controllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class UsersController : ControllerBase
  {
    private readonly AppDbContext _context;

    public UsersController(AppDbContext context)
    {
      _context = context;
    }

    // GET: api/Users
    [HttpGet]
<<<<<<< HEAD
=======
    //[Authorize]
>>>>>>> 66691986c00aa6cb878ccc1812523137c22593e1
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
      return await _context.Users.ToListAsync();
    }

    // GET: api/Users/5
    [HttpGet("{id}")]
<<<<<<< HEAD
=======
    //[Authorize]
>>>>>>> 66691986c00aa6cb878ccc1812523137c22593e1
    public async Task<ActionResult<User>> GetUser(int id)
    {
      var user = await _context.Users.FindAsync(id);

      if (user == null)
      {
        return NotFound();
      }

      return user;
    }

<<<<<<< HEAD
=======
    // POST: api/Users
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    //[Authorize] 
    public async Task<ActionResult<User>> PostUser(User user)
    {
      _context.Users.Add(user);
      await _context.SaveChangesAsync();

      return Created(string.Empty, new { id = user.Id });
    }

>>>>>>> 66691986c00aa6cb878ccc1812523137c22593e1
    // PUT: api/Users/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
<<<<<<< HEAD
=======
    //[Authorize]
>>>>>>> 66691986c00aa6cb878ccc1812523137c22593e1
    public async Task<IActionResult> PutUser(int id, User user)
    {
      if (id != user.Id)
      {
        return BadRequest();
      }

      _context.Entry(user).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!UserExists(id))
        {
          return NotFound();
        }
        else
        {
          throw;
        }
      }

      return NoContent();
    }

<<<<<<< HEAD
    // POST: api/Users
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    public async Task<ActionResult<User>> PostUser(User user)
    {
      _context.Users.Add(user);
      await _context.SaveChangesAsync();

      return CreatedAtAction("GetUser", new { id = user.Id }, user);
    }

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
=======

    // DELETE: api/Users/5
    [HttpDelete("{id}")]
    //[Authorize] 
>>>>>>> 66691986c00aa6cb878ccc1812523137c22593e1
    public async Task<ActionResult<User>> DeleteUser(int id)
    {
      var user = await _context.Users.FindAsync(id);
      if (user == null)
      {
        return NotFound();
      }

      _context.Users.Remove(user);
      await _context.SaveChangesAsync();

<<<<<<< HEAD
      return user;
=======
      return NoContent();
>>>>>>> 66691986c00aa6cb878ccc1812523137c22593e1
    }

    private bool UserExists(int id)
    {
      return _context.Users.Any(e => e.Id == id);
    }
  }
}