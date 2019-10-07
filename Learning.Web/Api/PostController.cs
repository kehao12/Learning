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
        [RoutePrefix("api/post")]
        [Authorize]
        public class PostController : ApiControllerBase
        {
            IPostService _postService;

            public PostController(IErrorService errorService, IPostService postService)
                : base(errorService)
            {
                this._postService = postService;
            }

            [Route("getallparents")]
            [HttpGet]
            public HttpResponseMessage GetAll(HttpRequestMessage request)
            {
                return CreateHttpResponse(request, () =>
                {
                    var model = _postService.GetAll();

                    var responseData = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(model);

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
                    var model = _postService.GetById(id);

                    var responseData = Mapper.Map<Post, PostViewModel>(model);

                    var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                    return response;
                });
            }


            [Route("getall")]
            [HttpGet]
            public HttpResponseMessage GetAll(HttpRequestMessage request, string keyword, int page, int pageSize = 20)
            {
                return CreateHttpResponse(request, () =>
                {
                    int totalRow = 0;
                    var model = _postService.GetAll(keyword);

                    totalRow = model.Count();
                    var query = model.OrderByDescending(x => x.CreatedDate).Skip(page * pageSize).Take(pageSize);

                    var responseData = Mapper.Map<IEnumerable<Post>, IEnumerable<PostViewModel>>(query);

                    var paginationSet = new PaginationSet<PostViewModel>()
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
            public HttpResponseMessage Create(HttpRequestMessage request, PostViewModel postVM)
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
                        var newpost = new Post();
                        newpost.UpdatePost(postVM);

                        _postService.Add(newpost);
                        _postService.Save();

                        var responseData = Mapper.Map<Post, PostViewModel>(newpost);
                        response = request.CreateResponse(HttpStatusCode.Created, responseData);
                    }

                    return response;
                });
            }

            [Route("delete")]
            [HttpDelete]
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
                        var oldpost = _postService.Delete(id);
                        _postService.Save();

                        var responseData = Mapper.Map<Post, PostViewModel>(oldpost);
                        response = request.CreateResponse(HttpStatusCode.Created, responseData);
                    }

                    return response;
                });
            }

            [Route("deletemulti")]
            [HttpDelete]

            public HttpResponseMessage DeleteMulti(HttpRequestMessage request, string checkedpostCategories)
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
                        var listpost = new JavaScriptSerializer().Deserialize<List<int>>(checkedpostCategories);
                        foreach (var item in listpost)
                        {
                            _postService.Delete(item);
                        }

                        _postService.Save();

                        response = request.CreateResponse(HttpStatusCode.OK, listpost.Count);
                    }

                    return response;
                });
            }

            [Route("update")]
            [HttpPut]

            public HttpResponseMessage Update(HttpRequestMessage request, PostViewModel postVm)
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
                        var dbpost = _postService.GetById(postVm.ID);

                        dbpost.UpdatePost(postVm);
                        dbpost.UpdatedDate = DateTime.Now;

                        _postService.Update(dbpost);
                        _postService.Save();

                        var responseData = Mapper.Map<Post, PostViewModel>(dbpost);
                        response = request.CreateResponse(HttpStatusCode.Created, responseData);
                    }

                    return response;
                });
            }
        }
    }

