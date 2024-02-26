using OOP.StudentManagementSystemApp.DbContent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP.StudentManagementSystemApp.StudentManagmentServices
{
    public abstract class AbstractService
    {
        protected StudentManagmentDB context;

        protected AbstractService(StudentManagmentDB db)
        {
            this.context = db;
        }
    }
}
