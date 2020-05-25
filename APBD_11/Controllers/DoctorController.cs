using APBD_11.DTO;
using APBD_11.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APBD_11.Controllers
{
    [Route("api/doctor")]
    [ApiController]

    public class DoctorController : ControllerBase
    {
        private readonly DoctorDBContext _context;
        public DoctorController(DoctorDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetDoctor(DoctorDBContext context)
        {
            return Ok(context.Doctors.ToList());
        }

        [HttpPost("add")]
        public IActionResult AddDoctor(DoctorRequest request)
        {
            Doctor doctor = new Doctor();
            doctor.FirstName = request.FirstName;
            doctor.LastName = request.LastName;
            doctor.Email = request.Email;
            _context.Add(doctor);
            _context.SaveChanges();

            return Ok(request.FirstName + " has been added.");
        }

        [HttpPost("update/{id}")]
        public IActionResult UpdateDoctor(DoctorRequest request, string id)
        {
            var update = _context.Doctors.Where(d => d.IdDoctor.Equals(id)).ToList().FirstOrDefault();
            Doctor doctorToUpdate = update;

            doctorToUpdate.FirstName = request.FirstName;
            doctorToUpdate.LastName = request.LastName;
            doctorToUpdate.Email = request.Email;

            _context.Update(doctorToUpdate);

            return Ok("Doctor with " + id + " has been updated.");
        }

        [HttpDelete("delete/{id}")]
        public IActionResult DeleteDoctor(string id)
        {
            var remove = _context.Doctors.Where(e => e.IdDoctor.Equals(id)).ToList().FirstOrDefault();
            _context.Remove(remove);
            return Ok("Removed Doctor with: " + id + " index");
        }
    }
}
