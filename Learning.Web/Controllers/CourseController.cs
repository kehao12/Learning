using AutoMapper;
using Learning.Model.Models;
using Learning.Service;
using Learning.Web.Infrastructure.Core;
using Learning.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Learning.Common;

namespace Learning.Web.Controllers
{
    public class CourseController : Controller
    {
        ICourseService _courseService;
        ICourseCategoryService _courseCategoryService;
        public CourseController(ICourseService courseService, ICourseCategoryService courseCategoryService)
        {
            this._courseService = courseService;
            this._courseCategoryService = courseCategoryService;
        }
        // GET: Course
        public ActionResult Detail(int courseId)
        {
            return View();
        }

        public ActionResult Category(int id, int page = 1)
        {
            int pageSize = int.Parse(ConfigHelper.GetByKey("PageSize"));
            int totalRow = 0;
            var courseModel = _courseService.GetListCourseByCategoryIdPaging(id, page, pageSize, out totalRow);
            var courseViewModel = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(courseModel);
            int totalPage = (int)Math.Ceiling((double)totalRow / pageSize);

            var category = _courseCategoryService.GetById(id);
            ViewBag.Category = Mapper.Map<CourseCategory, CourseCategoryViewModel>(category);

            var courseCategoryModel = _courseCategoryService.GetAllNotIDParent();
            ViewBag.listCourseCategoryViewModel = Mapper.Map<IEnumerable<CourseCategory>, IEnumerable<CourseCategoryViewModel>>(courseCategoryModel);

            var courseCategory = _courseCategoryService.GetAll();
            ViewBag.listCourseCategory = Mapper.Map<IEnumerable<CourseCategory>, IEnumerable<CourseCategoryViewModel>>(courseCategory);

            var paginationSet = new PaginationSet<CourseViewModel>()
            {
                Items = courseViewModel,
                MaxPage = int.Parse(ConfigHelper.GetByKey("MaxPage")),
                Page = page,
                TotalCount = totalRow,
                TotalPages = totalPage
            };

            return View(paginationSet);
        }
    }
}