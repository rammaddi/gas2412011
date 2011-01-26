using System.Collections.Generic;
using System.Linq;
using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.tasks.stubs
{
    public class StubDepartmentRepository : Catalog
    {
        public IEnumerable<Department> get_main_departments()
        {
            return Enumerable.Range(1, 100).Select(x => new Department{name = x.ToString("Main Department 00")});
        }
		public IEnumerable<Department> get_departments_in(Department department)
		{
			return Enumerable.Range(1, 100).Select(x => new Department { name = x.ToString("Sub Department 000") });
		}


        public IEnumerable<Product> get_products_in(Department department)
        {
            return Enumerable.Range(1, 100).Select(x => new Product { name = x.ToString("Product 000") });
	
        }
    }
}