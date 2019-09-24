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
        Course Add(Course Course);

    void Update(Course Course);

    Course Delete(int id);

    IEnumerable<Course> GetAll();

    IEnumerable<Course> GetAll(string keyword);

    IEnumerable<Course> GetAllByParentId(int parentId);

    Course GetById(int id);

    void Save();
}

public class CourseService : ICourseService
{
    private ICourseRepository _CourseRepository;
    private IUnitOfWork _unitOfWork;

    public CourseService(ICourseRepository CourseRepository, IUnitOfWork unitOfWork)
    {
        this._CourseRepository = CourseRepository;
        this._unitOfWork = unitOfWork;
    }

    public Course Add(Course Course)
    {
        return _CourseRepository.Add(Course);
    }

    public Course Delete(int id)
    {
        return _CourseRepository.Delete(id);
    }

    public IEnumerable<Course> GetAll()
    {
        return _CourseRepository.GetAll();
    }

    public IEnumerable<Course> GetAll(string keyword)
    {
        if (!string.IsNullOrEmpty(keyword))
        {
            return _CourseRepository.GetMulti(x => x.Name.Contains(keyword) || x.Description.Contains(keyword));
        }
        else
            return _CourseRepository.GetAll();

    }

    public IEnumerable<Course> GetAllByParentId(int parentId)
    {
        return _CourseRepository.GetMulti(x => x.Status && x.CategoryID == parentId);
    }

    public Course GetById(int id)
    {
        return _CourseRepository.GetSingleById(id);
    }

    public void Save()
    {
        _unitOfWork.Commit();
    }

    public void Update(Course Course)
    {
        _CourseRepository.Update(Course);
    }
}
}
