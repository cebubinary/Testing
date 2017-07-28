using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication4.Context;

namespace WebApplication4.Repository.DataContextRepository
{
    public class RepositoryBase
    {
        protected DataClasses1DataContext Context;
        public RepositoryBase(DataClasses1DataContext _context)
        {
            Context = _context;
        }
    }
}