using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EventCatalogAPI.Domain
{
    public class CatalogEventItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
        public string Location { get; set; }
        public string PictureUrl { get; set; }
        public int CatalogEventCategoryId { get; set; }
        public CatalogEventCategory CatalogEventCategory { get; set; }
    }
}
