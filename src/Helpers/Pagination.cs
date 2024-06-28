using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotnetCQRS.Helpers
{
    public class Pagination<T>
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public IEnumerable<T>? Items { get; private set; }
        public int PageIndex { get; private set; }
        public int TotalPages { get; private set; }
        public int TotalItems { get; private set; }
        public string? NextPageUrl { get; private set; }
        public string? PreviousPageUrl { get; private set; }

        public Pagination(IEnumerable<T> items, int count, int pageIndex, int pageSize, IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor ?? throw new ArgumentNullException(nameof(httpContextAccessor));
            // Validate pageIndex and pageSize
            if (pageIndex < 0)
            {
                throw new ArgumentException("Invalid pageIndex: must be >= 0.");
            }
            if (pageSize < 1)
            {
                throw new ArgumentException("Invalid pageSize: must be >= 1.");
            }
            Items = items;
            TotalItems = count;
            PageIndex = pageIndex;
            TotalPages = (int)Math.Ceiling(count / (double)pageSize);
            CalculateUrls(pageIndex, pageSize);
        }

        private void CalculateUrls(int pageIndex, int pageSize)
        {
            var httpContext = _httpContextAccessor?.HttpContext;
            if (pageIndex < TotalPages)
            {
                NextPageUrl = GetPageUrl(httpContext, pageSize, pageIndex + 1);
            }
            if (pageIndex > 1)
            {
                PreviousPageUrl = GetPageUrl(httpContext, pageSize, pageIndex - 1);
            }
        }

        private string GetPageUrl(HttpContext? httpContext, int pageSize, int pageNumber)
        {
            var request = httpContext?.Request;
            var url = $"{request?.Scheme}://{request?.Host}{request?.PathBase}{request?.Path}?pageIndex={pageNumber}&pageSize={pageSize}";
            return url;
        }

        public bool HasPreviousPage()
        {
            return PageIndex > 1;
        }

        public bool HasNextPage()
        {
            return PageIndex < TotalPages;
        }
       
    }
}
