﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Learning.Data.Infrastructure
{
    public class DbFactory : Disposable, IDbFactory
    {
        private LearningDbContext dbContext;

        public LearningDbContext Init()
        {
            return dbContext ?? (dbContext = new LearningDbContext());
        }

        protected override void DisposeCore()
        {
            if (dbContext != null)
                dbContext.Dispose();
        }
    }
}
