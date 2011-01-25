using System.Collections.Generic;

namespace nothinbutdotnetstore.specs.web.core
{
    public interface DepartmentsDataAccessor
    {
        IList<Department> getMainDepartments();
    }
}