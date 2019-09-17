using AutoMapper;
using Learning.Model.Models;
using Learning.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Learning.Web.Mappings
{
    public class AutoMapperConfiguration
    {
        public static void Configure()
        {
            Mapper.CreateMap<Post, PostViewModel>();
            Mapper.CreateMap<PostCategory, PostCategoryViewModel>();
            Mapper.CreateMap<Tag, TagViewModel>();
        }
    }
}