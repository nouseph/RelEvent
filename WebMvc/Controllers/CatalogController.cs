using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebMvc.Services;
using WebMvc.ViewModels;

namespace WebMvc.Controllers
{
    public class CatalogController : Controller
    {
        private readonly ICatalogService _service;
        public CatalogController(ICatalogService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index(int? page, int? categoryFilterApplied, int? typesFilterApplied)
        {
            var itemsOnPage = 5;

            var catalog = await _service.GetCatalogItemsAsync(page ?? 0, itemsOnPage, categoryFilterApplied, typesFilterApplied);

            var vm = new CatalogIndexViewModel
            {
                CatalogItems = catalog.Data,
                Categories = await _service.GetCategoriesAsync(),
                Types = await _service.GetTypesAsync(),
                PaginationInfo = new PaginationInfo
                {
                    ActualPage = page ?? 0,
                    ItemsPerPage = itemsOnPage,
                    TotalItems = catalog.Count,
                    TotalPages = (int)Math.Ceiling((decimal)catalog.Count / itemsOnPage)
                },
                CategoryFilterApplied = categoryFilterApplied ?? 0,
                TypesFilterApplied = typesFilterApplied ?? 0
            };

            return View(vm);
        }
    }
}
