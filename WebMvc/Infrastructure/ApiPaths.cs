using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebMvc.Infrastructure
{
    public static class ApiPaths
    {
        public static class Catalog
        {
            public static string GetAllTypes(string baseUri)
            {
                return $"{baseUri}catalogeventtypes";
            }
            public static string GetAllCategories(string baseUri)
            {
                return $"{baseUri}catalogeventcategories";
            }
            public static string GetAllCatalogItems(string baseUri, int page, int take, int? category, int? type)
            {
                var filterQs = string.Empty;
                if (category.HasValue || type.HasValue)
                {
                    var categoryQs = (category.HasValue) ? category.Value.ToString() : " ";
                    var typeQs = (type.HasValue) ? type.Value.ToString() : " ";
                    filterQs = $"/type/{typeQs}/category/{categoryQs}";
                }
                return $"{baseUri}items{filterQs}?pageIndex={page}&pageSize={take}";
            }
        }

        public static class Basket
        {
            public static string GetBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }

            public static string UpdateBasket(string baseUri)
            {
                return baseUri;
            }

            public static string CleanBasket(string baseUri, string basketId)
            {
                return $"{baseUri}/{basketId}";
            }
        }




    }



}

