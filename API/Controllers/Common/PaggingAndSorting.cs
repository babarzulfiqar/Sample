using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using API.Common;
using System;

namespace API.Controllers.Common
{

    public class PaggingAndSorting : ControllerBase
    {
        protected readonly LinkGenerator _linkGenerator;
        public PaggingAndSorting(LinkGenerator linkGenerator)
        {
            _linkGenerator = linkGenerator;
        }
        public void PaggingAndSortingData(
            HttpContext httpContext, int totalCount,
            string methodName, int? page = 1, int?
            pageSize = ConstantProps.maxPageSize
            )
        {
            if (pageSize > ConstantProps.maxPageSize)
            {
                pageSize = ConstantProps.maxPageSize;
            }

            // calculate data for metadata
            var totalPages = (int)Math.Ceiling((double)totalCount / (int)pageSize);
            var prevLink = page > 1 ? _linkGenerator.GetPathByAction(httpContext, methodName, values: new
            {
                page = page - 1,
                pageSize = pageSize

            }) : "";

            var nextLink = page < totalPages ? _linkGenerator.GetPathByAction(httpContext, methodName, values: new
            {
                page = page + 1,
                pageSize = pageSize

            }) : "";

            var paginationHeader = new
            {
                currentPage = page,
                pageSize = pageSize,
                totalCount = totalCount,
                totalPages = totalPages,
                previousPageLink = prevLink,
                nextPageLink = nextLink
            };
            httpContext.Response.Headers.Add("X-Pagination",
               Newtonsoft.Json.JsonConvert.SerializeObject(paginationHeader));     
        }
    }
}
