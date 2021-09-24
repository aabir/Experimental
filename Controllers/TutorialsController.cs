using Microsoft.AspNetCore.Mvc;
using PostGreBE.Entity;
using PostGreBE.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PostGreBE.Controllers
{
    [Route("api/[controller]")]
    public class TutorialsController : Controller
    {
        private IRepository<Tutorial> _tutorialRepo;
        public TutorialsController(IRepository<Tutorial> tutorialRepo)
        {
            _tutorialRepo = tutorialRepo;
        }

        [HttpGet]
        public IEnumerable<Tutorial> Get()
        {
            return _tutorialRepo.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Tutorial tutorial)
        {
            if (ModelState.IsValid)
            {
                //Guid obj = Guid.NewGuid();
                //tutorial.id = obj.ToString();
                _tutorialRepo.Insert(tutorial);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Tutorial Details(Guid id)
        {
            return _tutorialRepo.GetById(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Tutorial tutorial)
        {
            if (ModelState.IsValid)
            {
                _tutorialRepo.Update(tutorial);
                return Ok();
            }
            return BadRequest();
        }

        public IActionResult DeleteConfirmed(Guid id)
        {
            var tutorial = _tutorialRepo.GetById(id);
            if (tutorial == null)
            {
                return NotFound();
            }
            _tutorialRepo.Delete(tutorial);
            return Ok();
        }
    }
}
