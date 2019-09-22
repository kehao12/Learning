using Learning.Data.Infrastructure;
using Learning.Data.Repositories;
using Learning.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Service
{
    public interface ICourseCategoryService
    {
        CourseCategory Add(CourseCategory CourseCategory);

        void Update(CourseCategory CourseCategory);

        CourseCategory Delete(int id);

        IEnumerable<CourseCategory> GetAll();

        IEnumerable<CourseCategory> GetAll(string keyword);

        IEnumerable<CourseCategory> GetAllByParentId(int parentId);

        CourseCategory GetById(int id);

        void Save();
    }

    public class CourseCategoryService : ICourseCategoryService
    {
        private ICourseCategoryRepository _CourseCategoryRepository;
        private IUnitOfWork _unitOfWork;

        public CourseCategoryService(ICourseCategoryRepository CourseCategoryRepository, IUnitOfWork unitOfWork)
        {
            this._CourseCategoryRepository = CourseCategoryRepository;
            this._unitOfWork = unitOfWork;
        }

        public CourseCategory Add(CourseCategory CourseCategory)
        {
            return _CourseCategoryRepository.Add(CourseCategory);
        }

        public CourseCategory Delete(int id)
        {
            return _CourseCategoryRepository.Delete(id);
        }

        public IEnumerable<CourseCategory> GetAll()
        {
            return _CourseCategoryRepository.GetAll();
        }

        public IEnumerable<CourseCategory> GetAll(string keyword)
        {
            if (!string.IsNullOrEmpty(keyword))
            {
                return _CourseCategoryRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
            }
            else
                return _CourseCategoryRepository.GetAll();
           
        }

        public IEnumerable<CourseCategory> GetAllByParentId(int parentId)
        {
            return _CourseCategoryRepository.GetMulti(x => x.Status && x.ParentID == parentId);
        }

        public CourseCategory GetById(int id)
        {
            return _CourseCategoryRepository.GetSingleById(id);
        }

        public void Save()
        {
            _unitOfWork.Commit();
        }

        public void Update(CourseCategory CourseCategory)
        {
            _CourseCategoryRepository.Update(CourseCategory);
        }
    }
}
