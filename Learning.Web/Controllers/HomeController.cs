using AutoMapper;
using Learning.Model.Models;
using Learning.Service;
using Learning.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Learning.Web.Controllers
{
    public class HomeController : Controller
    {
        ICourseCategoryService _courseCategoryService;
        ICourseService _courseService;
        ICommonService _commonService;

        public HomeController (ICourseCategoryService courseCategoryService, ICourseService courseService,
            ICommonService commonService)
        {
            _courseCategoryService = courseCategoryService;
            _commonService = commonService;
            _courseService = courseService;
        }

        public ActionResult Index()
        {
            var slideModel = _commonService.GetSlides();
            var slideView = Mapper.Map<IEnumerable<Slide>, IEnumerable<SlideViewModel>>(slideModel);
            var homeViewModel = new HomeViewModel();
            homeViewModel.Slides = slideView;

            var lastestCourseModel = _courseService.GetLastest(3);
            var topSaleCourseModel = _courseService.GetHotCourse(3);
            var lastestCourseViewModel = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(lastestCourseModel);
            var topSaleCourseViewModel = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(topSaleCourseModel);
            homeViewModel.LastestCourses = lastestCourseViewModel;
            homeViewModel.TopSaleCourses = topSaleCourseViewModel;

            var courseCategoryModel = _courseCategoryService.GetAll();
            var listCourseCategoryViewModel = Mapper.Map<IEnumerable<CourseCategory>, IEnumerable<CourseCategoryViewModel>>(courseCategoryModel);
            homeViewModel.CourseCategories = listCourseCategoryViewModel;

            var course = _courseService.GetAll();
            var courses = Mapper.Map<IEnumerable<Course>, IEnumerable<CourseViewModel>>(course);
            homeViewModel.Courses = courses;

            return View(homeViewModel);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [ChildActionOnly]
        public ActionResult Footer()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Header()
        {
            return PartialView();
        }

        [ChildActionOnly]
        public ActionResult Category()
        {
            var model = _courseCategoryService.GetAll();
            var listCourseCategoryViewModel = Mapper.Map<IEnumerable<CourseCategory>, IEnumerable<CourseCategoryViewModel>> (model);
            return PartialView(listCourseCategoryViewModel);
        }
    }
}