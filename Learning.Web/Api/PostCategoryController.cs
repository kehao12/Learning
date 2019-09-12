using Learning.Model.Models;
using Learning.Service;
using Learning.Web.Infrastructure.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Learning.Web.Api
{
    public class PostCategoryController : ApiControllerBase
    {
        IPostCategoryServie _postCategoryServie;
        public PostCategoryController(IErrorService errorService,IPostCategoryServie postCategoryServie): 
            base(errorService)
        {
            this._postCategoryServie = postCategoryServie;
        }

        public HttpResponseMessage Create(HttpRequestMessage request,PostCategory postCategory)
        {
            return CreateHttpReponse(request, () =>
             {
                 HttpResponseMessage response = null;
                 if (!ModelState.IsValid)
                 {
                     request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                 }
                 else
                 {
                     _postCategoryServie.Add(postCategory);
                     
                 }
                 return response;
             });
        }
       
    }
}