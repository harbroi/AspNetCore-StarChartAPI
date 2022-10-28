using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using StarChart.Data;

namespace StarChart.Controllers
{
    [Route("")]
    [ApiController]
    public class CelestialObjectController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public CelestialObjectController(ApplicationDbContext context)
        {
            _context = context;
        }
        [HttpGet("{id:int}", Name = "GetById")]
        public IActionResult GetById(int id)
        {
            var celestial = _context.CelestialObjects.Where(x => x.Id == id);
            if(celestial == null)
            {
                return NotFound();
            }
            else
            {
                var satellites = _context.CelestialObjects.Where(x => x.Id == id).ToList();
                return Ok(satellites);
            }
        }

        [HttpGet("{name}", Name = "GetByName")]
        public IActionResult GetByName(string name)
        {
            var celestial = _context.CelestialObjects.Where(x => x.Name == name);
            if (celestial == null)
            {
                return NotFound();
            }
            else
            {
                var satellites = _context.CelestialObjects.Where(x => x.Name == name).ToList();
                return Ok(celestial);
            }
        }

        [HttpGet(Name = "GetAll")]
        public IActionResult GetAll()
        {
            var celestial = _context.CelestialObjects.ToList();
            return Ok(celestial);
        }
    }
}
