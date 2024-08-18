using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Deltas;
using Microsoft.AspNetCore.OData.Query;
using Microsoft.AspNetCore.OData.Routing.Attributes;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using WeatherPI.Data;
using WeatherPI.Shared.Models;

namespace WeatherPI.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
[EnableRateLimiting("Fixed")]
public class WeatherPIDataController(ApplicationDbContext ctx) : ControllerBase
{
    [HttpGet("")]
    [EnableQuery]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public ActionResult<IQueryable<WeatherPIData>> Get()
    {
        return Ok(ctx.WeatherPIData);
    }

    [HttpGet("{key}")]
    [EnableQuery]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WeatherPIData>> GetAsync(long key)
    {
        var weatherPIData = await ctx.WeatherPIData.FirstOrDefaultAsync(x => x.Id == key);

        if (weatherPIData == null)
        {
            return NotFound();
        }
        else
        {
            return Ok(weatherPIData);
        }
    }

    [HttpPost("")]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    public async Task<ActionResult<WeatherPIData>> PostAsync(WeatherPIData weatherPIData)
    {
        var record = await ctx.WeatherPIData.FindAsync(weatherPIData.Id);
        if (record != null)
        {
            return Conflict();
        }
    
        await ctx.WeatherPIData.AddAsync(weatherPIData);

        await ctx.SaveChangesAsync();

        return Created($"/weatherpidata/{weatherPIData.Id}", weatherPIData);
    }

    [HttpPut("{key}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WeatherPIData>> PutAsync(long key, WeatherPIData update)
    {
        var weatherPIData = await ctx.WeatherPIData.FirstOrDefaultAsync(x => x.Id == key);

        if (weatherPIData == null)
        {
            return NotFound();
        }

        ctx.Entry(weatherPIData).CurrentValues.SetValues(update);

        await ctx.SaveChangesAsync();

        return Ok(weatherPIData);
    }

    [HttpPatch("{key}")]
    [ProducesResponseType(StatusCodes.Status200OK)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<ActionResult<WeatherPIData>> PatchAsync(long key, Delta<WeatherPIData> delta)
    {
        var weatherPIData = await ctx.WeatherPIData.FirstOrDefaultAsync(x => x.Id == key);

        if (weatherPIData == null)
        {
            return NotFound();
        }

        delta.Patch(weatherPIData);

        await ctx.SaveChangesAsync();

        return Ok(weatherPIData);
    }

    [HttpDelete("{key}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status401Unauthorized)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IActionResult> DeleteAsync(long key)
    {
        var weatherPIData = await ctx.WeatherPIData.FindAsync(key);

        if (weatherPIData != null)
        {
            ctx.WeatherPIData.Remove(weatherPIData);
            await ctx.SaveChangesAsync();
        }

        return NoContent();
    }
}
