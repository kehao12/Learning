using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Data.Infrastructure
{
    public interface IDbFactory
    {
        LearningDbContext Init();
    }
}
