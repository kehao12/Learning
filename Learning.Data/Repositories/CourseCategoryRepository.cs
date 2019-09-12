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
    public interface ICourseCategoryRepository: IRepository<CourseCategory>
    {
        IEnumerable<CourseCategory> GetByAlias(string alias);
    }
    public class CourseCategoryRepository : RepositoryBase<CourseCategory>
    {
        public CourseCategoryRepository(DbFactory dbFactory)
            : base(dbFactory)
        {

        }
        public IEnumerable<CourseCategory> GetByAlias(string alias)
        {
            return this.DbContext.CourseCategories.Where(x => x.Alias == alias);
        }
    }
}
