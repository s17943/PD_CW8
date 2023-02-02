using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using CW_PD8.Models;
using CW_PD8.Services;
using CW_PD8.DTO;

namespace CW_PD8.Controllers
{
    
        [ApiController]
        [Route("/api/doctors")]
        [Authorize("admin, doctor")]
    public class DoctorController : ControllerBase
    {
        private readonly IDbService _DbService;

        public DoctorController(IDbService _DbService)
        {
            this._DbService = _DbService;
        }

        [HttpGet("doctors")]
        public async Task<IActionResult> GetDoctors()
        {
            var result = await _DbService.GetDoctorsAsync();

            if (result == null)
                return NoContent();

            return Ok(result);
        }

        [HttpPost("doctors")]
        public async Task<IActionResult> AddDoctor([FromBody] DoctorDTO dto)
        {
            var result = await _DbService.AddDoctorAsync(dto);

            if (result != "Success!")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpPut("doctors/{id}")]
        public async Task<IActionResult> ChangeDoctor([FromRoute] int id, [FromBody] DoctorDTO dto)
        {
            var result = await _DbService.ChangeDoctorAsync(id, dto);

            if (result != "Success!")
                return NotFound(result);

            return Ok(result);
        }

        [HttpDelete("doctors/{id}")]
        public async Task<IActionResult> DeleteDoctor([FromRoute] int id)
        {
            var result = await _DbService.DeleteDoctorAsync(id);

            if (result != "Success!")
                return BadRequest(result);

            return Ok(result);
        }

        [HttpGet("prescriptions/{id}")]
        public async Task<IActionResult> GetPrescription([FromRoute] int id)
        {
            var result = await _DbService.GetPrescriptionAsync(id);

            if (result == null)
                return NoContent();

            return Ok(result);
        }
    }
}
