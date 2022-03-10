using Microsoft.AspNetCore.Mvc;
using PostGreBE.Entity;
using PostGreBE.Service;
using System.Collections.Generic;

namespace PostGreBE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MonsterController : ControllerBase
    {
        private IRepository<Monster> _monsterRepo;
        public MonsterController(IRepository<Monster> monsterRepo)
        {
            _monsterRepo = monsterRepo;
        }

        [HttpGet]
        public IEnumerable<Monster> Get()
        {
            return _monsterRepo.GetAll();
        }

        [HttpPost]
        public IActionResult Create([FromBody] Monster monster)
        {
            if (ModelState.IsValid)
            {
                //Guid obj = Guid.NewGuid();
                //tutorial.id = obj.ToString();
                _monsterRepo.Insert(monster);
                return Ok();
            }
            return BadRequest();
        }

        [HttpGet("{id}")]
        public Monster Details(int id)
        {
            return _monsterRepo.GetById(id);
        }

        [HttpPut]
        public IActionResult Edit([FromBody] Monster monster)
        {
            if (ModelState.IsValid)
            {
                _monsterRepo.Update(monster);
                return Ok();
            }
            return BadRequest();
        }

        public IActionResult DeleteConfirmed(int id)
        {
            var monster = _monsterRepo.GetById(id);
            if (monster == null)
            {
                return NotFound();
            }
            _monsterRepo.Delete(monster);
            return Ok();
        }
    }
}
