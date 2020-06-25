using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EventCatalogAPI.Data;
using EventCatalogAPI.Domain;
using EventCatalogAPI.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace EventCatalogAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventController : ControllerBase
    {
        private readonly CatalogEventContext _context;
        private readonly IConfiguration _config;
        public EventController(CatalogEventContext context, IConfiguration config)

        {
            _context = context;
            _config = config;
        }

        [HttpGet("[action]")]
        public async Task<IActionResult> Items(
            [FromQuery] int pageIndex = 0,
            [FromQuery] int pageSize = 4)
        {
            var itemsCount = await _context.CatalogEventItems.LongCountAsync();
            var items = await _context.CatalogEventItems
                            .OrderBy(c => c.Name)
                            .Skip(pageIndex * pageSize)
                            .Take(pageSize)
                            .ToListAsync();

            items = ChangePictureUrl(items);
            var model = new PaginatedItemsViewModel<CatalogEventItem>
            {
                PageIndex = pageIndex,
                PageSize = items.Count,
                Count = itemsCount,
                Data = items
            };

            return Ok(model);
        }

        private List<CatalogEventItem> ChangePictureUrl(List<CatalogEventItem> items)
        {
            items.ForEach(item =>
                item.PictureUrl = item.PictureUrl.Replace(
                    "http://externalcatalogbaseurltobereplaced",
                    _config["ExternalCatalogBaseUrl"]));
            return items;
        }
    }
}
