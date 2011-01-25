using System.Collections.Generic;
using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.tasks
{
    public interface DepartmentsRepository
    {
        IEnumerable<Department> get_main_departments();
    }
}