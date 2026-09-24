using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehicleCare.API.Data;

namespace VehicleCare.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ServicesController : ControllerBase
{
    private readonly AppDbContext _context;

    public ServicesController(AppDbContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IActionResult> GetServices()
    {
        var services = await _context.Services.ToListAsync();
        return Ok(new
        {
            success = true,
            message = "Thành công",
            data = services
        });
    }
}
