using AutoMapper;
using Learning.Model.Models;
using Learning.Service;
using Learning.Web.Infrastructure.Core;
using Learning.Web.Infrastructure.Extensions;
using Learning.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Script.Serialization;

namespace Learning.Web.Api
{
    [RoutePrefix("api/coursecategory")]
    [Authorize]
    public class CourseCategoryController : ApiControllerBase
    {
        ICourseCategoryService _courseCategoryService;

        public CourseCategoryController(IErrorService errorService, ICourseCategoryService courseCategoryService)
            : base(errorService)
        {
            this._courseCategoryService = courseCategoryService;
        }

        [Route("getallparents")]
        [HttpGet]
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

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _courseCategoryService.GetById(id);

                var responseData = Mapper.Map<CourseCategory, CourseCategoryViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }


        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request,string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _courseCategoryService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<CourseCategory>, IEnumerable<CourseCategoryViewModel>>(query);

                var paginationSet = new PaginationSet<CourseCategoryViewModel>()
                {
                    Items = responseData,
                    Page = page,
                    TotalCount = totalRow,
                    TotalPages = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                var response = request.CreateResponse(HttpStatusCode.OK, paginationSet);
                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage request, CourseCategoryViewModel courseCategoryVM)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var newCourseCategory = new CourseCategory();
                    newCourseCategory.UpdateCourseCategory(courseCategoryVM);

                    _courseCategoryService.Add(newCourseCategory);
                    _courseCategoryService.Save();

                    var responseData = Mapper.Map<CourseCategory, CourseCategoryViewModel>(newCourseCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var oldCourseCategory = _courseCategoryService.Delete(id);
                    _courseCategoryService.Save();

                    var responseData = Mapper.Map<CourseCategory, CourseCategoryViewModel>(oldCourseCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

        [Route("deletemulti")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedCourseCategories)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var listCourseCategory = new JavaScriptSerializer().Deserialize<List<int>>(checkedCourseCategories);
                    foreach (var item in listCourseCategory)
                    {
                        _courseCategoryService.Delete(item);
                    }

                    _courseCategoryService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listCourseCategory.Count);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, CourseCategoryViewModel courseCategoryVm)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var dbCourseCategory = _courseCategoryService.GetById(courseCategoryVm.ID);

                    dbCourseCategory.UpdateCourseCategory(courseCategoryVm);
                    dbCourseCategory.UpdatedDate = DateTime.Now;

                    _courseCategoryService.Update(dbCourseCategory);
                    _courseCategoryService.Save();

                    var responseData = Mapper.Map<CourseCategory, CourseCategoryViewModel>(dbCourseCategory);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
    }
}
