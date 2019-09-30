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
    [RoutePrefix("api/course")]
    [Authorize]
    public class CourseController : ApiControllerBase
    {
        ICourseService _courseService;

        public CourseController(IErrorService errorService, ICourseService courseService)
            : base(errorService)
        {
            this._courseService = courseService;
        }

        [Route("getallparents")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var model = _courseService.GetAll();

                var responseData = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(model);

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
                var model = _courseService.GetById(id);

                var responseData = Mapper.Map<Course, CourseViewModel>(model);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }


        [Route("getall")]
        public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(request, () =>
            {
                int totalRow = 0;
                var model = _courseService.GetAll(keyword);

                totalRow = model.Count();
                var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                var responseData = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(query);

                var paginationSet = new PaginationSet<CourseViewModel>()
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
        public HttpResponseMessage Create(HttpRequestMessage request, CourseViewModel courseVM)
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
                    var newCourse = new Course();
                    newCourse.UpdateCourse(courseVM);

                    _courseService.Add(newCourse);
                    _courseService.Save();

                    var responseData = Mapper.Map<Course, CourseViewModel>(newCourse);
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
                    var oldCourse = _courseService.Delete(id);
                    _courseService.Save();

                    var responseData = Mapper.Map<Course, CourseViewModel>(oldCourse);
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
                    var listCourse = new JavaScriptSerializer().Deserialize<List<int>>(checkedCourseCategories);
                    foreach (var item in listCourse)
                    {
                        _courseService.Delete(item);
                    }

                    _courseService.Save();

                    response = request.CreateResponse(HttpStatusCode.OK, listCourse.Count);
                }

                return response;
            });
        }

        [Route("update")]
        [HttpPut]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage request, CourseViewModel courseVm)
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
                    var dbCourse = _courseService.GetById(courseVm.ID);

                    dbCourse.UpdateCourse(courseVm);
                    dbCourse.UpdatedDate = DateTime.Now;

                    _courseService.Update(dbCourse);
                    _courseService.Save();

                    var responseData = Mapper.Map<Course, CourseViewModel>(dbCourse);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }
    }
}
