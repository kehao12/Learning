using AutoMapper;
using Learning.Model.Models;
using Learning.Service;
using Learning.Web.Infrastructure.Core;
using Learning.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Learning.Web.Api
{
    [RoutePrefix("api/coursecategory")]
    public class CourseCategoryController : ApiControllerBase
    {
        ICourseCategoryService _courseCategoryService;

        public CourseCategoryController(IErrorService errorService, ICourseCategoryService courseCategoryService)
            : base(errorService)
        {
            this._courseCategoryService = courseCategoryService;
        }
        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _courseCategoryService.GetAll();
                var responseData = Mapper.Map<IEnumerable<CourseCategory>, IEnumerable<CourseCategoryViewModel>>(model);
                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}
