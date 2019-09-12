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
    public interface ICourseService
    {
        void Add(Course Course);
        void Update(Course Course);
        void Delete(int id);
        IEnumerable<Course> GetAll();
        IEnumerable<Course> GetAllPaging(int page, int pageSize, out int totalRow);
        Course GetById(int id);
        IEnumerable<Course> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow);
        void SaveChanges();
    }
    public class CourseService : ICourseService
    {
        ICourseRepository _courseRepository;
        IUnitOfWork _unitOfWork;
        public CourseService(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            this._courseRepository = courseRepository;
            this._unitOfWork = unitOfWork;
        }
        public void Add(Course Course)
        {
            _courseRepository.Add(Course);
        }

        public void Delete(int id)
        {
            _courseRepository.Delete(id);
        }

        public IEnumerable<Course> GetAll()
        {
            return _courseRepository.GetAll(new string[] { "CourseCategory" });
        }

        public IEnumerable<Course> GetAllByTagPaging(string tag, int page, int pageSize, out int totalRow)
        {
            //TODO: Sellect all course by tag
            return _courseRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public IEnumerable<Course> GetAllPaging(int page, int pageSize, out int totalRow)
        {
            return _courseRepository.GetMultiPaging(x => x.Status, out totalRow, page, pageSize);
        }

        public Course GetById(int id)
        {
            return _courseRepository.GetSingleById(id);
        }

        public void SaveChanges()
        {
            _unitOfWork.Commit();
        }

        public void Update(Course Course)
        {
            _courseRepository.Update(Course);
        }
    }
}
