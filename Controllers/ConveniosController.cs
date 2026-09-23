using ClinicaApi.Data;
using ClinicaApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.InteropServices;

namespace ClinicaApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ConveniosController : ControllerBase
{
    private readonly AppDbContext _context;

    public ConveniosController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Convenio>>> GetConvenios()
    {
        return await _context.Convenios.ToListAsync();
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Convenio>> GetConvenio(long id)
    {
        var convenio = await _context.Convenios.FindAsync(id);
        if (convenio == null) return NotFound();
        return convenio;
    }

    [HttpPost]
    public async Task<ActionResult<Convenio>> PostConvenio(Convenio convenio)
    {
        _context.Convenios.Add(convenio);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetConvenio), new { id = convenio.IdConvenio }, convenio);

    }

    [HttpPut("{id}")]
    public async Task<IActionResult> PutConvenio(long id, Convenio convenio)
    {
        if (id != convenio.IdConvenio) return BadRequest();

        _context.Entry(convenio).State = EntityState.Modified;
        await _context.SaveChangesAsync();

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteConvenio(long id)
    {
        var convenio = await _context.Convenios.FindAsync(id);
        if (convenio == null) return NotFound();

        _context.Convenios.Remove(convenio);
        await _context.SaveChangesAsync();
        
        return NoContent();
    }
}
