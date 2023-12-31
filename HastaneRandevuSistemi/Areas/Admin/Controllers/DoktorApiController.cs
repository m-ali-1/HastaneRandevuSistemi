using Hastane.Services;
using Hastane.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

[Route("api/[controller]")]
[ApiController]
public class DoktorApiController : ControllerBase
{
    private readonly IDoctorService _doctorService;

    public DoktorApiController(IDoctorService doctorService)
    {
        _doctorService = doctorService;
    }

    [HttpGet]
    public IActionResult GetAllDoctor(int pageNumber=1, int pageSize=10)
    {
        var doctors = _doctorService.GetAllDoctor(pageNumber, pageSize);
        return Ok(doctors);
    }

    [HttpGet("{id}")]
    public IActionResult GetDoctorById(int id)
    {
        var doctor = _doctorService.GetDoctorById(id);

        if (doctor == null)
        {
            return NotFound();
        }

        return Ok(doctor);
    }

    [HttpPost]
    public IActionResult CreateDoctor([FromBody] DoctorViewModel doctorViewModel)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        _doctorService.InsertDoctor(doctorViewModel);

        return CreatedAtAction(nameof(GetDoctorById), new { id = doctorViewModel.Id }, doctorViewModel);
    }

    [HttpPut("{id}")]
    public IActionResult UpdateDoctor(int id, [FromBody] DoctorViewModel doctorViewModel)
    {
        if (!ModelState.IsValid || id != doctorViewModel.Id)
        {
            return BadRequest(ModelState);
        }

        _doctorService.UpdateDoctor(doctorViewModel);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public IActionResult DeleteDoctor(int id)
    {
        _doctorService.DeleteDoctor(id);
        return NoContent();
    }
}
