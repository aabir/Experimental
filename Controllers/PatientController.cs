using Microsoft.AspNetCore.Mvc;
using PostGreBE.Entity;
using PostGreBE.Service;
using System;
using System.Collections.Generic;

namespace PostGreBE.Controllers
{
    [Route("api/[controller]")]
    public class PatientController : Controller
    {

        private readonly IPatientService _patientService;
        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpGet]
        public IEnumerable<Patient> Get()
        {
            return _patientService.GetPatientRecords();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Patient patient)
        {
            if (ModelState.IsValid)
            {
                Guid obj = Guid.NewGuid();
                patient.Id = obj.ToString();
                _patientService.AddPatientRecord(patient);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public ActionResult<Patient> Details(string id)
        {
            Patient data = _patientService.GetPatientSingleRecord(id);
            if (data != null)
                return Ok(data);
            return BadRequest();
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Patient patient)
        {
            if (ModelState.IsValid)
            {
                _patientService.UpdatePatientRecord(patient);
                return Ok();
            }
            return BadRequest();
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteConfirmed(string id)
        {
            var data = _patientService.GetPatientSingleRecord(id);
            if (data == null)
            {
                return NotFound();
            }
            _patientService.DeletePatientRecord(id);
            return Ok();
        }
    }
}
