using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubDepartmentRepository : DepartmentsRepository
    {
        public IEnumerable<Department> get_main_departments()
        {
            return Enumerable.Range(1, 100).Select(x => new Department{name = x.ToString("Main Department 00")});
        }
    }
}