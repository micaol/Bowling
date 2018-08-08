using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Bowling.Models;

namespace Bowling.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly BowlingContext _context;

        public ValuesController(BowlingContext context)
        {
                        _context = context;

            if (_context.Games.Count() == 0)
            {
                _context.Games.Add(new Game { Name = "Item1" });
                _context.SaveChanges();
            }

        }

        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return new string[] { "value1", "value2" };
        }

        [HttpGet]
        public ActionResult<List<Game>> GetAll()
        {
            return _context.Games.ToList();
        }

        // GET api/values/5
        [HttpGet("{id}", Name = "GetGame")]
        public ActionResult<Game> GetById(long id)
        {
            var item = _context.Games.Find(id);
            if (item == null)
            {
                return NotFound();
            }
            return item;
        }


        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
