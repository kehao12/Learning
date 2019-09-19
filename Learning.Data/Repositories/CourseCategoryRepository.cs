using Learning.Data.Infrastructure;
using Learning.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Data.Repositories
{
    public interface ICourseCategoryRepository : IRepository<CourseCategory>
    {
    }

    public class CourseCategoryRepository : RepositoryBase<CourseCategory>, ICourseCategoryRepository
    {
        public CourseCategoryRepository(IDbFactory dbFactory) : base(dbFactory)
        {
        }
    }
}
