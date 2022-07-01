using Asl.Core;
using Asl.Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace Asl.WebApi.Controllers
{
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IBusinessLogic businessLogic;
        public DoctorController()
        {
            businessLogic = new BusinessLogic();
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Doctor>))]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public IActionResult GetDoctors()
        {
            var doctors = businessLogic.GetAllDoctors();
            if (doctors == null || !doctors.Any())
                return NoContent();
            return Ok(doctors);
        }

        [HttpGet("patients/{doctorId}")]
        public IActionResult GetPatientByDoctor(int doctorId)
        {
            var patients = businessLogic.GetAllPatientsByDoctorId(doctorId);
            return Ok(patients);
        }

        [HttpGet("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Doctor))]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult GetDoctorById(int id)
        {
            var doctor = businessLogic.GetDoctorById(id);
            if(doctor == null)
            {
                return NotFound($"Doctor {id} not found.");
            } else
            {
                return Ok(doctor);
            }
        }


        [HttpPost]
        public IActionResult CreateDoctor([FromBody]Doctor doctor)
        {
            if (doctor == null)
                return BadRequest("doctor is null. Retry");
            bool result = businessLogic.InsertDoctor(doctor);
            if (!result)
                return StatusCode(500, "Cannot insert doctor");
            return CreatedAtAction("GetDoctorById", new { id = doctor.Id }, doctor);
        }
    }
}
