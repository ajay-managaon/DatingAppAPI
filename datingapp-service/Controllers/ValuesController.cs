using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using datingapp_service.datingapp.data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace datingapp_service.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ValuesController : ControllerBase
    {
        private readonly DatingAppDBContext _context;

        public ValuesController(DatingAppDBContext context)
        {
            _context = context;
        }
        // GET: Values
        [HttpGet]
        public IActionResult GetValues()
        {
            var values = _context.tbl_value.ToList();
            return Ok(values);
        }

        // GET: /Values/5
        [AllowAnonymous]
        [HttpGet("{id}")]
        public IActionResult GetValue(int id)
        {
            var value = _context.tbl_value.FirstOrDefault(x => x.id == id);
            return Ok(value);
        }

        // POST: /Values
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
