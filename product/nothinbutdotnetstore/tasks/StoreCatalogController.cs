using System.Collections.Generic;
using nothinbutdotnetstore.web.model;

namespace nothinbutdotnetstore.tasks
{
    public class StoreCatalogController
    {
        Catalog catalog;

        public StoreCatalogController(Catalog catalog)
        {
            this.catalog = catalog;
        }

        public IEnumerable<Department> get_the_main_departments()
        {
            return catalog.get_main_departments();
        }

        public IEnumerable<Product> get_the_products_in(Department department)
        {
            return catalog.get_products_in(department);
        }

        public IEnumerable<Department> get_the_departments_in(Department department)
        {
            return catalog.get_departments_in(department);
        }
    }
}