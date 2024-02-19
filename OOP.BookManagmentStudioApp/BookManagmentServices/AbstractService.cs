using BookManagmentSystemApp.DbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookManagmentSystemApp.BookManagmentServices
{
    public abstract  class AbstractService
    {
        protected BookManagmentDB context;

        protected AbstractService(BookManagmentDB db)
        {
            this.context = db;
        }
    }
}
