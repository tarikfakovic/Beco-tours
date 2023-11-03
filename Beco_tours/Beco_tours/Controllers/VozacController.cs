using System;
using Beco_tours.Contracts.Service;
using Beco_tours.Data.Dto.Vozac;
using Microsoft.AspNetCore.Mvc;

namespace Beco_tours.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VozacController : ControllerBase
    {
        private readonly IServiceManager _serviceManager;

        public VozacController(IServiceManager serviceManager)
        {
            _serviceManager = serviceManager;
        }

        [HttpGet]
        public async Task<IActionResult> GetVozace()
        {
            var response = await _serviceManager.VozacService.GetAllVozace();
            return Ok(response);
        }

        [HttpGet("{vozacID}")]
        public async Task<IActionResult> GetVozacByID(int vozacID)
        {
            var response = await _serviceManager.VozacService.GetVozacByID(vozacID);
            if (response is not null)
                return Ok(response);
            return NotFound("Vozac not found.");
        }

        [HttpPost]
        public async Task<IActionResult> CreateVozac(VozacCreateDto vozacCreateDto)
        {
            var response = await _serviceManager.VozacService.CreateVozac(vozacCreateDto);

            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpPut("{vozacID}")]
        public async Task<IActionResult> UpdateVozac(VozacUpdateDto vozacUpdateDto, int vozacID)
        {
            if (!vozacID.Equals(vozacUpdateDto.VozacID))
                return BadRequest("Invalid ID");
            var response = await _serviceManager.VozacService.UpdateVozac(vozacID, vozacUpdateDto);
            if (response.IsSuccess)
                return Ok(response);

            return BadRequest(response);
        }

        [HttpDelete("{vozacID}")]
        public async Task<IActionResult> DeleteVozac(int vozacID)
        {
            var response = await _serviceManager.VozacService.DeleteVozac(vozacID);
            if (response) return Ok("Vozac Deleted");

            return BadRequest("Failed to Delete Vozac.");
        }
    }
}

