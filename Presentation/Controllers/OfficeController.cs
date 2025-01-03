using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using OfficeService.Application.DTOs;
using OfficeService.Application.Interfaces;

namespace OfficeService.Presentation.Controllers;


[ApiController]
[Route("api/[controller]")]
public class OfficeController : ControllerBase
{
    private readonly IOfficesService _officeService;

    public OfficeController(IOfficesService officeService)
    {
        _officeService = officeService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var offices = await _officeService.GetAllOfficesAsync();
        return Ok(offices);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetById(string id)
    {
        var office = await _officeService.GetOfficeByIdAsync(id);
        return Ok(office);
    }

    [HttpPost]
    public async Task<IActionResult> Create([FromBody] OfficesDto officeDto)
    {
        await _officeService.CreateOfficeAsync(officeDto);
        return StatusCode(201);
    }

    [HttpPut("{id}")]
    public async Task<IActionResult> Update(string id, [FromBody] OfficesDto officeDto)
    {
        await _officeService.UpdateOfficeAsync(id, officeDto);
        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<IActionResult> Delete(string id)
    {
        await _officeService.DeleteOfficeAsync(id);
        return NoContent();
    }
}