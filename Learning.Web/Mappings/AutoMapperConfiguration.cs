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
            Mapper.CreateMap<PostTag, PostTagViewModel>();

            Mapper.CreateMap<Tag, TagViewModel>();

            Mapper.CreateMap<Course, CourseViewModel>();
            Mapper.CreateMap<CourseCategory, CourseCategoryViewModel>();
            Mapper.CreateMap<CourseTag, CourseTagViewModel>();

            Mapper.CreateMap<Slide, SlideViewModel>();


        }
    }
}