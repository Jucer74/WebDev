using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
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
  public class ConceptsController : ControllerBase
  {
    private readonly AppDbContext _context;

    public ConceptsController(AppDbContext context)
    {
      _context = context;
    }

    // GET: api/Concepts
    [HttpGet]
    [Authorize]
    public async Task<ActionResult<IEnumerable<Concept>>> GetConcepts(
      int? concept_id,
      string domain_id,
      string vocabulary_id,
      string word_desc)
    {
      return await _context.Concepts.Where(c =>
         c.Concept_Id == (concept_id ?? c.Concept_Id)
      && c.Domain_Id == (domain_id ?? c.Domain_Id)
      && c.Vocabulary_Id == (vocabulary_id ?? c.Vocabulary_Id)
      && c.Short_Desc.Contains(word_desc ?? c.Short_Desc))
        .Select(c => new Concept
        {
          Id = c.Id,
          Pxordx = c.Pxordx ?? string.Empty,
          Oldpxordx = c.Oldpxordx ?? string.Empty,
          CodeType = c.CodeType ?? string.Empty,
          Concept_Class_Id = c.Concept_Class_Id ?? string.Empty,
          Concept_Id = c.Concept_Id,
          Vocabulary_Id = c.Vocabulary_Id ?? string.Empty,
          Domain_Id = c.Domain_Id ?? string.Empty,
          Track = c.Track ?? string.Empty,
          Standard_Concept = c.Standard_Concept ?? string.Empty,
          Code = c.Code,
          CodeWithPeriods = c.CodeWithPeriods ?? string.Empty,
          CodeScheme = c.CodeScheme ?? string.Empty,
          Long_Desc = c.Long_Desc ?? string.Empty,
          Short_Desc = c.Short_Desc ?? string.Empty,
          Code_Status = c.Code_Status ?? string.Empty,
          Code_Change = c.Code_Change ?? string.Empty,
          Code_Change_Year = c.Code_Change_Year,
          Code_Planned_Type = c.Code_Planned_Type ?? string.Empty,
          Code_Billing_Status = c.Code_Billing_Status ?? string.Empty,
          Code_Cms_Claim_Status = c.Code_Cms_Claim_Status ?? string.Empty,
          Sex_Cd = c.Sex_Cd ?? string.Empty,
          Anat_Or_Cond = c.Anat_Or_Cond ?? string.Empty,
          Poa_Code_Status = c.Poa_Code_Status ?? string.Empty,
          Poa_Code_Change = c.Poa_Code_Change ?? string.Empty,
          Poa_Code_Change_Year = c.Poa_Code_Change_Year ?? string.Empty,
          Valid_Start_Date = c.Valid_Start_Date ?? string.Empty,
          Valid_End_Date = c.Valid_End_Date ?? string.Empty,
          Invalid_Reason = c.Invalid_Reason ?? string.Empty,
          Create_Dt = c.Create_Dt
        }).ToListAsync();
    }

    // POST: api/Concepts
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPost]
    [Authorize]
    public async Task<ActionResult<ConceptIdResponse>> PostConcept(Concept concept)
    {
      _context.Concepts.Add(concept);
      await _context.SaveChangesAsync();

      return Created(string.Empty, new ConceptIdResponse { Id = concept.Id });
    }


    // PUT: api/Concepts/5
    // To protect from overposting attacks, enable the specific properties you want to bind to, for
    // more details, see https://go.microsoft.com/fwlink/?linkid=2123754.
    [HttpPut("{id}")]
    [Authorize]
    public async Task<IActionResult> PutConcept(int id, Concept concept)
    {
      if (id != concept.Id)
      {
        return BadRequest();
      }

      _context.Entry(concept).State = EntityState.Modified;

      try
      {
        await _context.SaveChangesAsync();
      }
      catch (DbUpdateConcurrencyException)
      {
        if (!ConceptExists(id))
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


    // DELETE: api/Concepts/5
    [HttpDelete("{id}")]
    [Authorize]
    public async Task<ActionResult<User>> DeleteConcept(int id)
    {
      var concept = await _context.Concepts.FindAsync(id);
      if (concept == null)
      {
        return NotFound();
      }

      _context.Concepts.Remove(concept);
      await _context.SaveChangesAsync();

      return NoContent();
    }

    private bool ConceptExists(int id)
    {
      return _context.Concepts.Any(e => e.Id == id);
    }


  }
}