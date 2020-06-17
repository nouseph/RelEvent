using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly CatalogEventContext _context;

        public EventController(CatalogEventContext context)

        {

            _context = context;

        }



        [HttpGet("[action]")]

        public async Task<IActionResult> Items(

            [FromQuery] int pageIndex = 0,

            [FromQuery] int pageSize = 4)

        {

            var items = await _context.CatalogEventItems

                            .OrderBy(c => c.Name)

                            .Skip(pageIndex * pageSize)

                            .Take(pageSize)

                            .ToListAsync();



            return Ok(items);

        }
    }
}
