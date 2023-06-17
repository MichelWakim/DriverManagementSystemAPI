using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DriverManagementSystemAPI.Models;
using DriverManagementSystemAPI.Services;
using DriverManagementSystemAPI.Utilities;
using Microsoft.AspNetCore.Mvc;

namespace DriverManagementSystemAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly IDriverService _service;

        public DriverController(IDriverService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IEnumerable<Driver>?> GetAllDrivers()
        {
            return await _service.GetAllDrivers();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDriverById(int id)
        {
            var driver = await _service.GetDriverById(id);
            if (driver == null)
            {
                return NotFound();
            }
            return Ok(driver);
        }

        [HttpPost]
        public async Task<IActionResult> CreateDriver([FromBody] Driver driver)
        {
            try
            {
                await _service.CreateDriver(driver);
                return CreatedAtAction(nameof(GetDriverById), new { id = driver.Id }, driver);
            }
            catch (ArgumentNullException ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateDriver(int id, [FromBody] Driver driver)
        {
            try
            {
                return Ok(await _service.UpdateDriver(id, driver));
                //return NoContent();
            }
            catch (CustomException ex)
            {
                return ExceptionHandler.HandleException(ex);
            }
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteDriver(int id)
        {
            try
            {
                await _service.DeleteDriver(id);
                return NoContent();
            }
            catch (CustomException ex)
            {
                return ExceptionHandler.HandleException(ex);
            }

        }
    }
}